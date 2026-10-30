/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: StepLogicBase.cs
  Author:张辰       Version :1.0          Date: 2018-6-27
  Description:步骤类逻辑基类(步骤逻辑需要继承此脚本，最先调用
  StartStepLogic方法(推荐Start中调用)；重写StudyStepInput和
  ExamStepInput方法)
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
    public class StepLogicBase : MonoBehaviour
    {
        protected StepManager step;
        private UnityAction tmpAction;

        /// <summary>
        /// 学习模式逻辑
        /// </summary>
        protected virtual void StudyStepInput() { }

        /// <summary>
        /// 考核模式逻辑
        /// </summary>
        protected virtual void ExamStepInput() { }

        private void OnDestroy()
        {
            if (step != null)
            {
                step.RemoveAllStep();
            }
            
        }

        /// <summary>
        /// 开始执行步骤逻辑（最先调用,Start中）
        /// </summary>
        /// <param name="canvas">UI逻辑脚本</param>
        /// <param name="trigger">3D物体逻辑脚本</param>
        /// <param name="player">操作者对象</param>
        protected void StartStepLogic()
        {
            step = InjectService.Get<StepManager>();
            switch (ModeSelect.ProgramMode)
            {
                case ModeSelect.Mode.Study:
                    StudyStepInput();
                    NextStep();
                    break;
                case ModeSelect.Mode.Exam:
                    ExamStepInput();
                    NextStep();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 工程测试
        /// </summary>
        protected void ProjectTest()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 5f;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
            }
#endif
        }

        #region 内部逻辑
        /// <summary>
        /// 自动执行步骤
        /// </summary>
        private void StepAutoBuild()
        {
            if (!step.StepIndex.Equals(-1))
            {
                if (ModeSelect.ProgramMode == ModeSelect.Mode.Exam)//考核模式操作提示按键显示位置
                {
                    switch (step.GetStepTriggerType)
                    {
                        case Step.TriggerType.none:
                            break;
                        case Step.TriggerType.Obj:
                            ShowExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.ObjLight:
                            break;
                        case Step.TriggerType.UI:
                            ShowExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.UIFrame:
                            ShowExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.UILight:
                            break;
                        case Step.TriggerType.UIFrameLight:
                            break;
                        default:
                            break;
                    }
                    
                }
                if (step.GetStepStartFunction != null)
                {
                    step.GetStepStartFunction();
                }
                if (step.GetStepAudioName != string.Empty)
                {
                    GetObjLogic<AudioSystemLogic>("StepAudio").PlayAudioNotSave(step.GetStepAudioName);
                }
                if (step.GetStepAudioName == string.Empty)
                {
                    GetObjLogic<AudioSystemLogic>("StepAudio").StopAudio();
                }
                if (!step.GetStepMassage.Equals(string.Empty))
                {
                    GetUILogic<StepTipLogic>("StepTip").SetStepMessage(step.GetStepMassage);
                }
                switch (ModeSelect.ProgramMode)
                {
                    case ModeSelect.Mode.Study:
                        switch (step.GetStepTriggerType)
                        {
                            case Step.TriggerType.none:
                                step.GetStepFunction();
                                break;
                            case Step.TriggerType.Obj:
                                tmpAction = GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).AddObjClickListenerAT(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.ObjLight:
                                tmpAction = GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).AddObjClickListenerATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UI:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerAT(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UIFrame:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerAT(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UILight:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UIFrameLight:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerFrameATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            default:
                                break;
                        }
                        break;
                    case ModeSelect.Mode.Exam:
                        switch (step.GetStepTriggerType)
                        {
                            case Step.TriggerType.none:
                                step.GetStepFunction();
                                break;
                            case Step.TriggerType.Obj:
                                tmpAction = GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).AddObjClickListenerAT(step.GetStepTriggerObjName.ObjName, ()=> {
                                    step.GetStepFunction();
                                    HideExamTip(step.GetStepTriggerType,step.GetStepTriggerObjName);
                                });
                                break;
                            case Step.TriggerType.ObjLight:
                                tmpAction = GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).AddObjClickListenerATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UI:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerAT(step.GetStepTriggerObjName.ObjName, ()=> {
                                    step.GetStepFunction();
                                    HideExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                                });
                                break;
                            case Step.TriggerType.UIFrame:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerAT(step.GetStepTriggerObjName.ObjName, () => {
                                    step.GetStepFunction();
                                    HideExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                                });
                                break;
                            case Step.TriggerType.UILight:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            case Step.TriggerType.UIFrameLight:
                                tmpAction = GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).AddButtonListenerFrameATLight(step.GetStepTriggerObjName.ObjName, step.GetStepFunction);
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }
                
            }
        }

        /// <summary>
        /// 自动销毁步骤
        /// </summary>
        private void StepAutoDestory()
        {
            if (!step.StepIndex.Equals(-1))
            {
                if (ModeSelect.ProgramMode == ModeSelect.Mode.Exam)//考核模式操作提示按键隐藏位置
                {
                    switch (step.GetStepTriggerType)
                    {
                        case Step.TriggerType.none:
                            break;
                        case Step.TriggerType.Obj:
                            HideExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.ObjLight:
                            break;
                        case Step.TriggerType.UI:
                            HideExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.UIFrame:
                            HideExamTip(step.GetStepTriggerType, step.GetStepTriggerObjName);
                            break;
                        case Step.TriggerType.UILight:
                            break;
                        case Step.TriggerType.UIFrameLight:
                            break;
                        default:
                            break;
                    }
                }
                if (step.GetStepEndFunction != null)
                {
                    step.GetStepEndFunction();
                }
                switch (step.GetStepTriggerType)
                {
                    case Step.TriggerType.none:
                        break;
                    case Step.TriggerType.Obj:
                        GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveObjClickListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        break;
                    case Step.TriggerType.ObjLight:
                        GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveObjClickListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        GetObjLogic<TriggerLogic>(step.GetStepTriggerObjName.RootName).SetObjHighlight(step.GetStepTriggerObjName.ObjName, false);
                        break;
                    case Step.TriggerType.UI:
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveButtonListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        break;
                    case Step.TriggerType.UIFrame:
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveButtonListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        break;
                    case Step.TriggerType.UILight:
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveButtonListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).SetUIHighlight(step.GetStepTriggerObjName.ObjName, false);
                        break;
                    case Step.TriggerType.UIFrameLight:
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).RemoveButtonListener(step.GetStepTriggerObjName.ObjName, tmpAction);
                        GetUILogic<UITriggerLogic>(step.GetStepTriggerObjName.RootName).SetUIFrameHighlight(step.GetStepTriggerObjName.ObjName, false);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// 进入下一步
        /// </summary>
        public void NextStep()
        {
            StopAllCoroutines();
            StepAutoDestory();
            WaitEndFrameDoFunc(() =>
            {
                step.NextStep();
                StepAutoBuild();
            });
        }

        /// <summary>
        /// 跳入指定步骤
        /// </summary>
        /// <param name="stepNumber">步骤编号</param>
        public void JumpStep(StepManager.StepID stepNumber)
        {
            StopAllCoroutines();
            StepAutoDestory();
            WaitEndFrameDoFunc( () =>
            {
                step.JumpStep(stepNumber);
                StepAutoBuild();
            });
            
        }

        /// <summary>
        /// 延时指定时间后执行方法
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="func">方法</param>
        protected void WaitTimeDoFunc(float time, UnityAction func)
        {
            StartCoroutine(WaitTime(time, func));
        }

        private IEnumerator WaitTime(float time, UnityAction func)
        {
            yield return new WaitForSeconds(time);
            func();
        }

        /// <summary>
        /// 延迟一帧后执行方法
        /// </summary>
        /// <param name="func"></param>
        private void WaitEndFrameDoFunc(UnityAction func) {
            StartCoroutine(WaitEndFrame(func));
        }

        private IEnumerator WaitEndFrame(UnityAction func)
        {
            yield return new WaitForEndOfFrame();
            func();
        }

        #region 获取引用

        /// <summary>
        /// 获取物体
        /// </summary>
        /// <param name="rootName">根物体名字</param>
        /// <param name="objName">物体名字</param>
        /// <returns></returns>
        protected ObjBehaviours GetObjBehaviour(string rootName, string objName) {
            return InjectService.Get<ObjManager>().GetObjBehaviours(rootName, objName);
        }

        /// <summary>
        /// 获取UI
        /// </summary>
        /// <param name="rootName">根物体</param>
        /// <param name="objName">对象名</param>
        /// <returns></returns>
        protected UIBehaviours GetUIBehaviour(string rootName, string objName) {
            return InjectService.Get<UIManager>().GetUIBehaviours(rootName, objName);
        }

        /// <summary>
        /// 获取根节点ObjLogic
        /// </summary>
        /// <param name="rootName">根物体名</param>
        /// <returns></returns>
        protected T GetObjLogic<T>(string rootName)where T:LogicBehaviour 
        {
            if (!InjectService.Get<ObjManager>().GetDataModel<ObjDataModel>(rootName, rootName).GetComponent<T>())
            {
                InjectService.Get<ObjManager>().GetGameObject(rootName, rootName).AddComponent<T>();
            }
            return InjectService.Get<ObjManager>().GetDataModel<ObjDataModel>(rootName, rootName).GetComponent<T>();
        }

        /// <summary>
        /// 获取根节点UILogic
        /// </summary>
        /// <param name="rootName">根物体名</param>
        /// <returns></returns>
        protected T GetUILogic<T>(string rootName) where T : LogicBehaviour
        {
            if (!InjectService.Get<UIManager>().GetUIBehaviours(rootName, rootName).GetComponent<T>())
            {
                InjectService.Get<UIManager>().GetGameObject(rootName, rootName).AddComponent<T>();
            }
            return InjectService.Get<UIManager>().GetUIBehaviours(rootName, rootName).GetComponent<T>();
        }

        #endregion

        /// <summary>
        /// 显示考核提示
        /// </summary>
        /// <param name="triggerType">触发类型</param>
        /// <param name="namePair">对象名</param>
        protected virtual void ShowExamTip(Step.TriggerType triggerType,NamePair namePair) {

        }

        /// <summary>
        /// 隐藏考核提示
        /// </summary>
        /// <param name="triggerType">触发类型</param>
        /// <param name="namePair">对象名</param>
        protected virtual void HideExamTip(Step.TriggerType triggerType,NamePair namePair) {

        }

    }
}

