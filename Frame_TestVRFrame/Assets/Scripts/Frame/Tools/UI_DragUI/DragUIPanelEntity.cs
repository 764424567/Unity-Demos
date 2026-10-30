/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： DragUIPanelEntity
* 创建日期：2021-05-07 09:00:19
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
	public class DragUIPanelEntity : Entity
	{
        private int pointerEnter;

        /// <summary>
        /// 进入触发
        /// </summary>
        public int PointerEnter
        {
            get { return pointerEnter; }
            set
            {
                var oldvalue = pointerEnter;
                pointerEnter = value;
                FireEvent("PointerEnter", oldvalue, value);
            }
        }

        private int pointerExit;

        /// <summary>
        /// 进入触发
        /// </summary>
        public int PointerExit
        {
            get { return pointerExit; }
            set
            {
                var oldvalue = pointerExit;
                pointerExit = value;
                FireEvent("PointerExit", oldvalue, value);
            }
        }

        private int pointerDown;

        /// <summary>
        /// 按下触发
        /// </summary>
        public int PointerDown
        {
            get { return pointerDown; }
            set
            {
                var oldvalue = pointerDown;
                pointerDown = value;
                FireEvent("PointerDown", oldvalue, value);
            }
        }

        private int pointerUp;

        /// <summary>
        /// 抬起触发
        /// </summary>
        public int PointerUp
        {
            get { return pointerUp; }
            set
            {
                var oldvalue = pointerUp;
                pointerUp = value;
                FireEvent("PointerUp", oldvalue, value);
            }
        }

        private int pointerUpInTarget;

        /// <summary>
        /// 在目标上抬起触发
        /// </summary>
        public int PointerUpInTarget
        {
            get { return pointerUpInTarget; }
            set
            {
                var oldvalue = pointerUpInTarget;
                pointerUpInTarget = value;
                FireEvent("PointerUpInTarget", oldvalue, value);
            }
        }

        private int pointerDrag;

        /// <summary>
        /// 按下触发
        /// </summary>
        public int PointerDrag
        {
            get { return pointerDrag; }
            set
            {
                var oldvalue = pointerDrag;
                pointerDrag = value;
                FireEvent("PointerDrag", oldvalue, value);
            }
        }

        private Vector3 dragPosition;

        /// <summary>
        /// 鼠标拖拽位置
        /// </summary>
        public Vector3 DragPosition {
            get { return dragPosition; }
            set
            {
                var oldvalue = dragPosition;
                dragPosition = value;
                FireEvent("DragPosition", oldvalue, value);
            }
        }
    }
}

