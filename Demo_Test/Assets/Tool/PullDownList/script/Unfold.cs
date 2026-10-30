using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfold : MonoBehaviour
{
    GameObject[] m_item;
    // Use this for initialization
    void Start()
    {
        Invoke("OnVals", 1f);
        Invoke("OnVals", 2f);
        Invoke("OnVals", 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnVals()
    {
        m_item = GameObject.FindGameObjectsWithTag("Finish");
        for (int i = 0; i < m_item.Length; i++)
        {
            Debug.Log(m_item[i].name);
            m_item[i].GetComponent<ItemPanelBase>().OpenChild();
        }
    }
}
