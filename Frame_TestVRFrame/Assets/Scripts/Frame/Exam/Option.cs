/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： Option
* 创建日期：2019-07-30 19:17:08
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：选择题选项
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class Option
    {

        /// <summary>
        /// 选项名字
        /// </summary>
        private string optionName;

        /// <summary>
        /// 选项答案
        /// </summary>
        private bool answer;

        /// <summary>
        /// 选项名字
        /// </summary>
        public string OptionName
        {
            get { return optionName; }
            set { optionName = value; }
        }

        /// <summary>
        /// 选项答案
        /// </summary>
        public bool Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public Option() { }

        public Option(string optionName, bool answer)
        {
            this.optionName = optionName;
            this.answer = answer;
        }

    }
}

