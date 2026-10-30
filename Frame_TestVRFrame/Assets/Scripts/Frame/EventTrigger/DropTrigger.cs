/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: DropTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-8
  Description:结束拖拽事件监听(拖拽结束后鼠标如果停留在物体
  中才会被调用)
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class DropTrigger : MonoBehaviour,IDropHandler
    {
        public virtual void OnDrop(PointerEventData eventData)
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

        protected DropTrigger() { }

        [FormerlySerializedAs("onMouseDrop")]
        [SerializeField]
        private DropEvent onMouseDrop = new DropEvent();

        public DropEvent OnMouseDrop
        {
            get { return onMouseDrop; }
            set { onMouseDrop = value; }
        }

        private void Press()
        {
            onMouseDrop.Invoke();
        }

        [Serializable]
        public class DropEvent : UnityEvent { }
    }
}

