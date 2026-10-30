/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：AVProLogic
* 创建日期：2020-08-04 18:50:30
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：视频播放器
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;
using RenderHeads.Media.AVProVideo;


namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class AVProLogic : MVVMLogicBase 
	{
        public Sprite fullScreenSprite1;
        public Sprite fullScreenSprite2;
        public Sprite smallScreenSprite1;
        public Sprite smallScreenSprite2;

        /// <summary>
        /// 当前播放视频的player
        /// </summary>
        private MediaPlayer playingPlayer;

        /// <summary>
        /// UI显示界面
        /// </summary>
        private DisplayUGUI display;

        /// <summary>
        /// 缓冲条
        /// </summary>
        private RectTransform bufferSilder;

        private Image bufferSilderImage;

        /// <summary>
        /// 视频进度
        /// </summary>
        private float videoValue;

        /// <summary>
        /// 是否播放完成
        /// </summary>
        private bool isPlayingDone = false;

        /// <summary>
        /// 是否正在播放
        /// </summary>
        private bool isPlaying;

        /// <summary>
        /// 视频路径
        /// </summary>
        private string videoPath;

        /// <summary>
        /// 是否是全屏
        /// </summary>
        private bool isFullScreen = false;

        /// <summary>
        /// 子物体下标
        /// </summary>
        private int childNumber;

        /// <summary>
        /// 初始宽高
        /// </summary>
        private Vector2 orgWAndH;

        /// <summary>
        /// 是否自动播放
        /// </summary>
        private bool isAutoPlayVideo = false;

        /// <summary>
        /// 是否准备好播放
        /// </summary>
        private bool isReadyToPlay = false;

        private void Start()
        {
            AddEntity<AVProEntity>();
            bufferSilder = GetGameObject("VideoValueBufferFill").GetComponent<RectTransform>();
            if (bufferSilder != null)
            {
                bufferSilderImage = bufferSilder.GetComponent<Image>();
            }
            GetUIBehaviours("VideoValue").AddDownTriggerListener(OnBeginDrag);
            GetUIBehaviours("VideoValue").AddUpTriggerListener(OnEndDrag);
            GetUIBehaviours("VideoPlay").SetActive(true);
            GetUIBehaviours("VideoPause").SetActive(false);
            orgWAndH = GetUIBehaviours("AVProBG").WidthAndHeight;
            childNumber = GetUIBehaviours(name).ChildNumber;
#if UNITY_STANDALONE
            videoPath = Application.streamingAssetsPath + "/Video/MP4/";
#elif UNITY_WEBGL
            videoPath = Application.streamingAssetsPath + "/Video/OGV/";
#elif  UNITY_ANDROID || UNITY_IOS
            videoPath = Application.streamingAssetsPath + "/Video/MP4/";
#endif
        }

        private void Update()
        {
            if (isReadyToPlay)
            {
                float time = playingPlayer.Control.GetCurrentTimeMs();

                float duration = playingPlayer.Info.GetDurationMs();
                float d = Mathf.Clamp(time / duration, 0.0f, 1.0f);
                GetUIBehaviours("VideoDoneTime").Text = ShowTime(time); //当前播放进度
                GetUIBehaviours("VideoLastTime").Text = ShowTime(duration);//视频总时长
                // Debug.Log(string.Format("time: {0}, duration: {1}, d: {2}", time, duration, d));

                videoValue = d;
                if (!isPlaying)
                {
                    GetViewModel<SliderViewModel>("VideoValue").Value = d;
                }

                if (bufferSilder != null)
                {
                    if (playingPlayer.Control.IsBuffering())
                    {
                        float t1 = 0f;
                        float t2 = playingPlayer.Control.GetBufferingProgress();
                        if (t2 <= 0f)
                        {
                            if (playingPlayer.Control.GetBufferedTimeRangeCount() > 0)
                            {
                                playingPlayer.Control.GetBufferedTimeRange(0, ref t1, ref t2);
                                t1 /= playingPlayer.Info.GetDurationMs();
                                t2 /= playingPlayer.Info.GetDurationMs();
                            }
                        }

                        Vector2 anchorMin = Vector2.zero;
                        Vector2 anchorMax = Vector2.one;

                        if (bufferSilderImage != null &&
                            bufferSilderImage.type == Image.Type.Filled)
                        {
                            bufferSilderImage.fillAmount = d;
                        }
                        else
                        {
                            anchorMin[0] = t1;
                            anchorMax[0] = t2;
                        }

                        bufferSilder.anchorMin = anchorMin;
                        bufferSilder.anchorMax = anchorMax;
                    }
                }
            }
        }

        private void OnDestroy()
        {
            RemoveEntity<AVProEntity>();
        }

        /// <summary>
        /// 打开播放视频界面
        /// </summary>
        protected virtual void OpenVideoPanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;
            SetVideoFullScreen(false);
        }

        /// <summary>
        /// 关闭播放视频界面
        /// </summary>
        protected virtual void CloseVideoPanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.zero;
        }

        /// <summary>
        /// 播放网络视频
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="isAutoPlay">是否自动开始播放</param>
        public void PlayVideoUseWeb(string url,bool isAutoPlay = true) {
            isAutoPlayVideo = isAutoPlay;
            GetEntity<AVProEntity>().VideoUrl = url;
        }

        /// <summary>
        /// 播放本地视频（默认streamingasset下）
        /// </summary>
        /// <param name="videoName">视频名字</param>
        /// <param name="isAutoPlay">是否自动开始播放</param>
        public void PlayVideoUseLocal(string videoName , bool isAutoPlay = true) {
            isAutoPlayVideo = isAutoPlay;
            GetEntity<AVProEntity>().VideoName = videoName;
        }

        /// <summary>
        /// 设置关闭界面后的回调
        /// </summary>
        /// <param name="onEndAction"></param>
        public void SetEndAction(UnityAction onEndAction) {
            SetCallBackAction(onEndAction);
        }

        private void OnBeginDrag() {
            GetEntity<AVProEntity>().SliderDown++;
        }

        private void OnEndDrag() {
            GetEntity<AVProEntity>().SliderUp++;
        }

        /// <summary>
        /// 播放网络视频
        /// </summary>
        /// <param name="url"></param>
        private void PlayWebVideo(string url)
        {
            if (playingPlayer)
            {
                DestroyImmediate(playingPlayer.gameObject);
            }

            GameObject mediaPlayer = new GameObject("MediaPlayer");
            playingPlayer = mediaPlayer.AddComponent<MediaPlayer>();
            playingPlayer.m_AutoOpen = false;
            playingPlayer.m_AutoStart = false;
            playingPlayer.Events.AddListener(OnVideoEvent);
            GetGameObject("VideoDisplay").GetComponent<DisplayUGUI>().CurrentMediaPlayer = playingPlayer;
            playingPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, url, isAutoPlayVideo);

            if (isAutoPlayVideo)
            {
                GetUIBehaviours("VideoPlay").SetActive(false);
                GetUIBehaviours("VideoPause").SetActive(true);
            }
            else
            {
                GetUIBehaviours("VideoPlay").SetActive(true);
                GetUIBehaviours("VideoPause").SetActive(false);
            }

            OpenVideoPanel();
        }

        /// <summary>
        /// 播放streamingAssets视频
        /// </summary>
        /// <param name="name"></param>
        private void PlayLocalVideo(string name)
        {
            string path;
#if UNITY_STANDALONE
            path = videoPath + name + ".mp4";
#elif UNITY_WEBGL
            path = videoPath + name + ".ogv";
#elif UNITY_ANDROID || UNITY_IOS
            path = videoPath + name + ".mp4";
#endif
            if (playingPlayer)
            {
                DestroyImmediate(playingPlayer.gameObject);
            }

            GameObject mediaPlayer = new GameObject("MediaPlayer");
            playingPlayer = mediaPlayer.AddComponent<MediaPlayer>();
            playingPlayer.m_AutoOpen = false;
            playingPlayer.m_AutoStart = false;
            playingPlayer.Events.AddListener(OnVideoEvent);
            GetGameObject("VideoDisplay").GetComponent<DisplayUGUI>().CurrentMediaPlayer = playingPlayer;
            playingPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, path, isAutoPlayVideo);

            if (isAutoPlayVideo)
            {
                GetUIBehaviours("VideoPlay").SetActive(false);
                GetUIBehaviours("VideoPause").SetActive(true);
            }
            else
            {
                GetUIBehaviours("VideoPlay").SetActive(true);
                GetUIBehaviours("VideoPause").SetActive(false);
            }

            OpenVideoPanel();
        }

        /// <summary>
        /// 销毁视频播放组件
        /// </summary>
        private void DestoryVideo() {
            if (playingPlayer)
            {
                isReadyToPlay = false;
                GetGameObject("VideoDisplay").GetComponent<DisplayUGUI>().CurrentMediaPlayer = null;
                Destroy(playingPlayer.gameObject);
            }
        }

        /// <summary>
        /// 播放按键
        /// </summary>
        private void OnPlayButton()
        {
            if (playingPlayer)
            {
                if (!isPlayingDone)
                {
                    GetUIBehaviours("VideoPlay").SetActive(false);
                    GetUIBehaviours("VideoPause").SetActive(true);
                    playingPlayer.Control.Play();
                }
                else
                {
                    isPlayingDone = false;
                    GetUIBehaviours("VideoPlay").SetActive(false);
                    GetUIBehaviours("VideoPause").SetActive(true);
                    playingPlayer.Control.Rewind();
                    playingPlayer.Control.Play();
                }
            }
        }

        /// <summary>
        /// 暂停按键
        /// </summary>
        private void OnPauseButton()
        {
            if (playingPlayer)
            {
                GetUIBehaviours("VideoPlay").SetActive(true);
                GetUIBehaviours("VideoPause").SetActive(false);
                playingPlayer.Control.Pause();
            }
        }

        /// <summary>
        /// 进度条监听
        /// </summary>
        private void OnVideoSeekSlider(float value)
        {
            if (playingPlayer && value != videoValue)
            {
                playingPlayer.Control.Seek(value * playingPlayer.Info.GetDurationMs());
            }
        }

        /// <summary>
        /// 开始拖拽进度条
        /// </summary>
        private void OnVideoSliderDown()
        {
            if (playingPlayer)
            {
                isPlaying = playingPlayer.Control.IsPlaying();
                if (isPlaying)
                {
                    playingPlayer.Control.Pause();
                }
                OnVideoSeekSlider(GetUIBehaviours("VideoValue"). SliderValue);
            }
        }

        /// <summary>
        /// 结束拖拽进度条
        /// </summary>
        private void OnVideoSliderUp()
        {
            if (playingPlayer && isPlaying)
            {
                playingPlayer.Control.Play();
                isPlaying = false;
            }
        }

        private void SwapPlayers()
        {
            playingPlayer.Control.Pause();
            GetGameObject("VideoDisplay").GetComponent<DisplayUGUI>().CurrentMediaPlayer = playingPlayer;
            playingPlayer.Control.Play();
        }

        private void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
        {
            switch (et)
            {
                case MediaPlayerEvent.EventType.ReadyToPlay:
                    break;
                case MediaPlayerEvent.EventType.Started:
                    isReadyToPlay = true;
                    break;
                case MediaPlayerEvent.EventType.FirstFrameReady:
                    if (isAutoPlayVideo)
                    {
                        SwapPlayers();
                    }
                    break;
                case MediaPlayerEvent.EventType.FinishedPlaying:
                    OnPauseButton();
                    isPlayingDone = true;
                    break;
            }
        }

        /// <summary>
        /// 显示视频时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private string ShowTime(float time)
        {
            time = time * 0.001f;
            float hour = time / 3600;
            float minute = Mathf.Floor(time / 60);//转成分钟
            float seconds = time % 60;//转成秒
            return hour.ToString("00") + ":" + minute.ToString("00") + ":" + seconds.ToString("00");
        }

        /// <summary>
        /// 视频是否全屏
        /// </summary>
        /// <param name="isFullScreen"></param>
        private void SetVideoFullScreen(bool isFullScreen) {
            if (isFullScreen)
            {
                GetUIBehaviours(name).ChildNumber = GetUIBehaviours(name).Parent.childCount - 1;
                Vector2 wAndH = GetUIBehaviours(name).Parent.GetComponent<RectTransform>().sizeDelta;
                GetUIBehaviours("AVProBG").WidthAndHeight = wAndH;
                GetUIBehaviours("FullScreenButton").ImageSprite = smallScreenSprite1;
                GetUIBehaviours("FullScreenButton").ChangeButtonClickSprite(smallScreenSprite2, smallScreenSprite2, smallScreenSprite2);
            }
            else
            {
                GetUIBehaviours(name).ChildNumber = childNumber;
                GetUIBehaviours("AVProBG").WidthAndHeight = orgWAndH;
                GetUIBehaviours("FullScreenButton").ImageSprite = fullScreenSprite1;
                GetUIBehaviours("FullScreenButton").ChangeButtonClickSprite(fullScreenSprite2, fullScreenSprite2, fullScreenSprite2);
            }
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            if (evt.EventSource is ViewModel)
            {
                ViewModel vm = evt.EventSource as ViewModel;
                if (vm.name.Equals("VideoPlay"))
                {
                    OnPlayButton();
                }
                else if (vm.name.Equals("VideoPause"))
                {
                    OnPauseButton();
                }
                else if (vm.name.Equals("CloseButton"))
                {
                    CloseVideoPanel();
                    DestoryVideo();
                    InvokeCallBackAction();
                }
                else if (vm.name.Equals("VideoValue"))
                {
                    PropertyEvent propertyEvent = evt as PropertyEvent;
                    float newValue = (float)propertyEvent.NewValue;
                    if (isPlaying)
                    {
                        OnVideoSeekSlider(newValue);
                    }
                }
                else if (vm.name.Equals("AudioValue"))
                {
                    PropertyEvent propertyEvent = evt as PropertyEvent;
                    float newValue = (float)propertyEvent.NewValue;
                    if (playingPlayer)
                    {
                        playingPlayer.Control.SetVolume(newValue);
                    }
                }
                else if (vm.name.Equals("FullScreenButton"))
                {
                    if (!isFullScreen)
                    {
                        isFullScreen = true;
                        SetVideoFullScreen(isFullScreen);
                        
                    }
                    else
                    {
                        isFullScreen = false;
                        SetVideoFullScreen(isFullScreen);
                    }
                }
            }
            
            if (evt.EventName.Equals("VideoUrl"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                PlayWebVideo(newValue);
            }
            else if (evt.EventName.Equals("VideoName"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                PlayLocalVideo(newValue);
            }
            else if (evt.EventName.Equals("SliderDown"))
            {
                OnVideoSliderDown();
            }
            else if (evt.EventName.Equals("SliderUp"))
            {
                OnVideoSliderUp();
            }
        }
    }
}
