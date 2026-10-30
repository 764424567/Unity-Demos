using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_365 : MonoBehaviour
{
    private float[] m_FloatArray;
    private float m_Float;
    string tempStr;
    string tempStrIndex;
    // Use this for initialization
    void Start()
    {
        CountingProcess();
    }


    public void CountingProcess()
    {
        m_FloatArray = new float[366];
        for (int i = 0; i <= 36; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                if (j == 10)
                {
                    int temp = i + 1;
                    tempStr = temp + "0";
                    tempStrIndex = temp.ToString() + 0;
                }
                else
                {
                    tempStr = i.ToString() + j.ToString();
                    tempStrIndex = i.ToString() + j.ToString();
                }
                if (int.Parse(tempStrIndex) == 366)
                {
                    break;
                }
                m_FloatArray[int.Parse(tempStrIndex)] = float.Parse(tempStr);
            }
        }
        for (int i = 0; i < m_FloatArray.Length; i++)
        {
            m_Float += m_FloatArray[i];
        }
        Debug.Log(m_Float);
    }
}
