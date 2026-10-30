/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： Test
* 创建日期：2020-05-27 16:40:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit.Unity.Architecture.Injector;


namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class Test : StepLogicBase 
	{

        public Button button;

        private void Start()
        {
            StartStepLogic();
            button.onClick.AddListener(() =>
            {
                JumpStep(StepManager.StepID.jumpStep);
            });
            WaitTimeDoFunc(1f, () =>
            {
                GetObjLogic<AudioSystemLogic>("BGMAudio").PlayAudioNotSave("BGM");
            });

        }

        private void Update()
        {
            //Debug.Log(IPointerOver.CurrentPointerOverGameObject());
        }

        protected override void StudyStepInput()
        {
            step.AddStep(StepManager.StepID.jumpStep, "1", null, "第1步", new NamePair("StepTip", "StepTipButton"), Step.TriggerType.UIFrameLight, Step_1, null);
            step.AddStep(StepManager.StepID.orderStep,"2", null, string.Empty,new NamePair("Cube", "Cube"),Step.TriggerType.ObjLight,Step_2,null);
            step.AddStep(StepManager.StepID.jumpStep+1, "3", null, "第2步", new NamePair("StepTip", "StepTipButton"), Step.TriggerType.UILight, Step_3, null);
            step.AddStep(StepManager.StepID.orderStep,"4",null,string.Empty,new NamePair("Sphere2", "Sphere2"),Step.TriggerType.ObjLight,Step_4,null);
            step.AddStep(StepManager.StepID.orderStep,string.Empty,null,"第3步",new NamePair("StepTip", "StepTipButton"),Step.TriggerType.UI,Step_5,null);
            step.AddStep(StepManager.StepID.orderStep,string.Empty,null,string.Empty,null,Step.TriggerType.none,Step_6,null);
            step.AddStep(StepManager.StepID.orderStep,string.Empty,null,string.Empty,null,Step.TriggerType.none,Step_7,null);
        }

        protected override void ExamStepInput()
        {
            step.AddStep(StepManager.StepID.jumpStep, string.Empty, null, string.Empty, new NamePair("StepTip", "StepTipButton"), Step.TriggerType.UIFrame, Step_1, null);
            step.AddStep(StepManager.StepID.orderStep, string.Empty, null, string.Empty, new NamePair("Cube", "Cube"), Step.TriggerType.Obj, Step_2, null);
            step.AddStep(StepManager.StepID.jumpStep + 1, string.Empty, null, string.Empty, new NamePair("StepTip", "StepTipButton"), Step.TriggerType.UI, Step_3, null);
            step.AddStep(StepManager.StepID.orderStep, string.Empty, null, string.Empty, new NamePair("Sphere2", "Sphere2"), Step.TriggerType.Obj, Step_4, null);
            step.AddStep(StepManager.StepID.orderStep, string.Empty, null, string.Empty, new NamePair("StepTip", "StepTipButton"), Step.TriggerType.UI, Step_5, null);
        }


        protected override void ShowExamTip(Step.TriggerType triggerType, NamePair namePair)
        {
            switch (triggerType)
            {
                case Step.TriggerType.none:
                    break;
                case Step.TriggerType.Obj:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.one;
                    GetUIBehaviour("Panel", "ExamTip").AddButtonListener(() => {
                        GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                        GetObjBehaviour(namePair.RootName, namePair.ObjName).SetObjHighlight(true);
                    });
                    break;
                case Step.TriggerType.ObjLight:
                    break;
                case Step.TriggerType.UI:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.one;
                    GetUIBehaviour("Panel", "ExamTip").AddButtonListener(() =>
                    {
                        GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                        GetUIBehaviour(namePair.RootName, namePair.ObjName).SetUIHighlight(true);
                    });
                    break;
                case Step.TriggerType.UIFrame:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.one;
                    GetUIBehaviour("Panel", "ExamTip").AddButtonListener(() =>
                    {
                        GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                        GetUIBehaviour(namePair.RootName, namePair.ObjName).SetUIFrameHighlight(true);
                    });
                    break;
                case Step.TriggerType.UILight:
                    break;
                case Step.TriggerType.UIFrameLight:
                    break;
                default:
                    break;
            }
        }

        protected override void HideExamTip(Step.TriggerType triggerType, NamePair namePair)
        {
            switch (triggerType)
            {
                case Step.TriggerType.none:
                    break;
                case Step.TriggerType.Obj:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                    GetUIBehaviour("Panel", "ExamTip").RemoveButtonListener();
                    GetObjBehaviour(namePair.RootName, namePair.ObjName).SetObjHighlight(false);
                    break;
                case Step.TriggerType.ObjLight:
                    break;
                case Step.TriggerType.UI:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                    GetUIBehaviour("Panel", "ExamTip").RemoveButtonListener();
                    GetUIBehaviour(namePair.RootName, namePair.ObjName).SetUIHighlight(false);
                    break;
                case Step.TriggerType.UIFrame:
                    GetUIBehaviour("Panel", "ExamTip").Scale = Vector3.zero;
                    GetUIBehaviour("Panel", "ExamTip").RemoveButtonListener();
                    GetUIBehaviour(namePair.RootName, namePair.ObjName).SetUIFrameHighlight(false);
                    break;
                case Step.TriggerType.UILight:
                    break;
                case Step.TriggerType.UIFrameLight:
                    break;
                default:
                    break;
            }
        }

        private void Step_1() {
            List<string> fileNames = new List<string>();
            fileNames.Add("金黄色葡萄球菌及其毒素01");
            GetUILogic<ShowFilePanelLogic>("ShowFilePanel").StartShowFile(fileNames);
            GetUILogic<ShowFilePanelLogic>("ShowFilePanel").SetPanelCloseAction(NextStep);

            //GetUILogic<UITriggerLogic>("Panel").AddButtonListenerATLight("Button",()=> { Debug.Log("!!!"); });
            //显示考题
            //GetUILogic<UIExamLogic>("ExamPanel").LoadExam("32");
            //显示提示框
            //GetUILogic<WarningPanelLogic>("WarningPanel").SetWarningThenDoFunc("显示了一个提示框",NextStep);
            //第三人称移动观察相机
            //GetObjLogic<LookCameraLogic>("LookCamera").MoveLookCamera("1",1f,NextStep);
            //第一人称移动观察相机
            //GetObjBehaviour("FPS", "LookCamera").GetComponent<LookCameraLogic>().MoveLookCamera("1", 1f, NextStep);
            //第一人称移动
            //GetObjLogic<FPSLogic>("FPS").MoveToPos("1",2f, NextStep);
            //Debug.Log("执行了第一步");
            //NextStep();
        }

        private void FStep_2()
        {
            
        }

        private void Step_2()
        {
            Debug.Log("执行了第二步");
            
            GetUILogic<ScreenEffectLogic>("ScreenEffect").ShowEffect(()=> {
                GetObjLogic<LookCameraLogic>("LookCamera").ReSetLookCamera();
                
                NextStep();
            });
            
            //GetObjBehaviour("FPS", "LookCamera").GetComponent<LookCameraLogic>().ReSetLookCamera();
            
            
        }

        private void Step_3()
        {
            //设置目标提示
            GetUILogic<TargetPanelLogic>("TargetPanel").TargetCamera = Camera.main.gameObject;
            GetUILogic<TargetPanelLogic>("TargetPanel").ShowTargetTip(GetObjBehaviour("Sphere2", "Sphere2").gameObject);

            GetUILogic<WarningPanelLogic>("WarningPanel").SetWarningThenDoFunc("显示了一个有点长并且应该会超出一行长度的提示框", NextStep);
            Debug.Log("执行了第3步");
        }

        private void Step_4()
        {
            GetUILogic<TargetPanelLogic>("TargetPanel").HideTargetTip();
            GetUILogic<UIExamLogic>("ExamPanel").LoadExam("15");
            GetUILogic<UIExamLogic>("ExamPanel").SetEndAction(NextStep);
            Debug.Log("执行了第4步");
            //NextStep();
        }

        private void Step_5() {
            //加载视频
            //GetUILogic<VideoPanelLogic>("VideoPanel").LoadVideo("2");
            //GetUILogic<VideoPanelLogic>("VideoPanel").SetEndAction(NextStep);
            //加载视频（AVPro插件）
            GetUILogic<AVProLogic>("AVProPanel").PlayVideoUseLocal("2");
            GetUILogic<AVProLogic>("AVProPanel").SetEndAction(NextStep);

            //GetUILogic<UIExamLogic>("ExamPanel").LoadExam("3");
            //GetUILogic<UIExamLogic>("ExamPanel").SetEndAction(NextStep);
        }

        private void Step_6() {
            GetUILogic<UIExamLogic>("ExamPanel").LoadExam("32");
            GetUILogic<UIExamLogic>("ExamPanel").SetEndAction(NextStep);
        }

        private void Step_7()
        {
            List<string> fileNames = new List<string>();
            fileNames.Add("金黄色葡萄球菌及其毒素01");
            GetUILogic<ShowFilePanelLogic>("ShowFilePanel").StartShowFile(fileNames);
            GetUILogic<ShowFilePanelLogic>("ShowFilePanel").SetPanelCloseAction(NextStep);

        }
    }
}

