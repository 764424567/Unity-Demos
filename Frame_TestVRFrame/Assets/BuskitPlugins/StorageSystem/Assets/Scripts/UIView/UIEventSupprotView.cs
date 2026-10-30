/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UIEventSupprotView
* 创建日期：2019-08-23 14:15:35
* 作者名称：王庚
* 功能描述：
* 修改记录：
* 描述：
******************************************************************************/

using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// UI事件源基类，
    /// </summary>
	public class UIEventSupprotView : MonoBehaviour, IEventSourceSupportable
    {
        /// <summary>
        /// 实体有效性描述
        /// </summary>
        [FireInitEvent]
        public bool Enable
        {
            set
            {
                var oldValue = _enable;
                this._enable = value;
                this.FireEvent("Enable", oldValue, _enable);
            }
            get
            {
                return _enable;
            }
        }
        protected bool _enable = true;

        /// <summary>
        /// 事件源用于记录实体对象的侦听器、广播属性和方法事件
        /// </summary>
        EventSource eventSource = null;

        protected virtual void Awake()
        {
            eventSource = new EventSource(this);
        }

        /// <summary>
        /// 添加事件侦听器
        /// </summary>
        /// <param name="listener"></param>
        public void AddEventListener(IEventListener listener)
        {
            if (!this._enable)
            {
                return;
            }

            this.eventSource.AddEventListener(listener);
        }

        /// <summary>
        /// 清除事件侦听器
        /// </summary>
        public void ClearListeners()
        {
            if (!this._enable)
            {
                return;
            }

            this.eventSource.ClearListeners();
        }

        /// <summary>
        /// 广播属性事件
        /// </summary>
        /// <param name="evt"></param>
        public void FireEvent(PropertyEvent evt)
        {
            if (!this._enable)
            {
                return;
            }
            this.eventSource.FireEvent(evt);
        }

        /// <summary>
        /// 广播属性事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void FireEvent(string name, object oldValue, object newValue)
        {
            if (!this._enable)
            {
                return;
            }
            PropertyEvent pe = new PropertyEvent();
            pe.EventName = name;
            pe.OldValue = oldValue;
            pe.NewValue = newValue;
            this.eventSource.FireEvent(pe);
        }

        /// <summary>
        /// 广播方法事件
        /// </summary>
        /// <param name="evt"></param>
        public void FireEvent(MethodEvent evt)
        {
            if (!this._enable)
            {
                return;
            }
            this.eventSource.FireEvent(evt);
        }

        /// <summary>
        /// 广播方法事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        public void FireEvent(string name, object[] args)
        {
            if (!this._enable)
            {
                return;
            }

            MethodEvent me = new MethodEvent();
            me.EventName = name;
            if (args != null)
            {
                me.Argments = new object[args.Length];
                args.CopyTo(me.Argments, 0);
            }
            else
            {
                me.Argments = new object[0];
            }

            this.eventSource.FireEvent(me);
        }

        /// <summary>
        /// 关闭广播事件功能
        /// </summary>
        public void OffFire()
        {
            if (!this._enable)
            {
                return;
            }

            this.eventSource.OffFire();
        }

        /// <summary>
        /// 打开广播事件功能
        /// </summary>
        public void OnFire()
        {
            if (!this._enable)
            {
                return;
            }

            this.eventSource.OnFire();
        }

        /// <summary>
        /// 删除事件侦听器
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveEventListener(IEventListener listener)
        {
            if (!this._enable)
            {
                return;
            }

            this.eventSource.RemoveEventListener(listener);
        }

        /// <summary>
        /// 判断是否已经拥有事件源
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool Contains(IEventListener listener)
        {
            return this.eventSource.Contains(listener);
        }

        /// <summary>
        /// 强制发送所有属性事件
        /// </summary>
        public void ForceFireAll()
        {
            //广播初始化事件，在_eventSource中搜索所有带有
            //“FireInitEvent”注解的属性和字段
            //并广播需要广播初始化消息的属性或字段事件
            var allFields = this
                .GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(o => o.GetCustomAttributes(typeof(FireInitEventAttribute), true).Length > 0)
                .ToArray();
            var allProperties = this
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(o => o.GetCustomAttributes(typeof(FireInitEventAttribute), true).Length > 0)
                .ToArray();

            //向Listener广播字段初始化消息
            foreach (FieldInfo info in allFields)
            {
                var value = info.GetValue(this);
                var attr = info.GetCustomAttribute<FireInitEventAttribute>();
                this.FireEvent(info.Name, value, value);
            }

            //向Listener广播初属性始化消息
            foreach (PropertyInfo info in allProperties)
            {
                var value = info.GetValue(this);
                var attr = info.GetCustomAttribute<FireInitEventAttribute>();
                this.FireEvent(info.Name, value, value);
            }
        }

        public void OnDestroy()
        {
            ClearListeners();
        }
    }
}

