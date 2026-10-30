/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TouchManager
* 创建日期：2021-01-19 11:20:15
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：触屏手指ID管理脚本
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class TouchManager  
	{
        /// <summary>
        /// 已被占用手指集合
        /// </summary>
        public List<Touch> UseTouchList = new List<Touch>();
        /// <summary>
        /// 获取手指
        /// </summary>
        /// <returns></returns>
        public Touch GetFinger()
        {
            Touch touch = new Touch();
            //如果数组只有一个Touch直接获取
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
            }
            else
            {
                for (int i = 0; i < Input.touches.Length; i++)
                {
                    bool IsUse = false;
                    for (int j = 0; j < UseTouchList.Count; j++)
                    {
                        if (Input.touches[i].fingerId == UseTouchList[j].fingerId)
                        {
                            IsUse = true;
                        }
                    }
                    if (IsUse == false)
                    {
                        touch = Input.touches[i];
                    }
                }
            }
            //获取touch后放入数组内
            if (UseTouchList.Contains(touch) == false)
            {
                UseTouchList.Add(touch);
            }
            return touch;
        }
        /// <summary>
        /// 删除数组中的手指
        /// </summary>
        /// <param name="touch"></param>
        public void RemoveFinger(Touch touch)
        {
            if (UseTouchList.Contains(touch) == true)
            {
                UseTouchList.Remove(touch);
            }
        }

    }
}

