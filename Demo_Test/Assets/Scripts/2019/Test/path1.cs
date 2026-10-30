using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path1 : MonoBehaviour
{
    //DOTweenPath m_Path;
    DOTween m_Twn;
    Vector3[] m_path;
    // Use this for initialization
    void Start()
    {
        //m_Path.DOPlay();
        //m_Path.lastSrcPosition
        m_path = new Vector3[5];
        for (int i = 0; i < 5; i++)
        {
            m_path[i] = new Vector3(i*i, i*i, i*i);
        }
        transform.DOPath(m_path, 10f, PathType.Linear, PathMode.Full3D,10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
