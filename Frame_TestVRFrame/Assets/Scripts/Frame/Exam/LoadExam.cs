/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LoadExam
* 创建日期：2020-06-10 14:18:06
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：加载考题到内存中
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class LoadExam : MonoBehaviour 
	{

        private void Start()
        {
            StartLoadExams("Exam", LoadExamCallBack);
        }

        /// <summary>
        /// 考题回调
        /// </summary>
        /// <param name="message"></param>
        private void LoadExamCallBack(string message) {
            string value = StringAndZip.ZipToString(message);
            List<Exam> exams = JsonConvert.DeserializeObject<List<Exam>>(value, new ExamConverter());
            InjectService.Get<ExamManager>().SaveExams(exams);
        }

        /// <summary>
        /// 加载考题
        /// </summary>
        /// <param name="excelName"></param>
        /// <param name="LoadExamCallBack"></param>
        private void StartLoadExams(string excelName, UnityAction<string> LoadExamCallBack) {
            StartCoroutine(LoadExams(excelName, LoadExamCallBack));
        }

        private IEnumerator LoadExams(string name, UnityAction<string> LoadExamCallBack)
        {
            string url = Application.streamingAssetsPath + "/Exam/" + name + ".txt";
            var request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
                yield break;
            }
            while (!request.isDone)
            {
                yield return 0;
            }
            string message = request.downloadHandler.text;
            LoadExamCallBack(message);
        }

    }
}

