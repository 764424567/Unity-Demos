/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ObjLogicBase
* 创建日期：2020-05-27 19:54:15
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ObjLogicBase :  LogicBehaviour
	{
        #region 通用回调
        private UnityAction callBackAction;

        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="action"></param>
        protected void SetCallBackAction(UnityAction action)
        {
            callBackAction = action;
        }

        /// <summary>
        /// 获取回调
        /// </summary>
        /// <returns></returns>
        protected UnityAction GetCallBackAction()
        {
            return callBackAction;
        }

        /// <summary>
        /// 调用回调
        /// </summary>
        protected void InvokeCallBackAction()
        {
            if (callBackAction != null)
            {
                callBackAction.Invoke();
            }
            callBackAction = null;
        }

        #endregion

        #region Entity相关

        /// <summary>
        /// 注册entity
        /// </summary>
        /// <param name="entity"></param>
        protected void AddEntity<T>()where T :Entity,new() {
            GetComponent<ObjDataModel>().AddEntity<T>();
        }

        /// <summary>
        /// 注销entity
        /// </summary>
        /// <param name="entity"></param>
        protected void RemoveEntity<T>()where T :Entity {
            GetComponent<ObjDataModel>().RemoveEntity<T>();
        }

        /// <summary>
        /// 获取Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetEntity<T>() where T : Entity {
            return GetComponent<ObjDataModel>().FindEntity<T>();
        }

        #endregion

        #region 获取引用相关

        /// <summary>
        /// 获取此根物体下的ObjBehaviours
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <returns></returns>
        public ObjBehaviours GetObjBehaviour(string objName)
        {
            return InjectService.Get<ObjManager>().GetObjBehaviours(transform.name, objName);
        }

        /// <summary>
        /// 获取其他ObjLogic脚本
        /// </summary>
        /// <param name="rootName">根物体名</param>
        /// <returns></returns>
        protected T GetObjLogic<T>(string rootName) where T : LogicBehaviour
        {
            return InjectService.Get<ObjManager>().GetObjBehaviours(rootName, rootName).GetComponent<T>();
        }

        /// <summary>
        /// 获取UILogic脚本
        /// </summary>
        /// <param name="rootName">根物体名</param>
        /// <returns></returns>
        protected T GetUILogic<T>(string rootName) where T : LogicBehaviour
        {
            return InjectService.Get<UIManager>().GetUIBehaviours(rootName, rootName).GetComponent<T>();
        }

        #endregion


        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="gameObjectName">对象名</param>
        /// <param name="parent">父物体</param>
        protected GameObject LoadGameObject(string path, string gameObjectName, GameObject parent)
        {
            GameObject tmpGameObject = Instantiate(Resources.Load<GameObject>(path));
            tmpGameObject.name = gameObjectName;
            if (parent)
            {
                tmpGameObject.transform.SetParent(parent.transform, false);
            }
            Transform[] childTranms = tmpGameObject.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childTranms.Length; i++)
            {
                if (childTranms[i].gameObject.CompareTag(ObjectTag.Tag))
                {
                    childTranms[i].gameObject.AddComponent<ObjBehaviours>();
                }
            }
            return tmpGameObject;
        }
    }
}

