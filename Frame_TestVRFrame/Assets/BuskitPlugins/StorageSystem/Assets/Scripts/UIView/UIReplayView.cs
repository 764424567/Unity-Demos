/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UIReplayView
* 创建日期：2019-08-23 14:15:35
* 作者名称：王庚
* 功能描述：场景回放时的UI控制
* 修改记录：
* 描述：
******************************************************************************/

using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 场景回放时的UI控制
    /// </summary>
	public class UIReplayView : UIEventSupprotView, IEventSourceSupportable
    {

        private const float playPauseWidth = 24;
        private const float playPauseHeight = 20;

        private Texture2D playTexture = null;
        private Texture2D pauseTexture = null;

        /// <summary>
        /// 是否在播放
        /// </summary>
        private bool isPlaying = false;

        /// <summary>
        /// 进度
        /// </summary>
        private float _percent = 0;

        public float Percent
        {

            get
            {
                this.FireEvent("Percent", new object[] { this });
                return _percent;
            }
            set
            {
                _percent = value;
            }
        }

        /// <summary>
        /// 播放速度
        /// </summary>
        private int _speed = 0;
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (_speed != value)
                {
                    this.FireEvent("Speed", _speed, value + 1);
                }
                _speed = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            playTexture = Resources.Load<Texture2D>("Buskit3DTexture/PlayIcon");
            pauseTexture = Resources.Load<Texture2D>("Buskit3DTexture/PauseIcon");
        }

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

        //绘制GUI
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(25, Screen.height - 50, Screen.width - 50, 50));
            {

                GUILayout.BeginHorizontal();

                if (!isPlaying)
                {
                    if (GUILayout.Button(playTexture, GUILayout.Width(playPauseWidth), GUILayout.Height(playPauseHeight)))
                    {
                        isPlaying = true;
                        Play();
                    }
                }
                else
                {
                    if (GUILayout.Button(pauseTexture, GUILayout.Width(playPauseWidth), GUILayout.Height(playPauseHeight)))
                    {
                        isPlaying = false;
                        Pause();
                    }
                }

                GUILayout.Space(10);
                GUILayout.BeginVertical();
                {
                    GUILayout.Space(10);
                    GUILayout.HorizontalSlider(Percent, 0f, 1.00f);

                }
                GUILayout.EndVertical();

                GUILayout.Space(10);

                Speed = GUILayout.Toolbar(Speed, new string[] { "1X", "2X", "3X" }, GUILayout.Width(playPauseWidth * 4), GUILayout.Height(playPauseHeight));

                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();

        }
    }
}

