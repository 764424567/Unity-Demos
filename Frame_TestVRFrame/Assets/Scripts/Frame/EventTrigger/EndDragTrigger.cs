/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: EndDragTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:结束拖拽事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class EndDragTrigger : MonoBehaviour, IEndDragHandler
    {
        public virtual void OnEndDrag(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                Press();
            }
        }
        [SerializeField]
        private MouseClickType.MouseInput mouseInput;
        /// <summary>
        /// 鼠标点击种类
        /// </summary>
        public MouseClickType.MouseInput MouseInput
        {
            get { return mouseInput; }
            set { mouseInput = value; }
        }

        protected EndDragTrigger() { }

        [FormerlySerializedAs("onMouseEndDrag")]
        [SerializeField]
        private EndDragEvent onMouseEndDrag = new EndDragEvent();

        public EndDragEvent OnMouseEndDrag
        {
            get { return onMouseEndDrag; }
            set { onMouseEndDrag = value; }
        }

        private void Press()
        {
            onMouseEndDrag.Invoke();
        }

        [Serializable]
        public class EndDragEvent : UnityEvent { }
    }
}


