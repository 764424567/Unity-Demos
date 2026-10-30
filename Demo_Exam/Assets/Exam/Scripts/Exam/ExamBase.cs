/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamBase
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：实体基类
******************************************************************************/

public class ExamBase
{
    /// <summary>
    /// 考题类型
    /// </summary>
    private ExamType type;

    /// <summary>
    /// 题目名称
    /// </summary>
    private string examName;

    /// <summary>
    /// 题目分数
    /// </summary>
    private string examScore;

    /// <summary>
    /// 题目得分
    /// </summary>
    private string answerScore = "0";

    /// <summary>
    /// 回答是否正确
    /// </summary>
    private bool answer = false;

    /// <summary>
    /// 考题类型
    /// </summary>
    public ExamType ExamType
    {
        get { return type; }
        set { type = value; }
    }

    /// <summary>
    /// 题目名称
    /// </summary>
    public string ExamName
    {
        set { examName = value; }
        get { return examName; }
    }

    /// <summary>
    /// 题目分数
    /// </summary>
    public string ExamScore
    {
        set { examScore = value; }
        get { return examScore; }
    }

    /// <summary>
    /// 题目得分
    /// </summary>
    public string AnswerScore
    {
        get { return answerScore; }
        set { answerScore = value; }
    }

    /// <summary>
    /// 回答是否正确
    /// </summary>
    public bool Answer
    {
        get { return answer; }
        set { answer = value; }
    }

    public ExamBase() { }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="examType">考题类型</param>
    /// <param name="examName">考题名称</param>
    /// <param name="examScore">考题分值</param>
    public ExamBase(ExamType examType, string examName, string examScore)
    {
        this.type = examType;
        this.examName = examName;
        this.examScore = examScore;
    }

    /// <summary>
    /// 判断正误
    /// </summary>
    public virtual void JudgeTureOrFalse() { }

    /// <summary>
    /// 获取得分
    /// </summary>
    public virtual string GetScore()
    {
        return "0";
    }
}