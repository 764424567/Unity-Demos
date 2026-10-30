using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(Person))]
//public class PersonDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);
//        //FocusType.Passive 使用Tab键切换时不会被选中，FocusType.Keyboard 使用Tab键切换时会被选中，很显然这里我们不需要label能被选中进行编辑 
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//        //不让indentLevel层级影响到同一行的绘制，因为PropertyDrawer在很多地方都有可能被用到，可能出现嵌套使用
//        var indent = EditorGUI.indentLevel;
//        EditorGUI.indentLevel = 0;
//        var nameRect = new Rect(position.x, position.y, 80, position.height);
//        var typeRect = new Rect(position.x + 85, position.y, 30, position.height);
//        var overviewRect = new Rect(position.x + 120, position.y, position.width - 120, position.height);
//        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("Name"), GUIContent.none);
//        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("Age"), GUIContent.none);
//        EditorGUI.PropertyField(overviewRect, property.FindPropertyRelative("Sex"), GUIContent.none);
//        EditorGUI.indentLevel = indent;
//        EditorGUI.EndProperty();
//    }
//}