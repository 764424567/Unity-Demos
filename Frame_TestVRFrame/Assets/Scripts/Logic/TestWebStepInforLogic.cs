/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TestWebStepInforLogic
* 创建日期：2021-04-28 10:21:11
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class TestWebStepInforLogic : MVVMLogicBase 
	{
        public bool isNewPlatform = true;

        private WebStepInforManager manager;
        private WebStepInfor stepInfor;

        private void Start()
        {
            manager = InjectService.Get<WebStepInforManager>();
            if (isNewPlatform)
            {
                InjectService.Get<OwvlabSaasCTR>().SetLoginCallBack(LoginCallBack);
            }
            
            stepInfor = manager.GetStepInfor(1);
            for (int i = 0; i < 13; i++)
            {
                LoadGameObject("item", i.ToString(), GetUIBehaviours("测试界面Content").gameObject);
                
            }
            stepInfor.SetStepStartTime();
            stepInfor.SetStepRepeatCount();

            WaitTimeShow();

        }

        private void LoginCallBack(string appId,string expId,string host) {
            GetUIBehaviours("AppIdText").Text = appId;
            GetUIBehaviours("ExpIdText").Text = expId;
        }

        private void SendMessageCallBack(string message) {
            GetUIBehaviours("BackMessage").Text = message;
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

            if (vm.name.Equals("上传Button"))
            {
                if (isNewPlatform)
                {
                    InjectService.Get<OwvlabSaasCTR>().SendMessageToPlatform(SendMessageCallBack);
                }
                else
                {
                    InjectService.Get<OwvlabPlatformCTR>().SendMessageToPlatform();
                }
            }

        }


        private void WaitTimeShow() {
            StartCoroutine(WaitTime());
        }

        private IEnumerator WaitTime() {
            yield return new WaitForSeconds(2);
            stepInfor.SetStepEndTime();
            GetUIBehaviours("itemText0").Text = "步骤名称";
            GetUIBehaviours("itemInputField0").InputFieldText = stepInfor.ModuleFlag;
            GetUIBehaviours("itemInputField0").InputFieldReadOnly = true;
            GetUIBehaviours("itemText1").Text = "步骤编号";
            GetUIBehaviours("itemInputField1").InputFieldText = stepInfor.QuestionNumber.ToString();
            GetUIBehaviours("itemInputField1").InputFieldReadOnly = true;
            GetUIBehaviours("itemText2").Text = "步骤说明";
            GetUIBehaviours("itemInputField2").InputFieldText = stepInfor.QuestionStem;
            GetUIBehaviours("itemInputField2").InputFieldReadOnly = true;
            GetUIBehaviours("itemText3").Text = "步骤得分";
            GetUIBehaviours("itemInputField3").InputFieldText = stepInfor.Score.ToString();
            GetUIBehaviours("itemInputField3").AddInputEditEndListener((value)=> { stepInfor.Score = Convert.ToInt32( value); });
            GetUIBehaviours("itemText4").Text = "是否正确";
            GetUIBehaviours("itemInputField4").InputFieldText = stepInfor.TrueOrFalse;
            GetUIBehaviours("itemInputField4").InputFieldReadOnly = true;
            GetUIBehaviours("itemText5").Text = "步骤开始时间";
            GetUIBehaviours("itemInputField5").InputFieldText = stepInfor.StartTime;
            GetUIBehaviours("itemInputField5").InputFieldReadOnly = true;
            GetUIBehaviours("itemText6").Text = "步骤结束时间";
            GetUIBehaviours("itemInputField6").InputFieldText = stepInfor.EndTime;
            GetUIBehaviours("itemInputField6").InputFieldReadOnly = true;
            GetUIBehaviours("itemText7").Text = "步骤合理用时";
            GetUIBehaviours("itemInputField7").InputFieldText = stepInfor.ExpectTime.ToString();
            GetUIBehaviours("itemInputField7").InputFieldReadOnly = true;
            GetUIBehaviours("itemText8").Text = "步骤最大成绩";
            GetUIBehaviours("itemInputField8").InputFieldText = stepInfor.MaxScore.ToString();
            GetUIBehaviours("itemInputField8").AddInputEditEndListener((value) => { stepInfor.MaxScore = Convert.ToInt32(value); });
            GetUIBehaviours("itemText9").Text = "步骤操作次数";
            GetUIBehaviours("itemInputField9").InputFieldText = stepInfor.RepeatCount.ToString();
            GetUIBehaviours("itemInputField9").InputFieldReadOnly = true;
            GetUIBehaviours("itemText10").Text = "实验步骤评价";
            GetUIBehaviours("itemInputField10").InputFieldText = stepInfor.Evaluation;
            GetUIBehaviours("itemInputField10").InputFieldReadOnly = true;
            GetUIBehaviours("itemText11").Text = "考察点";
            GetUIBehaviours("itemInputField11").InputFieldText = stepInfor.ScoringModel;
            GetUIBehaviours("itemInputField11").InputFieldReadOnly = true;
            GetUIBehaviours("itemText12").Text = "备注";
            GetUIBehaviours("itemInputField12").InputFieldText = stepInfor.Remarks;
            GetUIBehaviours("itemInputField12").InputFieldReadOnly = true;
        }

    }
}
