/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TPSEntity
* 创建日期：2020-06-08 11:35:38
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class TPSEntity : Entity
	{
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
        /// 相机旋转速度
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
        public void TPSMove(float moveX, float moveZ)
        {
            FireEvent("TPSMove", new object[] { moveX, moveZ });
        }



        /// <summary>
        /// 相机旋转
        /// </summary>
        /// <param name="rotateX"></param>
        /// <param name="rotateY"></param>
        public void TPSRotate(float rotateX,float rotateY)
        {
            FireEvent("TPSRotate", new object[] { rotateX, rotateY });
        }

        /// <summary>
        /// 移动中
        /// </summary>
        public void OnMoveState() {
            FireEvent("OnMoveState",null);
        }

        /// <summary>
        /// 非移动中
        /// </summary>
        public void OnMoveEnd() {
            FireEvent("OnMoveEnd", null);
        }
    }
}

