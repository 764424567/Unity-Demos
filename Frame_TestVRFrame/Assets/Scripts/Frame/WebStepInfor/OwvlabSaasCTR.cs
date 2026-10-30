/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： OwvlabSaasCTR
* 创建日期：2021-04-27 16:24:20
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：2021年对接ILab接口控制脚本（新平台）
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D.Owvlab;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class OwvlabSaasCTR : MonoBehaviour
    {
        private OwvlabSaas owvlabSaas;

        private void Awake()
        {
            if (InjectService.Get<OwvlabSaasCTR>() == null) {
                InjectService.RegisterSingleton(this);
            }
            owvlabSaas = GetComponent<OwvlabSaas>();
        }

        private void Start()
        {
            InjectService.Get<WebStepInforManager>().SetAllStepStartTime();
        }

        private void OnDestroy()
        {
            InjectService.Unregister<OwvlabSaasCTR>();
        }

        /// <summary>
        /// 建立实验步骤信息数据
        /// </summary>
        /// <returns></returns>
        private JArray BuildStepInfor() {
            List<WebStepInfor> webStepInfors = InjectService.Get<WebStepInforManager>().GetAllStepInfor();
            JArray stepDetails = new JArray();
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (!string.IsNullOrEmpty(webStepInfors[i].StartTime) || !string.IsNullOrEmpty(webStepInfors[i].EndTime))//有开始时间和结束时间说明此步骤完成了
                {
                    JObject jObject = new JObject();
                    jObject["moduleFlag"] = webStepInfors[i].ModuleFlag;
                    jObject["questionNumber"] = webStepInfors[i].QuestionNumber;
                    jObject["questionStem"] = webStepInfors[i].QuestionStem;
                    jObject["score"] = webStepInfors[i].Score;
                    jObject["trueOrFalse"] = webStepInfors[i].TrueOrFalse;
                    jObject["startTime"] = webStepInfors[i].StartTime;
                    jObject["endTime"] = webStepInfors[i].EndTime;
                    jObject["expectTime"] = webStepInfors[i].ExpectTime;
                    jObject["maxScore"] = webStepInfors[i].MaxScore;
                    jObject["repeatCount"] = webStepInfors[i].RepeatCount;
                    jObject["evaluation"] = webStepInfors[i].Evaluation;
                    jObject["scoringModel"] = webStepInfors[i].ScoringModel;
                    jObject["remarks"] = webStepInfors[i].Remarks;

                    stepDetails.Add(jObject);
                }
                
            }

            return stepDetails;

        }

        /// <summary>
        /// 获取登录数据
        /// </summary>
        /// <param name="callback"></param>
        public void SetLoginCallBack(UnityAction<string,string,string> callback) {
            owvlabSaas.AddLoginCallBack(callback);
        }

        /// <summary>
        /// 上传实验数据
        /// </summary>
        /// <param name="callback"></param>
        public void SendMessageToPlatform()
        {
            InjectService.Get<WebStepInforManager>().SetNullStepEndTime();
            JObject result = new JObject();
            result["expScoreDetails"] = BuildStepInfor();
            Debug.Log(result);
            owvlabSaas.SendText(result);
        }

        /// <summary>
        /// 上传实验数据
        /// </summary>
        /// <param name="callback"></param>
        public void SendMessageToPlatform(UnityAction<string> callback) {
            InjectService.Get<WebStepInforManager>().SetNullStepEndTime();
            JObject result = new JObject();
            result["expScoreDetails"] = BuildStepInfor();
            Debug.Log(result);
            owvlabSaas.SendText(result, callback);
        }

        /// <summary>
        /// 上传实验数据（附带实验报告）
        /// </summary>
        /// <param name="table">实验报告</param>
        /// <param name="callback"></param>
        public void SendMessageToPlatform(JObject table, UnityAction<string> callback)
        {
            InjectService.Get<WebStepInforManager>().SetNullStepEndTime();
            JObject result = new JObject();
            result["reportData"] = table;
            result["expScoreDetails"] = BuildStepInfor();
            Debug.Log(result);
            owvlabSaas.SendText(result, callback);
        }

    }
		
}

