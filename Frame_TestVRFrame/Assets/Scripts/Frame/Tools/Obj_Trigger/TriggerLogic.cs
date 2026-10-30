/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TriggerLogic
* 创建日期：2020-05-27 18:33:38
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：3D物体点击逻辑脚本（此脚本需动态挂载）
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class TriggerLogic : ObjLogicBase 
	{
        private List<UnityAction> triggerActions = new List<UnityAction>();

        private void Awake()
        {
            AddEntity<TriggerEntity>();
        }

        private void Start()
        {
            
        }

        /// <summary>
        /// 添加物体点击监听（自动高亮，点击后自动移除高亮、监听）
        /// </summary>
        /// <param name="objName">需要加监听的对象名</param>
        /// <param name="action">执行的方法</param>
        public UnityAction AddObjClickListenerATLight(string objName, UnityAction action)
        {
            ObjBehaviours tmpBehaviour = GetObjBehaviour(objName);
            if (tmpBehaviour != null)
            {
                SetObjHighlight(objName, true);
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(() => {
                    SetObjHighlight(objName, false);
                    action.Invoke();
                    triggerActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveObjClickListener(OnTriggerClick);
                });
                triggerActions.Add(onTriggerClick);
                tmpBehaviour.AddObjClickListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加物体点击监听（点击后自动移除监听）
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public UnityAction AddObjClickListenerAT(string objName, UnityAction action)
        {
            ObjBehaviours tmpBehaviour = GetObjBehaviour(objName);
            if (tmpBehaviour != null)
            {
                UnityAction onTriggerClick = null;
                onTriggerClick = new UnityAction(() => {
                    action.Invoke();
                    triggerActions.Remove(onTriggerClick);
                    tmpBehaviour.RemoveObjClickListener(OnTriggerClick);
                });
                triggerActions.Add(onTriggerClick);
                tmpBehaviour.AddObjClickListener(OnTriggerClick);
                return onTriggerClick;
            }
            return null;
        }

        /// <summary>
        /// 添加物体点击监听
        /// </summary>
        /// <param name="objName">需要加监听的对象名</param>
        /// <param name="action">执行的方法</param>
        public UnityAction AddObjClickListener(string objName, UnityAction action)
        {
            ObjBehaviours tmpBehaviour = GetObjBehaviour(objName);
            if (tmpBehaviour != null)
            {
                triggerActions.Add(action);
                tmpBehaviour.AddObjClickListener(OnTriggerClick);
                return action;
            }
            return null;
        }

        /// <summary>
        /// 移除物体指定点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="action">方法</param>
        public void RemoveObjClickListener(string objName, UnityAction action)
        {
            ObjBehaviours tmpBehaviour = GetObjBehaviour(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveObjClickListener(OnTriggerClick);
                triggerActions.Remove(action);
            }
        }

        /// <summary>
        /// 移除物体所有点击监听
        /// </summary>
        /// <param name="objName">对象名</param>
        public void RemoveObjClickListener(string objName)
        {
            ObjBehaviours tmpBehaviour = GetObjBehaviour(objName);
            if (tmpBehaviour != null)
            {
                tmpBehaviour.RemoveObjClickListener();
                triggerActions.Clear();
            }
        }


        /// <summary>
        /// 设置物体高亮
        /// </summary>
        /// <param name="isLight">是否高亮</param>
        public void SetObjHighlight(string objName, bool isLight)
        {
            GetEntity<TriggerEntity>().SetObjHighlight(objName, isLight);
        }

        /// <summary>
        /// 触发了点击事件
        /// </summary>
        private void OnTriggerClick() {
            GetEntity<TriggerEntity>().OnTriggerClick++;
        }

        public override void ProcessLogic(IEvent evt)
        {
            //检测到点击触发事件
            if (evt.EventName.Equals("OnTriggerClick"))
            {
                for (int i = 0; i < triggerActions.Count; i++)
                {
                    triggerActions[i].Invoke();
                }
            }

            //检测到高亮逻辑
            if (evt is MethodEvent)
            {
                if (evt.EventName.Equals("SetObjHighlight"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string objName = (string)data[0];
                    bool isLight = (bool)data[1];
                    GetObjBehaviour(objName).SetObjHighlight(isLight);
                }
            }
        }

    }
}
