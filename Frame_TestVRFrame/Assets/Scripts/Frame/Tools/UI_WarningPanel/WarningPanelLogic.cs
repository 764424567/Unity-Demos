/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：WarningPanelLogic
* 创建日期：2020-06-08 20:01:05
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：提示框逻辑脚本
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class WarningPanelLogic : MVVMLogicBase 
	{

        private void Start()
        {
            AddEntity<WarningPanelEntity>();
        }

        private void OnDestroy()
        {
            RemoveEntity<WarningPanelEntity>();
        }

        /// <summary>
        /// 设置提示内容，点击后执行回调
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="callBack">回调</param>
        public void SetWarningThenDoFunc(string text,UnityAction callBack) {
            SetCallBackAction(callBack);
            GetEntity<WarningPanelEntity>().SetWarning(text);
        }

        /// <summary>
        /// 设置提示内容
        /// </summary>
        /// <param name="text">提示内容</param>
        public void SetWarning(string text)
        {
            GetEntity<WarningPanelEntity>().SetWarning(text);
        }

        /// <summary>
        /// 打开提示框（可重写）
        /// </summary>
        protected virtual void OpenPanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;
        }

        /// <summary>
        /// 关闭提示框（可重写）
        /// </summary>
        protected virtual void ClosePanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.zero;
        }


        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable") || evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable")) return;

            if (evt.EventSource is ViewModel) {
                //获取事件源
                ViewModel vm = evt.EventSource as ViewModel;
                //点击提示框确定键
                if (vm.name.Equals("WarningPanelButton"))
                {
                    ClosePanel();
                    InvokeCallBackAction();
                }
            }

            if (evt is MethodEvent)
            {
                //显示提示内容
                if (evt.EventName.Equals("SetWarning"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string message = (string)data[0];
                    OpenPanel();
                    ShowMessage(message);
                }
            }
        }

        /// <summary>
        /// 显示文字
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message) {
            UIBehaviours tmpText = GetUIBehaviours("WarningPanelText");
            tmpText.Text = message;
            if (tmpText.GetTextLength() > tmpText.Width)
            {
                tmpText.Alignment = TextAnchor.MiddleLeft;
            }
            else
            {
                tmpText.Alignment = TextAnchor.MiddleCenter;
            }
        }


    }
}
