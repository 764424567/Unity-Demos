using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_test : MonoBehaviour
{
    float m_MaxDistance = 100;
    string m_LayerName = "wall";
    Camera m_Camera;
    GameObject m_Parfab;
    // Use this for initialization
    void Start()
    {
        m_Camera = GameObject.Find("(Singleton)RTEditor.EditorCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MounseOnClickEvent();
    }

    private void MounseOnClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                
                if (hitInfo.transform.gameObject.layer == 8)
                {
                    Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，在scene视图中能看到由摄像机发射出的射线
                    Debug.Log("点击到物体");
                    Vector3 temoVec3 = m_Camera.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log(temoVec3);
                    Debug.Log(Input.mousePosition);
                    Debug.Log(hitInfo.point);
                    m_Parfab = (GameObject)Resources.Load("Cube");
                    Instantiate(m_Parfab, hitInfo.point, Quaternion.identity);
                }
            }
        }
    }
}
