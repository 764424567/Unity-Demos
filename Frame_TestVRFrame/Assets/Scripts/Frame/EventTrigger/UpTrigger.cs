/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: UpTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-7
  Description:抬起事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class UpTrigger : MonoBehaviour,IPointerUpHandler
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

        protected UpTrigger() { }

        [FormerlySerializedAs("onMouseUp")]
        [SerializeField]
        private UpEvent onMouseUp = new UpEvent();

        public UpEvent OnMouseUp
        {
            get { return onMouseUp; }
            set { onMouseUp = value; }
        }

        private void Press()
        {
            onMouseUp.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                Press();
            }
        }

        [Serializable]
        public class UpEvent : UnityEvent { }
    }


}



