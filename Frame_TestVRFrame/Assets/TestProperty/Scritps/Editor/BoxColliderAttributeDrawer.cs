using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BoxColliderAttribute), true)]
public class BoxColliderAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect drawRect = position;
        drawRect.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.LabelField(position, "是否显示");
        SerializedProperty m_Selected = property.FindPropertyRelative("m_IsCollider");
        SerializedProperty m_Panel = property.FindPropertyRelative("m_BoxCollider");
        drawRect.x += 80;
        EditorGUI.PropertyField(drawRect, m_Selected, GUIContent.none);
        if (m_Selected.boolValue)
        {
            drawRect.x += 45;
            drawRect.width = position.width - 125;
            EditorGUI.PropertyField(drawRect, m_Panel, GUIContent.none);
        }

    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        return 1 * EditorGUIUtility.singleLineHeight + 1 * EditorGUIUtility.standardVerticalSpacing;
    }
}