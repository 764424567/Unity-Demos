using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelTagShow : MonoBehaviour
{
    Color oricolor = Color.white;//物体本来的颜色

    private void Start()
    {
        Transform target = this.transform;
        target.AddEvent(EventTriggerType.PointerClick, (PointerEventData data) =>
        {
            Debug.Log("点击到物体。");
        });
    }
    void OnMouseEnter()
    {
        GetComponentInChildren<Renderer>().material.color = Color.cyan;
    }
    void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = oricolor;
    }
}