/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ToolTipPanelLogic
* 创建日期：2020-07-03 17:28:46
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：ToolTip面板逻辑脚本
******************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;


namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class ToolTipPanelLogic : MVVMLogicBase 
	{
        private Dictionary<NamePair, string> tips;

        private string ToolTipName = "ToolTip";

        private string ToolTipTextName = "ToolTipText";

        private void Start()
        {
            AddEntity<ToolTipPanelEntity>();
        }

        /// <summary>
        /// 初始化ToolTip
        /// </summary>
        /// <param name="tips"></param>
        public void SetToolTip(Dictionary<NamePair, string> tips) {
            this.tips = tips;
        }

        private void OnDestroy()
        {
            RemoveEntity<ToolTipPanelEntity>();
        }


        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            //忽略除ViewModel外其他Entity发出的事件
            //if (!(evt.EventSource is ViewModel))	return;

			//获取事件源
            //ViewModel vm = evt.EventSource as ViewModel;

            if (evt.EventName.Equals("MousePosition"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector3 newValue = (Vector3)propertyEvent.NewValue;
                SetTipPosition(newValue);
            }
            if (evt.EventName.Equals("IsShowTip"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                bool newValue = (bool)propertyEvent.NewValue;
                if (newValue)
                {
                    GetUIBehaviours(ToolTipName).UseRenderer();
                    GetUIBehaviours(ToolTipTextName).UseRenderer();
                }
                else
                {
                    GetUIBehaviours(ToolTipName).UnuseRenderer();
                    GetUIBehaviours(ToolTipTextName).UnuseRenderer();
                }
            }
            if (evt.EventName.Equals("TipName"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                GetViewModel<TextViewModel>(ToolTipTextName).Value = newValue;
            }
            if (evt.EventName.Equals("WidthAndHeight"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector2 newValue = (Vector2)propertyEvent.NewValue;
                GetUIBehaviours(ToolTipName).WidthAndHeight = newValue;
            }
        }

        /// <summary>
        /// 当鼠标进入
        /// </summary>
        /// <param name="obj">对象名</param>
        /// <param name="isEnter">是否进入</param>
        public void OnMouseChoose(GameObject obj,bool isEnter) {
            if (isEnter)
            {
                foreach (KeyValuePair<NamePair,string> item in tips)
                {
                    if (item.Key.ObjName.Equals(obj.name))
                    {
                        GetEntity<ToolTipPanelEntity>().TipName = tips[item.Key];
                        GetEntity<ToolTipPanelEntity>().WidthAndHeight = new Vector2(GetUIBehaviours(ToolTipTextName).Width + 20f, GetUIBehaviours(ToolTipTextName).Height + 10f);
                        GetEntity<ToolTipPanelEntity>().IsShowTip = true;
                        GetEntity<ToolTipPanelEntity>().MousePosition = Input.mousePosition;
                    }
                }
            }
            else
            {
                GetEntity<ToolTipPanelEntity>().TipName = string.Empty;
                GetEntity<ToolTipPanelEntity>().IsShowTip = false;
            }
        }

        /// <summary>
        /// 设置tooltip显示位置
        /// </summary>
        /// <param name="mousePosition"></param>
        private void SetTipPosition(Vector3 mousePosition) {
            if ((mousePosition.y < Screen.height / 4 && mousePosition.x < Screen.width / 2) ||
                    (mousePosition.y < Screen.height / 2 && mousePosition.x < Screen.width / 4))
            {
                GetUIBehaviours(ToolTipName).Position = mousePosition + new Vector3(0, GetUIBehaviours(ToolTipName).Height * GetScreenHeightScale(), 0);
            }
            else if ((mousePosition.y < Screen.height / 4 && mousePosition.x >= Screen.width / 2) ||
                (mousePosition.y < Screen.height / 2 && mousePosition.x >= Screen.width * 3 / 4))
            {
                GetUIBehaviours(ToolTipName).Position = mousePosition + new Vector3(-GetUIBehaviours(ToolTipName).Width * GetScreenWidthScale(), GetUIBehaviours(ToolTipName).Height * GetScreenHeightScale(), 0);
            }
            else if ((mousePosition.y >= Screen.height * 3 / 4 && mousePosition.x >= Screen.width / 2) ||
                (mousePosition.y >= Screen.height / 2 && mousePosition.x >= Screen.width * 3 / 4))
            {
                GetUIBehaviours(ToolTipName).Position = mousePosition + new Vector3(-GetUIBehaviours(ToolTipName).Width * GetScreenWidthScale(), 0, 0);
            }
            else
            {
                GetUIBehaviours(ToolTipName).Position = mousePosition;
            }
        }

        /// <summary>
        /// 获取屏幕高度缩放比例
        /// </summary>
        /// <returns></returns>
        private float GetScreenHeightScale()
        {
            CanvasScaler tmpScaler = transform.parent.GetComponent<CanvasScaler>();
            if (tmpScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                float heightScale = (float)Screen.height / tmpScaler.referenceResolution.y;
                return heightScale;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取屏幕宽缩放比例
        /// </summary>
        /// <returns></returns>
        private float GetScreenWidthScale()
        {
            CanvasScaler tmpScaler = transform.parent.GetComponent<CanvasScaler>();
            if (tmpScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                float widthScale = (float)Screen.width / tmpScaler.referenceResolution.x;
                return widthScale;
            }
            else
            {
                return 1;
            }
        }

    }
}
