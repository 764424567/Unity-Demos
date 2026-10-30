/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: BeginDragTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:开始拖拽事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class BeginDragTrigger : MonoBehaviour, IBeginDragHandler
    {
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                Press();
            }
        }

        [SerializeField]
        private MouseClickType.MouseInput mouseInput;

        public MouseClickType.MouseInput MouseInput
        {
            get { return mouseInput; }
            set { mouseInput = value; }
        }

        protected BeginDragTrigger() { }

        [FormerlySerializedAs("onMouseBeginDrag")]
        [SerializeField]
        private BeginDragEvent onMouseBeginDrag = new BeginDragEvent();

        public BeginDragEvent OnMouseBeginDrag
        {
            get { return onMouseBeginDrag; }
            set { onMouseBeginDrag = value; }
        }

        private void Press()
        {
            onMouseBeginDrag.Invoke();
        }

        [Serializable]
        public class BeginDragEvent : UnityEvent { }
    }
}


