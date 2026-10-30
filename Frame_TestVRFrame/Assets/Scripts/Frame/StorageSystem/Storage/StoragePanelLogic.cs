/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：StoragePanelLogic
* 创建日期：2021-04-19 10:33:55
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.Storage;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class StoragePanelLogic : MVVMLogicBase 
	{
        private bool canSave = true;
        private bool canLoad = true;

        /// <summary>
        /// 打开回放系统界面
        /// </summary>
        public void OpenStoragePanel() {
            GetUIBehaviours(transform.name).Scale = Vector3.one;
        }

        private void Update()
        {
            if (EventPool.EnableRecord)
            {
                if (canLoad)
                {
                    EventPool pool = InjectService.Get<EventPool>();
                    if (pool.Current.Count() > 0 || pool.Count() > 0)
                    {
                        Debug.Log("实验进行中 ");
                        GetUIBehaviours("Load").Scale = Vector3.zero;
                        canLoad = false;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            //忽略除ViewModel外其他Entity发出的事件
            if (!(evt.EventSource is ViewModel))	return;

			//获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

            if (vm.name.Equals("Save"))
            {
                if (EventPool.EnableRecord)
                {
                    if (canSave)
                    {
                        EventPool pool = InjectService.Get<EventPool>();
                        if (pool.Current.Count() <= 0)
                        {
                            Debug.Log("实验未开始 ");
                            return;
                        }
                        StorageSystemControl storage = InjectService.Get<StorageSystemControl>();
                        storage.BeginSave();
                        GetUIBehaviours(transform.name).Scale = Vector3.zero;
                    }
                }
            }
            if (vm.name.Equals("Load"))
            {
                if (EventPool.EnableRecord)
                {
                    if (canLoad)
                    {
                        EventPool pool = InjectService.Get<EventPool>();
                        if (pool.Current.Count() > 0 || pool.Count() > 0)
                        {
                            Debug.Log("实验进行中 ");
                            return;
                        }
                        StorageSystemControl storage = InjectService.Get<StorageSystemControl>();
                        storage.BeginLoad();
                        canLoad = false;
                        GetUIBehaviours(transform.name).Scale = Vector3.zero;
                        GetUIBehaviours("Load").Scale = Vector3.zero;
                    }
                    else
                    {
                        Debug.Log("实验已回放完毕 ");
                        GetUIBehaviours("Load").Scale = Vector3.zero;
                    }
                }
            }
            if (vm.name.Equals("CloseButton"))
            {
                GetUIBehaviours(transform.name).Scale = Vector3.zero;
            }

        }
    }
}
