using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitAnomaly : MonoBehaviour
{
    public Transform m_ChildPointParent;//要移动的子对象的父物体
    private List<GameObject> m_Child;//所有子对象
    private List<Vector3> m_InitPoint = new List<Vector3>();//初始位置

    public Transform m_TargetPointParent;//目标点对象的父物体
    private List<GameObject> m_TargetChild;//目标点所有子对象
    private List<Vector3> m_TargetPoint = new List<Vector3>();//要移动的位置

    private void Start()
    {
        m_Child = GetChild(transform);//获取所有子对象
        for (int i = 0; i < m_Child.Count; i++)
        {
            m_InitPoint.Add(m_Child[i].transform.position);
        }

        m_TargetChild = GetChild(m_TargetPointParent);//获取所有目标点子对象
        for (int i = 0; i < m_TargetChild.Count; i++)
        {
            m_TargetPoint.Add(m_TargetChild[i].transform.position);
        }
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //拆分
            SplitObject();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //合并
            MergeObject();
        }
    }

    private void SplitObject()
    {
        for (int i = 0; i < m_Child.Count; i++)
        {
            m_Child[i].transform.DOMove(m_TargetPoint[i], 3f, false);
        }
    }

    private void MergeObject()
    {
        for (int i = 0; i < m_InitPoint.Count; i++)
        {
            m_Child[i].transform.DOMove(m_InitPoint[i], 3f, false);
        }
    }
}
