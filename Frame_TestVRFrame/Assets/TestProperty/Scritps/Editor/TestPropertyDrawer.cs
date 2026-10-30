using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(TestItemProperty), true)]
public class TestPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        Rect drawRect = pos;
        drawRect.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.LabelField(pos, "是否显示");
        SerializedProperty m_Selected = prop.FindPropertyRelative("m_Selected");
        SerializedProperty m_Panel = prop.FindPropertyRelative("m_Panel");
        drawRect.x += 80;
        drawRect.width = 50;
        EditorGUI.PropertyField(drawRect, m_Selected, GUIContent.none);
        if (m_Selected.boolValue)
        {
            drawRect.x += 40;
            drawRect.width = 180;
            EditorGUI.PropertyField(drawRect, m_Panel, GUIContent.none);
        }
        
    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        return 1 * EditorGUIUtility.singleLineHeight + 1 * EditorGUIUtility.standardVerticalSpacing;
    }
}
