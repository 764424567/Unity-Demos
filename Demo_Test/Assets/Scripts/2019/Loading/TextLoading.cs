using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLoading : MonoBehaviour
{
    public Text m_Text;
    float m_CurProgressValue2 = 0;
    float m_ProgressValue2 = 100;
    float m_CurProgressValueTemp = 0;

    void Update()
    {
        if (m_CurProgressValue2 < m_ProgressValue2)
        {
            m_CurProgressValue2 += 1f;
        }
        if (m_CurProgressValue2 == 100)
        {
            m_CurProgressValue2 = 0;
        }
        m_CurProgressValueTemp = m_CurProgressValue2 / 100f;
        if (m_CurProgressValueTemp > 0.1f && m_CurProgressValueTemp <= 0.3f)
        {
            m_Text.text = "○○○○●";
        }
        else if (m_CurProgressValueTemp > 0.3f && m_CurProgressValueTemp <= 0.5f)
        {
            m_Text.text = "●○○○○";
        }
        else if (m_CurProgressValueTemp > 0.5f && m_CurProgressValueTemp <= 0.7f)
        {
            m_Text.text = "○●○○○";
        }
        else if (m_CurProgressValueTemp > 0.7f && m_CurProgressValueTemp <= 0.9f)
        {
            m_Text.text = "○○●○○";
        }
        else
        {
            m_Text.text = "○○○●○";
        }
    }
}
