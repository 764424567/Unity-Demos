using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UnityActonTools
{
    /// <summary>
    /// 为EventTrigger的事件类型绑定Action方法
    /// </summary>
    /// <param name="trigger">EventTrigger组件对象</param>
    /// <param name="eventType">事件类型</param>
    /// <param name="listenedAction">要执行的方法</param>
    public static void AddListener(this GameObject obj, EventTriggerType eventType, Action<PointerEventData> listenedAction)
    {
        //添加组件——EventTrigger
        if (obj.GetComponent<EventTrigger>() != null)
        {
            UnityEngine.Object.Destroy(obj.GetComponent<EventTrigger>());
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(data => listenedAction.Invoke((PointerEventData)data));
        obj.gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    }
    public static void AddListener(this Transform tra, EventTriggerType eventType, Action<PointerEventData> listenedAction)
    {
        //添加组件——EventTrigger
        //if (tra.GetComponent<EventTrigger>() != null)
        //{
        //    UnityEngine.Object.Destroy(tra.GetComponent<EventTrigger>());
        //}
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(data => listenedAction.Invoke((PointerEventData)data));
        tra.gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
    }
    public static void AddEvent(this Transform tra, EventTriggerType eventType, Action<PointerEventData> listenedAction)
    {
        //添加组件——EventTrigger
        EventTrigger trigger = null;
        if (tra.GetComponent<EventTrigger>() != null)
        {
            trigger = tra.GetComponent<EventTrigger>();
        }
        else
        {
            trigger = tra.gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(data => listenedAction.Invoke((PointerEventData)data));
        trigger.triggers.Add(entry);
    }
}
