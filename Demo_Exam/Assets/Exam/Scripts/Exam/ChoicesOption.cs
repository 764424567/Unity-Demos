/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ChoicesOption
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：选择题 选项 实体
******************************************************************************/

public class ChoicesOption
{
    /// <summary>
    /// 选项名字
    /// </summary>
    private string optionName;

    /// <summary>
    /// 选项答案
    /// </summary>
    private bool answer;

    /// <summary>
    /// 选项名字
    /// </summary>
    public string OptionName
    {
        get { return optionName; }
        set { optionName = value; }
    }

    /// <summary>
    /// 选项答案
    /// </summary>
    public bool Answer
    {
        get { return answer; }
        set { answer = value; }
    }

    public ChoicesOption() { }

    public ChoicesOption(string optionName, bool answer)
    {
        this.optionName = optionName;
        this.answer = answer;
    }
}