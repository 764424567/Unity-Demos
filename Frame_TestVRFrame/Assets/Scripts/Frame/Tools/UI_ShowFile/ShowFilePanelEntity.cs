/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ShowFilePanelEntity
* 创建日期：2021-09-06 09:54:48
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
	public class ShowFilePanelEntity : Entity
	{
        private float scaleValue;

        /// <summary>
        /// 缩放比例
        /// </summary>
        public float ScaleValue
        {
            get { return scaleValue; }
            set
            {
                var oldvalue = scaleValue;
                scaleValue = value;
                FireEvent("ScaleValue", oldvalue, value);
            }
        }

        private Vector2 dragPosition;

        /// <summary>
        /// 拖拽位置
        /// </summary>
        public Vector2 DragPosition {
            get { return dragPosition; }
            set
            {
                var oldvalue = dragPosition;
                dragPosition = value;
                FireEvent("DragPosition", oldvalue, value);
            }
        }

        private Vector2 mousePosition;

        /// <summary>
        /// 鼠标位置
        /// </summary>
        public Vector2 MousePosition {
            get { return mousePosition; }
            set
            {
                var oldvalue = mousePosition;
                mousePosition = value;
                FireEvent("MousePosition", oldvalue, value);
            }
        }

    }
}

