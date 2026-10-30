/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WeightedRandomData
* 创建日期：2019-09-11 15:29:05
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：加权随机数条件设置
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class WeightedRandomData  
	{
        private float randomMinF;
        /// <summary>
        /// 随机最小值
        /// </summary>
        public float RandomMinF {
            get { return randomMinF; }
        }

        private float randomMaxF;
        /// <summary>
        /// 随机最大值
        /// </summary>
        public float RandomMaxF {
            get { return randomMaxF; }
        }

        private float percentage;
        /// <summary>
        /// 所占百分比（1-100）
        /// </summary>
        public float Percentage {
            get { return percentage; }
        }

        public WeightedRandomData() {

        }

        public WeightedRandomData(float randomMinF,float randomMaxF,float percentage) {
            this.randomMinF = randomMinF;
            this.randomMaxF = randomMaxF;
            this.percentage = percentage;
        }

    }
}

