/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：GameObjectExtension
* 创建日期：2019-08-14 17:35:01
* 作者名称：王庚
* 功能描述：GameObject扩展工具，提供搜索GameObject路径和将GameObject放到指定路径的功能
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// gameobject扩展，提供序列化需要的内容
    /// </summary>
	public static class GameObjectExtension  
	{
        /// <summary>
        /// 获取GameObject在场景中的路径
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static string GetHirearchyPath(this GameObject go)
        {
            //GameObject名称
            string path = go.name;

            //生产GameObject路径
            Transform rootParent = go.transform.parent;
            while (rootParent != null)
            {
                path = rootParent.name + "/" + path;
                rootParent = rootParent.parent;
            }
            return path;
        }
	}
}

