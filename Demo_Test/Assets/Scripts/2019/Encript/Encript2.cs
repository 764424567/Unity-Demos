using UnityEngine;
using UnityEngine.UI;

public class Encript2 : MonoBehaviour
{
    //设置一个初始的账号和密码 
    public string UserName = "";
    public string PassWord = "";
    //UI
    public Text m_UserNameText;
    public Text m_PassWordText;
    public Text m_HelpText;
    public Button m_BtnAticvation;
    public Button m_BtnExit;
    
    void Start()
    {
        m_BtnAticvation.onClick.AddListener(BtnEvent_Aticvation);
        m_BtnExit.onClick.AddListener(BtnEvent_Exit);
        //判断是否已经激活
        Decide_Acticvation();
    }

    public void Decide_Acticvation()
    {
        if (UserName == "admin" && PassWord == "123456")
        {
            gameObject.SetActive(false);
        }
    }

    public void BtnEvent_Aticvation()
    {
        UserName = m_UserNameText.text;
        PassWord = m_PassWordText.text;
        if (m_UserNameText.text == "admin" && m_PassWordText.text == "123456")
        {
            //激活成功
            gameObject.SetActive(false);
        }
        else
        {
            //未激活成功
            m_HelpText.text = "账号密码不正确";
        }
    }

    public void BtnEvent_Exit()
    {
        Application.Quit();
    }
}