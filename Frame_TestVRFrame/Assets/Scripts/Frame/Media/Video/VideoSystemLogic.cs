/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：VideoSystemLogic
* 创建日期：2020-06-04 13:40:30
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：视频播放逻辑（PC版使用MP4格式，webgl版使用OGV格式）视频存放路径为
* StreamingAssets/Video中
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;


namespace Com.Rainier.ZC_Frame
{   

	public class VideoSystemLogic : ObjLogicBase 
	{
        private VideoPanelLogic videoPanel;
        private VideoPlayer videoPlayer;
        private AudioSource audioPlayer;

        private float videoTime = 0f;
        private float videoMaxTime = 0f;
        private bool isVideoPlaying = false;

        private string videoURL;

        private RenderTexture targetTexture;
        [SerializeField]
        private int width = 1920;
        [SerializeField]
        private int height = 1080;
        private int depth = 24;

        //private bool setToUIValue = true;

        ///// <summary>
        ///// 是否同步数据到UI
        ///// </summary>
        //public bool SetToUIValue {
        //    get { return setToUIValue; }
        //    set { setToUIValue = value; }
        //}

        /// <summary>
        /// 是否同步数据到UI
        /// </summary>
        public bool IsSetToUIValue {
            get { return GetEntity<VideoSystemEntity>().IsSetToUIValue; }
            set { GetEntity<VideoSystemEntity>().IsSetToUIValue = value; }
        }

        /// <summary>
        /// 播放用Texture
        /// </summary>
        public RenderTexture videoTexture
        {
            get { return targetTexture; }
        }

        /// <summary>
        /// 视频当前进度
        /// </summary>
        public float VideoTime
        {
            get { return videoTime; }
            set
            {
                if (videoPlayer)
                {
                    videoTime = value;
                    videoPlayer.time = videoTime;
                    PlayOrPause(true);
                }
            }
        }

        /// <summary>
        /// 视频总时长
        /// </summary>
        public float VideoMaxTime
        {
            get { return videoMaxTime; }
        }

        private void Start()
        {
            videoPanel = InjectService.Get<UIManager>().GetGameObject("VideoPanel", "VideoPanel").GetComponent<VideoPanelLogic>();
            AddEntity<VideoSystemEntity>();
#if UNITY_STANDALONE
            videoURL = Application.streamingAssetsPath + "/Video/MP4/";
#elif UNITY_WEBGL
            videoURL = Application.streamingAssetsPath + "/Video/OGV/";
#endif
            audioPlayer = gameObject.AddComponent<AudioSource>();
            audioPlayer.playOnAwake = false;
            targetTexture = new RenderTexture(width, height, depth);
            //Initialize();
        }

        private void Update()
        {
            if (videoPlayer)
            {
                if (videoPlayer.isPlaying)
                {
                    SetVideoTime((float)videoPlayer.time);
                }
            }
            
        }

        private void OnDestroy()
        {
            RemoveEntity<VideoSystemEntity>();
        }

        /// <summary>
        /// 加载视频
        /// </summary>
        /// <param name="videoName"></param>
        public void LoadVideo(string videoName) {
            GetEntity<VideoSystemEntity>().VideoName = videoName;
        }

        /// <summary>
        /// 加载视频后执行回调
        /// </summary>
        /// <param name="videoName">视频名</param>
        /// <param name="callBack">回调</param>
        public void LoadVideo(string videoName,UnityAction callBack)
        {
            SetCallBackAction(callBack);
            GetEntity<VideoSystemEntity>().LoadVideoAndDoCallBack(videoName);
        }

        /// <summary>
        /// 设置视频进度
        /// </summary>
        /// <param name="time"></param>
        private void SetVideoTime(float time) {
            GetEntity<VideoSystemEntity>().VideoTime = time;
        }

        /// <summary>
        /// 播放暂停
        /// </summary>
        /// <param name="isPlay"></param>
        public void PlayOrPause(bool isPlay) {
            GetEntity<VideoSystemEntity>().IsPlay = isPlay;
            videoPanel.GetViewModel<ToggleViewModel>("VideoSwitch").Value = isPlay;
        }

