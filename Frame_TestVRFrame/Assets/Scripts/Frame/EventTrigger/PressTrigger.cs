/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: PressTrigger.cs
  Author:张辰       Version :1.0          Date: 2018-5-30
  Description:按住事件接口
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class PressTrigger : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        private bool isHoldOn = false;

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

        protected PressTrigger() { }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                isHoldOn = true;
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                isHoldOn = false;
            }
        }

        [FormerlySerializedAs("onMouseHoldOn")]
        [SerializeField]
        private PressEvent onMousePress = new PressEvent();

        public PressEvent OnMousePress
        {
            get { return onMousePress; }
            set { onMousePress = value; }
        }

        private void Press()
        {
            onMousePress.Invoke();
        }

        private void Update()
        {
            if (isHoldOn)
            {
                Press();
            }
        }

        

        [Serializable]
        public class PressEvent : UnityEvent { }
    }
}


