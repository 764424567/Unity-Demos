using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WebControl : MonoBehaviour
{
    public static WebControl Instance;

    private string m_url = "http://YOUR_INTERNAL_SERVER";
    private string ticket = "YOUR_TICKET";
    private string appid = "YOUR_APPID";
    private string secret = "YOUR_SECRET";
    private string signature;

    void Awake()
    {
        Instance = this;
    }


    [DllImport("__Internal")]
    private static extern string GetVariable();
    void Start()
    {
        //if (WebData.Instance.firstLogin)
        //{
        //    WebData.Instance.firstLogin = false;
        //    GetUserData();
        //}
        //string url = "http://YOUR_API_HOST:8080/api/open/dataupload?access_token=YOUR_ACCESS_TOKEN";
        //WebRequestControl.RequestDataFormat(url,"{'username'='test1'}", ReturnUserInfo);

        if (WebData.Instance.firstLogin)
        {
            WebData.Instance.firstLogin = false;

            string json = GetVariable();
            Debug.Log("从前端获取到的参数：" + json);
            WebPassPar data = JsonUtility.FromJson<WebPassPar>(json);

            ticket = data.ticket;
            Debug.Log("解析ticket：" + data.ticket);
            GetUserData();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetUserData();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UploadExpData();
        }
    }

    // 向平台请求用户信息
    public void GetUserData()
    {
        signature = WebRequestControl.Encrypt_MD5(ticket + appid + secret);
        string url = m_url + "/api/open/token";
        url += "?ticket=" + ticket + "&appid=" + appid + "&signature=" + signature;
        Debug.Log(signature + "  " + url);
        WebRequestControl.RequestDataFormat(url, ReturnUserInfo);
    }

    private void ReturnUserInfo(string info)
    {
        Debug.Log("返回的用户数据：" + info);
        RetunUserData data = JsonUtility.FromJson<RetunUserData>(info);
        WebData.Instance.expData = data;
        Debug.Log(data.access_token);
        Debug.Log(data.un);
        Debug.Log(data.dis);
        Debug.Log(data.course_id);

        WebData.Instance.updateData.username = data.dis;
        WebData.Instance.updateData.title = "地黄抗病基因PR1的克隆及蛋白纯化的虚拟仿真实验";
        WebData.Instance.updateData.status = 1;
        WebData.Instance.updateData.startTime = WebRequestControl.GetTimeStamp(true);
        WebData.Instance.updateData.steps = new List<ExpDataSteps>();
    }

    /// <summary>
    /// 保存实验步骤数据
    /// </summary>
    /// <param name="stepCode"></param>
    /// <param name="score"></param>
    public void SaveExpData(int stepCode, int score = -1)
    {
        stepCode = stepCode - 1;
        WebData.Instance.endTime = WebRequestControl.GetTimeStamp(true);
        WebData.Instance.steps[stepCode].startTime = WebData.Instance.startTime;
        WebData.Instance.steps[stepCode].endTime = WebData.Instance.endTime;
        WebData.Instance.steps[stepCode].usedTime = WebRequestControl.GetTimeUsed(WebData.Instance.startTime, WebData.Instance.endTime);
        if (score != -1)
            WebData.Instance.steps[stepCode].score = score;
        WebData.Instance.startTime = WebData.Instance.endTime;
    }

    // 向平台上传数据
    public void UploadExpData()
    {
        //更新实验数据
        WebData.Instance.updateData.endTime = WebRequestControl.GetTimeStamp(true);
        WebData.Instance.updateData.steps = WebData.Instance.steps;
        WebData.Instance.updateData.timeUsed = WebRequestControl.GetTimeUsed(WebData.Instance.updateData.startTime, WebData.Instance.updateData.endTime);//将结束时间减去开始时间

        WWWForm form = new WWWForm();
        form.AddField("access_token", WebData.Instance.expData.access_token);
        form.AddField("username", WebData.Instance.updateData.username);
        form.AddField("title", WebData.Instance.updateData.title);
        form.AddField("status", WebData.Instance.updateData.status);
        form.AddField("score", WebData.Instance.updateData.score);
        form.AddField("startTime", WebData.Instance.updateData.startTime.ToString());
        form.AddField("endTime", WebData.Instance.updateData.endTime.ToString());
        form.AddField("timeUsed", WebData.Instance.updateData.timeUsed.ToString());
        form.AddField("steps", JsonUtility.ToJson(WebData.Instance.updateData.steps));

        string json = JsonUtility.ToJson(WebData.Instance.updateData);
        Debug.Log(json);

        string url = m_url + "/api/open/dataupload?access_token=" + WebData.Instance.expData.access_token;
        Debug.Log(url);
        WebRequestControl.RequestDataFormat(url, json, ReturnExpData);
    }

    // 返回数据
    private void ReturnExpData(string json)
    {
        Debug.Log(json);
    }
}