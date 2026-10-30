/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TestLogic
* 创建日期：2020-06-19 17:12:58
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class TestLogic : ObjLogicBase 
	{
        private void Start()
        {
            GetObjBehaviour("Cube").AddObjClickListener(()=> {
                Debug.Log("!!");
                transform.DOMove(new Vector3(transform.position.x, 2, transform.position.z), 0.5f);
            });
        }



        public override void ProcessLogic(IEvent evt)
        {
            
        }
    }
}
