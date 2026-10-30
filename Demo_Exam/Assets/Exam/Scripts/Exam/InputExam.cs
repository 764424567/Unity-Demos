/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ChoicesOption
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：填空题实体
******************************************************************************/

using System.Collections.Generic;

public class InputExam : ExamBase
{
    /// <summary>
    /// 题干
    /// </summary>
    private string examDetail;

    /// <summary>
    /// 分项
    /// </summary>
    private List<InputOption> options;

    /// <summary>
    /// 输入答案
    /// </summary>
    private List<string> inputAnswer;

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
    public List<InputOption> Options
    {
        set { options = value; }
        get { return options; }
    }

    /// <summary>
    /// 输入答案
    /// </summary>
    public List<string> InputAnswer
    {
        get { return inputAnswer; }
        set { inputAnswer = value; JudgeTureOrFalse(); }
    }

    public InputExam() { }

    public InputExam(ExamType examType, string examName, string examDetail, string examScore, List<InputOption> options) : base(examType, examName, examScore)
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
            int rightCount = 0;
            for (int i = 0; i < inputAnswer.Count; i++)
            {
                for (int j = 0; j < options[i].Answer.Length; j++)
                {
                    if (inputAnswer[i].Contains(options[i].Answer[j]))
                    {
                        rightCount++;
                        break;
                    }
                }
            }
            if (rightCount == InputAnswer.Count)
            {
                Answer = true;
            }
            else
            {
                Answer = false;
            }
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