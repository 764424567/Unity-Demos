//using UnityEditor;

//namespace XChartsDemo
//{
//    [CustomEditor(typeof(ChangePanel), false)]
//    public class ChangeEditor : Editor
//    {
//        //protected ChangePanel m_Target;
//        //protected SerializedProperty m_Script;
//        //protected SerializedProperty m_ChangeModule;
//        //protected virtual void OnEnable()
//        //{
//        //    m_Target = (ChangePanel)target;
//        //    m_Script = serializedObject.FindProperty("m_Script");
//        //    m_ChangeModule = serializedObject.FindProperty("m_ChangeModule");
//        //}

//        //public override void OnInspectorGUI()
//        //{
//        //    if (m_Target == null && target == null)
//        //    {
//        //        base.OnInspectorGUI();
//        //        return;
//        //    }
//        //    serializedObject.Update();

//        //    var size = m_ChangeModule.arraySize;
//        //    size = EditorGUILayout.IntField("Change Module Size", size);
//        //    if (size != m_ChangeModule.arraySize)
//        //    {
//        //        while (size > m_ChangeModule.arraySize) m_ChangeModule.arraySize++;
//        //        while (size < m_ChangeModule.arraySize) m_ChangeModule.arraySize--;
//        //    }
//        //    for (int i = 0; i < size; i++)
//        //    {
//        //        EditorGUILayout.PropertyField(m_ChangeModule.GetArrayElementAtIndex(i));
//        //    }

//        //    serializedObject.ApplyModifiedProperties();
//        //}
//    }
//}