using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomEditorTest : MonoBehaviour
{
    public GameObject StartObj = null;
    public GameObject EndObj = null;
}


[CustomEditor(typeof(CustomEditorTest))]
public class CustomDitorTestEditor : Editor
{
    public GameObject StartObj = null;
    public GameObject EndObj = null;
    void OnEnable()
    {
    }
    public override void OnInspectorGUI()
    {
        //Debug.Log("ShowWindows");
        //serializedObject.Update();
        ////设置整个布局为垂直布局
        //EditorGUILayout.BeginVertical();
        //EditorGUI.LabelField(new Rect(0, 0, 85, 20),"Start:");
        //StartObj = (GameObject)EditorGUI.ObjectField(new Rect(0, 20, 150, 20), StartObj, typeof(GameObject), true);
        //EditorGUI.LabelField(new Rect(0, 40, 85, 20),"End:");
        //EndObj = (GameObject)EditorGUI.ObjectField(new Rect(0, 60, 150, 20), EndObj, typeof(GameObject), true);
        if (GUI.Button(new Rect(0, 80, 85, 20), "切换"))
        {
            StartObj.SetActive(false);
            EndObj.SetActive(true);
        }
        //EditorGUILayout.EndHorizontal();
        //serializedObject.ApplyModifiedProperties();
    }
}