using UnityEngine;
using UnityEngine.AI;
using FSM;

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
    NavMeshAgent agent;
    //动画组件
    Animator animator;
    //巡逻点集合
    [SerializeField] private Vector3[] Points;

    public bool isDrawGizmos = false;

    FSMComponent fsm;
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
        fsm = GameObject.Find("敌人FSM管理").GetComponent<FSMComponent>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        var machine = fsm.Create<StateMachine>(name)
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
                    agent.SetDestination(Points[s.index]);
                    //设置动画参数 进入Walk
                    animator.SetBool(AnimatorParams.Idle, false);
                    animator.SetBool(AnimatorParams.Walk, true);
                })
                .OnStay(s =>
                {
                    //判断是否到达目标巡逻点
                    if (Vector3.Distance(transform.position, Points[s.index]) <= 1f)
                    {
                        //设置动画参数 进入Idle
                        animator.SetBool(AnimatorParams.Walk, false);
                        animator.SetBool(AnimatorParams.Idle, true);
                        //到达后随机休息若干秒
                        s.timer += Time.deltaTime;
                        if (s.timer >= Random.Range(3f, 5f))
                        {
                            //重置计时器
                            s.timer = 0f;
                            //设置下一个巡逻点
                            s.index++;
                            s.index = s.index == Points.Length ? 0 : s.index;
                            agent.SetDestination(Points[s.index]);
                            //设置动画参数 进入Walk
                            animator.SetBool(AnimatorParams.Idle, false);
                            animator.SetBool(AnimatorParams.Walk, true);
                        }
                    }
                })
                .OnExit(s =>
                {
                    agent.isStopped = true;
                    animator.SetBool(AnimatorParams.Idle, false);
                    animator.SetBool(AnimatorParams.Walk, false);
                })
                //当Player进入20米范围内时 Enemy进入寻路状态
                .SwitchWhen(() => Vector3.Distance(player.position, transform.position) <= 20f, "寻路状态")
                .Complete()
                .Build<State>("寻路状态")
                .OnEnter(s =>
                {
                    agent.isStopped = false;
                    //StopDistance设为1
                    agent.stoppingDistance = 1.5f;
                    //加速移动
                    agent.speed = 3f;
                    //设置动画参数 进入Run
                    animator.SetBool(AnimatorParams.Run, true);
                })
                .OnStay(s =>
                {
                    //未到达Player前指定距离时 不断寻路
                    if (Vector3.Distance(transform.position, player.position) > 15f)
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
                    animator.SetBool(AnimatorParams.Run, false);
                })
                //距离Player大于指定值时 重回巡逻状态
                .SwitchWhen(() => Vector3.Distance(transform.position, player.position) > 25f, "巡逻状态")
                .Complete()
                .Build<AttackState>("攻击状态")
                .OnEnter(s => agent.isStopped = true)
                .OnStay(s =>
                {
                    //朝向Player
                    transform.rotation = Quaternion.LookRotation(player.position - transform.position);
                    //Attack Action
                    if (s.attackCD == 2f)
                    {
                        s.attackCD = 0f;
                        animator.SetInteger(AnimatorParams.Action, 1);
                        // 射线检测
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit rayHit, 100))
                        {
                            if (rayHit.collider.CompareTag("Player"))
                            {
                                //场景显示红线，方便调试查看
                                Debug.DrawLine(transform.position, rayHit.point, Color.red, 10f);
                                Debug.Log("击中敌人");
                                //TODO：扣血
                                rayHit.collider.gameObject.GetComponent<PlayerControl>().Hit();
                            }
                        }
                    }
                    //攻击CD
                    else
                    {
                        s.attackCD += Time.deltaTime;
                        if (s.attackCD >= 2f) s.attackCD = 2f;
                    }
                })
                .OnExit(s => animator.SetInteger(AnimatorParams.Action, 0))
                .SwitchWhen(() => Vector3.Distance(transform.position, player.position) >= 5f, "寻路状态")
            .Complete();

        //进入第一个状态
        machine.Switch2Next();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        GameObject selectObj = Selection.activeGameObject;
        if (selectObj == gameObject && isDrawGizmos && Points.Length > 0)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Handles.PositionHandle(Points[i], Quaternion.identity);
                Handles.Label(Points[i], string.Format("{0} Point {1}", gameObject.name, i + 1));
            }

            Handles.color = Color.red;
            Handles.DrawWireArc(transform.position, transform.up, transform.right, 360f, 10f);
            Handles.color = Color.cyan;
            Handles.DrawWireArc(transform.position, transform.up, transform.right, 360f, 20f);
        }
    }
#endif

    public void Hit()
    {
        Debug.Log("被击中");
        //扣血
        HealthSystem hs = GetComponent<HealthSystem>();
        if (hs != null)
        {
            hs.SubstractHealth(10);
            if (hs.CurrentHp == 0)
                return;
        }
    }

    void Death()
    {
        Debug.Log("死亡");
        GameObject.Find("敌人FSM管理").GetComponent<FSMComponent>().Destroy(name);
        Destroy(gameObject);
    }
}