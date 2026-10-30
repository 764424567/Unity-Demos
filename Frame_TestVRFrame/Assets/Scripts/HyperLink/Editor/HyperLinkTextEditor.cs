using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(HyperLink1Text), true)]
[CanEditMultipleObjects]
public class HyperLinkTextEditor : GraphicEditor
{

    SerializedProperty m_Text;
    SerializedProperty m_FontData;

    SerializedProperty m_TextIndent;
    SerializedProperty m_IndentCharCount;

    SerializedProperty m_IsHaveGap;
    SerializedProperty m_IsRichTextColor;
    SerializedProperty m_GapColor;
    SerializedProperty m_LineColor;
    SerializedProperty m_LineOffset;
    SerializedProperty m_LineHeight;
    SerializedProperty m_GapLineLength;
    SerializedProperty m_GapLineRario;
    SerializedProperty m_GapPrefabPath;

    SerializedProperty m_IsHaveHref;
    SerializedProperty m_HrefLineOffset;
    SerializedProperty m_HrefLineHeight;
    SerializedProperty m_onHrefClick;
    SerializedProperty m_HrefLineLength;
    SerializedProperty m_HrefLineRario;

    SerializedProperty m_IsHaveLine;
    SerializedProperty m_LowLineOffset;
    SerializedProperty m_MiddleLineOffset;
    SerializedProperty m_HighLineOffset;
    SerializedProperty m_LineHeightOffset;
    SerializedProperty m_LineLength;
    SerializedProperty m_LineRario;

    private static bool gapToggle;
    private static bool gapFaldout = true;

    private static bool hrefToggle;
    private static bool hrefFaldout = true;

    private static bool lineToggle;
    private static bool lineFaldout = true;

    protected override void OnEnable()
    {
        base.OnEnable();

        m_Text = serializedObject.FindProperty("m_Text");
        m_FontData = serializedObject.FindProperty("m_FontData");

        m_TextIndent = serializedObject.FindProperty("textIndent");
        m_IndentCharCount = serializedObject.FindProperty("indentCharCount");

        m_IsHaveGap = serializedObject.FindProperty("isHaveGap");
        m_IsRichTextColor = serializedObject.FindProperty("m_IsRichTextColor");
        m_GapColor = serializedObject.FindProperty("m_GapColor");
        m_LineColor = serializedObject.FindProperty("m_LineColor");
        m_LineOffset = serializedObject.FindProperty("m_LineOffset");
        m_LineHeight = serializedObject.FindProperty("m_LineHeight");
        m_GapLineLength = serializedObject.FindProperty("m_SingleLineLength");
        m_GapLineRario = serializedObject.FindProperty("m_BrokenLineRario");
        m_GapPrefabPath = serializedObject.FindProperty("InputFieldPrefabPath");

        m_IsHaveHref = serializedObject.FindProperty("isHaveHref");
        m_HrefLineOffset = serializedObject.FindProperty("m_HrefLineOffset");
        m_HrefLineHeight = serializedObject.FindProperty("m_HrefLineHeight");
        m_onHrefClick = serializedObject.FindProperty("onHrefClick");
        m_HrefLineLength = serializedObject.FindProperty("m_HrefLineLength");
        m_HrefLineRario = serializedObject.FindProperty("m_HrefLineRario");

        m_IsHaveLine = serializedObject.FindProperty("isHaveLine");
        m_LowLineOffset = serializedObject.FindProperty("m_LowLineOffset");
        m_MiddleLineOffset = serializedObject.FindProperty("m_MiddleLineOffset");
        m_HighLineOffset = serializedObject.FindProperty("m_HighLineOffset");
        m_LineHeightOffset = serializedObject.FindProperty("m_LineHeightOffset");
        m_LineLength = serializedObject.FindProperty("m_LineLength");
        m_LineRario = serializedObject.FindProperty("m_LineRario");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_Text);
        EditorGUILayout.PropertyField(m_FontData);

        //EditorGUILayout.PropertyField(m_TextIndent, new GUIContent("    TextIndent"));
        //if (m_TextIndent.boolValue)
        //    EditorGUILayout.PropertyField(m_IndentCharCount, new GUIContent("    IndentCharCount"));

