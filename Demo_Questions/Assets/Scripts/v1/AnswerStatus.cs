using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerStatus : MonoBehaviour
{
    public float Grade;//题目分数
    public string CorrectText;//正确选项
    public List<Toggle> Options;//选项

    [HideInInspector] public bool isAnswer = false;//是否答题
    [HideInInspector] public string title;
    public string option;
    [HideInInspector] public string answer;
    [HideInInspector] public float score;


    void Start()
    {
        for (int i = 0; i < Options.Count; i++)
        {
            option += Options[i].GetComponentInChildren<Text>().text + "\n";
            Options[i].onValueChanged.AddListener((isOn) => ToggleValueChange());
        }
        answer = "";
    }

    private void ToggleValueChange()
    {
        string tempStr = "";
        for (int i = 0; i < Options.Count; i++)
        {
            if (Options[i].isOn)
            {
                tempStr += Options[i].GetComponentInChildren<Text>().text.Substring(0, 1);
            }
        }
        isAnswer = true;
        answer = tempStr;
        if (tempStr == CorrectText)
        {
            score = Grade;
        }
        else
        {
            score = 0;
        }
        UpdateValue(answer, score);
    }

    private void UpdateValue(string answer, float score)
    {
        //在这里处理 选项 和  对号
        string tempOption = "";
        for (int j = 0; j < Options.Count; j++)
        {
            string tempAnswer = Options[j].GetComponentInChildren<Text>().text.Substring(0, 1);
            if (tempAnswer == answer)
            {
                tempOption += Options[j].GetComponentInChildren<Text>().text + " ✔ " + "\n";
            }
            else
            {
                tempOption += Options[j].GetComponentInChildren<Text>().text + "\n";
            }
        }
    }
}
