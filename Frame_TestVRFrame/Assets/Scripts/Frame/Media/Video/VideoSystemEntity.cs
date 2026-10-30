/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： VideoSystemEntity
* 创建日期：2020-06-04 13:30:26
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：视频播放
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine.Events;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class VideoSystemEntity : Entity
	{
        private string videoName;

        /// <summary>
        /// 视频名称
        /// </summary>
        public string VideoName {
            get { return videoName; }
            set {
                var oldvalue = videoName;
                videoName = value;
                FireEvent("VideoName", oldvalue, value);
            }
        }

        private bool isPlay = false;

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

        private float videoTime = 0f;

        /// <summary>
        /// 视频进度
        /// </summary>
        public float VideoTime {
            get { return videoTime; }
            set {
                var oldvalue = videoTime;
                videoTime = value;
                FireEvent("VideoTime", oldvalue, value);
            }
        }

        private bool isSetToObjValue = false;

        private bool isSetToUIValue = true;

        /// <summary>
        /// 是否同步视频进度
        /// </summary>
        public bool IsSetToObjValue {
            get { return isSetToObjValue; }
            set
            {
                var oldvalue = isSetToObjValue;
                isSetToObjValue = value;
                FireEvent("IsSetToObjValue", oldvalue, value);
            }
        }

        /// <summary>
        /// 是否同步UI进度条
        /// </summary>
        public bool IsSetToUIValue {
            get { return isSetToUIValue; }
            set {
                var oldvalue = isSetToUIValue;
                isSetToUIValue = value;
                FireEvent("IsSetToUIValue", oldvalue, value);
            }
        }

        /// <summary>
        /// 加载视频并执行回调
        /// </summary>
        /// <param name="videoName"></param>
        /// <param name="callBack"></param>
        public void LoadVideoAndDoCallBack(string videoName) {
            FireEvent("LoadVideoAndDoCallBack", new object[] { videoName });
        }
	}
}

