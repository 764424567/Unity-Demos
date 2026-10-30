/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： OwvlabPlatformNew
* 创建日期：2020-03-19 15:35:27
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D.Owvlab
{
    /// <summary>
    /// 与新平台的数据交互接口
    /// </summary>
	public class OwvlabPlatformNew : MonoBehaviour
    {


        #region user info new
        [Header("发布pc版本，需要填写esid")]
        public string NEW_ESID = "";

        [Header("发布pc版本，需要填写host")]
        public string NEW_HOST = "";

        //对应expId
        [HideInInspector]
        public string NEW_EID { get; set; }

        //学号或者工号
        [HideInInspector]
        public string NEW_ID { get; set; }

        //姓名
        [HideInInspector]
        public string NEW_Name { get; set; }

        #endregion

        public virtual void Awake()
        {
            if (InjectService.Get<OwvlabPlatformNew>() == null)
                InjectService.RegisterSingleton(this);
        }

        public virtual void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Application.ExternalCall("getExpId", this.gameObject.name, "New_JsCallBack");
#endif
        }

        /// <summary>
        /// pc端用户登录
        /// </summary>
        /// <param name="uname">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="isCloud">是否是云平台</param>
        public void Login(string uname = "", string pwd = "", bool isCloud = false)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            if (isCloud)
            {
                StartCoroutine(New_CloudLogin());
            }
            else
            {
                StartCoroutine(New_PcLogin(uname, pwd));
            }
#endif
        }

        /// <summary>
        /// Js回调函数，获取登录用户信息，新平台
        /// </summary>
        /// <param name="jsonStr"></param>
        public void New_JsCallBack(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
            {
                Debug.LogError("网页返回用户信息为空");
            }
            else
            {
                JObject jstr = JObject.Parse(jsonStr);
                NEW_ESID = jstr["appId"].ToString();
                NEW_EID = jstr["expId"].ToString();
                NEW_HOST = jstr["host"].ToString();
                Debug.Log("获取到的用户信息：" + jstr);
            }
        }

        /// <summary>
        /// 新平台上传成绩接口
        /// </summary>
        /// <param name="score">分数</param>
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
            StartCoroutine(New_SubmitScore(score));
