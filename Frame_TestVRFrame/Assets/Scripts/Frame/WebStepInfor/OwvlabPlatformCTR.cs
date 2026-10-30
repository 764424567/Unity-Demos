/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： OwvlabPlatformCTR
* 创建日期：2021-06-07 13:58:43
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：2021年对接ILab接口控制脚本（旧平台）
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using Com.Rainier.Buskit3D.Owvlab;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class OwvlabPlatformCTR : MonoBehaviour 
	{

        //Host地址
        [Header("Host地址,WebGL不用填写")]
        public string Host = "http://dj.owvlab.net/virexp";

        [Header("实验登录ESID,WebGL不用填写")]
        public string ESID = "";
        #region user info
        //姓名
        [HideInInspector]
        public string Name { get; set; }

        //学号或者工号
        [HideInInspector]
        public string NumberID { get; set; }

        //角色类型
        [HideInInspector]
        public string Role { get; set; }

        //实验唯一标识符
        [HideInInspector]
        public string EID { get; set; }
        #endregion]

        public virtual void Awake()
        {
            InjectService.RegisterSingleton(this);
        }

        public virtual void Start()
        {
#if UNITY_WEBGL
            GetLabUserInfo(this.gameObject.name, "JsCallBack");
#endif
            InjectService.Get<WebStepInforManager>().SetAllStepStartTime();
        }

        /// <summary>
        /// js库中的GetUserInfo函数见：Assets\BuskitPlugins\OwvlabInteraction\Plugin\LanInterApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _GetUserInfo(string objname, string methodname);

        /// <summary>
        /// 调用js库函数获取当前登录用户信息
        /// </summary>
        public void GetLabUserInfo(string objname, string methodname)
        {
            try
            {
                _GetUserInfo(objname, methodname);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }

        }

        /// <summary>
        /// Js回调函数，获取登录用户信息,旧平台
        /// </summary>
        /// <param name="jsonStr"></param>
        public void JsCallBack(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
            {
                Debug.LogError("网页返回用户信息为空");
            }
            else
            {
                JObject jstr = JObject.Parse(jsonStr);
                Role = jstr["role"].ToString();
                NumberID = jstr["numberId"].ToString();
                Name = jstr["name"].ToString();
                EID = jstr["eid"].ToString();
                Debug.Log("获取到的用户信息：" + jstr);
            }
        }

        /// <summary>
        /// pc端登录接口
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        public void Login(string uname = "", string pwd = "", bool isCloud = false)
        {
#if UNITY_STANDALONE
            if (isCloud)
            {
                StartCoroutine(CloudLogin());
            }
            else
            {
                StartCoroutine(PcLogin(uname, pwd));
            }
#endif
        }


        /// <summary>
        /// webgl端成绩上传
        /// </summary>
        /// <param name="score">实验成绩</param>
        public void SendScoreToWeb(int score)
        {
#if UNITY_WEBGL
            string[] moduleFlag = { "实验成绩" };
            string[] questionNumber = { "1" };
            string[] questionStem = { "学生实验操作成绩" };
            string[] scores = { score.ToString() };
            string[] isTrue = { "True" };
            Application.ExternalCall("ReciveData", moduleFlag, questionNumber, questionStem, scores, isTrue);
#endif

#if UNITY_STANDALONE
            StartCoroutine(SubmitScore(score));
#endif
        }

        /// <summary>
        /// 建立实验步骤信息数据
        /// </summary>
        /// <returns></returns>
        private JArray BuildStepInfor()
        {
            List<WebStepInfor> webStepInfors = InjectService.Get<WebStepInforManager>().GetAllStepInfor();

            JArray stepDetails = new JArray();
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                if (!string.IsNullOrEmpty(webStepInfors[i].StartTime) || !string.IsNullOrEmpty(webStepInfors[i].EndTime))//有开始时间和结束时间说明此步骤完成了
                {
                    JObject jObject = new JObject();
                    jObject["seq"] = webStepInfors[i].QuestionNumber;
                    jObject["title"] = webStepInfors[i].ModuleFlag;
                    jObject["startTime"] = webStepInfors[i].StartTime;
                    jObject["endTime"] = webStepInfors[i].EndTime;
                    jObject["expectTime"] = webStepInfors[i].ExpectTime;
                    jObject["maxScore"] = webStepInfors[i].MaxScore;
                    jObject["score"] = webStepInfors[i].Score;
                    jObject["repeatCount"] = webStepInfors[i].RepeatCount;
                    jObject["evaluation"] = webStepInfors[i].Evaluation;
                    jObject["scoringModel"] = webStepInfors[i].ScoringModel;
                    jObject["remarks"] = webStepInfors[i].Remarks;
                    stepDetails.Add(jObject);
                }

            }

            return stepDetails;

        }

        private int ExpScore() {
            List<WebStepInfor> webStepInfors = InjectService.Get<WebStepInforManager>().GetAllStepInfor();
            int score = 0;
            for (int i = 0; i < webStepInfors.Count; i++)
            {
                score += webStepInfors[i].Score;
            }
            return score;
        }

        /// <summary>
        /// 上传实验步骤
        /// </summary>
        /// <param name="jsonResult"></param>
        public void SendMessageToPlatform() {
            InjectService.Get<WebStepInforManager>().SetNullStepEndTime();
#if UNITY_WEBGL
            JObject result = new JObject();
            result["eid"] = EID;
            result["steps"] = BuildStepInfor();
            Debug.Log(result);
            int score = ExpScore();
            Debug.Log(score);
            SendScoreToWeb(score);
            WaitTimeDoFunc(3f, () => {
                Application.ExternalCall("UploadSteps", result.ToString());
            });
            
#endif
        }


        /// <summary>
        /// webgl提交实验报告
        /// </summary>
        /// <param name="jsonReslut">json格式报告字符串</param>
        public void SendReportToWeb(string jsonResult)
        {
#if UNITY_WEBGL
            Application.ExternalCall("ReportEdit", jsonResult);
#endif
#if UNITY_STANDALONE
            StartCoroutine(SubmitReport(jsonResult));
#endif
        }


        /// <summary>
        /// 上传实验脚本
        /// </summary>
        /// <param name="jsonReq">请求参数</param>
        public void UploadReplay(string jsonReq)
        {
            StartCoroutine(SubmitReplay(jsonReq));
        }

        /// <summary>
        /// 下载实验脚本接口
        /// </summary>
        /// <param name="action">回调函数</param>
        public void DownloadReplay(Action<string> action)
        {
            StartCoroutine(ObtainReplay(action));
        }

        /// <summary>
        /// pc登录获取信息
        /// </summary>
        /// <param name="uname">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="esid">pc端实验esid</param>
        /// <returns></returns>
        IEnumerator PcLogin(string uname, string pwd)
        {
            JObject info = new JObject();
            info["account"] = uname;
            info["password"] = pwd;
            info["esid"] = ESID;

            byte[] postBtye = System.Text.Encoding.UTF8.GetBytes(info.ToString());
            string postData = System.Convert.ToBase64String(postBtye);

            WWWForm form = new WWWForm();
            form.AddField("param", postData);

            var req = UnityWebRequest.Post($"{Host}/outer/login", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            var op = req.SendWebRequest<PcLoginReqData>();
            yield return op;

            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<PcLoginReqData>().GetObject();

            Name = obj.name;
            NumberID = obj.numberId;
            Role = obj.role;
            //显示实验选择列表
            PopUpExpWindow(obj);
        }

        /// <summary>
        /// pc登录获取信息
        /// </summary>
        /// <returns></returns>
        IEnumerator CloudLogin()
        {
            string[] args = Environment.GetCommandLineArgs();

            string token = "";

            foreach (var item in args)
            {

                if (item.StartsWith("token"))
                {
                    token = item.Split('=')[1];
                }
            }

            JObject info = new JObject();
            info["token"] = token;

            byte[] postBtye = System.Text.Encoding.UTF8.GetBytes(info.ToString());
            string postData = System.Convert.ToBase64String(postBtye);

            WWWForm form = new WWWForm();
            form.AddField("param", postData);

            var req = UnityWebRequest.Post($"{Host}/outer/getMessageByToken", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            var op = req.SendWebRequest<CloudLoginReqData>();
            yield return op;

            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<CloudLoginReqData>().GetObject();

            Name = obj.name;
            NumberID = obj.numberId;
            Role = obj.role;
            EID = obj.eid;
        }

        /// <summary>
        /// 提交实验成绩
        /// </summary>
        /// <param name="score"></param>
        IEnumerator SubmitScore(int score)
        {

            JObject info = new JObject();
            info["numberId"] = NumberID;
            info["name"] = Name;
            info["eid"] = EID;
            info["expScore"] = score.ToString();

            WWWForm form = new WWWForm();
            form.AddField("param", info.ToString());

            var req = UnityWebRequest.Post($"{Host}/outer/intelligent/!expScoreSave", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            var op = req.SendWebRequest<CommonReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<CommonReqData>().GetObject();
            Debug.Log(string.Format("上传实验成绩请求返回：状态码[{0}] statusMessage[{1}]", obj.status, obj.statusMessage));
        }

        /// <summary>
        /// 提交实验报告
        /// </summary>
        /// <param name="jsonReq"></param>
        IEnumerator SubmitReport(string jsonReq)
        {
            WWWForm form = new WWWForm();
            form.AddField("param", jsonReq.ToString());
            var req = UnityWebRequest.Post($"{Host}/outer/report/!reportEdit", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            var op = req.SendWebRequest<CommonReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<CommonReqData>().GetObject();
            Debug.Log(string.Format("上传实验报告请求返回：状态码[{0}] statusMessage[{1}]", obj.status, obj.statusMessage));
        }

        /// <summary>
        /// 提交实验脚本
        /// </summary>
        /// <param name="jsonReq">请求参数</param>
        IEnumerator SubmitReplay(string jsonReq)
        {

            OwvlabPlatform owvlab = InjectService.Get<OwvlabPlatform>();

            JObject info = new JObject();
            info["role"] = owvlab.Role;
            info["numberId"] = owvlab.NumberID;
            info["name"] = owvlab.Name;
            info["eid"] = owvlab.EID;
            info["initScript"] = jsonReq;

            WWWForm form = new WWWForm();
            form.AddField("param", info.ToString());

            var req = UnityWebRequest.Post($"{owvlab.Host}/outer/playback/!submit", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            var op = req.SendWebRequest<CommonReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<CommonReqData>().GetObject();
            Debug.Log(string.Format("上传回放请求返回：状态码[{0}] statusMessage[{1}]", obj.status, obj.statusMessage));
        }

        /// <summary>
        /// 下载实验脚本
        /// </summary>
        /// <param name="action">回调函数</param>
        /// <returns></returns>
        IEnumerator ObtainReplay(Action<string> action)
        {
            OwvlabPlatform owvlab = InjectService.Get<OwvlabPlatform>();

            JObject info = new JObject();
            info["role"] = owvlab.Role;
            info["numberId"] = owvlab.NumberID;
            info["name"] = owvlab.Name;
            info["eid"] = owvlab.EID;


            WWWForm form = new WWWForm();
            form.AddField("param", info.ToString());

            var req = UnityWebRequest.Post($"{owvlab.Host}/outer/playback/!obtain", form);
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            var op = req.SendWebRequest<DownLoadReplayReqData>();

            yield return op;

            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }

            var obj = op.webRequest.DownLoadHanlderJson<DownLoadReplayReqData>().GetObject();
            if (obj == null)
            {
                // 没有实验数据
                Debug.Log("没有试验数据");
                yield break;
            }
            if (action != null)
            {
                action(obj.initScript);

            }
        }

        /// <summary>
        /// 弹出实验选择窗口,选择实验，并赋值eid
        /// </summary>
        public virtual void PopUpExpWindow(PcLoginReqData reqData)
        {
            GameObject canvas = Instantiate(Resources.Load<GameObject>("OwvlabWindow"));

            Transform content = canvas.transform.Find("ScrollView/Viewport/Content");

            foreach (ExpListData item in reqData.expList)
            {
                GameObject _item = Instantiate(Resources.Load<GameObject>("owvlabExpItem"));
                _item.transform.SetParent(content);
                _item.transform.SetAsLastSibling();
                _item.transform.Find("eid").GetComponent<Text>().text = item.id;
                _item.transform.Find("expname").GetComponent<Text>().text = item.expName;
                _item.transform.Find("lessonname").GetComponent<Text>().text = item.lectureName;
                _item.transform.Find("teacher").GetComponent<Text>().text = item.teacher;
                _item.transform.Find("time").GetComponent<Text>().text = item.createTime;

                _item.GetComponent<Button>().onClick.AddListener(() => {

                    EID = item.id;
                    Destroy(canvas);
                });
            }
        }
        private void OnDestroy()
        {
            InjectService.Unregister<OwvlabPlatformCTR>();
        }


        /// <summary>
        /// 延时指定时间后执行方法
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="func">方法</param>
        protected void WaitTimeDoFunc(float time, UnityAction func)
        {
            StartCoroutine(WaitTime(time, func));
        }

        private IEnumerator WaitTime(float time, UnityAction func)
        {
            yield return new WaitForSeconds(time);
            func();
        }
    }

    /// <summary>
    /// 云平台实验登录请求返回内容参数，旧平台
    /// </summary>
    [System.Serializable]
    public class CloudLoginReqData
    {
        //状态码
        public string status;
        //角色类型
        public string role;
        //学号或者工号
        public string numberId;
        //姓名
        public string name;
        //用户id
        public string userId;
        //实验记录唯一标识符eid
        public string eid;

    }

    /// <summary>
	/// pc实验登录请求返回内容参数，旧平台
	/// </summary>
	[System.Serializable]
    public class PcLoginReqData
    {
        //状态码
        public string status;
        //角色类型
        public string role;
        //学号或者工号
        public string numberId;
        //姓名
        public string name;
        //所属班级
        public string className;
        //实验资源id
        public string resourceId;
        //实验信息列表
        public List<ExpListData> expList;

    }

    /// <summary>
    /// 实验信息列表
    /// </summary>
    [System.Serializable]
    public class ExpListData
    {
        //实验记录唯一标识符eid
        public string id;
        //实验名称
        public string expName;
        //开课名称
        public string lectureName;
        //所属教师
        public string teacher;
        //开始时间
        public string createTime;
    }

    /// <summary>
    /// 下载回放请求返回内容参数
    /// </summary>
    [System.Serializable]
    public class DownLoadReplayReqData
    {
        //状态码
        public string status;
        public string statusMessage;
        //回放数据
        public string initScript;
    }

    /// <summary>
    /// 默认返回的内容参数
    /// </summary>
    public class CommonReqData
    {
        public string status;
        public string statusMessage;
    }
}


