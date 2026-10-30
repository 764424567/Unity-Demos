/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ObjDataModel
* 创建日期：2020-05-28 11:21:50
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{
	/// <summary>
    /// datamodel模板
    /// </summary>
	public class ObjDataModel : DataModelBehaviour
	{

        /// <summary>
        /// 绑定entity
        /// </summary>
        /// <param name="entity"></param>
        public void AddEntity<T>()where T :Entity,new() {
            if (FindEntity<T>() != null)//如果已有就不添加
            {
                return;
            }
            AttachEntity<T>();
        }

        /// <summary>
        /// 移除绑定的entity
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity<T>() where T : Entity {
            for (int i = Entities.Count - 1; i >= 0; i--)
            {
                if (Entities[i].GetType().Equals(typeof(T)))
                {
                    Entities.Remove(Entities[i]);
                }
            }
            
        }

        
    }
}

