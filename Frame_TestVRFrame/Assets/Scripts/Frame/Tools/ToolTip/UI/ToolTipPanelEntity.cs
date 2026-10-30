/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ToolTipPanelEntity
* 创建日期：2020-07-03 17:44:56
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class ToolTipPanelEntity : Entity
	{
        private Vector3 mousePosition;

        /// <summary>
        /// 鼠标坐标
        /// </summary>
        public Vector3 MousePosition {
            get { return mousePosition; }
            set {
                var oldvalue = mousePosition;
                mousePosition = value;
                FireEvent("MousePosition", oldvalue, value);
            }
        }

        private bool isShowTip = false;

        /// <summary>
        /// 是否显示tooltip
        /// </summary>
        public bool IsShowTip {
            get { return isShowTip; }
            set
            {
                var oldvalue = isShowTip;
                isShowTip = value;
                FireEvent("IsShowTip", oldvalue, value);
            }
        }

        private string tipName;

        /// <summary>
        /// 提示文字
        /// </summary>
        public string TipName {
            get { return tipName; }
            set {
                var oldvalue = tipName;
                tipName = value;
                FireEvent("TipName", oldvalue, value);
            }
        }

        private Vector2 widthAndheight;

        public Vector2 WidthAndHeight {
            get { return widthAndheight; }
            set {
                var oldvalue = widthAndheight;
                widthAndheight = value;
                FireEvent("WidthAndHeight", oldvalue, value);
            }
        }


    }
}

