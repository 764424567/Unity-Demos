/*******************************************************************************
* 版权所有：北京润尼尔网络科技有限公司
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.Buskit3D
* 类 名 称：StorageIgnoredAttribute
* 创建日期：2016/11/13 下午 05:03:58
* 作者名称：王志远
* 功能描述：被忽略的事件名称定义
* 修改记录：
* 日期 描述 更新功能
******************************************************************************/

using System;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 被忽略的事件名称定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StorageIgnored : Attribute
    {
        /// <summary>
        /// 被忽略的事件名称
        /// </summary>
        public string[] IgnoredEvents;

        /// <summary>
        /// 被忽略的事件类型
        /// </summary>
        public Type[] IgnoredEventTypes;

        /// <summary>
        /// 判断是否是被忽略的类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsIgnored(Type type)
        {
            if (IgnoredEventTypes == null)
            {
                return false;
            }

            if (IgnoredEventTypes.Length == 0)
            {
                return false;
            }

            foreach (Type t in IgnoredEventTypes)
            {
                if (type.Equals(t))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否被忽略
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public bool IsIgnored(string eventName)
        {
            if(IgnoredEvents == null)
            {
                return false;
            }
            if(IgnoredEvents.Length == 0)
            {
                return false;
            }

            foreach(string str in IgnoredEvents)
            {
                if (str.Equals(eventName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
