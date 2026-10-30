using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option
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

    public Option() { }

    public Option(string optionName, bool answer)
    {
        this.optionName = optionName;
        this.answer = answer;
    }
}