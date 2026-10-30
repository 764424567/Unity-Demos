using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

[CustomPropertyDrawer(typeof(TimeAttribute))]
public class TimeAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Float)
        {
            property.floatValue = EditorGUI.FloatField(new Rect(position.x, position.y, position.width * 0.6f, position.height), label, property.floatValue);
            EditorGUI.LabelField(new Rect(position.x + position.width * 0.6f, position.y, position.width * 0.4f, position.height), GetTimeFormat(property.floatValue));
        }
        else
        {
            EditorGUI.HelpBox(new Rect(position.x, position.y, position.width, position.height), "只支持float类型属性", MessageType.Error);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }

    private string GetTimeFormat(float secondsTime)
    {
        TimeAttribute ta = attribute as TimeAttribute;
        //显示小时不显示毫秒
        if (ta.displayHours && !ta.displayMillseconds)
        {
            int l = Convert.ToInt32(secondsTime);
            int hours = l / 3600;
            int minutes = l % 3600 / 60;
            int seconds = l % 3600 % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        //显示毫秒不显示小时
        else if (!ta.displayHours && ta.displayMillseconds)
        {
            int l = Convert.ToInt32(secondsTime * 1000);
            int minutes = l / 60000;
            int seconds = l % 60000 / 1000;
            int millSeconds = l % 60000 % 1000;
            return string.Format("{0:D2}:{1:D2}.{2:D3}", minutes, seconds, millSeconds);
        }
        //既显示小时也显示毫秒
        else if (ta.displayHours && ta.displayMillseconds)
        {
            int l = Convert.ToInt32(secondsTime * 1000);
            int hours = l / 3600000;
            int minutes = l % 3600000 / 60000;
            int seconds = l % 3600000 % 60000 / 1000;
            int millSeconds = l % 3600000 % 60000 % 1000;
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", hours, minutes, seconds, millSeconds);
        }
        //既不显示小时也不显示毫秒
        else
        {
            int l = Convert.ToInt32(secondsTime);
            int minutes = l / 60;
            int seconds = l % 60;
            return string.Format("{0:D2}:{1:D2})", minutes, seconds);
        }
    }
}