        AppearanceControlsGUI();

        //if (m_IsHaveGap.boolValue)
        //{
        //    gapToggle = EditorGUILayout.Toggle("GapInfo", gapToggle);
        //    if (gapToggle)
        //    {
        //        gapFaldout = EditorGUILayout.Foldout(gapFaldout, "GapInfo");
        //        if (gapFaldout)
        //        {
        //            m_IsRichTextColor.boolValue = EditorGUILayout.Toggle("    IsRichTextColor", m_IsRichTextColor.boolValue);
        //            EditorGUILayout.PropertyField(m_GapColor, new GUIContent("    GapColor"));
        //            EditorGUILayout.PropertyField(m_LineColor, new GUIContent("    LineColor"));
        //            EditorGUILayout.PropertyField(m_LineOffset, new GUIContent("    LineOffset"));
        //            EditorGUILayout.PropertyField(m_LineHeight, new GUIContent("    LineHeight"));
        //            EditorGUILayout.PropertyField(m_GapLineLength, new GUIContent("    LineLength"));
        //            EditorGUILayout.PropertyField(m_GapLineRario, new GUIContent("    LineRario"));
        //            EditorGUILayout.PropertyField(m_GapPrefabPath, new GUIContent("    GapPrefabPath"));
        //            EditorGUILayout.Space();
        //        }
        //    }
        //}

        hrefToggle = EditorGUILayout.Toggle("HrefInfo", hrefToggle);
        if (hrefToggle)
        {
            hrefFaldout = EditorGUILayout.Foldout(hrefFaldout, "HrefInfo");
            if (hrefFaldout)
            {
                EditorGUILayout.PropertyField(m_HrefLineOffset, new GUIContent("    LineOffset"));
                EditorGUILayout.PropertyField(m_HrefLineHeight, new GUIContent("    LineHeight"));
                EditorGUILayout.PropertyField(m_HrefLineLength, new GUIContent("    LineLength"));
                EditorGUILayout.PropertyField(m_HrefLineRario, new GUIContent("    LineRario"));
                EditorGUILayout.PropertyField(m_onHrefClick);
            }
        }
        //if (m_IsHaveHref.boolValue)
        //{
        //    hrefToggle = EditorGUILayout.Toggle("HrefInfo", hrefToggle);
        //    if (hrefToggle)
        //    {
        //        hrefFaldout = EditorGUILayout.Foldout(hrefFaldout, "HrefInfo");
        //        if (hrefFaldout)
        //        {
        //            EditorGUILayout.PropertyField(m_HrefLineOffset, new GUIContent("    LineOffset"));
        //            EditorGUILayout.PropertyField(m_HrefLineHeight, new GUIContent("    LineHeight"));
        //            EditorGUILayout.PropertyField(m_HrefLineLength, new GUIContent("    LineLength"));
        //            EditorGUILayout.PropertyField(m_HrefLineRario, new GUIContent("    LineRario"));
        //            EditorGUILayout.PropertyField(m_onHrefClick);
        //        }
        //    }
        //}

        //if (m_IsHaveLine.boolValue)
        //{
        //    lineToggle = EditorGUILayout.Toggle("LineInfo", lineToggle);
        //    if (lineToggle)
        //    {
        //        lineFaldout = EditorGUILayout.Foldout(lineFaldout, "LineInfo");
        //        if (lineFaldout)
        //        {
        //            EditorGUILayout.PropertyField(m_LowLineOffset, new GUIContent("    LowLineOffset"));
        //            EditorGUILayout.PropertyField(m_MiddleLineOffset, new GUIContent("    MiddleLineOffset"));
        //            EditorGUILayout.PropertyField(m_HighLineOffset, new GUIContent("    HighLineOffset"));
        //            EditorGUILayout.PropertyField(m_LineHeightOffset, new GUIContent("    LineHeightOffset"));
        //            EditorGUILayout.PropertyField(m_LineLength, new GUIContent("    LineLength"));
        //            EditorGUILayout.PropertyField(m_LineRario, new GUIContent("    LineRario"));
        //        }
        //    }
        //}

        EditorGUILayout.PropertyField(m_RaycastTarget);

        serializedObject.ApplyModifiedProperties();
    }

}
