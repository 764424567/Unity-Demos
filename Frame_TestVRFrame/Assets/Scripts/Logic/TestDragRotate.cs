/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TestDragRotate
* 创建日期：2020-08-19 10:27:10
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
	public class TestDragRotate : MonoBehaviour 
	{

	
		/// <summary>
        /// Unity Method
        /// </summary>
		void Update ()
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                // transform.rotation = Quaternion.Lerp (transform.rotation , Quaternion.LookRotation (Vector3.Cross (transform.right , hitForward.normal) , hitForward.normal) , Time.deltaTime * 10);
                transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal), hit.normal);
                transform.position = hit.point;
            }
        }
	}
}

