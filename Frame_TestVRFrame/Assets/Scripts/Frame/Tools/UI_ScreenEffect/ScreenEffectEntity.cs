/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ScreenEffectEntity
* 创建日期：2020-06-09 19:45:13
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
	public class ScreenEffectEntity : Entity
	{
        public void SetScreenEffect()
        {
            FireEvent("SetScreenEffect", new object[] {  });
        }
    }
}

