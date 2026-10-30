/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： RePlayEntity
* 创建日期：2021-04-19 09:18:29
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：回放系统播放器
******************************************************************************/

using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class RePlayEntity : Entity
	{

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            FireEvent("Play", null);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            FireEvent("Pause", null);
        }
    }
}

