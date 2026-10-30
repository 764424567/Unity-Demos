/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：UIExamLogic
* 创建日期：2020-06-10 16:59:25
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：考题显示和判断正误逻辑脚本（此脚本可继承重写部分方法改变题目展示逻辑）
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class UIExamLogic : MVVMLogicBase 
	{
        private UnityAction endAction;

        /// <summary>
        /// 当前考题
        /// </summary>
        protected Exam exam;

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
        /// 题目未选择就点击提交键（可重写）
        /// </summary>
        protected virtual void WhenExamNotSelect() {
            GetUILogic<WarningPanelLogic>("WarningPanel").SetWarning("请先作答此题再提交");
        }

        /// <summary>
        /// 读取考题
        /// </summary>
        /// <param name="examName">考题名称</param>
        public void LoadExam(string examName) {
            OpenPanel();
            int rightCount = 0;
            GetUIBehaviours("UpLoadButton").Scale = Vector3.one;
            GetUIBehaviours("GoOnButton").Scale = Vector3.zero;
            exam = InjectService.Get<ExamManager>().GetExam(examName);
            switch (exam.ExamType)
            {
                case ExamType.KaoTi:
                    break;
                case ExamType.XuanZeTi:
                    Choices choices = (Choices)exam;
                    for (int i = 0; i < choices.Options.Count; i++)
                    {
                        LoadOption(i);
                        GetViewModel<TextViewModel>("ExamToggleText" + i.ToString()).Value = choices.Options[i].OptionName;
                        if (choices.Options[i].Answer)
                        {
                            rightCount++;
                        }
                    }
                    GetViewModel<TextViewModel>("ExamPanelText").Value = choices.ExamDetail;
                    GetViewModel<TextViewModel>("ExamPanelTip").Value = string.Empty;
                    GetViewModel<TextViewModel>("ExamPanelTitle").Value = "选择题";
                    if (rightCount == 1)
                    {
                        for (int i = 0; i < choices.Options.Count; i++)
                        {
                            GetUIBehaviours("ExamToggle" + i.ToString()).AddToggleGroup(GetGameObject("ExamPanelContent"));
                        }
                    }
                    break;
                case ExamType.TianKongTi:
                    InputExam inputExam = (InputExam)exam;
                    for (int i = 0; i < inputExam.Options.Count; i++)
                    {
                        LoadInputOption(i);
                        GetViewModel<TextViewModel>("ExamInputTitle" + i.ToString()).Value = inputExam.Options[i].OptionName;

                    }
                    GetViewModel<TextViewModel>("ExamPanelText").Value = inputExam.ExamDetail;
                    GetViewModel<TextViewModel>("ExamPanelTip").Value = string.Empty;
                    GetViewModel<TextViewModel>("ExamPanelTitle").Value = "填空题";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 设置点击继续键后的回调
        /// </summary>
        /// <param name="endAction"></param>
        public void SetEndAction(UnityAction endAction) {
            SetCallBackAction(endAction);
        }

        /// <summary>
        /// 加载选择题选项
        /// </summary>
        /// <param name="number"></param>
        private void LoadOption(int number) {
            GameObject option = Instantiate(Resources.Load<GameObject>("ExamToggle"));
            option.name = option.name.Remove(option.name.Length - 7);
            option.transform.SetParent(GetGameObject("ExamPanelContent").transform, false);
            Transform[] childTranms = option.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childTranms.Length; i++)
            {
                childTranms[i].gameObject.name += number.ToString();
                childTranms[i].gameObject.AddComponent<UIBehaviours>();
                GetComponent<MvvmContext>().Initialize(childTranms[i]);//动态注册
            }
        }

        /// <summary>
        /// 加载填空题选项
        /// </summary>
        /// <param name="number"></param>
        private void LoadInputOption(int number) {
            GameObject option = Instantiate(Resources.Load<GameObject>("ExamInput"));
            option.name = option.name.Remove(option.name.Length - 7);
            option.transform.SetParent(GetGameObject("ExamPanelContent").transform, false);
            Transform[] childTranms = option.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childTranms.Length; i++)
            {
                childTranms[i].gameObject.name += number.ToString();
                childTranms[i].gameObject.AddComponent<UIBehaviours>();
                GetComponent<MvvmContext>().Initialize(childTranms[i]);//动态注册
            }
        }

        /// <summary>
        /// 当提交键被点击(可重写判断正误的逻辑)
        /// </summary>
        protected virtual void OnUpLoadButtonClick() {
            if (IsSelect())
            {
                GetUIBehaviours("UpLoadButton").Scale = Vector3.zero;
                GetUIBehaviours("GoOnButton").Scale = Vector3.one;
                switch (exam.ExamType)
                {
                    case ExamType.KaoTi:
                        break;
                    case ExamType.XuanZeTi:
                        Choices choices = (Choices)exam;
                        if (choices.InputAnswer == null)//如果此题没有回答过
                        {
                            List<bool> answers = new List<bool>();
                            for (int i = 0; i < choices.Options.Count; i++)
                            {
                                answers.Add(GetViewModel<ToggleViewModel>("ExamToggle" + i.ToString()).Value);
                            }
                            choices.InputAnswer = answers;
                            if (exam.Answer)
                            {
                                GetViewModel<TextViewModel>("ExamPanelTip").Value = "回答正确";
                            }
                            else
                            {
                                string rightName = string.Empty;
                                for (int i = 0; i < choices.Options.Count; i++)
                                {
                                    if (choices.Options[i].Answer)
                                    {
                                        rightName += choices.Options[i].OptionName.Substring(0, 1);
                                    }
                                }
                                GetViewModel<TextViewModel>("ExamPanelTip").Value = "回答错误，答案为:" + rightName;
                            }
                        }
                        break;
                    case ExamType.TianKongTi:
                        InputExam inputExam = (InputExam)exam;
                        if (inputExam.InputAnswer == null)
                        {
                            List<string> answers = new List<string>();
                            for (int i = 0; i < inputExam.Options.Count; i++)
                            {
                                answers.Add(GetViewModel<InputFieldViewModel>("ExamInputIF" + i.ToString()).Value);
                            }
                            inputExam.InputAnswer = answers;
                            if (inputExam.Answer)
                            {
                                GetViewModel<TextViewModel>("ExamPanelTip").Value = "回答正确";
                            }
                            else
                            {
                                string rightName = string.Empty;
                                for (int i = 0; i < inputExam.Options.Count; i++)
                                {
                                    rightName += inputExam.Options[i].OptionName;
                                    for (int j = 0; j < inputExam.Options[i].Answer.Length; j++)
                                    {
                                        if (j != inputExam.Options[i].Answer.Length - 1)
                                        {
                                            rightName += inputExam.Options[i].Answer[j] + " 或 ";
                                        }
                                        else
                                        {
                                            rightName += inputExam.Options[i].Answer[j];
                                        }
                                    }
                                }
                                GetViewModel<TextViewModel>("ExamPanelTip").Value = "回答错误，答案为:" + rightName;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                WhenExamNotSelect();
            }
        }

        /// <summary>
        /// 销毁选项
        /// </summary>
        private void DestroyChoices()
        {
            switch (exam.ExamType)
            {
                case ExamType.KaoTi:
                    break;
                case ExamType.XuanZeTi:
                    Choices choices = (Choices)exam;
                    for (int i = 0; i < choices.Options.Count; i++)
                    {
                        Destroy(GetUIBehaviours("ExamToggle" + i.ToString()).gameObject);
                    }
                    break;
                case ExamType.TianKongTi:
                    InputExam inputExam = (InputExam)exam;
                    for (int i = 0; i < inputExam.Options.Count; i++)
                    {
                        Destroy(GetUIBehaviours("ExamInput" + i.ToString()).gameObject);
                    }
                    break;
                default:
                    break;
            }
           
            
        }

        /// <summary>
        /// 判断是否选择答案
        /// </summary>
        /// <returns></returns>
        protected bool IsSelect()
        {
            switch (exam.ExamType)
            {
                case ExamType.KaoTi:
                    return false;
                case ExamType.XuanZeTi:
                    Choices choices = (Choices)exam;
                    for (int i = 0; i < choices.Options.Count; i++)
                    {
                        if (GetViewModel<ToggleViewModel>("ExamToggle" + i.ToString()).Value)
                        {
                            return true;
                        }
                    }
                    return false;
                case ExamType.TianKongTi:
                    InputExam inputExam = (InputExam)exam;
                    for (int i = 0; i < inputExam.Options.Count; i++)
                    {
                        if (GetViewModel<InputFieldViewModel>("ExamInputIF" + i.ToString()).Value != string.Empty)
                        {
                            return true;
                        }
                    }
                    return false;
                default:
                    return false;
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

            //显示题干
            if (vm.name.Equals("ExamPanelText")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                GetUIBehaviours("ExamPanelText").Text = newValue;
            }
            //显示选项
            if (vm.name.Contains("ExamToggleText"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                GetUIBehaviours(vm.name).Text = newValue;
            }
            //回答正误反馈
            if (vm.name.Contains("ExamPanelTip")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                GetUIBehaviours(vm.name).Text = newValue;
            }
            //提交键
            if (vm.name.Equals("UpLoadButton")) {
                OnUpLoadButtonClick();
            }
            //继续键
            if (vm.name.Equals("GoOnButton")) {
                DestroyChoices();
                ClosePanel();
                InvokeCallBackAction();
            }
        }
    }
}
