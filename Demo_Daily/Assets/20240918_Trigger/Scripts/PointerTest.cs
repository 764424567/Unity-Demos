using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerTest : MonoBehaviour
{
    public Transform Target;
    Color oricolor = Color.white;//物体本来的颜色

    void Start()
    {
        Target.AddEvent(EventTriggerType.PointerClick, (PointerEventData data) =>
        {
            Debug.Log("点击到物体。");
        });

        AddListener(Target, EventTriggerType.PointerClick, (PointerEventData data) =>
        {
            Debug.Log("点击到物体。");
        });
    }

    public void AddListener(Transform tra,EventTriggerType eventType, Action<PointerEventData> listenedAction)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(data => listenedAction.Invoke((PointerEventData)data));
        tra.GetComponent<EventTrigger>().triggers.Add(entry);
    }

    public void ChangCutMat(int index)
    {
        switch (index)
        {
            case 0:
                Target.GetComponentInChildren<Renderer>().material.color = Color.cyan;
                break;
            case 1:
                Target.GetComponentInChildren<Renderer>().material.color = oricolor;
                break;
            case 2:
                Debug.Log("点击到物体。");
                break;
        }
    }

    public void MouseClickAction(Transform target, Action act = null)
    {
        target.GetComponent<BoxCollider>().enabled = true;
        target.AddListener(EventTriggerType.PointerClick, (PointerEventData data) =>
        {
            target.GetComponent<BoxCollider>().enabled = false;
            act?.Invoke();
        });
    }
}