/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: DragTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:拖拽事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class DragTrigger : MonoBehaviour, IDragHandler
    {
        public virtual void OnDrag(PointerEventData eventData)
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

        protected DragTrigger() { }

        [FormerlySerializedAs("onMouseDrag")]
        [SerializeField]
        private DragEvent onMouseDrag = new DragEvent();

        public DragEvent OnMouseDrag
        {
            get { return onMouseDrag; }
            set { onMouseDrag = value; }
        }

        private void Press()
        {
            onMouseDrag.Invoke();
        }

        [Serializable]
        public class DragEvent : UnityEvent { }
    }
}


