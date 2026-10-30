/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： AudioSystemEntity
* 创建日期：2020-06-02 15:44:25
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：音频控制
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class AudioSystemEntity : Entity 
	{

        //[FireInitEvent]
        private bool isPlay = true;

        //[FireInitEvent]
        private float volume = 1f;

        //[FireInitEvent]
        private bool isLoop = false;

        private int stop = 0;

        private string audioName;

        /// <summary>
        /// 播放暂停
        /// </summary>
        public bool IsPlay {
            get { return isPlay; }
            set {
                var oldvalue = isPlay;
                isPlay = value;
                FireEvent("IsPlay", oldvalue, value);
            }
        }

        /// <summary>
        /// 音量
        /// </summary>
        public float Volume {
            get { return volume; }
            set {
                var oldvalue = volume;
                volume = value;
                FireEvent("Volume", oldvalue, value);
            }
        }

        /// <summary>
        /// 是否循环
        /// </summary>
        public bool IsLoop {
            get { return isLoop; }
            set {
                var oldvalue = isLoop;
                isLoop = value;
                FireEvent("IsLoop", oldvalue, value);
            }
        }

        /// <summary>
        /// 停止音频
        /// </summary>
        public int Stop
        {
            get { return stop; }
            set
            {
                var oldvalue = stop;
                stop = value;
                FireEvent("Stop", oldvalue, value);
            }
        }

        /// <summary>
        /// 音频名字
        /// </summary>
        public string AudioName {
            get { return audioName; }
            set {
                var oldvalue = audioName;
                audioName = value;
                FireEvent("AudioName", oldvalue, value);
            }
        }
		
	}
}

