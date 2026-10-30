/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：UpLoadStepInforPanelLogic
* 创建日期：2021-07-10 14:00:08
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class UpLoadStepInforPanelLogic : MVVMLogicBase 
	{
        private List<WebStepInfor> webStepInfors;


        private float time = 180f;

        public enum WebPlatform {
            /// <summary>
            /// 新平台
            /// </summary>
            newPlatform = 0,
            /// <summary>
            /// 旧平台
            /// </summary>
            oldPlatform
        }

        public WebPlatform webPlatform = WebPlatform.newPlatform;

        public void ShowUpLoadScorePanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;

            webStepInfors = InjectService.Get<WebStepInforManager>().GetAllStepInfor();
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                LoadGameObject("StepInforItem", i.ToString(), GetGameObject("UpLoadStepInforContent"));
                GetUIBehaviours("StepNumber" + i.ToString()).Text = webStepInfors[i].QuestionNumber.ToString();
                GetUIBehaviours("StepName" + i.ToString()).Text = webStepInfors[i].ModuleFlag;
                GetUIBehaviours("StepMaxScore" + i.ToString()).Text = webStepInfors[i].MaxScore.ToString();
            }
        }

        private void OnUpLoadClick() {
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (!string.IsNullOrEmpty(GetUIBehaviours("StepScore" + i.ToString()).InputFieldText))
                {
                    webStepInfors[i].SetStepScore(Convert.ToInt32(GetUIBehaviours("StepScore" + i.ToString()).InputFieldText));
                }
            }
            switch (webPlatform)
            {
                case WebPlatform.newPlatform:
                    InjectService.Get<OwvlabSaasCTR>().SendMessageToPlatform(SendMessageCallBack);
                    break;
                case WebPlatform.oldPlatform:
                    InjectService.Get<OwvlabPlatformCTR>().SendMessageToPlatform();
                    break;
                default:
                    break;
            }
        }

        private void SendMessageCallBack(string message) {
            GetUIBehaviours("CallBackPanel").Scale = Vector3.one;
            GetUIBehaviours("CallBackPanelText").Text = message;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                GetUIBehaviours("UpLoadButton").SetButtonActive(true);
                GetUIBehaviours("UpLoadTime").Text = "可以上传";
            }
            else
            {
                GetUIBehaviours("UpLoadTime").Text = ((int)time).ToString() + "秒后可上传成绩";
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                ShowUpLoadScorePanel();
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

            if (vm.name.Equals("CloseButton"))
            {
                GetUIBehaviours(transform.name).Scale = Vector3.zero;
                for (int i = webStepInfors.Count - 1; i >= 0; i--)
                {
                    DestroyImmediate(GetGameObject("StepInforItem" + i.ToString()));
                }
            }
            if (vm.name.Equals("UpLoadButton"))
            {
                OnUpLoadClick();
            }
            if (vm.name.Equals("CallBackPanelButton"))
            {
                GetUIBehaviours("CallBackPanel").Scale = Vector3.zero;
            }
        }
    }
}
