/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： AudioSystemLogic
* 创建日期：2020-06-02 16:48:03
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：音频控制逻辑脚本
******************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class AudioSystemLogic : ObjLogicBase 
	{
        private AudioSource audioSource;
        private AudioWebLoadSystem loadSystem;
        private string sceneName;

        private void Awake()
        {
            
        }

        private void Start()
        {
            AddEntity<AudioSystemEntity>();
            sceneName = SceneManager.GetActiveScene().name;
            audioSource = GetComponent<AudioSource>();
            loadSystem = transform.parent.GetComponent<AudioWebLoadSystem>();
            if (this.name.Equals("StepAudio"))
            {
                audioSource.volume = SaveValue.StepAudioVolume;
            }
            else if (this.name.Equals("BGMAudio"))
            {
                audioSource.volume = SaveValue.BGMAudioVolume;
                if (SaveValue.BGMAudioSwitch && audioSource.clip != null)
                {
                    audioSource.UnPause();
                }
                else
                {
                    audioSource.Pause();
                }
                //GetEntity<AudioSystemEntity>().IsPlay = SaveValue.BGMAudioSwitch;
            }
        }

        private void OnDestroy()
        {
            RemoveEntity<AudioSystemEntity>();
        }

        /// <summary>
        /// 读取音频
        /// </summary>
        /// <param name="clip"></param>
        private void LoadAudioClipDone(AudioClip clip) {
            audioSource.clip = clip;
            if (!SaveValue.BGMAudioSwitch && this.name.Equals("BGMAudio"))
            {
                audioSource.Play();
                audioSource.Pause();
                return;
            }
            audioSource.Play();
        }

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="clipName"></param>
        public void PlayAudio(string clipName) {
            GetEntity<AudioSystemEntity>().AudioName = clipName;
        }

        /// <summary>
        /// 播放视频，不保存
        /// </summary>
        /// <param name="clipName"></param>
        public void PlayAudioNotSave(string clipName) {
            loadSystem.LoadAudio(sceneName + "/" + clipName, LoadAudioClipDone);
        }

        /// <summary>
        /// 播放暂停
        /// </summary>
        public bool IsPlay {
            get { return GetEntity<AudioSystemEntity>().IsPlay; }
            set { GetEntity<AudioSystemEntity>().IsPlay = value; }
        }

        /// <summary>
        /// 循环播放
        /// </summary>
        public bool IsLoop
        {
            get { return GetEntity<AudioSystemEntity>().IsLoop; }
            set { GetEntity<AudioSystemEntity>().IsLoop = value; }
        }

        /// <summary>
        /// 音量
        /// </summary>
        public float Volume
        {
            get { return GetEntity<AudioSystemEntity>().Volume; }
            set { GetEntity<AudioSystemEntity>().Volume = value; }
        }

        /// <summary>
        /// 停止音频
        /// </summary>
        public void StopAudio()
        {
            GetEntity<AudioSystemEntity>().Stop++;
        }

        public override void ProcessLogic(IEvent evt)
        {
            //播放暂停
            if (evt.EventName.Equals("IsPlay"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                bool newValue = (bool)propertyEvent.NewValue;
                if (newValue && audioSource.clip != null)
                {
                    audioSource.UnPause();
                }
                else
                {
                    audioSource.Pause();
                }
            }
            //音量控制
            if (evt.EventName.Equals("Volume"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                var newValue = propertyEvent.NewValue;
                audioSource.volume = (float)newValue;
            }
            //循环播放
            if (evt.EventName.Equals("IsLoop"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                var newValue = propertyEvent.NewValue;
                audioSource.loop = (bool)newValue;
            }
            //加载音频
            if (evt.EventName.Equals("AudioName"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                string newValue = (string)propertyEvent.NewValue;
                loadSystem.LoadAudio(sceneName + "/" + newValue, LoadAudioClipDone);
            }
            //停止音频
            if (evt.EventName.Equals("Stop"))
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                    loadSystem.StopLoadAudio();
                }
            }
        }
    }
}

