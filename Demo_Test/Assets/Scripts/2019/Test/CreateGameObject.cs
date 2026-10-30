using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameObject : MonoBehaviour
{
    public GameObject[] m_lineGameObject;
    // Use this for initialization
    void Start()
    {
        m_lineGameObject = new GameObject[5];
        CreateObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateObject()
    {
        //GameObject go = new GameObject("0");
        //go.AddComponent<Rigidbody>();
        for (int i = 0; i < 5; i++)
        {
            m_lineGameObject[i] = new GameObject(i.ToString());
            m_lineGameObject[i].AddComponent<Rigidbody>();
        }
    }
}
