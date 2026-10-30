/*******************************************************************************
* 版权所有：北京润尼尔网络科技有限公司
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.Buskit3D
* 类 名 称：EventStorageLogic
* 创建日期：2016/11/13 下午 05:03:58
* 作者名称：王志远
* 功能描述：事件存储业务逻辑
* 修改记录：
* 日期 描述 更新功能
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;
using System;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 事件存储业务逻辑
    /// </summary>
    [StorageIgnored(
        IgnoredEvents = new string[] {"OnDestroy","OnDisable"},
        IgnoredEventTypes = new Type[] { typeof(PropertyInitEvent) }
    )]
    public class EventStorageLogic :LogicBehaviour
    {
        [Inject]
        //private StorageSystem storage;
        private StorageSystemControl storage;

        /// <summary>
        /// 注入存储系统
        /// </summary>
        protected void Start()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 存储事件
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //获取StorageIgnored注解
            object[] attrs = this.GetType().GetCustomAttributes(true);
            StorageIgnored si = null;
            foreach (var attr in attrs)
            {
                if (attr.GetType().Equals(typeof(StorageIgnored)))
                {
                    si = (StorageIgnored)attr;
                }
            }

            //获取存储系统单利
            if (storage == null)
            {
                //storage = InjectService.Get<StorageSystem>();
                storage = InjectService.Get<StorageSystemControl>();
            }

            //如果没有定义StorageIgnored则认为所有事件不必忽略
            if (si == null)
            {
                storage.Push(evt as AbstractEvent);
            }
            //如果定义了StorageIgnored则在判断不是忽略类型且不是忽略事件的情况下保存事件
            else if (!si.IsIgnored(evt.GetType()) && !si.IsIgnored(evt.EventName))
            {
                storage.Push(evt as AbstractEvent);
            }
        }
    }
}
