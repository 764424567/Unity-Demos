using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Com.Rainier.ZC_Frame {
    public class UGUIEnhanceItem : EnhanceItem,IDragHandler,IEndDragHandler
    {
        private InfinitelyScrollViewLogic infinitelyScrollViewLogic;
        private Button uButton;
        private Image rawImage;
        public bool IsClick;
        private bool isCanDrag = true;

        /// <summary>
        /// 是否可以拖拽
        /// </summary>
        public bool IsCanDrag {
            get { return isCanDrag; }
            set { isCanDrag = value; }
        }

        protected override void OnStart()
        {
            if (transform.parent.parent.GetComponent<InfinitelyScrollViewLogic>())
            {
                infinitelyScrollViewLogic = transform.parent.parent.GetComponent<InfinitelyScrollViewLogic>();
            }
            rawImage = GetComponent<Image>();
            uButton = GetComponent<Button>();
            uButton.onClick.AddListener(OnClickUGUIButton);
        }

        private void OnClickUGUIButton()
        {
            OnClickEnhanceItem();
        }

        // Set the item "depth" 2d or 3d
        protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
        {
            int newDepth = (int)(depthCurveValue * itemCount);
            this.transform.SetSiblingIndex(newDepth);
        }

        public override void SetSelectState(bool isCenter)
        {
            if (rawImage == null)
                rawImage = GetComponent<Image>();
            // rawImage.color = isCenter ? Color.white : Color.gray;
            if (uButton == null)
                uButton = GetComponent<Button>();
            //image.color = isCenter ? Color.white : Color.gray;
            if (isCenter == false)
            {
                IsClick = false;
                // uButton.interactable = false;
                rawImage.color = Color.gray;
                uButton.enabled = false;
            }
            else if (isCenter == true)
            {
                IsClick = true;
                uButton.enabled = true;
                //  uButton.interactable = true;
                rawImage.color = Color.white;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (infinitelyScrollViewLogic != null && isCanDrag)
                infinitelyScrollViewLogic.OnItemDrag(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (infinitelyScrollViewLogic != null && isCanDrag)
                infinitelyScrollViewLogic.OnItemDragEnd();
        }
    }
}

