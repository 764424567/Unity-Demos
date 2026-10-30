using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ButtonHandler
{
    public string showDescription;
    public Action onClickCallBack;
    public ButtonHandler(string showDescription, Action onClickCallBack)
    {
        this.showDescription = showDescription;
        this.onClickCallBack = onClickCallBack;
    }
}
[CanEditMultipleObjects]
//[CustomEditor(typeof(Transform))]
public class TransformEditor2 : Editor
{
    static public Editor instance;

    private bool extensionBool;

    ButtonHandler[] buttonHandlerArray;

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

        extensionBool = EditorPrefs.GetBool("extensionBool");

        buttonHandlerArray = new ButtonHandler[9];
        buttonHandlerArray[0] = new ButtonHandler("Position Copy", () =>
        {
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            // x,y,z
            s.Append(mPos.vector3Value.x.ToString() + "," + mPos.vector3Value.y.ToString() + "," + mPos.vector3Value.z.ToString());
            //添加到剪贴板
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        });
        buttonHandlerArray[1] = new ButtonHandler("Position Paste", () =>
        {
            //把数值打印出来
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            try
            {
                mPos.vector3Value = ParseV3(s);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        });
        buttonHandlerArray[2] = new ButtonHandler("Position Reset", () =>
        {
            mPos.vector3Value = Vector3.zero;
        });
        buttonHandlerArray[3] = new ButtonHandler("Rotation Copy", () =>
        {
            //把数值打印出来
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            s.Append(mRot.quaternionValue.eulerAngles.x + "," + mRot.quaternionValue.eulerAngles.y + "," + mRot.quaternionValue.eulerAngles.z);
            //添加到剪贴板
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        });
        buttonHandlerArray[4] = new ButtonHandler("Rotation Paste", () =>
        {
            //把数值打印出来
            Debug.Log(UnityEngine.GUIUtility.systemCopyBuffer);
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            try
            {
                mRot.quaternionValue = Quaternion.Euler(ParseV3(s));
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        });
        buttonHandlerArray[5] = new ButtonHandler("Rotation Reset", () =>
        {
            mRot.quaternionValue = Quaternion.identity;
        });
        buttonHandlerArray[6] = new ButtonHandler("Scale Copy", () =>
        {
            //把数值打印出来
            var select = Selection.activeGameObject;
            if (select == null)
                return;
            StringBuilder s = new StringBuilder();
            s.Append(mScale.vector3Value.x.ToString() + "," + mScale.vector3Value.y.ToString() + "," + mScale.vector3Value.z.ToString());
            //添加到剪贴板
            UnityEngine.GUIUtility.systemCopyBuffer = s.ToString();
        });
        buttonHandlerArray[7] = new ButtonHandler("Scale Paste", () =>
        {
            //把数值打印出来
            Debug.Log(UnityEngine.GUIUtility.systemCopyBuffer);
            string s = UnityEngine.GUIUtility.systemCopyBuffer;
            try
            {
                mScale.vector3Value = ParseV3(s);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
                return;
            }
        });
        buttonHandlerArray[8] = new ButtonHandler("Scale Reset", () =>
        {
            mScale.vector3Value = Vector3.one;
        });
    }

    private void OnDisable()
    {
        EditorPrefs.SetBool("extensionBool", extensionBool);
    }

    public override void OnInspectorGUI()
    {
        instance.OnInspectorGUI();

        GUI.color = Color.cyan;
        extensionBool = EditorGUILayout.Foldout(extensionBool, "拓展功能");
        if (extensionBool)
        {
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < buttonHandlerArray.Length; i++)
            {
                ButtonHandler temporaryButtonHandler = buttonHandlerArray[i];
                if (GUILayout.Button(temporaryButtonHandler.showDescription, "toolbarbutton"))//, GUILayout.MaxWidth(150)
                {
                    temporaryButtonHandler.onClickCallBack();
                }
                GUILayout.Space(5);
                if ((i + 1) % 3 == 0 || i + 1 == buttonHandlerArray.Length)
                {
                    EditorGUILayout.EndHorizontal();
                    if (i + 1 < buttonHandlerArray.Length)
                    {
                        GUILayout.Space(5);
                        EditorGUILayout.BeginHorizontal();
                    }
                }
            }
        }
        GUI.color = Color.white;

        serializedObject.ApplyModifiedProperties();
    }

    Vector3 ParseV3(string strVector3)
    {
        string[] s = strVector3.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }
}