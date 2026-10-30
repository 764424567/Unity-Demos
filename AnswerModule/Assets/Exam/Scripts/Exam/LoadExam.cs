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
        var request = UnityWebRequest.Get(url);
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
        string message = request.downloadHandler.text;
        LoadExamCallBack(message);
    }
}
