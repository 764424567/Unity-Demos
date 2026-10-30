/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ButtonNavigation
* 创建日期：2021-05-27 13:51:29
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：关闭按键导航
******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ButtonNavigation : Editor 
	{
        [MenuItem("Tools/关闭按键导航")]
        public static void CloseButtonNavigation() {
            var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            var previousSelection = Selection.objects;
            Selection.objects = allGos;
            var selectedTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
            Selection.objects = previousSelection;
            int count = 0;
            foreach (var trans in selectedTransforms)
            {
                if (trans.GetComponent<Button>())
                {
                    Button tmpButton = trans.GetComponent<Button>();
                    Undo.RecordObject(tmpButton, tmpButton.gameObject.name);
                    Navigation tmpNav = new Navigation();
                    tmpNav.mode = Navigation.Mode.None;
                    tmpButton.navigation = tmpNav;
                    EditorUtility.SetDirty(tmpButton);
                    count++;
                }
            }
            Debug.Log("关闭按键导航 " + count + " 个");
        }
	}
}

