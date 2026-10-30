/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UITriggerEntity
* 创建日期：2020-06-02 08:47:04
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class UITriggerEntity : Entity 
	{
        /// <summary>
        /// 点击触发事件
        /// </summary>
        private int onTriggerClick;

        /// <summary>
        /// 点击触发事件
        /// </summary>
        public int OnTriggerClick
        {
            get { return onTriggerClick; }
            set
            {
                var oldvalue = onTriggerClick;
                onTriggerClick = value;
                FireEvent("OnTriggerClick", oldvalue, value);
            }
        }

        /// <summary>
        /// 设置UI高亮
        /// </summary>
        /// <param name="objName">高亮UI名字</param>
        /// <param name="isLight">是否高亮</param>
        public void SetUIHighlight(string objName, bool isLight)
        {
            FireEvent("SetUIHighlight", new object[] { objName, isLight });
        }

        /// <summary>
        /// 设置UI框高亮
        /// </summary>
        /// <param name="objName">高亮UI名字</param>
        /// <param name="isLight">是否高亮</param>
        public void SetUIFrameHighlight(string objName,bool isLight) {
            FireEvent("SetUIFrameHighlight", new object[] { objName, isLight });
        }

    }
}

