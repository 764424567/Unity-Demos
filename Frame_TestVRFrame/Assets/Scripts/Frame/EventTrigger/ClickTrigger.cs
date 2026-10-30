/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: ClickTrigger.cs
  Author:张辰       Version :1.0          Date: 2017-12-7
  Description:点击事件监听
************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;
using System;

namespace Com.Rainier.ZC_Frame
{
    public class ClickTrigger : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private MouseClickType.MouseInput mouseInput;

        public MouseClickType.MouseInput MouseInput {
            get { return mouseInput; }
            set { mouseInput = value; }
        }

        protected ClickTrigger() { }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (MouseClickType.current.MouseInputJudgment(mouseInput, eventData))
            {
                EventSystem.current.SetSelectedGameObject(this.gameObject);
                Press();
            }
        }

        [FormerlySerializedAs("onMouseClick")]
        [SerializeField]
        private ClickEvent onMouseClick = new ClickEvent();
        
        public ClickEvent OnMouseClick
        {
            get { return onMouseClick; }
            set { onMouseClick = value; }
        }

        private void Press()
        {
            onMouseClick.Invoke();
        }

        [Serializable]
        public class ClickEvent : UnityEvent { }

    }
}

