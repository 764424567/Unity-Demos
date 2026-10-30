using UnityEngine;
using UnityEditor;

public static class CustomWireGUI {

    public static GUIStyle ButtonStyle()
    {
        GUIStyle style = new GUIStyle(EditorStyles.toolbarButton);
        style.stretchWidth = false;
        style.fixedWidth = 22f;

        return style;
    }
}