/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：BasePanelLogic
* 创建日期：2020-07-03 14:04:35
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：基础功能UI界面逻辑
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;


namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class BasePanelLogic : MVVMLogicBase 
	{
        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="endAction">关闭界面后的回调</param>
        public void ShowPanel(UnityAction endAction) {
            OpenPanel();
            SetCallBackAction(endAction);
        }

        /// <summary>
        /// 打开界面（可重写）
        /// </summary>
        protected virtual void OpenPanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;
        }

        /// <summary>
        /// 关闭界面（可重写）
        /// </summary>
        protected virtual void ClosePanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.zero;
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

            if (vm.name.Equals("BasePanelButton"))
            {
                ClosePanel();
                InvokeCallBackAction();
            }

        }
    }
}
