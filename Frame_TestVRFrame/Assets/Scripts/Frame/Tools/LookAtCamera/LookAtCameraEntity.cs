/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LookAtCameraEntity
* 创建日期：2020-06-15 16:09:44
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZhangChen
{
	/// <summary>
    ///
    /// </summary>
	public class LookAtCameraEntity : Entity
	{

        private float mouseScrollWheel = 0f;

        /// <summary>
        /// 鼠标滚轮变化值
        /// </summary>
        public float MouseScrollWheel {
            get { return mouseScrollWheel; }
            set {
                var oldvalue = mouseScrollWheel;
                mouseScrollWheel = value;
                FireEvent("MouseScrollWheel", oldvalue, value);
            }
        }

        private float rotationX = 0f;

        /// <summary>
        /// 相机旋转X值
        /// </summary>
        public float RotationX {
            get { return rotationX; }
            set {
                var oldvalue = rotationX;
                rotationX = value;
                FireEvent("RotationX", oldvalue, value);
            }
        }

        private float rotationY = 0f;

        /// <summary>
        /// 相机旋转Y值
        /// </summary>
        public float RotationY {
            get { return rotationY; }
            set {
                var oldvalue = rotationY;
                rotationY = value;
                FireEvent("RotationY", oldvalue, value);
            }
        }


        private float moveX = 0f;

        /// <summary>
        /// 目标点移动X值
        /// </summary>
        public float MoveX {
            get { return moveX; }
            set {
                var oldvalue = moveX;
                moveX = value;
                FireEvent("MoveX", oldvalue, value);
            }
        }

        private float moveY = 0f;

        /// <summary>
        /// 目标点移动Y值
        /// </summary>
        public float MoveY {
            get { return moveY; }
            set {
                var oldvalue = moveY;
                moveY = value;
                FireEvent("MoveY", oldvalue, value);
            }
        }

        /// <summary>
        /// 重置观察点位置
        /// </summary>
        public void ResetTargetPosition() {
            FireEvent("ResetTargetPosition", new object[] { });
        }

	}
}

