using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReceiveDataHandle : MonoBehaviour
{
    public Button BtnLoad;
    public Image showImg;
    public Text showText;

    [DllImport("__Internal")]
    private static extern void clickSelectFileBtn();
    /// <summary>
    /// 点击Open按钮
    /// </summary>
    public static void BtnLoadEvent()
    {
        clickSelectFileBtn();
    }

    void Start()
    {
        BtnLoad.onClick.AddListener(BtnLoadEvent);
    }

    /// <summary>
    /// 接收base64字符串
    /// </summary>
    /// <param name="base64Str"></param>
    public void GetBase64(string base64Str)
    {
        Debug.Log(base64Str);

        string[] split = base64Str.Split('|');
        if (split[0].Contains("jpg"))
        {
            StartCoroutine(ReadTexture(split[1], LoadImg));
        }
        else if (split[0].Contains("txt"))
        {
            StartCoroutine(ReadData(split[1], LoadText));
        }
        else
        {
            Debug.Log("文件格式错误");
            return;
        }
        
    }

    /// <summary>
    /// 读取图片
    /// </summary>
    /// <param name="path"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    IEnumerator ReadTexture(string path,UnityAction<Texture> action)
    {
        Debug.Log(path);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        yield return request.SendWebRequest();
#if UNITY_2020_2_OR_NEWER
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
#elif UNITY_2017_1_OR_NEWER
            if (request.isHttpError || request.isNetworkError)
#else
            if (request.isError)
#endif
        {
            Debug.Log(request.error);
        }
        else
        {
            byte[] imgdata = request.downloadHandler.data;

            action(DownloadHandlerTexture.GetContent(request));
        }
    }

    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="texture"></param>
    void LoadImg(Texture texture)
    {
        Sprite ImgSprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        showImg.sprite = ImgSprite;
    }

    /// <summary>
    /// 读取文本
    /// </summary>
    /// <param name="path"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    IEnumerator ReadData(string path, UnityAction<string> action)
    {
        Debug.Log(path);
        UnityWebRequest request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();
#if UNITY_2020_2_OR_NEWER
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
#elif UNITY_2017_1_OR_NEWER
            if (request.isHttpError || request.isNetworkError)
#else
            if (request.isError)
#endif
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            action(request.downloadHandler.text);
        }
    }

    /// <summary>
    /// 加载文本
    /// </summary>
    /// <param name="text"></param>
    void LoadText(string text)
    {
        showText.text = text;
    }
}