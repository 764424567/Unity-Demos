/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ShowFilePanelLogic
* 创建日期：2021-06-29 09:14:31
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：图片查看功能(未适配回放系统)
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class ShowFilePanelLogic : MVVMLogicBase 
	{
        /// <summary>
        /// 图片资源加载路径
        /// </summary>
        public string loadPath = "Image/ImageFiles/";
        private List<string> fileNames;
        private List<Sprite> files;

        private int index = 0;

        private float tmpX = 0;
        private float tmpY = 0;
        private float scaleX = 0;
        private float scaleY = 0;

        private bool isDrag = false;

        /// <summary>
        /// 鼠标位移差量
        /// </summary>
        private Vector3 tmpPos = Vector3.zero;

        private void Start()
        {
            AddEntity<ShowFilePanelEntity>();
            Initialized();

            GetUIBehaviours("ShowFileContent").AddScrollListener(PlantScale);
            GetUIBehaviours("ShowFileSV").AddBeginDragListener(OnBeginDrag);
            GetUIBehaviours("ShowFileSV").AddEndDragListener(OnEndDrag);
        }

        private void OnDestroy()
        {
            RemoveEntity<ShowFilePanelEntity>();
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        protected virtual void OpenPanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        protected virtual void ClosePanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.zero;
        }

        /// <summary>
        /// 重置状态
        /// </summary>
        private void ResetFile() {
            GetUIBehaviours("ShowFileContent").Scale = Vector3.one;
            GetUIBehaviours("ShowFileContent").Pivot = new Vector2(0.5f, 0.5f);
            GetUIBehaviours("ShowFileContent").LocalPosition = Vector3.zero;
            GetViewModel<SliderViewModel>("ShowFileSlider").Value = 1;
            tmpPos = Vector3.zero;
        }

        /// <summary>
        /// 显示查看器
        /// </summary>
        /// <param name="fileNames"></param>
        public void StartShowFile(List<string> fileNames) {
            this.fileNames = fileNames;
            files = new List<Sprite>();
            for (int i = 0; i < fileNames.Count; i++)
            {
                Sprite sprite = Resources.Load<Sprite>(loadPath + fileNames[i]);
                files.Add(sprite);
            }
            ResetFile();
            GetUIBehaviours("ShowFileImage").ImageSprite = files[index];
            GetUIBehaviours("ShowFileTitle").Text = fileNames[index];
            OpenPanel();
        }

        /// <summary>
        /// 设置关闭界面后回调
        /// </summary>
        /// <param name="callBack"></param>
        public void SetPanelCloseAction(UnityAction callBack) {
            SetCallBackAction(callBack);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialized()
        {
            tmpX = GetUIBehaviours("ShowFileContent").Position.x;
            tmpY = GetUIBehaviours("ShowFileContent").Position.y;
            scaleX = GetUIBehaviours("ShowFileContent").Pivot.x;
            scaleY = GetUIBehaviours("ShowFileContent").Pivot.y;
            
        }

        /// <summary>
        /// 当鼠标移动
        /// </summary>
        /// <param name="mousePosition"></param>
        private void OnMouseMove(Vector2 mousePosition) {
            Vector2 pPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetUIBehaviours("ShowFileContent").GetComponent<RectTransform>(), mousePosition, null, out pPos);
            Vector3 wPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(GetUIBehaviours("ShowFileContent").GetComponent<RectTransform>(), mousePosition, null, out wPos);

            float x = (pPos.x + (GetUIBehaviours("ShowFileContent").Width * GetUIBehaviours("ShowFileContent").Pivot.x)) / GetUIBehaviours("ShowFileContent").Width;
            float y = (pPos.y + (GetUIBehaviours("ShowFileContent").Height * GetUIBehaviours("ShowFileContent").Pivot.y)) / GetUIBehaviours("ShowFileContent").Height;
            scaleX = x;
            scaleY = y;

            tmpX = wPos.x;
            tmpY = wPos.y;
        }

        /// <summary>
        /// 当滑动鼠标滚轮
        /// </summary>
        /// <param name="value"></param>
        private void OnMouseScrollWheelChange(float value) {
            if (value > 0 && GetUIBehaviours("ShowFileContent").Scale.x < 5.09f)
            {
                GetViewModel<SliderViewModel>("ShowFileSlider").Value += 0.1f;
            }
            else if (value < 0 && GetUIBehaviours("ShowFileContent").Scale.x > 1.09f)
            {
                GetViewModel<SliderViewModel>("ShowFileSlider").Value -= 0.1f;
            }
        }



        /// <summary>
        /// 观看大图功能
        /// </summary>
        private void PlantScale()
        {
            GetEntity<ShowFilePanelEntity>().MousePosition = Input.mousePosition;
            GetEntity<ShowFilePanelEntity>().ScaleValue = Input.GetAxis("Mouse ScrollWheel");
        }

        private void OnBeginDrag() {
            isDrag = true;
        }

        private void OnEndDrag() {
            isDrag = false;
        }

        private void Update()
        {
            if (GetUIBehaviours("ShowFileContent").Scale == Vector3.one)
            {
                GetUIBehaviours("ShowFileContent").Pivot = new Vector2(0.5f, 0.5f);
                GetUIBehaviours("ShowFileContent").LocalPosition = Vector3.zero;
                return;
            }
            if (!isDrag)
            {
                GetUIBehaviours("ShowFileContent").Position = Vector3.Lerp(GetUIBehaviours("ShowFileContent").Position, new Vector3(tmpX, tmpY, 0), 0.2f);
                GetUIBehaviours("ShowFileContent").Pivot = Vector2.Lerp(GetUIBehaviours("ShowFileContent").Pivot, new Vector2(scaleX, scaleY), 0.2f);
            }
            else
            {
                tmpX = GetUIBehaviours("ShowFileContent").Position.x;
                tmpY = GetUIBehaviours("ShowFileContent").Position.y;
            }
            
        }

        /// <summary>
        /// 向左键点击
        /// </summary>
        private void OnLeftButtonClick() {
            if (index>0)
            {
                index--;
                ResetFile();
                GetUIBehaviours("ShowFileImage").ImageSprite = files[index];
                GetUIBehaviours("ShowFileTitle").Text = fileNames[index];
            }
        }

        /// <summary>
        /// 向右键点击
        /// </summary>
        private void OnRightButtonClick() {
            if (fileNames != null)
            {
                if (index < fileNames.Count-1)
                {
                    index++;
                    ResetFile();
                    GetUIBehaviours("ShowFileImage").ImageSprite = files[index];
                    GetUIBehaviours("ShowFileTitle").Text = fileNames[index];
                }
            }
            
        }

        /// <summary>
        /// 关闭键点击
        /// </summary>
        private void OnCloseButtonClick() {
            ResetFile();
            GetUIBehaviours("ShowFileImage").ImageSprite = null;
            ClosePanel();
            GetUIBehaviours("ShowFileTitle").Text = string.Empty;
            fileNames = null;
            files = null;
            index = 0;
            InvokeCallBackAction();
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            if (evt.EventSource is ViewModel)
            {
                ViewModel vm = evt.EventSource as ViewModel;
                if (vm.name.Equals("ShowFileSlider")) //控制缩放滑动条
                {
                    SliderViewModel slider = vm as SliderViewModel;
                    GetUIBehaviours("ShowFileContent").Scale = Vector3.one * slider.Value;
                }
                else if (vm.name.Equals("ShowFileLeftButton"))  //向左
                {
                    OnLeftButtonClick();
                }
                else if (vm.name.Equals("ShowFileRightButton"))  //向右
                {
                    OnRightButtonClick();
                }
                else if (vm.name.Equals("ShowFileCloseButton"))//关闭键
                {
                    OnCloseButtonClick();
                }
            }

            if (evt.EventName.Equals("ScaleValue"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                OnMouseScrollWheelChange(newValue);
            }
            else if (evt.EventName.Equals("DragPosition"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector2 newValue = (Vector2)propertyEvent.NewValue;

            }
            else if (evt.EventName.Equals("MousePosition"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector2 newValue = (Vector2)propertyEvent.NewValue;
                OnMouseMove(newValue);
            }

        }
    }
}
