using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame {
    public class EnhanceScrollView : MonoBehaviour
    {
        /// <summary>
        /// 图标缩放程度曲线
        /// </summary>
        public AnimationCurve scaleCurve;

        /// <summary>
        /// 图标位移曲线
        /// </summary>
        public AnimationCurve positionCurve;

        /// <summary>
        /// 深度曲线
        /// </summary>
        public AnimationCurve depthCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));

        /// <summary>
        /// 中心图标的下标
        /// </summary>
        public int startCenterIndex = 0;

        /// <summary>
        /// 图标间距
        /// </summary>
        public float cellWidth = 130f;
        private float totalHorizontalWidth = 500.0f;

        /// <summary>
        /// 图标高度
        /// </summary>
        public float yFixedPositionValue = 0.0f;

        /// <summary>
        /// 图标是否可以拖拽
        /// </summary>
        public bool isCanDragItem = true;

        // Lerp duration
        public float lerpDuration = 0.2f;
        private float mCurrentDuration = 0.0f;
        private int mCenterIndex = 0;
        public bool enableLerpTween = true;

        // center and preCentered item
        private EnhanceItem curCenterItem;
        private EnhanceItem preCenterItem;

        // if we can change the target item
        private bool canChangeItem = true;
        private float dFactor = 0.2f;

        // originHorizontalValue Lerp to horizontalTargetValue
        private float originHorizontalValue = 0.1f;
        public float curHorizontalValue = 0.5f;

        // "depth" factor (2d widget depth or 3d Z value)
        private int depthFactor = 5;

        /// <summary>
        /// 图标
        /// </summary>
        private List<EnhanceItem> listEnhanceItems = new List<EnhanceItem>();
        // sort to get right index
        private List<EnhanceItem> listSortedItems = new List<EnhanceItem>();



        private void Awake()
        {
            InitItems();
        }

        /// <summary>
        /// 初始化子图标
        /// </summary>
        private void InitItems()
        {
            int itemCount = transform.childCount;
            for (int i = 0; i < itemCount; i++)
            {
                listEnhanceItems.Add(transform.GetChild(i).GetComponent<UGUIEnhanceItem>());
                transform.GetChild(i).GetComponent<UGUIEnhanceItem>().IsCanDrag = isCanDragItem;
            }
        }

        private void Start()
        {
            canChangeItem = true;
            int count = listEnhanceItems.Count;
            dFactor = (Mathf.RoundToInt((1f / count) * 10000f)) * 0.0001f;
            mCenterIndex = count / 2;
            if (count % 2 == 0)
                mCenterIndex = count / 2 - 1;
            int index = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                listEnhanceItems[i].CurveOffSetIndex = i;
                listEnhanceItems[i].CenterOffSet = dFactor * (mCenterIndex - index);
                listEnhanceItems[i].SetSelectState(false);
                GameObject obj = listEnhanceItems[i].gameObject;

                index++;
            }

            // set the center item with startCenterIndex
            if (startCenterIndex < 0 || startCenterIndex >= count)
            {
                Debug.LogError("## startCenterIndex < 0 || startCenterIndex >= listEnhanceItems.Count  out of index ##");
                startCenterIndex = mCenterIndex;
            }

            // sorted items
            listSortedItems = new List<EnhanceItem>(listEnhanceItems.ToArray());
            totalHorizontalWidth = cellWidth * count;
            curCenterItem = listEnhanceItems[startCenterIndex];
            curHorizontalValue = 0.5f - curCenterItem.CenterOffSet;
            LerpTweenToTarget(0f, curHorizontalValue, false);

        }

        private void LerpTweenToTarget(float originValue, float targetValue, bool needTween = false)
        {
            if (!needTween)
            {
                SortEnhanceItem();
                originHorizontalValue = targetValue;
                UpdateEnhanceScrollView(targetValue);
                this.OnTweenOver();
            }
            else
            {
                originHorizontalValue = originValue;
                curHorizontalValue = targetValue;
                mCurrentDuration = 0.0f;
            }
            enableLerpTween = needTween;
        }

        public void DisableLerpTween()
        {
            this.enableLerpTween = false;
        }

        /// 
        /// Update EnhanceItem state with curve fTime value
        /// 
        public void UpdateEnhanceScrollView(float fValue)
        {
            for (int i = 0; i < listEnhanceItems.Count; i++)
            {
                EnhanceItem itemScript = listEnhanceItems[i];
                float xValue = GetXPosValue(fValue, itemScript.CenterOffSet);
                float scaleValue = GetScaleValue(fValue, itemScript.CenterOffSet);
                float depthCurveValue = depthCurve.Evaluate(fValue + itemScript.CenterOffSet);
                itemScript.UpdateScrollViewItems(xValue, depthCurveValue, depthFactor, listEnhanceItems.Count, yFixedPositionValue, scaleValue);
            }
        }

        private void Update()
        {
            if (enableLerpTween)
                TweenViewToTarget();
        }

        private void TweenViewToTarget()
        {
            mCurrentDuration += Time.deltaTime;
            if (mCurrentDuration > lerpDuration)
                mCurrentDuration = lerpDuration;

            float percent = mCurrentDuration / lerpDuration;
            float value = Mathf.Lerp(originHorizontalValue, curHorizontalValue, percent);
            UpdateEnhanceScrollView(value);
            if (mCurrentDuration >= lerpDuration)
            {
                canChangeItem = true;
                enableLerpTween = false;
                OnTweenOver();
            }
        }

        private void OnTweenOver()
        {
            if (preCenterItem != null)
                preCenterItem.SetSelectState(false);
            if (curCenterItem != null)
                curCenterItem.SetSelectState(true);
        }

        // Get the evaluate value to set item's scale
        private float GetScaleValue(float sliderValue, float added)
        {
            float scaleValue = scaleCurve.Evaluate(sliderValue + added);
            return scaleValue;
        }

        /// <summary>
        /// 根据Position动画曲线的Y值确定图标横坐标位置
        /// </summary>
        /// <param name="sliderValue"></param>
        /// <param name="added"></param>
        /// <returns></returns>
        private float GetXPosValue(float sliderValue, float added)
        {
            float evaluateValue = positionCurve.Evaluate(sliderValue + added) * totalHorizontalWidth;
            return evaluateValue;
        }

        private int GetMoveCurveFactorCount(EnhanceItem preCenterItem, EnhanceItem newCenterItem)
        {
            SortEnhanceItem();
            int factorCount = Mathf.Abs(newCenterItem.RealIndex) - Mathf.Abs(preCenterItem.RealIndex);
            return Mathf.Abs(factorCount);
        }

        // sort item with X so we can know how much distance we need to move the timeLine(curve time line)
        static public int SortPosition(EnhanceItem a, EnhanceItem b) { return a.transform.localPosition.x.CompareTo(b.transform.localPosition.x); }
        private void SortEnhanceItem()
        {
            listSortedItems.Sort(SortPosition);
            for (int i = listSortedItems.Count - 1; i >= 0; i--)
                listSortedItems[i].RealIndex = i;
        }

        public void SetHorizontalTargetItemIndex(EnhanceItem selectItem)
        {
            if (!canChangeItem)
                return;

            if (curCenterItem == selectItem)
                return;

            canChangeItem = false;
            preCenterItem = curCenterItem;
            curCenterItem = selectItem;

            // calculate the direction of moving
            float centerXValue = positionCurve.Evaluate(0.5f) * totalHorizontalWidth;
            bool isRight = false;
            if (selectItem.transform.localPosition.x > centerXValue)
                isRight = true;

            // calculate the offset * dFactor
            int moveIndexCount = GetMoveCurveFactorCount(preCenterItem, selectItem);
            float dvalue = 0.0f;
            if (isRight)
            {
                dvalue = -dFactor * moveIndexCount;
            }
            else
            {
                dvalue = dFactor * moveIndexCount;
            }
            float originValue = curHorizontalValue;
            LerpTweenToTarget(originValue, curHorizontalValue + dvalue, true);
        }

        /// <summary>
        /// 右移按键点击
        /// </summary>
        public void OnBtnRightClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex + 1;
            if (targetIndex > listEnhanceItems.Count - 1)
                targetIndex = 0;
            SetHorizontalTargetItemIndex(listEnhanceItems[targetIndex]);
        }

        /// <summary>
        /// 左移按键点击
        /// </summary>
        public void OnBtnLeftClick()
        {
            if (!canChangeItem)
                return;
            int targetIndex = curCenterItem.CurveOffSetIndex - 1;
            if (targetIndex < 0)
                targetIndex = listEnhanceItems.Count - 1;
            SetHorizontalTargetItemIndex(listEnhanceItems[targetIndex]);
        }

        public float factor = 0.001f;
        
        /// <summary>
        /// 子项拖拽中
        /// </summary>
        /// <param name="delta"></param>
        public void OnDragEnhanceViewMove(Vector2 delta)
        {
            // In developing
            if (Mathf.Abs(delta.x) > 0.0f)
            {
                curHorizontalValue += delta.x * factor;
                LerpTweenToTarget(0.0f, curHorizontalValue, false);
            }
        }

        /// <summary>
        /// 子项拖拽结束
        /// </summary>
        public void OnDragEnhanceViewEnd()
        {
            // find closed item to be centered
            int closestIndex = 0;
            float value = (curHorizontalValue - (int)curHorizontalValue);
            float min = float.MaxValue;
            float tmp = 0.5f * (curHorizontalValue < 0 ? -1 : 1);
            for (int i = 0; i < listEnhanceItems.Count; i++)
            {
                float dis = Mathf.Abs(Mathf.Abs(value) - Mathf.Abs((tmp - listEnhanceItems[i].CenterOffSet)));
                if (dis < min)
                {
                    closestIndex = i;
                    min = dis;
                }
            }
            originHorizontalValue = curHorizontalValue;
            float target = ((int)curHorizontalValue + (tmp - listEnhanceItems[closestIndex].CenterOffSet));
            preCenterItem = curCenterItem;
            curCenterItem = listEnhanceItems[closestIndex];
            LerpTweenToTarget(originHorizontalValue, target, true);
            canChangeItem = false;
        }
    }
}
