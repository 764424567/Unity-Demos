/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ObjectTag
* 创建日期：2020-05-28 11:42:44
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public static class ObjectTag 
	{
        private static string tag = "TargetObj";

        /// <summary>
        /// 可互动物体标签名称
        /// </summary>
        public static string Tag {
            get { return tag; }
        }
    }
}

