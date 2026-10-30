/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ExamManager
* 创建日期：2020-06-10 14:57:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：考题管理脚本
******************************************************************************/

using UnityEngine;
using System;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class ExamManager  
	{
        private List<Exam> exams ;

        /// <summary>
        /// 存储考题
        /// </summary>
        /// <param name="choices"></param>
        public void SaveExams(List<Exam> choices) {
            if (exams == null)
            {
                exams = choices;
            }
        }

        /// <summary>
        /// 获取考题
        /// </summary>
        /// <param name="examName"></param>
        /// <returns></returns>
        public Exam GetExam(string examName) {
            for (int i = 0; i < exams.Count; i++)
            {
                if (exams[i].ExamName.Equals(examName))
                {
                    return exams[i];
                } 
                
            }
            return null;
        }

        /// <summary>
        /// 获取考题总成绩
        /// </summary>
        /// <returns></returns>
        public int GetScore() {
            if (exams != null)
            {
                int score = 0;
                for (int i = 0; i < exams.Count; i++)
                {
                    score += Convert.ToInt32(exams[i].GetScore());
                }
                return score;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取考题总数
        /// </summary>
        /// <returns></returns>
        public int GetExamCount() {
            if (exams != null)
            {
                return exams.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 清空选择题输入答案
        /// </summary>
        public void ClearAllInputAnswer() {
            if (exams != null)
            {
                for (int i = 0; i < exams.Count; i++)
                {
                    if (exams[i].ExamType == ExamType.XuanZeTi)
                    {
                        ((Choices)exams[i]).InputAnswer = null;
                    }
                    else if (exams[i].ExamType == ExamType.TianKongTi)
                    {
                        ((InputExam)exams[i]).InputAnswer = null;
                    }
                }
            }
        }

        /// <summary>
        /// 清空考题
        /// </summary>
        public void ClearExam() {
            exams.Clear();
        }
    }
}

