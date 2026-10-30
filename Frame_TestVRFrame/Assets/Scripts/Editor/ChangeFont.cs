/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: ChangeFont.cs
  Author:张辰       Version :1.1          Date: 2020-1-10
  Description:批量换字体(拖入要替换的字体)
  V1.1更新内容:新增仅替换unity自带字体功能
************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class ChangeFont : EditorWindow
{
    private Font getFont;
    private static Font targetFont;


    [MenuItem("Tools/批量换字体")]
    public static void Open()
    {
        EditorWindow.GetWindow(typeof(ChangeFont));
    }
    

    void OnGUI()
    {
        getFont = (Font)EditorGUILayout.ObjectField(getFont, typeof(Font), true, GUILayout.MinWidth(100f));
        targetFont = getFont;
        if (GUILayout.Button("替换全部字体"))
        {
            ChangeFonts();
        }
        if (GUILayout.Button("仅替换Unity自带字体"))
        {
            ChangeArialFonts();
        }
    }

    public static void ChangeFonts()
    {
        var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        var previousSelection = Selection.objects;
        Selection.objects = allGos;
        var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
        Selection.objects = previousSelection;
        int count = 0;
        foreach (var trans in selectedTransforms) {
            if (trans.GetComponent<Text>()) {
                Text tmptext = trans.GetComponent<Text>();
                Undo.RecordObject(tmptext, tmptext.gameObject.name);
                tmptext.font = targetFont;
                EditorUtility.SetDirty(tmptext);
                count++;
            }
        }
        Debug.Log("替换 " + targetFont.name + " 字体完毕,共替换 " + count + " 个");
    }

    public static void ChangeArialFonts()
    {
        var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        var previousSelection = Selection.objects;
        Selection.objects = allGos;
        var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
        Selection.objects = previousSelection;
        int count = 0;
        foreach (var trans in selectedTransforms)
        {
            if (trans.GetComponent<Text>())
            {
                Text tmptext = trans.GetComponent<Text>();
                Undo.RecordObject(tmptext, tmptext.gameObject.name);
                if (tmptext.font.name == "Arial")
                {
                    tmptext.font = targetFont;
                    EditorUtility.SetDirty(tmptext);
                    count++;
                }
                
            }
        }
        if (count==0)
        {
            Debug.Log("场景中所有Text中已经无unity自带字体");
        }
        else
        {
            Debug.Log("替换 " + targetFont.name + " 字体完毕,共替换 " + count + " 个");
        }
        
    }
}
