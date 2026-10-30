using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image m_Image;
    public Text m_Text;
    float m_CurProgressValue = 0;
    float m_ProgressValue = 100;

    void Update()
    {
        if (m_CurProgressValue < m_ProgressValue)
        {
            m_CurProgressValue++;
        }
        //实时更新进度百分比的文本显示 
        m_Text.text = m_CurProgressValue + "%";
        //实时更新滑动进度图片的fillAmount值  
        m_Image.GetComponent<Image>().fillAmount = m_CurProgressValue / 100f;
        if (m_CurProgressValue == 100)
        {
            m_Text.text = "OK";
        }
    }
}
