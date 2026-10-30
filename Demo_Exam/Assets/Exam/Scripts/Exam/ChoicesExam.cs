/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ChoicesExam
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：选择题实体
******************************************************************************/

using System.Collections.Generic;

public class ChoicesExam : ExamBase
{
    /// <summary>
    /// 题干
    /// </summary>
    private string examDetail;

    /// <summary>
    /// 选项
    /// </summary>
    private List<ChoicesOption> options;

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
    public List<ChoicesOption> Options
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

    public ChoicesExam() { }


    public ChoicesExam(ExamType examType, string examName, string examDetail, string examScore, List<ChoicesOption> options) : base(examType, examName, examScore)
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