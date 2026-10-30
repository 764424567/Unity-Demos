using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 上传实验报告类
/// </summary>
public class WebRequestControl
{
    public delegate void DelegateRequest(string handler);

    /// <summary>
    /// 数据发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="action">用来接收数据的函数</param>
    public static void RequestDataFormat(string url, WWWForm form, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData(url, form, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    /// <summary>
    /// 数据发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="action">用来接收数据的函数</param>
    public static void RequestDataFormat(string url, string json, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData(url, json, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    /// <summary>
    /// 数据发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="action">用来接收数据的函数</param>
    public static void RequestDataFormat2(string url, string json, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData2(url, json, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    /// <summary>
    /// 数据发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="action">用来接收数据的函数</param>
    public static void RequestDataFormat(string url, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData(url, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    /// <summary>
    /// 数据请求与发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="dele">返回数据</param>
    /// <returns></returns>
    protected static IEnumerator RequestData(string url, WWWForm form, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, form);
        yield return req.SendWebRequest();
#if UNITY_2020
        if (req.result == UnityWebRequest.Result.ProtocolError
                || req.result == UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && req.result != UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
#endif
        if (req.isHttpError || req.isNetworkError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && !req.isHttpError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
    }

    /// <summary>
    /// 数据请求与发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="dele">返回数据</param>
    /// <returns></returns>
    protected static IEnumerator RequestData(string url, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();
#if UNITY_2020
        if (req.result == UnityWebRequest.Result.ProtocolError
                || req.result == UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && req.result != UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
#endif
        if (req.isHttpError || req.isNetworkError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && !req.isHttpError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
    }

    /// <summary>
    /// 数据请求与发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="dele">返回数据</param>
    /// <returns></returns>
    protected static IEnumerator RequestData(string url, string json, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, json);
        req.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        yield return req.SendWebRequest();
#if UNITY_2020
        if (req.result == UnityWebRequest.Result.ProtocolError
                || req.result == UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && req.result != UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
#endif
        if (req.isHttpError || req.isNetworkError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && !req.isHttpError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
    }

    /// <summary>
    /// 数据请求与发送
    /// </summary>
    /// <param name="url">请求的url</param>
    /// <param name="form">表单</param>
    /// <param name="dele">返回数据</param>
    /// <returns></returns>
    protected static IEnumerator RequestData2(string url, string json, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, json);

        yield return req.SendWebRequest();
#if UNITY_2020
        if (req.result == UnityWebRequest.Result.ProtocolError
                || req.result == UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && req.result != UnityWebRequest.Result.ConnectionError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
#endif
        if (req.isHttpError || req.isNetworkError)
        {
            if (dele != null)
                dele(req.error);
        }

        if (req.isDone && !req.isHttpError)
        {
            if (dele != null)
                dele(req.downloadHandler.text);
        }
    }

    /// <summary>
    /// 返回时间戳
    /// </summary>
    /// <param name="isDecimal">是否是10进制</param>
    /// <returns></returns>
    public static long GetTimeStamp(bool isDecimal)
    {
        if (isDecimal)
        {
            DateTimeOffset tiemStamp = DateTimeOffset.Now;
            return tiemStamp.ToUnixTimeMilliseconds();
        }
        else
        {
            DateTimeOffset tiemStamp = DateTimeOffset.Now;
            return tiemStamp.ToUnixTimeSeconds();
        }
    }

    /// <summary>
    /// 返回步骤用时
    /// </summary>
    /// <returns></returns>
    public static int GetTimeUsed(long startTime, long endTime)
    {
        return Convert.ToInt32((
            DateTimeOffset.FromUnixTimeMilliseconds(endTime) -
            DateTimeOffset.FromUnixTimeMilliseconds(startTime)
            ).TotalSeconds);
    }

    //MD5解密
    public static string Encrypt_MD5(string _encryptContent)
    {
        string content_Normal = _encryptContent;
        string content_Encrypt = "";
        MD5 md5 = MD5.Create();

        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(content_Normal));

        for (int i = 0; i < s.Length; i++)
        {
            content_Encrypt = content_Encrypt + s[i].ToString("x2");
        }
        return content_Encrypt;
    }
}