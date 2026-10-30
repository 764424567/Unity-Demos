/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： AVProEntity
* 创建日期：2020-08-04 18:50:01
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
	public class AVProEntity : Entity
	{
        /// <summary>
        /// 视频URL地址
        /// </summary>
        private string videoUrl;

        /// <summary>
        /// 视频URL地址
        /// </summary>
        public string VideoUrl {
            get { return videoUrl; }
            set {
                var oldvalue = videoUrl;
                videoUrl = value;
                FireEvent("VideoUrl", oldvalue, value);
            }
        }

        /// <summary>
        /// 视频名称
        /// </summary>
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

        /// <summary>
        /// 按下进度条
        /// </summary>
        private int sliderDown = 0;

        /// <summary>
        /// 按下进度条
        /// </summary>
        public int SliderDown {
            get { return sliderDown; }
            set {
                var oldvalue = sliderDown;
                sliderDown = value;
                FireEvent("SliderDown", oldvalue, value);
            }
        }

        /// <summary>
        /// 抬起进度条
        /// </summary>
        private int sliderUp = 0;

        /// <summary>
        /// 抬起进度条
        /// </summary>
        public int SliderUp
        {
            get { return sliderUp; }
            set
            {
                var oldvalue = sliderUp;
                sliderUp = value;
                FireEvent("SliderUp", oldvalue, value);
            }
        }
    }
}

