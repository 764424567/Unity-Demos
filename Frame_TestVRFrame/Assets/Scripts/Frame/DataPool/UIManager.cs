/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UIManager
* 创建日期：2020-05-22 15:59:10
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：UI对象池
******************************************************************************/

using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using UnityEngine;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class UIManager  
	{
        /// <summary>
        /// UI对象池
        /// </summary>
        private Dictionary<string, Dictionary<string, UIBehaviours>> uiItems = new Dictionary<string, Dictionary<string, UIBehaviours>>();

        /// <summary>
        /// 保存单一对象
        /// </summary>
        /// <param name="panelName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        /// <param name="tmpObj">引用</param>
        public void SaveGameObject(string panelName, string objName, UIBehaviours tmpObj)
        {
            if (uiItems.ContainsKey(panelName))
            {
                try
                {
                    uiItems[panelName].Add(objName, tmpObj);
                }
                catch (System.ArgumentException)
                {
                    Debug.LogError("UI对象命名有重名: " + panelName + "，" + objName + "请检查");
                }
            }
            else
            {
                Dictionary<string, UIBehaviours> tmpDict = new Dictionary<string, UIBehaviours>();
                tmpDict.Add(objName, tmpObj);
                uiItems.Add(panelName, tmpDict);
            }
        }

        
        /// <summary>
        /// 删除UI对象
        /// </summary>
        /// <param name="panleName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        public void DeleteGameObject(string panleName, string objName)
        {
            if (uiItems.ContainsKey(panleName))
            {
                uiItems[panleName].Remove(objName);
            }
        }

        /// <summary>
        /// 获取UI对象
        /// </summary>
        /// <param name="panelName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        /// <returns>对象</returns>
        public GameObject GetGameObject(string panelName, string objName)
        {
            if (uiItems.ContainsKey(panelName))
            {
                if (uiItems[panelName].ContainsKey(objName))
                {
                    return uiItems[panelName][objName].gameObject;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取viewmodel组件
        /// </summary>
        /// <typeparam name="T">viewmodel</typeparam>
        /// <param name="panelName">根节点panelName</param>
        /// <param name="objName">物体名字</param>
        /// <returns></returns>
        public T GetViewModel<T>(string panelName, string objName) where T:ViewModel
        {
            if (uiItems.ContainsKey(panelName))
            {
                if (uiItems[panelName].ContainsKey(objName))
                {
                    return uiItems[panelName][objName].GetComponent<T>();
                }
            }
            return null;
        }

        /// <summary>
        /// 获取UI对象
        /// </summary>
        /// <param name="panelName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        /// <returns>对象</returns>
        public UIBehaviours GetUIBehaviours(string panelName, string objName)
        {
            if (uiItems.ContainsKey(panelName))
            {
                if (uiItems[panelName].ContainsKey(objName))
                {
                    return uiItems[panelName][objName];
                }
            }
            return null;
        }
    }
}

