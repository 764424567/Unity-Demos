/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WebStepInforManager
* 创建日期：2021-04-27 14:42:02
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
	public class WebStepInforManager  
	{
        private List<WebStepInfor> webStepInfors ;

        /// <summary>
        /// 存储考题
        /// </summary>
        /// <param name="choices"></param>
        public void SaveStepInfors(List<WebStepInfor> choices)
        {
            if (webStepInfors == null)
            {
                webStepInfors = choices;
            }
        }

        /// <summary>
        /// 获取步骤信息
        /// </summary>
        /// <param name="examName">步骤编号</param>
        /// <returns></returns>
        public WebStepInfor GetStepInfor(int stepNumber)
        {
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (webStepInfors[i].QuestionNumber.Equals(stepNumber))
                {
                    return webStepInfors[i];
                }

            }
            return null;
        }

        /// <summary>
        /// 获取所有步骤信息
        /// </summary>
        /// <returns></returns>
        public List<WebStepInfor> GetAllStepInfor() {
            return webStepInfors;
        }

        /// <summary>
        /// 设置所有步骤统一开始时间（如已有则略过）
        /// </summary>
        public void SetAllStepStartTime()
        {
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (webStepInfors[i].StartTime.Equals(string.Empty))
                {
                    webStepInfors[i].SetStepStartTime();
                }
            }
        }

        /// <summary>
        /// 设置所有步骤统一结束时间（如已有则略过）
        /// </summary>
        public void SetNullStepEndTime()
        {
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (webStepInfors[i].EndTime.Equals(string.Empty))
                {
                    webStepInfors[i].SetStepRepeatCount();
                    webStepInfors[i].SetStepEndTime();
                }

            }
        }
    }
}

