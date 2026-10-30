using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

public class ExampleTTS : MonoBehaviour
{
    public AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Speech.Tts("你好，我是小雅", Application.streamingAssetsPath);
        //SpeakCoroutine("你好，我是小雅");
        SpeakCoroutine2("你好，我是小雅");
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void SpeakCoroutine(string _msg)
    {
        StartCoroutine(TtsCoroutine(_msg, TtsVoice.XiaoYan));
        m_AudioSource.Play();
    }

    private IEnumerator TtsCoroutine(string _msg, TtsVoice voice = TtsVoice.XiaoYan)
    {
        // 执行方法的代码
        m_AudioSource.clip = Speech.Tts(_msg, voice);
        yield return null;
    }

    public void SpeakCoroutine2(string _msg)
    {
        string path = Path.Combine(Application.streamingAssetsPath,"123.mp3");
        StartCoroutine(TtsCoroutine2(_msg, path));
        Debug.Log("完成");
    }

    private IEnumerator TtsCoroutine2(string _msg, string path)
    {
        // 执行方法的代码
        bool isFinsh = Speech.Tts(_msg, path);
        yield return isFinsh;
    }
}
