/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: DownTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-7
  Description:按下事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class DownTrigger : MonoBehaviour, IPointerDownHandler
    {
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

        protected DownTrigger() { }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                Press();
            }
        }

        [FormerlySerializedAs("onMouseDown")]
        [SerializeField]
        private DownEvent onMouseDown = new DownEvent();

        public DownEvent OnMouseDown
        {
            get { return onMouseDown; }
            set { onMouseDown = value; }
        }

        private void Press()
        {
            onMouseDown.Invoke();
        }

        [Serializable]
        public class DownEvent : UnityEvent { }
    }
}

