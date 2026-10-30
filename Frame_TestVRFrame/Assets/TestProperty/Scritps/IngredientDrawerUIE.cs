using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Ingredient))]
public class IngredientDrawerUIE : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // 控制字段缩进 设置为不缩进
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // 计算矩形范围
        var nameRect = new Rect(position.x, position.y, 30, position.height); 
        var amountRect = new Rect(position.x + 35, position.y, 50, position.height);
        var unitRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);


        // 绘制字段
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
        

        // 控制字段缩进 设置为原来的数值
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}