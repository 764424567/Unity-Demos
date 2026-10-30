using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;

public class Tools_Encryption : MonoBehaviour
{
    //提示界面
    public GameObject m_Panel;
    //信息显示
    public Text[] m_Text;
    //退出按钮
    public Button m_Button;

    void Start()
    {
        m_Button.onClick.AddListener(OnExit);
        SetPlayUseNumber();
    }

    /// <summary>
    /// 设置用户使用次数
    /// </summary>
    void SetPlayUseNumber()
    {
        //创建键值对
        RegistryKey RootKey, RegKey;
        //项名为：HKEY_CURRENT_USER\Software
        RootKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
        //打开子项：HKEY_CURRENT_USER\Software\TestToControlUseTime
        if ((RegKey = RootKey.OpenSubKey("Activation", true)) == null)
        {
            m_Panel.SetActive(true);
            m_Text[0].text = "程序未激活";
            m_Text[1].text = "请联系您的管理员激活程序";
        }
        //异常捕捉，如果出现程序异常，比如闪退
        try
        {
            object usetime = RegKey.GetValue("UserName");        //读取键值
            if (usetime.ToString() == "已激活2")
            {
                m_Panel.SetActive(false);
            }
            else
            {
                m_Panel.SetActive(true);
                m_Text[0].text = "程序未激活";
                m_Text[1].text = "请联系您的管理员激活程序";
            }
        }
        catch
        {
            print("异常状况");
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