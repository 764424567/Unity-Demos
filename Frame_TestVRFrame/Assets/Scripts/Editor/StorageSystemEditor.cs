/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StorageSystemEditor
* 创建日期：2021-04-19 16:41:20
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：回放系统脚本绑定移除辅助功能脚本
******************************************************************************/

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class StorageSystemEditor : EditorWindow
    {
        [MenuItem("GameObject/Rainier/一键绑定EventStorageControlLogic脚本", priority = 0)]
        public static void AddEventStorageControlLogic() {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            int dataModelCount = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<ObjDataModel>() || trans.GetComponent<MvvmContext>())
                {
                    dataModelCount++;
                    if (!trans.GetComponent<EventStorageControlLogic>())
                    {
                        trans.gameObject.AddComponent<EventStorageControlLogic>();
                        EditorUtility.SetDirty(trans);
                        count++;
                    }
                }
            }
            if (dataModelCount == 0)
            {
                Debug.Log("场景中无DataModel脚本，不能添加EventStorageControlLogic脚本。");
            }
            else
            {
                if (count == 0)
                {
                    Debug.Log("场景中已添加过EventStorageControlLogic脚本。");
                }
                else
                {
                    Debug.Log("添加成功，共添加 " + count + " 个EventStorageControlLogic脚本。");
                }
            }
            
        }

        [MenuItem("GameObject/Rainier/一键移除EventStorageControlLogic脚本", priority = 0)]
        public static void RemoveEventStorageControlLogic()
        {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<EventStorageControlLogic>())
                {
                    DestroyImmediate(trans.GetComponent<EventStorageControlLogic>());
                    EditorUtility.SetDirty(trans);
                    count++;
                }
            }
            if (count == 0)
            {
                Debug.Log("场景中未发现 EventStorageControlLogic 脚本");
            }
            else
            {
                Debug.Log("移除完毕,共移除 " + count + " 个 EventStorageControlLogic 脚本");
            }
        }

        [MenuItem("GameObject/Rainier/3D物体一键添加Unique脚本", priority = 0)]
        public static void AddOBJUniqueID()
        {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<ObjDataModel>())
                {
                    if (!trans.GetComponent<UniqueID>())
                    {
                        trans.gameObject.AddComponent<UniqueID>();
                        EditorUtility.SetDirty(trans);
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Debug.Log("场景中3D物体无需添加UniqueID脚本。");
            }
            else
            {
                Debug.Log("添加成功，共添加 " + count + " 个UniqueID脚本。");
            }
            
        }

        [MenuItem("GameObject/Rainier/3D物体一键移除Unique脚本", priority = 0)]
        public static void RemoveOBJUniqueID()
        {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<ObjDataModel>())
                {
                    if (trans.GetComponent<UniqueID>())
                    {
                        DestroyImmediate(trans.GetComponent<UniqueID>());
                        EditorUtility.SetDirty(trans);
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Debug.Log("3D物体无需移除UniqueID脚本");
            }
            else
            {
                Debug.Log("移除成功，3D物体共移除" + count + "个UniqueID脚本");
            }
        }

        [MenuItem("GameObject/Rainier/UI一键移除Unique脚本", priority = 0)]
        public static void RemoveUIUniqueID()
        {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<RectTransform>())
                {
                    if (trans.GetComponent<UniqueID>())
                    {
                        DestroyImmediate(trans.GetComponent<UniqueID>());
                        EditorUtility.SetDirty(trans);
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Debug.Log("UI无需移除UniqueID脚本");
            }
            else
            {
                Debug.Log("移除成功，UI共移除" + count + "个UniqueID脚本");
            }
        }
    }
}

