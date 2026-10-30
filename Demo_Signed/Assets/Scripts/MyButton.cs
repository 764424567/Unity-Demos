using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Selection
{
    Normal,
    Highlighted,
    Pressed,
    Disabled
}

public class MyButton : Button
{
    public Selection m_BtnState;
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        switch (state)
        {
            case SelectionState.Normal:
                //Debug.Log("鼠标离开button！");
                m_BtnState = Selection.Normal;
                break;
            case SelectionState.Highlighted:
                //Debug.Log("鼠标移到button上！");
                m_BtnState = Selection.Highlighted;
                break;
            case SelectionState.Pressed:
                //Debug.Log("鼠标点击button！");
                m_BtnState = Selection.Pressed;
                break;
            case SelectionState.Disabled:
                //Debug.Log("销毁button！");
                m_BtnState = Selection.Disabled;
                break;
            default:
                break;
        }
    }
} 