using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ChangeModule), true)]
public class ChangeModuleDrawer : PropertyDrawer
{
    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        Rect drawRect = pos;
        drawRect.height = EditorGUIUtility.singleLineHeight;
        SerializedProperty m_Name = prop.FindPropertyRelative("m_Name");
        SerializedProperty m_Selected = prop.FindPropertyRelative("m_Selected");
        SerializedProperty m_Panel = prop.FindPropertyRelative("m_Panel");
        drawRect.width = 30;
        EditorGUI.PropertyField(drawRect, m_Selected, GUIContent.none);
        drawRect.x += 30;
        drawRect.width = 100;
        EditorGUI.PropertyField(drawRect, m_Name, GUIContent.none);
        drawRect.x += 120;
        drawRect.width = 200;
        EditorGUI.PropertyField(drawRect, m_Panel, GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        return 1 * EditorGUIUtility.singleLineHeight + 1 * EditorGUIUtility.standardVerticalSpacing;
    }
}