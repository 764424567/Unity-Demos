using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(BaseAttribute))] //需要重写的类
public class MyTouchJoystick : Editor
{
    BaseAttribute baseAttribute;
    bool isShowBackSetting;
    bool isShowForwardSetting;

    void OnEnable()
    {
        //获取当前编辑自定义的Inspector的对象
        baseAttribute = (BaseAttribute)target;
    }

    //自定义检视面板
    public override void OnInspectorGUI()
    {
        //设置整个布局为垂直布局
        EditorGUILayout.BeginVertical();

        //空行
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //绘制摇杆的背景属性
        isShowBackSetting = EditorGUILayout.Foldout(isShowBackSetting, "BackSprite:");
        if (isShowBackSetting)
        {
            //绘制背景
            baseAttribute.BackSprite = (Sprite)EditorGUILayout.ObjectField("Texture:", baseAttribute.BackSprite, typeof(Sprite), true);
            //水平绘制大小属性面板       
            EditorGUILayout.LabelField("Size:");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            //绘制标签
            EditorGUILayout.LabelField("Width:", GUILayout.MaxWidth(50));
            //绘制可以输入的float类型
            baseAttribute.BackSpriteWidth = EditorGUILayout.FloatField(baseAttribute.BackSpriteWidth);
            EditorGUILayout.LabelField("Height:", GUILayout.MaxWidth(50));
            baseAttribute.BackSpriteHeight = EditorGUILayout.FloatField(baseAttribute.BackSpriteHeight);
            EditorGUILayout.EndHorizontal();
        }
        isShowForwardSetting = EditorGUILayout.Foldout(isShowForwardSetting, "ForwardSprite:");
        if (isShowForwardSetting)
        {
            //绘制前景
            baseAttribute.ForwardSprite = (Sprite)EditorGUILayout.ObjectField("Texture:", baseAttribute.ForwardSprite, typeof(Sprite), true);
            //水平绘制大小属性面板       
            EditorGUILayout.LabelField("Size:");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Width:", GUILayout.MaxWidth(50));
            baseAttribute.ForwardSpriteWidth = EditorGUILayout.FloatField(baseAttribute.BackSpriteWidth);
            EditorGUILayout.LabelField("Height:", GUILayout.MaxWidth(50));
            baseAttribute.ForwardSpriteHeight = EditorGUILayout.FloatField(baseAttribute.BackSpriteHeight);
            EditorGUILayout.EndHorizontal();
        }
    }
}