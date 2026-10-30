/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TestToolTip
* 创建日期：2020-07-03 19:50:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class TestToolTip : MonoBehaviour 
	{
        private Dictionary<NamePair, string> tips;

        private void Start()
        {
            tips = new Dictionary<NamePair, string>();
            tips.Add(new NamePair("Cube", "Cube"), "正方体");
            //tips.Add(new NamePair("Cube2", "Cube2"), "大一点的正方体");
            tips.Add(new NamePair("Sphere2", "Sphere2"), "球");

            transform.GetComponent<ToolTipPanelLogic>().SetToolTip(tips);
        }

    }
}

