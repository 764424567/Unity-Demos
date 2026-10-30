using SK.Framework;
using SK.Framework.FSM;
using UnityEngine;

public class UseFSM : MonoBehaviour
{
    FSM fsm;
    public class TestState : State
    {
        public string stringValue;
    }

    private void Start()
    {
        fsm = SKFramework.Module<FSM>();
        //创建状态机
        var machine = fsm.Create<StateMachine>("示例状态机")
            //构建状态一
            .Build<TestState>("状态一")
                //设置状态一初始化事件
                .OnInitialization(state => state.stringValue = "A")
                //设置状态一进入事件
                .OnEnter(state => Debug.Log("进入状态一"))
                //设置状态一停留事件
                .OnStay(state => Debug.Log("状态一"))
                //设置状态一推出事件
                .OnExit(state => Debug.Log("退出状态一"))
                //设置状态一销毁事件
                .OnTermination(state => state.stringValue = null)
            //状态一构建完成
            .Complete()
            //构建状态二
            .Build<State>("状态二")
                //设置状态二进入事件
                .OnEnter(state => Debug.Log("进入状态二"))
                //设置状态二停留事件
                .OnStay(state => Debug.Log("状态二"))
                //设置状态二退出事件
                .OnExit((state => Debug.Log("退出状态二")))
            //状态二构建完成
            .Complete()
            //构建状态三
            .Build<State>("状态三")
                //设置状态三进入事件
                .OnEnter(state => Debug.Log("进入状态三"))
                //设置状态三停留事件
                .OnStay(state => Debug.Log("状态三"))
                //设置状态三退出事件
                .OnExit((state => Debug.Log("退出状态三")))
            //状态三构建完成
            .Complete()
            //添加状态切换条件 当按下快捷键1时 切换至状态一
            .SwitchWhen(() => Input.GetKeyDown(KeyCode.Alpha1), "状态一")
            //添加状态切换条件 当按下快捷键2时 切换至状态二
            .SwitchWhen(() => Input.GetKeyDown(KeyCode.Alpha2), "状态二")
            //添加状态切换条件 当按下快捷键3时 切换至状态三
            .SwitchWhen(() => Input.GetKeyDown(KeyCode.Alpha3), "状态三")
            //为状态一至状态二添加切换条件：若当前状态为状态一时 按下快捷键4 切换至状态二
            .SwitchWhen(() => Input.GetKeyDown(KeyCode.Alpha4), "状态一", "状态二");
    }
}