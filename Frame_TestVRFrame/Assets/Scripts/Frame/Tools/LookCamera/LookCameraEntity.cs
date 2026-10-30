/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LookCameraEntity
* 创建日期：2020-06-09 11:18:58
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine.Events;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class LookCameraEntity : Entity
	{
        /// <summary>
        /// 设置观察相机到目标位置
        /// </summary>
        /// <param name="targetName"></param>
        public void SetLookCamera(string targetName) {
            FireEvent("SetLookCamera", new object[] { targetName});
        }

        /// <summary>
        /// 移动观察相机到目标位置
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="time"></param>
        /// <param name="action"></param>
        public void MoveLookCamera(string targetName, float time) {
            FireEvent("MoveLookCamera", new object[] { targetName, time });
        }

        /// <summary>
        /// 重置观察相机
        /// </summary>
        public void ReSetLookCamera() {
            MethodEvent tmpMethodEvent = new MethodEvent();
            tmpMethodEvent.EventName = "ReSetLookCamera";
            tmpMethodEvent.Argments = new object[0];
            FireEvent(tmpMethodEvent);
        }


    }
}

