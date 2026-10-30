/// <summary>
/// 考题类型
/// </summary>
public enum ExamType
{
    /// <summary>
    /// 原始考题
    /// </summary>
    KaoTi = 0,
    /// <summary>
    /// 选择题
    /// </summary>
    XuanZeTi,
    /// <summary>
    /// 填空题
    /// </summary>
    TianKongTi
}


/// <summary>
/// 
/// </summary>
public class Exam
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

    public Exam() { }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="examType">考题类型</param>
    /// <param name="examName">考题名称</param>
    /// <param name="examScore">考题分值</param>
    public Exam(ExamType examType, string examName, string examScore)
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
