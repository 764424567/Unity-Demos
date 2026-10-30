/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StartPanelLogic
* 创建日期：2020-05-26 11:51:50
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class StartPanelLogic : MVVMLogicBase 
	{

        int clickCount = 0;

        private void Start()
        {
            GetUIBehaviours("VerText").Text = "Ver: " + Application.version;
        }

        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、Diable事件、有Destroy事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable") || evt.EventName.Equals("OnDestroy")) return;

            //忽略除ViewModel外其他Entity发出的事件
            if (!(evt.EventSource is ViewModel)) return;

            //获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

            if (vm.name.Equals("StartButton"))
            {
                ModeSelect.ProgramMode = ModeSelect.Mode.Study;
                //GetUILogic<LoadSceneLogic>("LoadScene").LoadScene("Test");
                GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("Test");
                //GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("WebTestScene");
                //GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("TestDrag");
                //GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("DragUI");

            }
            if (vm.name.Equals("StartButton2"))
            {
                ModeSelect.ProgramMode = ModeSelect.Mode.Exam;
                GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("Test");

            }
        }
    }
}

