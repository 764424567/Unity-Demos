/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： DragObjEntity
* 创建日期：2020-06-17 09:18:48
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class DragObjEntity : Entity
	{
        private Vector3 dragPosition;

        /// <summary>
        /// 拖拽位置
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


        private int downAction;

        /// <summary>
        /// 按下触发
        /// </summary>
        public int DownAction {
            get { return downAction; }
            set {
                var oldvalue = downAction;
                downAction = value;
                FireEvent("DownAction", oldvalue, value);
            }
        }

        private int upAction;

        /// <summary>
        /// 抬起触发
        /// </summary>
        public int UpAction {
            get { return upAction; }
            set {
                var oldvalue = upAction;
                upAction = value;
                FireEvent("UpAction", oldvalue, value);
            }
        }

        private int dragAction;

        /// <summary>
        /// 拖拽触发
        /// </summary>
        public int DragAction {
            get { return dragAction; }
            set {
                var oldvalue = dragAction;
                dragAction = value;
                FireEvent("DragAction", oldvalue, value);
            }
        }
	}
}