#endif
        }

        /// <summary>
        /// 实验报告的表单形式
        /// </summary>
        /// <param name="form"></param>
        public void SendReportToWeb(WWWForm form)
        {
            StartCoroutine(New_SendReportToWeb(form));
        }


        /// <summary>
        /// 新平台登录
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        IEnumerator New_PcLogin(string uname, string pwd)
        {


            WWWForm form = new WWWForm();
            form.AddField("account", uname);
            form.AddField("password", pwd);
            form.AddField("isiabx", 0);

            var req = UnityWebRequest.Post(NEW_HOST + "/openapi/" + NEW_ESID, form);
            var op = req.SendWebRequest<NewLoginReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<NewLoginReqData>().GetObject();
            New_PopUpExpWindow(obj);

            NEW_ID = obj.user["id"].ToString();
            NEW_Name = obj.user["name"].ToString();
            if (!string.IsNullOrEmpty(obj.error))
                Debug.Log(obj.error);
        }

        /// <summary>
        /// 新平台 云登录
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        IEnumerator New_CloudLogin()
        {
            string[] args = Environment.GetCommandLineArgs();

            string sequenceCode = "";

            foreach (var item in args)
            {

                if (item.StartsWith("sequenceCode"))
                {
                    sequenceCode = item.Split('=')[1];
                }
            }

            WWWForm form = new WWWForm();
            form.AddField("sequenceCode", sequenceCode);

            var req = UnityWebRequest.Post(NEW_HOST + "/openapi/" + NEW_ESID, form);
            var op = req.SendWebRequest<NewLoginReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<NewLoginReqData>().GetObject();

            //赋值eid
            NEW_EID = obj.expList[0].expId;
        }

        /// <summary>
        /// 新平台上传实验成绩
        /// </summary>
        /// <param name="score">成绩</param>
        /// <returns></returns>
        IEnumerator New_SubmitScore(int score)
        {
            JArray ja = new JArray();
            JObject jsonStr = new JObject();
            jsonStr["moduleFlag"] = "实验成绩";
            jsonStr["questionNumber"] = 1;
            jsonStr["questionStem"] = "学生操作成绩";
            jsonStr["score"] = score;
            jsonStr["trueOrFalse"] = "True";
            ja.Add(jsonStr);

            var req = new UnityWebRequest(NEW_HOST + "/openapi/scoredetail/" + NEW_ESID + "/" + NEW_EID, "POST");

            byte[] data = System.Text.Encoding.UTF8.GetBytes(ja.ToString());
            req.uploadHandler = new UploadHandlerRaw(data);
            req.SetRequestHeader("Content-Type", "application/json");
            var op = req.SendWebRequest<NewCommonReqData>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<NewCommonReqData>().GetObject();
            Debug.Log(string.Format("上传实验成绩请求返回：code[{0}] message[{1}]", obj.code, obj.msg));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form">实验报告的表单格式</param>
        /// <returns></returns>
        IEnumerator New_SendReportToWeb(WWWForm form)
        {
            //WWWForm form = new WWWForm();
            //form.AddField("appid", NEW_ESID);
            //form.AddField("resourceReservationId", NEW_EID);
            //form.AddField("reportData", reportData);
            //foreach (var item in pics)
            //{
            //    form.AddBinaryData("picFiles", item.Value, item.Key);
            //}
            var req = UnityWebRequest.Post(NEW_HOST + "/openapi/report/reportEdit/" + NEW_ESID + "/" + NEW_EID, form);
            var op = req.SendWebRequest<JObject>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<JObject>().GetObject();
            Debug.Log(obj.ToString());

        }

        /// <summary>
        /// 新平台上传实验脚本
        /// </summary>
        /// <param name="jsonReplay">请求参数</param>
        /// <returns></returns>
        IEnumerator New_SubmitReplay(string jsonReplay)
        {

            WWWForm form = new WWWForm();

            form.AddField("context", jsonReplay);
            var req = UnityWebRequest.Post(NEW_HOST + "/openapi/datastore/" + NEW_ESID + "/" + NEW_EID, form);

            var op = req.SendWebRequest<JObject>();
            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<JObject>().GetObject();
            //   Debug.Log(string.Format("上传实验成绩请求返回：code[{0}] message[{1}]", obj.code, obj.msg));
            Debug.Log(obj);
        }

        /// <summary>
        /// 新平台下载实验脚本
        /// </summary>
        /// <param name="jsonReq">请求参数</param>
        /// <param name="action">回调函数</param>
        /// <returns></returns>
        IEnumerator New_ObtainReplay(string jsonReq, Action<string> action)
        {

            string url = NEW_HOST + "/openapi/datastore/get/" + NEW_ESID + "/" + NEW_EID;

            var req = UnityWebRequest.Get(url);

            var op = req.SendWebRequest<JObject>();

            yield return op;
            if (op.webRequest.isNetworkError)
            {
                Debug.LogError($"Network Error: {op.webRequest.error}");
                yield break;
            }
            var obj = op.webRequest.DownLoadHanlderJson<JObject>().GetObject();

            if (obj == null)
            {
                // 没有实验数据
                Debug.Log("没有试验数据");
                yield break;
            }

            if (action != null)
            {
                action(obj["context"].ToString());
            }
        }


        /// <summary>
        /// 弹出实验选择窗口,选择实验，并赋值eid  新平台
        /// </summary>
        /// <param name="reqData"></param>
        public virtual void New_PopUpExpWindow(NewLoginReqData reqData)
        {
            GameObject canvas = Instantiate(Resources.Load<GameObject>("NewOwvlabWindow"));

            Transform content = canvas.transform.Find("ScrollView/Viewport/Content");

            foreach (NewExpListData item in reqData.expList)
            {
                GameObject _item = Instantiate(Resources.Load<GameObject>("NewowvlabExpItem"));
                _item.transform.SetParent(content);
                _item.transform.SetAsLastSibling();
                _item.transform.Find("eid").GetComponent<Text>().text = item.expId;
                _item.transform.Find("expname").GetComponent<Text>().text = item.expName;
                _item.transform.Find("expScore").GetComponent<Text>().text = item.expScore;
                _item.transform.Find("expComment").GetComponent<Text>().text = item.expComment;

                _item.GetComponent<Button>().onClick.AddListener(() =>
                {
                    NEW_EID = item.expId;
                    Destroy(canvas);
                });
            }
        }

        private void OnDestroy()
        {
            InjectService.Unregister<OwvlabPlatformNew>();
        }
    }

    /// <summary>
    /// 默认返回的内容参数(新平台)
    /// </summary>
    [System.Serializable]
    public class NewCommonReqData
    {
        public string msg;
        public string code;
    }

    [System.Serializable]
    public class NewLoginReqData
    {
        public string error;
        public string urlDataPost;
        public List<NewExpListData> expList;
        public JObject user;
    }

    [System.Serializable]
    public class NewExpListData
    {
        public string expId;
        public string expName;
        public string expScore;
        public string expComment;
    }
    [System.Serializable]
    public class ReplayReqData
    {
        public string code;
        public string msg;
        public string teachercontext;
        public string context;
    }

}

