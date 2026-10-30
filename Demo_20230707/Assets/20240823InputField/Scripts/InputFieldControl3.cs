using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldControl3 : MonoBehaviour
{
    public InputField input;

    void Start()
    {
        InputSet("^(0|[1-9]\\d*)(\\.\\d{0,1})?$");
    }

    /// <summary>
    /// 输入设置
    /// </summary>
    /// <param name="pattern">正则表达式</param>
    /// <param name="limit">输入字符限制</param>
    public void InputSet(string pattern)
    {
        input.onValueChanged.AddListener((str) => OnInputFieldValueChange(str, pattern));
    }

    public void OnInputFieldValueChange(string inputInfo, string _InputType)
    {
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