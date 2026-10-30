using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{
    static public Editor instance;
    Transform m_Transform;

    private bool extensionBool;

    string axisName = "Local";
    bool isAxis = false;
    bool isDefined = false;
    string row1;
    string row2;
    string row3;
    string row4;
    //当前的本地坐标
    SerializedProperty mPos;
    //当前的本地旋转
    SerializedProperty mRot;
    //当前的本地缩放
    SerializedProperty mScale;

    private void OnEnable()
    {
        instance = this;

        var editorType = Assembly.GetAssembly(typeof(Editor)).GetTypes().FirstOrDefault(m => m.Name == "TransformInspector");
        instance = CreateEditor(targets, editorType);

        isAxis = EditorPrefs.GetBool("isAxis");
        isDefined = EditorPrefs.GetBool("isDefined");

        m_Transform = this.target as Transform;

        if (this)
        {
            try
            {
                var so = serializedObject;
                mPos = so.FindProperty("m_LocalPosition");
                mRot = so.FindProperty("m_LocalRotation");
                mScale = so.FindProperty("m_LocalScale");
            }
            catch { }
        }
    }

    private void OnDisable()
    {
        EditorPrefs.SetBool("extensionBool", extensionBool);
        EditorPrefs.SetBool("isDefined", isDefined);
    }

    public override void OnInspectorGUI()
    {
        instance.OnInspectorGUI();

        extensionBool = EditorPrefs.GetBool("extensionBool");
        extensionBool = EditorGUILayout.Foldout(extensionBool, "拓展功能");

        if (extensionBool)
        {
            OnTopGUI();

            OnTransformGUI();

            OnPositionGUI();

            OnRotationGUI();

            OnScaleGUI();

            OnDefindGUI();
        }
    }

    void OnTopGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");

        if (GUILayout.Button("Local/Global"))
        {
            isAxis = !isAxis;
            EditorPrefs.SetBool("isAxis", isAxis);
        }
        axisName = isAxis ? "Local" : "Global";
        GUILayout.Label("当前坐标轴：" + axisName);
        EditorGUILayout.EndHorizontal();
    }

    void OnTransformGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Transform");
        if (GUILayout.Button("Copy"))
        {
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            s.Append("Transform_");
            if (isAxis)
            {
                s.Append(FormatVe3(m_Transform.localPosition) + "_");
                s.Append(FormatVe3(m_Transform.localRotation.eulerAngles) + "_");
                s.Append(FormatVe3(m_Transform.localScale));
            }
            else
            {
                s.Append(FormatVe3(m_Transform.position) + "_");
                s.Append(FormatVe3(m_Transform.rotation.eulerAngles) + "_");
                s.Append(FormatVe3(m_Transform.localScale));
            }
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        }
        if (GUILayout.Button("Paste"))
        {
            if (isDefined)
            {
                Debug.LogError("不支持自定义文本！");
                UnityEngine.GUIUtility.systemCopyBuffer = "";
                return;
            }
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            string[] sArr = s.Split('_');
            if (sArr[0] != "Transform" || s == "")
            {
                Debug.LogError("未复制Transform组件内容！");
                return;
            }
            try
            {
                m_Transform.position = ParseV3(sArr[1]);
                m_Transform.rotation = Quaternion.Euler(ParseV3(sArr[2]));
                m_Transform.localScale = ParseV3(sArr[3]);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        }
        if (GUILayout.Button("Reset"))
        {
            m_Transform.position = Vector3.zero;
            m_Transform.rotation = Quaternion.identity;
            m_Transform.localScale = Vector3.one;
        }
        EditorGUILayout.EndHorizontal();
    }

    void OnPositionGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Position");
        if (GUILayout.Button("Copy"))
        {
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            if (isAxis)
            {
                s.Append(FormatVe3(m_Transform.localPosition));
            }
            else
            {
                s.Append(FormatVe3(m_Transform.position));
            }
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
            Debug.Log(s);
        }
        if (GUILayout.Button("Paste"))
        {
            if (isDefined)
            {
                Debug.LogError("不支持自定义文本！");
                UnityEngine.GUIUtility.systemCopyBuffer = "";
                return;
            }
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            if (s == "")
            {
                Debug.LogError("未复制Position内容！");
                return;
            }
            try
            {
                m_Transform.position = ParseV3(s);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        }
        if (GUILayout.Button("Reset"))
        {
            m_Transform.position = Vector3.zero;
        }
        EditorGUILayout.EndHorizontal();
    }

    void OnRotationGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Rotation");
        if (GUILayout.Button("Copy"))
        {
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            if (isAxis)
            {
                s.Append(FormatVe3(m_Transform.localRotation.eulerAngles));
            }
            else
            {
                s.Append(FormatVe3(m_Transform.rotation.eulerAngles));
            }
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        }
        if (GUILayout.Button("Paste"))
        {
            if (isDefined)
            {
                Debug.LogError("不支持自定义文本！");
                UnityEngine.GUIUtility.systemCopyBuffer = "";
                return;
            }
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            if (s == "")
            {
                Debug.LogError("未复制Rotation内容！");
                return;
            }
            try
            {
                m_Transform.rotation = Quaternion.Euler(ParseV3(s));
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        }
        if (GUILayout.Button("Reset"))
        {
            m_Transform.rotation = Quaternion.identity;
        }
        EditorGUILayout.EndHorizontal();
    }

    void OnScaleGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Scale");
        if (GUILayout.Button("Copy"))
        {
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            s.Append(FormatVe3(m_Transform.localScale));
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        }
        if (GUILayout.Button("Paste"))
        {
            if (isDefined)
            {
                Debug.LogError("不支持自定义文本！");
                UnityEngine.GUIUtility.systemCopyBuffer = "";
                return;
            }
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            if (s == "")
            {
                Debug.LogError("未复制Scale内容！");
                return;
            }
            try
            {
                m_Transform.localScale = ParseV3(s);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        }
        if (GUILayout.Button("Reset"))
        {
            m_Transform.localScale = Vector3.one;
        }
        EditorGUILayout.EndHorizontal();
    }

    void OnDefindGUI()
    {
        GUILayout.BeginVertical();
        isDefined = GUILayout.Toggle(isDefined, "启用自定义文本拼接");
        if (isDefined)
        {
            GUILayout.BeginHorizontal();
            row1 = GUILayout.TextField(row1);
            GUILayout.Label("X");
            row2 = GUILayout.TextField(row2);
            GUILayout.Label("Y");
            row3 = GUILayout.TextField(row3);
            GUILayout.Label("Z");
            row4 = GUILayout.TextField(row4);
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }

    // x,y,z
    Vector3 ParseV3(string strVector3)
    {
        string[] s = strVector3.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }

    // x,y,z
    string FormatVe3(Vector3 ve3)
    {
        string str;
        if (!isDefined)
        {
            str = ve3.x + "," + ve3.y + "," + ve3.z;
        }
        else
        {
            str = row1 + ve3.x + row2 + ve3.y + row3 + ve3.z + row4;
        }
        return str;
    }
}