using UnityEngine;
using UnityEngine.AI;
using SK.Framework.FSM;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// 敌人单位
/// </summary>
public class EnemyUnit : MonoBehaviour
{
    //Player位置
    [SerializeField] private Transform player;
    //寻路代理
    [SerializeField] private NavMeshAgent agent;
    //动画组件
    //[SerializeField] private Animator animator;
    //巡逻点集合
    [SerializeField] private Transform[] patrolPoints;

    public FSMComponent fsm;
    private class PatrolState : State
    {
        //当前巡逻点的索引值
        public int index;
        //休息计时
        public float timer;
    }

    private class AttackState : State
    {
        public float attackCD = 2f;
    }

    private class AnimatorParams
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Walk = Animator.StringToHash("Walk");
        public static readonly int Run = Animator.StringToHash("Run");
        public static readonly int Action = Animator.StringToHash("Action");
    }

    private void Start()
    {
        var machine = fsm.Create<StateMachine>("Enemy AI")
            .Build<PatrolState>("巡逻状态")
                .OnEnter(s =>
                {
                    agent.isStopped = false;
                    //StopDistance设为0
                    agent.stoppingDistance = 0f;
                    //设置速度
                    agent.speed = 2f;
                    //进入巡逻状态时 设置第一个巡逻点
                    s.index = 0;
                    agent.SetDestination(patrolPoints[s.index].position);
                    //设置动画参数 进入Walk
                    //animator.SetBool(AnimatorParams.Idle, false);
                    //animator.SetBool(AnimatorParams.Walk, true);
                })
                .OnStay(s =>
                {
                    //判断是否到达目标巡逻点
                    if (Vector3.Distance(transform.position, patrolPoints[s.index].position) <= 1f)
                    {
                        //设置动画参数 进入Idle
                        //animator.SetBool(AnimatorParams.Walk, false);
                        //animator.SetBool(AnimatorParams.Idle, true);
                        //到达后随机休息若干秒
                        s.timer += Time.deltaTime;
                        if (s.timer >= Random.Range(3f, 5f))
                        {
                            //重置计时器
                            s.timer = 0f;
                            //设置下一个巡逻点
                            s.index++;
                            s.index = s.index == patrolPoints.Length ? 0 : s.index;
                            agent.SetDestination(patrolPoints[s.index].position);
                            //设置动画参数 进入Walk
                            //animator.SetBool(AnimatorParams.Idle, false);
                            //animator.SetBool(AnimatorParams.Walk, true);
                        }
                    }
                })
                .OnExit(s =>
                {
                    agent.isStopped = true;
                    //animator.SetBool(AnimatorParams.Idle, false);
                    //animator.SetBool(AnimatorParams.Walk, false);
                })
                //当Player进入5米范围内时 Enemy进入寻路状态
                .SwitchWhen(() => Vector3.Distance(player.position, transform.position) <= 5f, "寻路状态")
            .Complete()
            .Build<State>("寻路状态")
                .OnEnter(s =>
                {
                    agent.isStopped = false;
                    //StopDistance设为1
                    agent.stoppingDistance = 1.5f;
                    //加速移动
                    agent.speed = 4f;
                    //设置动画参数 进入Run
                    //animator.SetBool(AnimatorParams.Run, true);
                })
                .OnStay(s =>
                {
                    //未到达Player前指定距离时 不断寻路
                    if (Vector3.Distance(transform.position, player.position) > 1.5f)
                    {
                        agent.SetDestination(player.position);
                    }
                    else
                    {
                        //到达Player前指定距离 进入攻击状态
                        s.Machine.Switch("攻击状态");
                    }
                })
                .OnExit(s =>
                {
                    //animator.SetBool(AnimatorParams.Run, false);
                })
                //距离Player大于指定值时 重回巡逻状态
                .SwitchWhen(() => Vector3.Distance(transform.position, player.position) > 10f, "巡逻状态")
            .Complete()
            .Build<AttackState>("攻击状态")
                .OnEnter(s => agent.isStopped = true)
                .OnStay(s =>
                {
                    //朝向Player
                    transform.rotation = Quaternion.LookRotation(player.position - transform.position);
                    //Attack Action
                    //if (s.attackCD == 2f) animator.SetInteger(AnimatorParams.Action, 1);
                    ////攻击CD
                    //else
                    //{
                    //    s.attackCD -= Time.deltaTime;
                    //    if (s.attackCD <= 0f) s.attackCD = 2f;
                    //}
                })
                //.OnExit(s => animator.SetInteger(AnimatorParams.Action, 0))
                .SwitchWhen(() => Vector3.Distance(transform.position, player.position) >= 2f, "寻路状态")
            .Complete();

        //进入第一个状态
        machine.Switch2Next();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Handles.PositionHandle(patrolPoints[i].position, Quaternion.identity);
            Handles.Label(patrolPoints[i].position, string.Format("Patrol Point {0}", i + 1));
        }

        Handles.color = Color.red;
        Handles.DrawWireArc(transform.position, transform.up, transform.right, 360f, 5f);
        Handles.color = Color.cyan;
        Handles.DrawWireArc(transform.position, transform.up, transform.right, 360f, 10f);
    }
#endif
}
