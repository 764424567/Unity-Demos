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
        Debug.Log("message" + " " + message);
        string value = StringAndZip.ZipToString(message);
        Debug.Log("value" + " " + value);
        List<Exam> exams = JsonConvert.DeserializeObject<List<Exam>>(value, new ExamConverter());
        for (int i = 0; i < exams.Count; i++)
        {
            Debug.Log("exams" + "i" + " " + exams[i].Answer);
        }
        InjectService.Get<ExamManager>().SaveExams(exams);
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
        string url = Application.streamingAssetsPath + "/v2/Exam/" + name + ".txt";
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
