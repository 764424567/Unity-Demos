/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ObjManager
* 创建日期：2020-05-27 19:41:11
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：物体对象池
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{

	public class ObjManager  
	{

        private Dictionary<string, Dictionary<string, ObjBehaviours>> ObjMembers = new Dictionary<string, Dictionary<string, ObjBehaviours>>();

        /// <summary>
        /// 保存单一对象
        /// </summary>
        /// <param name="panelName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        /// <param name="tmpObj">引用</param>
        public void SetObjBehaviour(string panelName, string objName, ObjBehaviours tmpObj)
        {
            if (ObjMembers.ContainsKey(panelName))
            {
                try
                {
                    ObjMembers[panelName].Add(objName, tmpObj);
                }
                catch (System.ArgumentException)
                {
                    Debug.LogError("UI对象命名有重名: " + panelName + "，" + objName + "请检查");
                }
            }
            else
            {
                Dictionary<string, ObjBehaviours> tmpDict = new Dictionary<string, ObjBehaviours>();
                tmpDict.Add(objName, tmpObj);
                ObjMembers.Add(panelName, tmpDict);
            }
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="parentName">根节点名字</param>
        /// <param name="objName">对象名</param>
        public void DeleteObjBehaviour(string parentName, string objName)
        {
            if (ObjMembers.ContainsKey(parentName))
            {
                ObjMembers[parentName].Remove(objName);
            }
        }

        /// <summary>
        /// 获取物体
        /// </summary>
        /// <param name="panelName">根节点父物体名字</param>
        /// <param name="objName">对象名</param>
        /// <returns>对象</returns>
        public ObjBehaviours GetObjBehaviours(string panelName, string objName)
        {
            if (ObjMembers.ContainsKey(panelName))
            {
                if (ObjMembers[panelName].ContainsKey(objName))
                {
                    return ObjMembers[panelName][objName];
                }
            }
            return null;
        }

        /// <summary>
        /// 获取物体
        /// </summary>
        /// <param name="parentName">根节点panel名字</param>
        /// <param name="objName">对象名</param>
        /// <returns>对象</returns>
        public GameObject GetGameObject(string parentName, string objName)
        {
            if (ObjMembers.ContainsKey(parentName))
            {
                if (ObjMembers[parentName].ContainsKey(objName))
                {
                    return ObjMembers[parentName][objName].gameObject;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取物体数据实体
        /// </summary>
        /// <typeparam name="T">数据实体</typeparam>
        /// <param name="objName">对象名</param>
        /// <returns></returns>
        public T GetDataModel<T>(string parentName, string objName) where T : DataModelBehaviour {
            if (ObjMembers.ContainsKey(parentName) )
            {
                if (ObjMembers[parentName].ContainsKey(objName))
                {
                    return ObjMembers[parentName][objName].GetComponent<T>();
                }
                Debug.LogError("此对象: " + objName + "，不存在DataModel组件");
                return null;
            }
            else
            {
                Debug.LogError("不存在此对象: " + objName + "，请检查名字");
                return null;
            }
        }

    }
}

