using UnityEngine;
using UnityEngine.UI;

public class PullDown : MonoBehaviour
{
    public Button m_Btn1;//一级菜单按钮
    public Button m_Btn2;//二级菜单按钮
    public Button m_Btn3;//三级菜单按钮

    bool m_is1;//全局参数 控制开关
    bool m_is2;//全局参数 控制开关

    void Start()
    {
        m_is1 = true;
        m_is2 = true;
        m_Btn1.onClick.AddListener(Btn1_Event);
        m_Btn2.onClick.AddListener(Btn2_Event);
    }

    public void Btn1_Event()
    {
        if (m_is1)
        {
            m_Btn2.gameObject.SetActive(false);
            m_Btn3.gameObject.SetActive(false);
            m_is1 = false;
        }
        else
        {
            m_Btn2.gameObject.SetActive(true);
            m_Btn3.gameObject.SetActive(true);
            m_is1 = true;
        }
    }

    public void Btn2_Event()
    {
        if (m_is2)
        {
            m_Btn3.gameObject.SetActive(false);
            m_is2 = false;
        }
        else
        {
            m_Btn3.gameObject.SetActive(true);
            m_is2 = true;
        }
    }
}
