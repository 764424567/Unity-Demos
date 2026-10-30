using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InputFieldControl1 : MonoBehaviour
{
    public InputField input;
    public Text m_Info;

    void Start()
    {
        InputSet("^[A-Za-z0-9]+$",40);
    }

    /// <summary>
    /// 输入设置
    /// </summary>
    /// <param name="pattern">正则表达式</param>
    /// <param name="limit">输入字符限制</param>
    public void InputSet(string pattern,int limit)
    {
        input.characterLimit = limit;//限制输入
        input.onValueChanged.AddListener((str) => OnInputFieldValueChange(str, pattern));
    }

    public void OnInputFieldValueChange(string inputInfo, string _InputType)
    {
        m_Info.text = "还可输入" + (input.characterLimit - input.text.Length) + "字";
        Regex reg = new Regex(_InputType);
        if (reg.IsMatch(inputInfo))
        {
            input.text = inputInfo;
        }
        else
        {
            if (input.text == "")
            {
                input.text = "";
            }
            else
            {
                input.text = inputInfo.Substring(0, inputInfo.Length - 1);
            }
        }
    }
}