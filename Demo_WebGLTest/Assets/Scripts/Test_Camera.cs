using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class Test_Camera : MonoBehaviour
{
    public Transform[] m_Tagert;
    public GameObject m_Camera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Camera.GetComponent<AutoCam>().SetTarget(m_Tagert[0]);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Camera.GetComponent<AutoCam>().SetTarget(m_Tagert[1]);
        }
    }
}
