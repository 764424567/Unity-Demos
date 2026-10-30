/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TriggerEntity
* 创建日期：2020-05-27 17:28:10
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine.Events;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class TriggerEntity : Entity
	{
        /// <summary>
        /// 点击触发事件
        /// </summary>
        private int onTriggerClick;

        /// <summary>
        /// 点击触发事件
        /// </summary>
        [FireInitEvent]
        public int OnTriggerClick {
            get { return onTriggerClick; }
            set {
                var oldvalue = onTriggerClick;
                onTriggerClick = value;
                FireEvent("OnTriggerClick", oldvalue, value);
            }
        }

        /// <summary>
        /// 设置物体高亮
        /// </summary>
        /// <param name="objName">高亮物体名字</param>
        /// <param name="isLight">是否高亮</param>
        public void SetObjHighlight(string objName, bool isLight)
        {

            FireEvent("SetObjHighlight", new object[] { objName, isLight });
        }
    }
}

