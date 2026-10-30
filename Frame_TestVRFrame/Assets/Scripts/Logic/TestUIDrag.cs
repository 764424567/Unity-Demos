/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TestUIDrag
* 创建日期：2021-05-07 10:28:04
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
	public class TestUIDrag : MonoBehaviour 
	{

		/// <summary>
        /// Unity Method
        /// </summary>
		void Start () 
		{
            GetComponent<DragUIPanelLogic>().SetDragObj(new NamePair("Target", "Target"), new NamePair("Drager", "Drager"), () => {
                GetComponent<DragUIPanelLogic>().SetDragObj(new NamePair("Target1", "Target1"), new NamePair("Drager1", "Drager1"), () => {
                    Debug.Log("!!!");
                });
            });
		}
	
		/// <summary>
        /// Unity Method
        /// </summary>
		void Update ()
		{
		}
	}
}

