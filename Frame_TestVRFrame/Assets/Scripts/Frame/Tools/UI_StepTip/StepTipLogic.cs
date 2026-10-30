/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StepTipLogic
* 创建日期：2020-06-01 13:25:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：步骤提示框逻辑脚本
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Coffee.UIExtensions;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class StepTipLogic : MVVMLogicBase 
	{
        
        /// <summary>
        /// 当确定键点击（点击后如需收回提示框可重写此方法）
        /// </summary>
        protected virtual void OnStepTipButtonClick() {
            
        }

        /// <summary>
        /// 当显示提示内容时（可重写此方法）
        /// </summary>
        protected virtual void OnStepTipMessageShow() {

        }

        /// <summary>
        /// 设置步骤提示(可重写此方法)
        /// </summary>
        /// <param name="message">提示内容</param>
        public virtual void SetStepMessage(string message) {
            GetViewModel<TextViewModel>("StepTipText").Value = message;
            OnStepTipMessageShow();
        }

        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、Diable事件、有Destroy事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable") || evt.EventName.Equals("OnDestroy")) return;

            //忽略除ViewModel外其他Entity发出的事件
            if (!(evt.EventSource is ViewModel)) return;

            //获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

            //点击步骤提示按键
            if (vm.name.Equals("StepTipButton"))
            {
                OnStepTipButtonClick();
            }

        }
    }
}

