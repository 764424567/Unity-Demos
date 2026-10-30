/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ResetUniqueID
* 创建日期：2020-04-28 10:18:49
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 
    /// </summary>
	public class ResetUniqueID : Editor 
	{

        /// <summary>
        /// 有些物体未激活状态下，id为-1,需要在编辑下激活进行编号 
        /// </summary>
        [MenuItem("Rainier/Reset UniqueID")]
        static void ResetUniqueIDNumber()
        {
            GameObject[] roots = EditorSceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject item in roots)
            {

                UniqueID[] uniqueIDs = item.GetComponentsInChildren<UniqueID>(true);

                foreach (var uid in uniqueIDs)
                {
                    System.Reflection.MethodInfo minfo = uid.GetType().GetMethod("Awake", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
                    minfo.Invoke(uid, null);
                }
            }
        }

    }
}

