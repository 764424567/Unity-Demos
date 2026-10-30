/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： FPSEntity
* 创建日期：2020-06-05 13:25:47
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine.Events;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    ///
    /// </summary>
    public class FPSEntity : Entity
    {
        private float rotationX = 0f;

        /// <summary>
        /// X轴旋转值
        /// </summary>
        public float RotationX{
            get { return rotationX; }
            set {
                var oldvalue = rotationX;
                rotationX = value;
                FireEvent("RotationX", oldvalue, value);
            }
        }

        private float rotationY = 0f;

        /// <summary>
        /// Y轴旋转值
        /// </summary>
        public float RotationY {
            get { return rotationY; }
            set {
                var oldvalue = rotationY;
                rotationY = value;
                FireEvent("RotationY", oldvalue, value);
            }
        }

        private float fov = 60f;

        /// <summary>
        /// 视野范围
        /// </summary>
        public float Fov {
            get { return fov; }
            set {
                var oldvalue = fov;
                fov = value;
                FireEvent("Fov", oldvalue, value);
            }
        }

        private float moveSpeed = 5f;

        /// <summary>
        /// 移动速度
        /// </summary>
        public float MoveSpeed {
            get { return moveSpeed; }
            set {
                var oldvalue = moveSpeed;
                moveSpeed = value;
                FireEvent("MoveSpeed", oldvalue, value);
            }
        }

        private float rotateSpeed = 2f;

        /// <summary>
        /// 旋转速度
        /// </summary>
        public float RotateSpeed {
            get { return rotateSpeed; }
            set {
                var oldvalue = rotateSpeed;
                rotateSpeed = value;
                FireEvent("RotateSpeed", oldvalue, value);
            }
        }

        /// <summary>
        /// 人物移动
        /// </summary>
        /// <param name="moveX"></param>
        /// <param name="moveZ"></param>
        public void Move(float moveX,float moveZ)
        {
            FireEvent("Move", new object[] { moveX, moveZ });
        }

        /// <summary>
        /// 移动到目标位置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="time"></param>
        /// <param name="action"></param>
        public void MoveToPos(string target,float time) {
            FireEvent("MoveToPos", new object[] { target, time });
        }

        /// <summary>
        /// 同步到目标位置
        /// </summary>
        /// <param name="target"></param>
        public void SetToPos(string target) {
            FireEvent("SetToPos", new object[] { target });
        }
    }
}

