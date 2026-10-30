using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ManagerCallLoca : MonoBehaviour
{
    public GameObject[] PanelMain;
    public Button btnAddReg_Click;
    public InputField InputCourseID;
    public InputField InputReturn;

    public InputField[] InputPage4;

    void Start()
    {
        //PanelMain[0].SetActive(true);
        //PanelMain[1].SetActive(false);

        btnAddReg_Click.onClick.AddListener(btnAddReg_Event);

        string str = "virtualcourse.test2://token=YOUR_TOKEN&experimentId=test01&realName=%E6%B5%8B%E8%AF%95%E5%AE%9E%E9%AA%8C&refurl=http://o3t0306119.zicp.vip:48940/";
        Debug.Log(str.IndexOf("token"));
        str = str.Substring(str.IndexOf("token"), str.Length - str.IndexOf("token"));
        Debug.Log(str);
        //读取文件并显示
        ReadFileShow();
    }

    //生成注册表
    private void btnAddReg_Event()
    {
        try
        {
            //主key统一使用 "virtualcourse."+课程唯一ID来生成
            if (string.IsNullOrEmpty(InputCourseID.text.Trim()))
            {
                InputReturn.text = "实验业务ID不能为空";
                return;
            }

            string strPrimaryKey = "virtualcourse." + InputCourseID.text.Trim();
            RegistryKey key = Registry.ClassesRoot;
            RegistryKey regPrimaryKey = key.CreateSubKey(strPrimaryKey);
            regPrimaryKey.SetValue("", strPrimaryKey + " Protocol");
            regPrimaryKey.SetValue("URL Protocol", "");

            //在HKEY_CLASSES_ROOT\virtualcourse.54e469cac796cb2530d1bf08ded0589f下创建一个名为“URL Protocol”，值为“”的键值。如果该键值原本已经存在，则会修改替换原来的键值，如果不存在则是创建该键值。
            // 注意：SetValue()还有第三个参数，主要是用于设置键值的类型，如：字符串，二进制，Dword等等~~默认是字符串。如：
            // regPrimaryKey.SetValue("URL Protocol", "", RegistryValueKind.DWord); //二进制信息

            RegistryKey regDefaultIconKey = key.CreateSubKey(strPrimaryKey + "\\DefaultIcon");

            string strExePathName = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + Application.productName;
            InputReturn.text = strExePathName;

            regDefaultIconKey.SetValue("", strExePathName + ",1");

            RegistryKey regshellKey = key.CreateSubKey(strPrimaryKey + "\\shell");

            RegistryKey regshellopenKey = key.CreateSubKey(strPrimaryKey + "\\shell\\open");

            RegistryKey regshellopencommandKey = key.CreateSubKey(strPrimaryKey + "\\shell\\open\\command");

            regshellopencommandKey.SetValue("", string.Format("\"{0}\" \"%1\"", strExePathName));

            key.Close();

            //InputReturn.text = "生成注册表成功！";
            btnAddReg_Click.interactable = false;
        }
        catch (Exception ex)
        {
            InputReturn.text = "生成注册表失败：" + ex.Message;
        }
    }

    //读取文件并显示
    private void ReadFileShow()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\TextRead.txt";
        string textTxt = File.ReadAllText(path);
        InputPage4[1].text = textTxt;
        string[] splitLeft = Regex.Split(textTxt, "//");
        textTxt = splitLeft[1];

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        string[] vars = textTxt.Split('&');
        for (int i = 0; i < vars.Length; i++)
        {
            string[] pair = vars[i].Split('=');
            parameters.Add(pair[0], pair[1]);
        }

        InputPage4[0].text = parameters["experimentId"];
        InputPage4[2].text = parameters["token"];
        InputPage4[3].text = parameters["experimentId"];
        InputPage4[4].text = UnityWebRequest.UnEscapeURL(parameters["realName"]);
        InputPage4[5].text = "http://"+parameters["refurl"];
    }

}
