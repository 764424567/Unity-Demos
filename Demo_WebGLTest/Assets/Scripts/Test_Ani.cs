using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UTJ.Alembic;

public class Test_Ani : MonoBehaviour
{
    public Animator m_Ani;
    public Slider m_Sli;
    public AlembicStreamPlayer m_AlembicCT;
    public AlembicStreamPlayer m_AlembicMD;

    void Start()
    {
        m_Sli.onValueChanged.AddListener(_data => ChangeValue(_data));
    }

    public void ChangeValue(float _angle)
    {
        m_AlembicCT.currentTime = _angle * 6.7f;
        m_AlembicMD.currentTime = _angle * 6.7f;
    }
}
