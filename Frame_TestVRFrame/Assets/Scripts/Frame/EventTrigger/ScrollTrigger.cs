/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: ScrollTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:鼠标滚轮滚动事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class ScrollTrigger : MonoBehaviour, IScrollHandler
    {
        public virtual void OnScroll(PointerEventData eventData)
        {
            Press();
        }

        protected ScrollTrigger() { }

        [FormerlySerializedAs("onMouseScroll")]
        [SerializeField]
        private ScrollEvent onMouseScroll = new ScrollEvent();

        public ScrollEvent OnMouseScroll
        {
            get { return onMouseScroll; }
            set { onMouseScroll = value; }
        }

        private void Press()
        {
            onMouseScroll.Invoke();
        }

        [Serializable]
        public class ScrollEvent : UnityEvent { }
    }
}


