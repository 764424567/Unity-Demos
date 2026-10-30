/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: ExitTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:鼠标离开事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class ExitTrigger : MonoBehaviour, IPointerExitHandler
    {
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            Press();
        }
        protected ExitTrigger() { }

        [FormerlySerializedAs("onMouseExit")]
        [SerializeField]
        private ExitEvent onMouseExit = new ExitEvent();

        public ExitEvent OnMouseExit
        {
            get { return onMouseExit; }
            set { onMouseExit = value; }
        }

        private void Press()
        {
            onMouseExit.Invoke();
        }
        [Serializable]
        public class ExitEvent : UnityEvent { }
    }
}


