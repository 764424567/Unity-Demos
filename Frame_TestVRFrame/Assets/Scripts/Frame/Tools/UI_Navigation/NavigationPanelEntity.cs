/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： NavigationPanelEntity
* 创建日期：2020-12-01 09:26:14
* 作者名称：周新彭
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：界面导航实体
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    ///
    /// </summary>
	public class NavigationPanelEntity : CommonEntity
	{
        /// <summary>
        /// 设置导航按键(方形)
        /// </summary>
        /// <param name="image">需要点击的界面</param>
        public void SetNavigationImage(Image image,UnityAction actions)
        {
            FireEvent("SetNavigationImage", new object[] { image , actions });
        }

        /// <summary>
        /// 设置导航按键(圆形)
        /// </summary>
        /// <param name="image">需要点击的界面</param>
        public void SetCirleNavigationImage(Image image, UnityAction actions)
        {
            FireEvent("SetCirleNavigationImage", new object[] { image, actions });
        }
    }
}

