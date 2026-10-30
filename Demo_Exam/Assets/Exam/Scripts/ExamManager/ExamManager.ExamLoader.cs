/*******************************************************************************
* 版权声明：张尧，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ExamManager.ExamLoader
* 创建日期：2024-03-12 09:35:52
* 作者名称：张尧
* 修改记录：
* 描述：加载题目处理类
******************************************************************************/

using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;
using System.Xml.Linq;
using UnityEditor.PackageManager.Requests;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public partial class ExamManager
{
    public sealed class ExamLoader
    {
        public delegate void LoadCallbacks(string value);

        private readonly ExamManager m_ExamManager;
        private readonly LoadCallbacks m_LoadCallbacks;

        private List<ExamBase> m_Exams;
        private int m_ExamCount;
        UnityWebRequest m_UnityWebRequest;
        private float m_LastProgress = 0f;

        /// <summary>
        /// 初始化加载资源器的新实例。
        /// </summary>
        /// <param name="resourceManager">资源管理器。</param>
        public ExamLoader(ExamManager examManager)
        {
            m_ExamManager = examManager;
            m_LoadCallbacks = new LoadCallbacks(OnLoadSuccess);
        }

        /// <summary>
        /// 获取题目
        /// </summary>
        public List<ExamBase> Exam
        {
            get
            {
                return m_Exams;
            }
            set
            {
                m_Exams = value;
            }
        }

        /// <summary>
        /// 获取题目数量
        /// </summary>
        public int ExamCount
        {
            get
            {
                return m_ExamCount;
            }
            set
            {
                m_ExamCount = value;
            }
        }

        /// <summary>
        /// 回调事件
        /// </summary>
        /// <param name="value"></param>
        private void OnLoadSuccess(string value)
        {
            m_LoadEventHandler(this, value);
        }

        public void Update()
        {
            UpdateUnityWebRequest();
        }

        /// <summary>
        /// 开始加载题目
        /// </summary>
        public void AddLoadAgent(string excelName)
        {
            StartLoadExams(excelName);
        }


        public void StartLoadExams(string excelName)
        {
            string path = Application.streamingAssetsPath + "/Exam/" + excelName + ".txt";
#if UNITY_5_4_OR_NEWER
            m_UnityWebRequest = UnityWebRequest.Get(path);
#if UNITY_2017_2_OR_NEWER
            m_UnityWebRequest.SendWebRequest();
#else
            m_UnityWebRequest.Send();
#endif
#else
            m_WWW = new WWW(Utility.Path.GetRemotePath(fullPath));
#endif
        }

        private void LoadSuccess(string message)
        {
            try
            {
                string value = StringAndZip.ZipToString(message);
                List<ExamBase> exams = JsonConvert.DeserializeObject<List<ExamBase>>(value, new LitJsonHelper());
                m_Exams = exams;
                m_ExamCount = exams.Count;
                m_LoadCallbacks.Invoke("加载成功");
                Debug.Log("加载成功");
            }
            catch (System.Exception e)
            {
                Debug.LogError("cant load exam by：" + e);
                Debug.Log("message：" + message);
            }
        }

        private void UpdateUnityWebRequest()
        {
            if (m_UnityWebRequest != null)
            {
                if (m_UnityWebRequest.isDone)
                {
                    if (string.IsNullOrEmpty(m_UnityWebRequest.error))
                    {
                        // 通知下载完毕
                        LoadSuccess(m_UnityWebRequest.downloadHandler.text);

                        m_UnityWebRequest.Dispose();
                        m_UnityWebRequest = null;
                        m_LastProgress = 0f;
                    }
                    else
                    {
                        bool isError = false;
#if UNITY_2020_2_OR_NEWER
                        isError = m_UnityWebRequest.result != UnityWebRequest.Result.Success;
#elif UNITY_2017_1_OR_NEWER
                        isError = m_UnityWebRequest.isNetworkError || m_UnityWebRequest.isHttpError;
#else
                        isError = m_UnityWebRequest.isError;
#endif
                    }
                }
                else
                {
                    m_LastProgress = m_UnityWebRequest.downloadProgress;
                }
            }
        }

        private IEnumerator LoadExams(string name, UnityAction<string> LoadExamCallBack)
        {
            string url = Application.streamingAssetsPath + "/Exam/" + name + ".txt";
            var request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
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

        public ExamBase GetExam(string examName)
        {
            return m_Exams.Find(value => value.ExamName == examName);
        }

        /// <summary>
        /// 清空选择题输入答案
        /// </summary>
        public void ClearAllInputAnswer()
        {
            if (m_Exams != null)
            {
                for (int i = 0; i < m_Exams.Count; i++)
                {
                    if (m_Exams[i].ExamType == ExamType.XuanZeTi)
                    {
                        ((ChoicesExam)m_Exams[i]).InputAnswer = null;
                    }
                    else if (m_Exams[i].ExamType == ExamType.TianKongTi)
                    {
                        ((InputExam)m_Exams[i]).InputAnswer = null;
                    }
                }
            }
        }

        /// <summary>
        /// 清空考题
        /// </summary>
        public void ClearExam()
        {
            m_Exams.Clear();
        }
    }
}