        /// <summary>
        /// 是否同步视频进度
        /// </summary>
        public bool IsSetToObjValue {
            get { return GetEntity<VideoSystemEntity>().IsSetToObjValue; }
            set { GetEntity<VideoSystemEntity>().IsSetToObjValue = value; }
        }

        /// <summary>
        /// 加载视频
        /// </summary>
        /// <param name="videoName"></param>
        /// <returns></returns>
        private IEnumerator Load(string videoName) {
            Initialize();
#if UNITY_STANDALONE
            videoPlayer.url = videoURL + videoName + ".mp4";
#elif UNITY_WEBGL
            videoPlayer.url = videoURL + videoName + ".ogv";
#endif
            targetTexture.Release();
            videoPlayer.Prepare();
            while (!videoPlayer.isPrepared)
            {
                yield return null;
            }
            videoMaxTime = videoPlayer.frameCount / videoPlayer.frameRate;
        }

        /// <summary>
        /// 加载视频,加载完成后执行回调
        /// </summary>
        /// <param name="videoName">视频名字</param>
        /// <param name="callBack">回调</param>
        /// <returns></returns>
        private IEnumerator Load(string videoName,UnityAction callBack)
        {
            Initialize();
#if UNITY_STANDALONE
            videoPlayer.url = videoURL + videoName + ".mp4";
#elif UNITY_WEBGL
            videoPlayer.url = videoURL + videoName + ".ogv";
#endif
            targetTexture.Release();
            videoPlayer.Prepare();
            while (!videoPlayer.isPrepared)
            {
                yield return null;
            }
            videoMaxTime = videoPlayer.frameCount / videoPlayer.frameRate;
            if (callBack != null)
            {
                callBack.Invoke();
            }
        }


        /// <summary>
        /// 初始化video
        /// </summary>
        private void Initialize() {
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.source = VideoSource.Url;
            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.SetTargetAudioSource(0, audioPlayer);
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.controlledAudioTrackCount = 1;
            videoPlayer.targetTexture = targetTexture;
            videoPlayer.loopPointReached += OnVideoPlayingDone;
        }

        /// <summary>
        /// 当视频播放完成
        /// </summary>
        /// <param name="videoPlayer"></param>
        private void OnVideoPlayingDone(VideoPlayer videoPlayer) {
            videoPlayer.time = 0;
            PlayOrPause(false);
        }

        /// <summary>
        /// 销毁视频
        /// </summary>
        public void DestoryVideo() {
            if (videoPlayer)
            {
                targetTexture.Release();
                DestroyImmediate(videoPlayer);
            }
        }

        public override void ProcessLogic(IEvent evt)
        {
            //加载视频
            if (evt.EventName.Equals("VideoName")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                var newValue = propertyEvent.NewValue;
                PlayOrPause(false);
                videoPanel.GetViewModel<SliderViewModel>("VideoValue").Value = 0;
                DestoryVideo();
                StartCoroutine(Load((string)newValue));
            }
            //播放暂停
            if (evt.EventName.Equals("IsPlay")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                bool newValue = (bool)propertyEvent.NewValue;
                if (videoPlayer)
                {
                    if (newValue)
                    {
                        videoPlayer.Play();
                        audioPlayer.Play();
                    }
                    else
                    {
                        videoPlayer.Pause();
                        audioPlayer.Pause();
                    }
                }
                
            }
            //播放进度
            if (evt.EventName.Equals("VideoTime")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                if (videoPlayer)
                {
                    if (IsSetToUIValue)
                    {
                        videoPanel.GetViewModel<SliderViewModel>("VideoValue").Value = newValue / VideoMaxTime;
                    }
                }
            }

            if (evt.EventName.Equals("LoadVideoAndDoCallBack"))
            {
                MethodEvent mthodEvent = evt as MethodEvent;
                object[] data = mthodEvent.Argments;
                string videoName = (string)data[0];
                PlayOrPause(false);
                videoPanel.GetViewModel<SliderViewModel>("VideoValue").Value = 0;
                DestoryVideo();
                StartCoroutine(Load(videoName,GetCallBackAction()));
            }
        }
    }
}
