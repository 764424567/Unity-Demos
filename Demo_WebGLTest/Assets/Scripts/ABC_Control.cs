using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UTJ.Alembic;
using DG.Tweening;
using DG.DemiLib;

public class ABC_Control : MonoBehaviour
{
    AlembicStreamPlayer m_AlembicSP;
    public float m_CurrentTime = 0;
    public float m_CurrentTimeTemp = 0;
    public bool m_IsOrderPlay = false;
    public float m_Current = 0;
    public float m_Current2 = 0;
    public Animator m_Ani;

    void Awake()
    {
        m_AlembicSP = GetComponent<AlembicStreamPlayer>();

        if (m_IsOrderPlay)
        {
            m_CurrentTime = 0;
            m_CurrentTimeTemp = (float)m_AlembicSP.endTime;
        }
        else
        {
            m_CurrentTime = (float)m_AlembicSP.endTime;
            m_AlembicSP.currentTime = (float)m_AlembicSP.endTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsOrderPlay)
        {
            if (m_CurrentTime < m_CurrentTimeTemp)
            {
                m_CurrentTime += Time.deltaTime;
                m_AlembicSP.currentTime = m_CurrentTime;
            }
            else
            {
                //m_CurrentTime = 0;
                //m_AlembicSP.currentTime = 0;
            }
        }
        else
        {
            if (m_CurrentTime > 0)
            {
                m_CurrentTime -= Time.deltaTime * 0.85f;
                m_AlembicSP.currentTime = m_CurrentTime;
            }
        }
        //if (m_IsOrderPlay)
        //{
        //    if (m_CurrentTime < m_CurrentTimeTemp)
        //    {
        //        m_CurrentTime += Time.deltaTime;
        //        m_AlembicSP.currentTime = m_CurrentTime;
        //    }
        //}
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "ABCControl"))
        {
            //m_AlembicSP.currentTime = m_Current;
            //m_AlembicSP.currentTime.
            //transform.DOMove();
            m_IsOrderPlay = true;
            m_CurrentTime = 0;
            m_CurrentTimeTemp = m_Current;
            //m_Ani.playbackTime = m_Current;
            //m_Ani.SetFloat("time", m_Current);
            m_Ani.Play("Take 001", 0, m_Current2);
        }
    }
}
