/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UITriggerLogic
* 创建日期：2020-06-02 08:50:50
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class UITriggerLogic : MVVMLogicBase 
	{
        /// <summary>
        /// button事件暂存
        /// </summary>
        private List<UnityAction> buttonActions = new List<UnityAction>();

        /// <summary>
        /// 点击事件暂存
        /// </summary>
        private List<UnityAction> clickActions = new List<UnityAction>();

        protected override void Awake()
        {
            base.Awake();
            AddEntity<UITriggerEntity>();
        }

        #region Button相关
        /// <summary>
        /// 添加Button点击监听（自动高亮，点击后自动取消高亮并移除监听）
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        /// <returns></returns>
        public UnityAction AddButtonListenerATLight(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                SetUIHighlight(objName, true);
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(() => {
                    action.Invoke();
                    SetUIHighlight(objName, false);
                    buttonActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveButtonListener(OnTriggerClick);
                });
                buttonActions.Add(onTriggerClick);
                tmpBehaviour.AddButtonListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加Button点击监听（UI框自动高亮，点击后自动取消高亮并移除监听）
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public UnityAction AddButtonListenerFrameATLight(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                SetUIFrameHighlight(objName, true);
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(()=> {
                    action.Invoke();
                    SetUIFrameHighlight(objName, false);
                    buttonActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveButtonListener(OnTriggerClick);
                });
                buttonActions.Add(onTriggerClick);
                tmpBehaviour.AddButtonListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加Button点击监听（点击后自动移除监听）
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public UnityAction AddButtonListenerAT(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(() => {
                    action.Invoke();
                    buttonActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveButtonListener(OnTriggerClick);
                });
                buttonActions.Add(onTriggerClick);
                tmpBehaviour.AddButtonListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加Button点击监听
        /// </summary>
        /// <param name="objName">需要加监听的对象名</param>
        /// <param name="action">执行的方法</param>
        public UnityAction AddButtonListener(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                buttonActions.Add(action);
                tmpBehaviour.AddButtonListener(OnTriggerClick);
                return action;
            }
            return null;
        }

        /// <summary>
        /// 移除Button指定点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public void RemoveButtonListener(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveButtonListener(OnTriggerClick);
                buttonActions.Remove(action);
            }
        }

        /// <summary>
        /// 移除Button所有点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        public void RemoveButtonListener(string objName)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveButtonListener();
                buttonActions.Clear();
            }
        }

        #endregion

        /// <summary>
        /// 添加Click监听（点击后自动移除监听）
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public UnityAction AddClickListenerAT(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(() => {
                    action.Invoke();
                    clickActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveClickListener(OnTriggerClick);
                });
                clickActions.Add(onTriggerClick);
                tmpBehaviour.AddClickListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加Click监听
        /// </summary>
        /// <param name="objName">需要加监听的对象名</param>
        /// <param name="action">执行的方法</param>
        public UnityAction AddClickListener(string objName,UnityAction action) {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                clickActions.Add(action);
                tmpBehaviour.AddClickListener(OnTriggerClick);
                return action;
            }
            return null;
        }

        /// <summary>
        /// 移除Click点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public void RemoveClickListener(string objName, UnityAction action)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveClickListener(action);
                clickActions.Remove(action);
            }
        }

        /// <summary>
        /// 移除Click点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        public void RemoveClickListener(string objName)
        {
            UIBehaviours tmpBehaviour = GetUIBehaviours(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveClickListener();
                clickActions.Clear();
            }
        }

        /// <summary>
        /// 触发了点击事件
        /// </summary>
        private void OnTriggerClick() {
            GetEntity<UITriggerEntity>().OnTriggerClick++;
        }

        /// <summary>
        /// 设置UI高亮
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="isLight">是否高亮</param>
        public void SetUIHighlight(string objName, bool isLight)
        {
            GetEntity<UITriggerEntity>().SetUIHighlight(objName, isLight);
        }

        /// <summary>
        /// 设置UI框高亮
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="isLight">是否高亮</param>
        public void SetUIFrameHighlight(string objName, bool isLight)
        {
            GetEntity<UITriggerEntity>().SetUIFrameHighlight(objName, isLight);
        }


        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、Diable事件、有Destroy事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable") || evt.EventName.Equals("OnDestroy")) return;

            //检测到Button触发事件
            if (evt.EventName.Equals("OnTriggerClick"))
            {
                for (int i = 0; i < buttonActions.Count; i++)
                {
                    buttonActions[i].Invoke();
                }
            }

            //检测到高亮逻辑
            if (evt is MethodEvent)
            {
                if (evt.EventName.Equals("SetUIHighlight"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string objName = (string)data[0];
                    bool isLight = (bool)data[1];
                    GetUIBehaviours(objName).SetUIHighlight(isLight);
                }
                if (evt.EventName.Equals("SetUIFrameHighlight"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string objName = (string)data[0];
                    bool isLight = (bool)data[1];
                    GetUIBehaviours(objName).SetUIFrameHighlight(isLight);
                }
            }
        }

    }
}

