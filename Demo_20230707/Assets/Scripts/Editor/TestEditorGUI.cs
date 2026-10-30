using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEditorGUI : EditorWindow
{
    [MenuItem("Tool/TestOnGUI")]
    private static void OpenGUIExample()
    {
        GetWindow<TestEditorGUI>().Show();
    }

    string _tagFiled;
    public void OnGUI()
    {
        _tagFiled = EditorGUILayout.TagField("TagField:", _tagFiled);
    }  
}