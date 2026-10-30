/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WarningPanelEntity
* 创建日期：2020-06-08 20:00:42
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
	public class WarningPanelEntity : Entity
	{

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="text"></param>
        public void SetWarning(string text)
        {
            FireEvent("SetWarning", new object[] { text });
        }
    }
}

