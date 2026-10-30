using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;

public class Tools_DeCode : MonoBehaviour
{
    public GameObject m_Text;

    //激活程序
    public void Activation()
    {
        string name = "已激活";
        // 创建键值对
        RegistryKey RootKey, RegKey;
        //项名为：HKEY_CURRENT_USER\Software
        RootKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
        //打开子项：HKEY_CURRENT_USER\Software\TestToControlUseTime
        if ((RegKey = RootKey.OpenSubKey("Activation", true)) == null)
        {
            RootKey.CreateSubKey("Activation");               //不存在，则创建子项
            RegKey = RootKey.OpenSubKey("Activation", true);  //打开键值
            RegKey.SetValue("UserName", (object)name);         //创建键值，存储最大可使用次数
            m_Text.SetActive(true);
            return;
        }
        else
        {
            RegKey.SetValue("UserName", (object)name);
            m_Text.SetActive(true);
            return;
        }
    }

    /// <summary>
    /// 退出程序
    /// </summary>
    public void OnExit()
    {
        Application.Quit();
    }
}