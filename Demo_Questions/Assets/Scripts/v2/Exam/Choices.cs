using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : Exam
{

    /// <summary>
    /// 题干
    /// </summary>
    private string examDetail;

    /// <summary>
    /// 选项
    /// </summary>
    private List<Option> options;

    /// <summary>
    /// 输入答案
    /// </summary>
    private List<bool> inputAnswer;

    /// <summary>
    /// 考题题干
    /// </summary>
    public string ExamDetail
    {
        set { examDetail = value; }
        get { return examDetail; }
    }

    /// <summary>
    /// 考题选项
    /// </summary>
    public List<Option> Options
    {
        set { options = value; }
        get { return options; }
    }

    /// <summary>
    /// 输入答案
    /// </summary>
    public List<bool> InputAnswer
    {
        get { return inputAnswer; }
        set { inputAnswer = value; JudgeTureOrFalse(); }
    }

    public Choices() { }


    public Choices(ExamType examType, string examName, string examDetail, string examScore, List<Option> options) : base(examType, examName, examScore)
    {
        this.examDetail = examDetail;
        this.options = options;
    }

    /// <summary>
    /// 判断正误
    /// </summary>
    public override void JudgeTureOrFalse()
    {
        if (inputAnswer != null)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i].Answer != inputAnswer[i])
                {
                    Answer = false;
                    return;
                }

            }
            Answer = true;
        }
        else
        {
            Answer = false;
        }

    }

    /// <summary>
    /// 获取得分
    /// </summary>
    /// <returns></returns>
    public override string GetScore()
    {
        if (Answer)
        {
            return ExamScore;
        }
        else
        {
            return "0";
        }
    }
}
