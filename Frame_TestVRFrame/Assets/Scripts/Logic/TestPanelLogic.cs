/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TestPanelLogic
* 创建日期：2021-01-13 11:59:28
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class TestPanelLogic : MVVMLogicBase 
	{

        private void Start()
        {
            for (int i = 1; i < 4; i++)
            {
                //string name = "Button" + i;
                GetUIBehaviours("Button" + i).AddButtonListener(()=> {
                    Debug.Log("Button" + i);
                });
            }

        }


        






        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            //忽略除ViewModel外其他Entity发出的事件
            if (!(evt.EventSource is ViewModel))	return;

			//获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

        }
    }
}
