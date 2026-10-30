/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： InputOption
* 创建日期：2021-04-15 13:36:19
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：填空题分项
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class InputOption 
	{
        /// <summary>
        /// 选项名字
        /// </summary>
        private string optionName;

        /// <summary>
        /// 选项答案
        /// </summary>
        private string[] answer;

        /// <summary>
        /// 选项名字
        /// </summary>
        public string OptionName {
            get { return optionName; }
            set { optionName = value; }
        }

        /// <summary>
        /// 选项答案
        /// </summary>
        public string[] Answer {
            get { return answer; }
            set { answer = value; }
        }

        public InputOption() { }

        public InputOption(string optionName,string[] answer) {
            this.optionName = optionName;
            this.answer = answer;
        }

    }
}

