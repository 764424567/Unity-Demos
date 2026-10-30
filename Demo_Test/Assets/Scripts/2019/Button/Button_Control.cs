using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Control : MonoBehaviour
{
    GameObject m_UIWall;
    GameObject m_UIFroor;
    Camera m_Camera;
    Vector3 m_HitPoint;
    GameObject m_Parfab;

    private void Awake()
    {
        m_UIWall = GameObject.Find("PanelWall");
        m_UIFroor = GameObject.Find("PanelFloor");
        m_Camera = GameObject.Find("(Singleton)RTEditor.EditorCamera").GetComponent<Camera>();
        m_UIFroor.SetActive(false);
        m_UIWall.SetActive(false);
    }

    private void Update()
    {
        ButtonOnClick();
    }

    public void ButtonOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("BUttonDown");
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.transform.name);
                m_HitPoint = hit.point;
                switch (hit.transform.name)
                {
                    case "Wall":
                        m_UIWall.SetActive(true);
                        m_UIFroor.SetActive(false);
                        break;
                    case "floor":
                        m_UIWall.SetActive(false);
                        m_UIFroor.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void ButtonOnClick_Wall()
    {
        m_Parfab = (GameObject)Resources.Load("Cube");
        Instantiate(m_Parfab, m_HitPoint, Quaternion.identity);
    }
}
