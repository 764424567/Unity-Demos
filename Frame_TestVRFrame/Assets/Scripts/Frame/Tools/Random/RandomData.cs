/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： RandomData
* 创建日期：2019-09-11 15:43:32
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：随机数扩展类
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 随机数扩展类
    /// </summary>
	public static class RandomData 
	{
        /// <summary>
        /// 加权随机数，随机小数
        /// </summary>
        /// <param name="data">随机条件</param>
        /// <returns></returns>
        public static float WeightedRandomFloat(List<WeightedRandomData> data) {
            int percentage = Random.Range(1, 100);
            float lastValue = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (lastValue < percentage && percentage <= (lastValue + data[i].Percentage))
                {
                    return Random.Range(data[i].RandomMinF, data[i].RandomMaxF);
                }
                lastValue += data[i].Percentage;
            }
            return float.NaN;
        }

        /// <summary>
        /// 加权随机数，随机整数
        /// </summary>
        /// <param name="data">随机条件</param>
        /// <returns></returns>
        public static int WeightedRandomInt(List<WeightedRandomData> data) {
            int percentage = Random.Range(1, 100);
            float lastValue = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (lastValue < percentage && percentage <= (lastValue + data[i].Percentage))
                {
                    float tmpValue = Random.Range(data[i].RandomMinF, data[i].RandomMaxF);
                    return Mathf.RoundToInt(tmpValue);
                }
                lastValue += data[i].Percentage;
            }
            return int.MinValue;
        }

        /// <summary>
        /// 不重复随机数
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="count">随机个数</param>
        /// <returns>结果</returns>
        public static List<int> RandomNotRepeat(int minValue,int maxValue,int count) {
            List<int> values = new List<int>();
            List<int> results = new List<int>();
            for (int i = minValue; i < maxValue+1; i++)
            {
                values.Add(i);
            }
            if (count>values.Count) //如果随机数量大于总数，返回所有备选数
            {
                return values;
            }
            for (int i = 0; i < count; i++)
            {
                float tmpValue = Random.Range(0f, values.Count-1);
                int tmpResult = Mathf.RoundToInt(tmpValue);
                results.Add(values[tmpResult]);
                values.Remove(values[tmpResult]);
            }
            return results;
        }
	}
}

