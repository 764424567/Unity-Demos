using System.Text.RegularExpressions;
using UnityEngine;

public class Test_8_1 : MonoBehaviour
{
    void Start()
    {
        string temp = "Hello World 2020";
        IsMatch(temp);
    }
    ///<summary>
    ///在输入的字符串中搜索正则表达式的匹配项
    ///</summary>
    ///<param name="strInput">输入的字符串</param>
    public void IsMatch(string strInput)
    {
        string pattern = "(\\w+)$";
        Match resultBool = Regex.Match(strInput, pattern);
        Debug.Log(resultBool.Value);
    }
}
