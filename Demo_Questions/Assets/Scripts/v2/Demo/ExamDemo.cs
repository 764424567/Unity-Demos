using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamDemo : MonoBehaviour
{
    /// <summary>
    /// 当前考题
    /// </summary>
    protected Exam exam;

    void Start()
    {
        Invoke("LoadExam", 0.5f);
    }

    private void LoadExam()
    {
        LoadExam("1");
    }

    public void LoadExam(string examName)
    {
        exam = InjectService.Get<ExamManager>().GetExam(examName);
        Choices choices = (Choices)exam;
        Debug.Log(choices.ExamName);
        for (int i = 0; i < choices.Options.Count; i++)
        {
            Debug.Log(choices.Options[i].OptionName);
            Debug.Log(choices.Options[i].Answer);
        }
        Debug.Log(choices.InputAnswer);
        Debug.Log(choices.ExamType);
        Debug.Log(choices.ExamScore);
        Debug.Log(choices.AnswerScore);
        Debug.Log(choices.Answer);
    }
}
