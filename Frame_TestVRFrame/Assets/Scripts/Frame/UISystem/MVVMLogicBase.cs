/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： MVVMLogicBase
* 创建日期：2020-05-26 10:56:03
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
	public class MVVMLogicBase : CommonLogic
    {
        #region 通用回调
        private UnityAction callBackAction;

        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="action"></param>
        protected void SetCallBackAction(UnityAction action) {
            callBackAction = action;
        }

        /// <summary>
        /// 获取回调
        /// </summary>
        /// <returns></returns>
        protected UnityAction GetCallBackAction() {
            return callBackAction;
        }

        /// <summary>
        /// 调用回调
        /// </summary>
        protected void InvokeCallBackAction() {
            if (callBackAction != null)
            {
                callBackAction.Invoke();
            }
            callBackAction = null;
        }

        #endregion


        protected override void Awake()
        {
            base.Awake();
            Transform[] childTranms = transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childTranms.Length; i++)
            {
                if (!childTranms[i].GetComponent<UIBehaviours>())
                {
                    childTranms[i].gameObject.AddComponent<UIBehaviours>();
                }
            }
            

        }

        #region Entity相关

        /// <summary>
        /// 注册entity
        /// </summary>
        /// <param name="entity"></param>
        protected void AddEntity<T>() where T : Entity, new()
        {
            GetComponent<DataModelBehaviour>().AttachEntity<T>();
        }

        /// <summary>
        /// 注销entity
        /// </summary>
        /// <param name="entity"></param>
        protected void RemoveEntity<T>() where T : Entity
        {
            GetComponent<DataModelBehaviour>().DetachEntity<T>();
        }

        /// <summary>
        /// 获取Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetEntity<T>() where T : Entity
        {
            return GetComponent<DataModelBehaviour>().FindEntity<T>();
        }

        #endregion

        #region 获取引用相关

        /// <summary>
        /// 获取此物体下的ViewModel组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetViewModel<T>(string name)where T : ViewModel{
            return InjectService.Get<UIManager>().GetViewModel<T>(transform.name, name);
        }

        /// <summary>
        /// 获取此物体下的GameObject
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string name) {
            return InjectService.Get<UIManager>().GetGameObject(transform.name, name);
        }

        /// <summary>
        /// 获取此物体下的UIBehaviours组件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UIBehaviours GetUIBehaviours(string name) {
            return InjectService.Get<UIManager>().GetUIBehaviours(transform.name, name);
        }

        /// <summary>
        /// 获取其他UILogic脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootName"></param>
        /// <returns></returns>
        protected T GetUILogic<T>(string rootName) where T :MVVMLogicBase {
            return InjectService.Get<UIManager>().GetUIBehaviours(rootName, rootName).GetComponent<T>();
        }

        /// <summary>
        /// 获取其他ObjLogic脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootName"></param>
        /// <returns></returns>
        protected T GetObjLogic<T>(string rootName) where T : ObjLogicBase {
            return InjectService.Get<ObjManager>().GetObjBehaviours(rootName, rootName).GetComponent<T>();
        }

        /// <summary>
        /// 获取其他ObjLogic脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="namePair"></param>
        /// <returns></returns>
        protected T GetObjLogic<T>(NamePair namePair) where T : ObjLogicBase
        {
            return InjectService.Get<ObjManager>().GetObjBehaviours(namePair.RootName, namePair.ObjName).GetComponent<T>();
        }

        #endregion

        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="number">标号（没有可传空）</param>
        /// <param name="parent">父物体（没有可传空）</param>
        protected void LoadGameObject(string path,string number ,GameObject parent)
        {
            GameObject loadObject = Instantiate(Resources.Load<GameObject>(path));
            loadObject.name = loadObject.name.Remove(loadObject.name.Length - 7);
            if (parent != null)
            {
                loadObject.transform.SetParent(parent.transform, false);
            }
            Transform[] childTrans = loadObject.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < childTrans.Length; i++)
            {
                childTrans[i].gameObject.name += number;
                childTrans[i].gameObject.AddComponent<UIBehaviours>();
            }

        }



    }
}

