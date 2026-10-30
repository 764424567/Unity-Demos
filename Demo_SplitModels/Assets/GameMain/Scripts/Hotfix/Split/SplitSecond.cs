using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSecond : MonoBehaviour
{
    private Transform m_ParObj;//中心点
    private List<GameObject> m_Child;//所有子对象
    private List<Vector3> m_InitPoint = new List<Vector3>();//初始位置

    private int m_IsSplitState = 0;
    private float m_TimeTotal = 0;//总时间
    private float m_Timecurrent = 0;//当前时间
    private int m_TimeDisRe = 0;//时间间隔 记录
    private int IndexCount = 0;//计数

    public int m_TimeDistance = 1;//时间间隔

    void Start()
    {
        m_ParObj = GetComponent<Transform>();
        m_Child = GetChild(m_ParObj);
        for (int i = 0; i < m_Child.Count; i++)
        {
            m_InitPoint.Add(m_Child[i].transform.position);
        }
        m_TimeTotal = m_Child.Count* m_TimeDistance;
    }

    //获取所有子对象
    public List<GameObject> GetChild(Transform obj)
    {
        List<GameObject> tempArrayobj = new List<GameObject>();
        foreach (Transform child in obj)
        {
            tempArrayobj.Add(child.gameObject);
        }
        return tempArrayobj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Timecurrent = 0;
            m_TimeDisRe = 0;
            IndexCount = 0;
            m_IsSplitState = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Timecurrent = 0;
            m_TimeDisRe = 0;
            IndexCount = 0;
            m_IsSplitState = 2;
        }
        if (m_IsSplitState == 1)
        {
            //拆分
            SplitObject();
        }
        else if(m_IsSplitState == 2)
        {
            //合并
            MergeObject();
        }
    }

    private void SplitObject()
    {
        m_Timecurrent += Time.deltaTime;
        if (m_Timecurrent <= m_TimeTotal && IndexCount< m_Child.Count)
        {
            if (Mathf.FloorToInt(m_Timecurrent) == m_TimeDisRe)
            {
                m_TimeDisRe += m_TimeDistance;
                Vector3 tempV3 = SplitObjTest(m_ParObj.transform, m_Child[IndexCount].transform);
                m_Child[IndexCount].transform.DOMove(tempV3, 1f, false);
                IndexCount++;
            }
        }
    }

    private void MergeObject()
    {
        m_Timecurrent += Time.deltaTime;
        if (m_Timecurrent <= m_TimeTotal && IndexCount < m_Child.Count)
        {
            if (Mathf.FloorToInt(m_Timecurrent) == m_TimeDisRe)
            {
                m_TimeDisRe += m_TimeDistance;
                m_Child[IndexCount].transform.DOMove(m_InitPoint[IndexCount], 3f, false);
                IndexCount++;
            }
        }
    }

    public Vector3 SplitObjTest(Transform m_ParObj, Transform _TargetObj)
    {
        Vector3 tempV3;
        tempV3.x = (_TargetObj.position.x - m_ParObj.position.x) * 2;
        tempV3.y = (_TargetObj.position.y - m_ParObj.position.y) * 2;
        tempV3.z = (_TargetObj.position.z - m_ParObj.position.z) * 2;
        return tempV3;
    }

    //显示时间
    void OnGUI()
    {
        GUI.Label(new Rect(100, 50, 100, 30), m_TimeDisRe + "秒");
    }
}