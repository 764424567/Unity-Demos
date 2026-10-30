using SK.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UseExtension : MonoBehaviour
{
    List<Action> ActionList;
    void Start()
    {
        ActionList=new List<Action>();
        ActionList.Add(() => { Debug.Log("1"); });
        ActionList.Add(() => { Debug.Log("2"); });
        ActionList.Add(() => { Debug.Log("3"); });
        ActionList.Add(() => { Debug.Log("4"); });

        ActionList.ForEach((value) => { EventAction(value); });
    }

    void EventAction(Action value)
    {
        value.Invoke();
    }
}