using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnGUI : MonoBehaviour
{
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 300));
        GUI.Box(new Rect(0, 0, 200, 200), "我的界面");
        GUI.Button(new Rect(20, 50, 100, 30), "我是个按钮！");
        GUI.EndGroup();
    }
}