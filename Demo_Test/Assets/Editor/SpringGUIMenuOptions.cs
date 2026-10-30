using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpringGUIMenuOptions
{
    [MenuItem("GameObject/UI/Calendar")]
    public static void AddCalendar(MenuCommand menuCommand)
    {
        //GameObject calendar = SpringGUIDefaultControls.CreateCalendar(GetStandardResources());
        //PlaceUIElementRoot(calendar, menuCommand);
        //calendar.transform.localPosition = Vector3.zero;
    }
}
public static class SpringGUIDefaultControls
{
    //public static GameObject CreateCalendar(Resources resources)
    //{
    //    //创建日历组件的详细代码..在Github中下载获取
    //    GameObject datePicker = SpringGUIDefaultControls.CreateDatePicker(GetStandardResources());
    //    PlaceUIElementRoot(datePicker, menuCommand);
    //    datePicker.transform.localPosition = Vector3.zero;
    //}
}