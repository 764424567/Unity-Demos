using UnityEngine;
using UnityEngine.UI;

public class TestButton : Button
{
    enum Selection
    {
        Normal,
        Highlighted,
        Pressed,
        Disabled
    }
    Selection selection;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        switch (state)
        {
            case SelectionState.Normal:
                Debug.Log("Normal");
                selection = Selection.Normal;
                break;
            case SelectionState.Highlighted:
                Debug.Log("Highlighted");
                selection = Selection.Highlighted;
                break;
            case SelectionState.Pressed:
                Debug.Log("Pressed");
                selection = Selection.Pressed;
                break;
            case SelectionState.Disabled:
                Debug.Log("Disabled");
                selection = Selection.Disabled;
                break;
            default:
                break;
        }
    }

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 10;
        switch (selection)
        {
            case Selection.Highlighted:
                GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 25), "Highlighted");
                break;
            case Selection.Pressed:
                GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 25), "Pressed");
                break;
            default:
                break;
        }
    }
}