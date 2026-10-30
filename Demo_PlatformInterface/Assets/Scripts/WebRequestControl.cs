//服务器请求
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

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

    public static void RequestDataFormat(string url, WWWForm form, string token, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData(url, form, token, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    public static void RequestDataFormat(string url, WWWForm form, string token, string ticket, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestData(url, form, token, ticket ,(string value) =>
        {
            action.Invoke(value);
        }));
    }

    public static void RequestDataFormat(string url, string json, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(RequestByJsonBodyPost(url, json, (string value) =>
        {
            action.Invoke(value);
        }));
    }

    public static void RequestDataFormatGet(string url, string token, Action<string> action = null)
    {
        MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
        mono.StartCoroutine(GetData(url, token, (string value) =>
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

    protected static IEnumerator RequestData(string url, WWWForm form, string _token, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, form);
        req.SetRequestHeader("token", _token);
        yield return req.SendWebRequest();
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

    protected static IEnumerator RequestData(string url, WWWForm form, string _token, string _ticket, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, form);
        req.SetRequestHeader("token", _token);
        req.SetRequestHeader("ticket", _ticket);
        yield return req.SendWebRequest();
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

    protected static IEnumerator GetData(string url, string _token, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        //请求添加token验证
        req.SetRequestHeader("token", _token);
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
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

    private static IEnumerator RequestByJsonBodyPost(string url, string json, DelegateRequest dele = null)
    {
        UnityWebRequest req = UnityWebRequest.Post(url, json);
        req.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
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
}