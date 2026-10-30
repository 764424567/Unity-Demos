/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： InfinitelyScrollViewEntity
* 创建日期：2021-04-30 16:04:24
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class InfinitelyScrollViewEntity : Entity
	{
        /// <summary>
        /// 拖拽项
        /// </summary>
        /// <param name="position"></param>
        public void OnDrag(Vector2 position)
        {
            FireEvent("OnDrag", new object[] { position });
        }

        /// <summary>
        /// 拖拽项结束
        /// </summary>
        /// <param name="name"></param>
        public void OnDragEnd()
        {
            FireEvent("OnDragEnd", null );
        }
    }
}

