/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： AudioWebLoadSystem
* 创建日期：2020-06-02 15:33:53
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：动态加载StreamingAssets/Audio/场景名/音频名，的音频。支持WebGL;音频格式为WAV
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{

	public class AudioWebLoadSystem : MonoBehaviour 
	{

        /// <summary>
        /// 加载音频
        /// </summary>
        /// <param name="path">路径（场景名/音频名）</param>
        /// <param name="LoadAudioClipCallBack">完成加载后的回调</param>
        public void LoadAudio(string path, UnityAction<AudioClip> LoadAudioClipCallBack)
        {
            StartCoroutine(LoadAudioClip(path, LoadAudioClipCallBack));
        }

        /// <summary>
        /// 停止加载音频
        /// </summary>
        public void StopLoadAudio()
        {
            StopAllCoroutines();
        }

        private IEnumerator LoadAudioClip(string path, UnityAction<AudioClip> LoadAudioClipCallBack)
        {
            string url = Application.streamingAssetsPath + "/Audio/" + path + ".wav";
            var request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
            request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
                yield break;
            }
            while (!request.isDone)
            {
                yield return 0;
            }
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            LoadAudioClipCallBack(clip);
        }

    }
}

