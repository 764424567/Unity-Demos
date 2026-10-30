using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOption
{
    /// <summary>
    /// 选项名字
    /// </summary>
    private string optionName;

    /// <summary>
    /// 选项答案
    /// </summary>
    private string[] answer;

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
    public string[] Answer
    {
        get { return answer; }
        set { answer = value; }
    }

    public InputOption() { }

    public InputOption(string optionName, string[] answer)
    {
        this.optionName = optionName;
        this.answer = answer;
    }
}