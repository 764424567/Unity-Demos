using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class LoadExam : MonoBehaviour
{
    private void Start()
    {
        StartLoadExams("Exam", LoadExamCallBack);
    }

    /// <summary>
    /// 考题回调
    /// </summary>
    /// <param name="message"></param>
    private void LoadExamCallBack(string message)
    {
        try
        {
            string value = StringAndZip.ZipToString(message);
            List<Exam> exams = JsonConvert.DeserializeObject<List<Exam>>(value, new ExamConverter());
            InjectService.Get<ExamManager>().SaveExams(exams);
        }
        catch (System.Exception e)
        {
            Debug.LogError("cant load exam by:" + e);
            Debug.Log("message" + " " + message);
        }
    }

    /// <summary>
    /// 加载考题
    /// </summary>
    /// <param name="excelName"></param>
    /// <param name="LoadExamCallBack"></param>
    private void StartLoadExams(string excelName, UnityAction<string> LoadExamCallBack)
    {
        StartCoroutine(LoadExams(excelName, LoadExamCallBack));
    }

    private IEnumerator LoadExams(string name, UnityAction<string> LoadExamCallBack)
    {
        string url = Application.streamingAssetsPath + "/Exam/" + name + ".txt";
        var req = UnityWebRequest.Get(url);
        req.SendWebRequest();
#if UNITY_2020_2_OR_NEWER
        if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
#elif UNITY_2017_1_OR_NEWER
        if (req.isHttpError || req.isNetworkError)
#else
            if (req.isError)
#endif
        {
            Debug.Log(req.error);
            yield break;
        }
        while (!req.isDone)
        {
            yield return 0;
        }
        string message = req.downloadHandler.text;
        LoadExamCallBack(message);
    }
}
