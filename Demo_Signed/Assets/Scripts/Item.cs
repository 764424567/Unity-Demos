using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject canvass;
    Control_Painting m_ControlPainting;

    private void Start()
    {
        m_ControlPainting = GetComponent<Control_Painting>();
    }

    private void Update()
    {
        GameObject g;
        g = GetOverUI(canvass);
        if (g.name == "Image_2")
        {
            m_ControlPainting.enabled = true;
        }
        else
        {
            m_ControlPainting.enabled = false;
        }
    }

    public GameObject GetOverUI(GameObject canvas)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            return results[0].gameObject;
        }

        return null;
    }
}
