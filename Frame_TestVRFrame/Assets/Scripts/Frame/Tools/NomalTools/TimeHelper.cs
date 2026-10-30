/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TimeHelper
* 创建日期：2021-04-27 15:35:05
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using System;
using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public static class TimeHelper  
	{
        /// <summary>
        /// 日期转换为00000000格式
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns></returns>
        public static string ChangeDateToNumber(DateTime dateTime)
        {
            return dateTime.Year.ToString("0000") + dateTime.Month.ToString("00") + dateTime.Day.ToString("00");
        }

        /// <summary>
        /// 日期转换为0000-00-00格式
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns></returns>
        public static string ChangeDateTo_Number(DateTime dateTime)
        {
            return dateTime.Year.ToString("0000") + "-" + dateTime.Month.ToString("00") + "-" + dateTime.Day.ToString("00");
        }

        public static string ChangeTimeTo_Number(DateTime dateTime) {
            return dateTime.Hour.ToString("00") + ":" + dateTime.Minute.ToString("00") + ":" + dateTime.Second.ToString("00");
        }

        /// <summary>
        /// 日期转化为0000年0月0日格式
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns></returns>
        public static string ChangeDateToCNNumber(DateTime dateTime)
        {
            return dateTime.Year.ToString() + "年" + dateTime.Month.ToString() + "月" + dateTime.Day.ToString() + "日";
        }
    }
}

