/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: EnterTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:鼠标进入事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class EnterTrigger : MonoBehaviour,IPointerEnterHandler
    {
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            Press();
        }
        protected EnterTrigger() { }

        [FormerlySerializedAs("onMouseEnter")]
        [SerializeField]
        private EnterEvent onMouseEnter = new EnterEvent();

        public EnterEvent OnMouseEnter
        {
            get { return onMouseEnter; }
            set { onMouseEnter = value; }
        }

        private void Press()
        {
            onMouseEnter.Invoke();
        }

        [Serializable]
        public class EnterEvent : UnityEvent { }
    }
}

