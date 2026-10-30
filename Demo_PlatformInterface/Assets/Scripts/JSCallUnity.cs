using System;
using UnityEngine;
using UnityEngine.UI;

public class JSCallUnity : MonoBehaviour
{
    public InputField m_Input;

    void Start()
    {
        // 从控制台接收参数
        ReadEnvironmentData();
    }

    private void ReadEnvironmentData()
    {
        string[] CommandLineArgs = Environment.GetCommandLineArgs();
        if (CommandLineArgs.Length < 2 || CommandLineArgs[1] == "")
        {
            m_Input.text = "没有接收到参数";
            Application.Quit();//启动时没有参数则退出
        }
        else
        {
            ParseInitData(CommandLineArgs[1]);
        }
    }

    void ParseInitData(string data)
    {
        //解析参数
        m_Input.text = data;
    }
}