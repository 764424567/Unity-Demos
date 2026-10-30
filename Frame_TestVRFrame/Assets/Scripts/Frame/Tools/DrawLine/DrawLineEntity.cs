/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： DrawLineEntity
* 创建日期：2020-09-11 09:34:24
* 作者名称：周新彭
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：画线实体
******************************************************************************/

using Com.Rainier.Buskit3D;
using UnityEngine;

namespace Com.Rainier.ZhouXinPeng
{
	/// <summary>
    ///
    /// </summary>
	public class DrawLineEntity : Entity
	{
       /// <summary>
       /// 画线
       /// </summary>
       /// <param name="startPos2"></param>
       /// <param name="endPos"></param>
        public void Drawline(string key,GameObject startPos, GameObject endPos)
        {
            FireEvent("Drawline", new object[] { key, startPos, endPos });
        }
    }
}

