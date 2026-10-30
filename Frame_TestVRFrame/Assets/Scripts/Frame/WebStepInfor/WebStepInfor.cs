/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WebStepInfor
* 创建日期：2021-04-27 13:21:15
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
	public class WebStepInfor  
	{
        /// <summary>
        /// 步骤名称
        /// </summary>
        private string moduleFlag;

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string ModuleFlag {
            get { return moduleFlag; }
            set { moduleFlag = value; }
        }

        /// <summary>
        /// 步骤编号
        /// </summary>
        private int questionNumber;

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int QuestionNumber {
            get { return questionNumber; }
            set { questionNumber = value; }
        }

        /// <summary>
        /// 步骤说明
        /// </summary>
        private string questionStem;

        /// <summary>
        /// 步骤说明
        /// </summary>
        public string QuestionStem {
            get { return questionStem; }
            set { questionStem = value; }
        }

        /// <summary>
        /// 步骤得分
        /// </summary>
        private int score = 0;

        /// <summary>
        /// 步骤得分
        /// </summary>
        public int Score {
            get {  return score; }
            set { score = value; }
        }

        /// <summary>
        /// 是否正确
        /// </summary>
        private string trueOrFalse = "True";

        /// <summary>
        /// 是否正确
        /// </summary>
        public string TrueOrFalse {
            get { return trueOrFalse; }
            set { trueOrFalse = value; }
        }

        /// <summary>
        /// 步骤开始时间
        /// </summary>
        private string startTime = string.Empty;

        /// <summary>
        /// 步骤开始时间
        /// </summary>
        public string StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// 步骤结束时间
        /// </summary>
        private string endTime = string.Empty;

        /// <summary>
        /// 步骤结束时间
        /// </summary>
        public string EndTime {
            get { return endTime; }
            set { endTime = value; }
        }

        /// <summary>
        /// 步骤合理用时
        /// </summary>
        private int expectTime;

        /// <summary>
        /// 步骤合理用时
        /// </summary>
        public int ExpectTime {
            get { return expectTime; }
            set { expectTime = value; }
        }

        /// <summary>
        /// 步骤最大成绩
        /// </summary>
        private int maxScore;

        /// <summary>
        /// 步骤最大成绩
        /// </summary>
        public int MaxScore {
            get { return maxScore; }
            set { maxScore = value; }
        }

        /// <summary>
        /// 步骤操作次数
        /// </summary>
        private int repeatCount = 0;

        /// <summary>
        /// 步骤操作次数
        /// </summary>
        public int RepeatCount {
            get { return repeatCount; }
            set { repeatCount = value; }
        }

        /// <summary>
        /// 实验步骤评价
        /// </summary>
        private string evaluation = "无";

        /// <summary>
        /// 实验步骤评价
        /// </summary>
        public string Evaluation {
            get { return evaluation; }
            set { evaluation = value; }
        }

        /// <summary>
        /// 考察点
        /// </summary>
        private string scoringModel = "无";

        /// <summary>
        /// 考察点
        /// </summary>
        public string ScoringModel {
            get { return scoringModel; }
            set { scoringModel = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string remarks = "无";

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks {
            get { return remarks; }
            set { remarks = value; }
        }

        public WebStepInfor() { }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="moduleFlag">步骤名称</param>
        /// <param name="questionNumber">步骤编号</param>
        /// <param name="questionStem">步骤说明</param>
        /// <param name="expectTime">步骤合理用时</param>
        /// <param name="maxScore">步骤最大成绩</param>
        /// <param name="evaluation">实验步骤评价</param>
        /// <param name="scoringModel">考察点</param>
        /// <param name="remarks">备注</param>
        public WebStepInfor(string moduleFlag,
            int questionNumber,string questionStem,
            int expectTime,int maxScore,
            string evaluation = "无",string scoringModel = "无",
            string remarks = "无") {
            this.moduleFlag = moduleFlag;
            this.questionNumber = questionNumber;
            this.questionStem = questionStem;
            this.expectTime = expectTime;
            this.maxScore = maxScore;
            this.evaluation = evaluation;
            this.scoringModel = scoringModel;
            this.remarks = remarks;
        }

        /// <summary>
        /// 设置步骤开始时间
        /// </summary>
        public void SetStepStartTime() {
            startTime = GetNowTime();
        }

        /// <summary>
        /// 设置步骤结束时间
        /// </summary>
        public void SetStepEndTime() {
            endTime = GetNowTime();
        }

        /// <summary>
        /// 设置步骤得分
        /// </summary>
        /// <param name="score"></param>
        public void SetStepScore(int score) {
            this.score = score;
        }

        /// <summary>
        /// 设置步骤操作次数
        /// </summary>
        public void SetStepRepeatCount() {
            repeatCount++;
        }

        /// <summary>
        /// 获取当前系统时间
        /// </summary>
        /// <returns></returns>
        private string GetNowTime()
        {
            string time = TimeHelper.ChangeDateTo_Number(DateTime.Now) + " ";
            time += TimeHelper.ChangeTimeTo_Number(DateTime.Now);
            return time;
        }
    }
}

