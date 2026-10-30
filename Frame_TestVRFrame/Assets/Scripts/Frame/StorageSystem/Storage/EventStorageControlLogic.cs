/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：EventStorageControlLogic
* 创建日期：2021-04-19 16:04:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：回放事件存储控制脚本
******************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{
    [StorageIgnored(
        IgnoredEvents = new string[] { "OnDestroy", "OnDisable" },
        IgnoredEventTypes = new Type[] { typeof(PropertyInitEvent) }
    )]
    public class EventStorageControlLogic : ObjLogicBase 
	{
        [Inject]
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

            if (storage == null)
            {
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
