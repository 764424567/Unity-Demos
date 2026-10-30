using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ManagerPC : MonoBehaviour
{
    public GameObject[] PanelLsit;
    public Toggle[] ToggleList;

    public InputField[] InputPage1;
    public InputField[] InputPage2;
    public InputField[] InputPage3;

    public Button BtnPage1;
    public Button BtnPage2;
    public Button BtnPage3;


    void Start()
    {
        ToggleList[0].onValueChanged.AddListener((ison) => ToggleValueChange(0));
        ToggleList[1].onValueChanged.AddListener((ison) => ToggleValueChange(1));
        ToggleList[2].onValueChanged.AddListener((ison) => ToggleValueChange(2));
        ToggleList[0].isOn = true;

        BtnPage1.onClick.AddListener(() => BtnPage1Event());
        BtnPage2.onClick.AddListener(() => BtnPage2Event());
        BtnPage3.onClick.AddListener(() => BtnPage3Event());

        GetUrl();
        ShowInfo();
    }

    private void ToggleValueChange(int index)
    {
        for (int i = 0; i < PanelLsit.Length; i++)
        {
            PanelLsit[i].SetActive(false);
        }
        PanelLsit[index].SetActive(true);
        if (index == 1)
        {
            InputPage2[1].text = experimentId;
            InputPage2[2].text = realName;
        }
    }


    private void ShowInfo()
    {
        //面板1
        InputPage1[0].text = UrlLogin;
        InputPage1[1].text = "admin";
        InputPage1[2].text = "123456";

        //面板2
        InputPage2[0].text = UrlData;
        InputPage2[1].text = "12";
        InputPage2[2].text = "test";
        InputPage2[3].text = "测试实验";
        InputPage2[4].text = "1";
        InputPage2[5].text = "100";
        InputPage2[6].text = "2022/05/25 15:19:10";
        InputPage2[7].text = "2022/05/25 15:39:10";
        InputPage2[8].text = "1200";
        InputPage2[9].text = "10010";
        InputPage2[10].text = "10010";
        StepData step = new StepData();
        step.endTime = "2022/05/25 15:21:10";
        step.evaluation = "评价：未评价";
        step.expectTime = 60;
        step.maxScore = 100;
        step.remarks = "备注：无";
        step.repeatCount = 6;
        step.score = 60;
        step.scoringModel = "赋分模型：无";
        step.seq = 1;
        step.startTime = "2022/05/25 15:20:10";
        step.timeUsed = 60;
        step.title = "步骤1";
        string json = JsonUtility.ToJson(step);
        InputPage2[11].text = json;
        //InputPage2[11].interactable = false;

        //面板3
        InputPage3[0].text = UrlReport;
        InputPage3[1].text = "测试实验";
        InputPage3[2].text = "2021";
    }

    private void BtnPage1Event()
    {
        WebRequestControl.RequestDataFormat(UrlLogin, ReturnLoginJson(), ReturnData);
    }

    private string ReturnLoginJson()
    {
        UserIData data = new UserIData();
        data.account = InputPage1[1].text;
        data.password = InputPage1[2].text;

        string json = JsonUtility.ToJson(data);
        return json;
    }

    public WWWForm GetSubmitData(string account, string password)
    {
        //UserIData data = new UserIData();
        //data.account = account;
        //data.password = password;
        //string json = JsonUtility.ToJson(data);
        //WWWForm form = new WWWForm();
        //form.AddField("data", json);
        //return form;

        WWWForm form = new WWWForm();
        form.AddField("account", account);
        form.AddField("password", password);
        return form;
    }

    string token = "";
    string experimentId = "null";
    string realName = "";
    private void ReturnData(string value)
    {
        InputPage1[3].text = value;

        try
        {
            PassPar data = JsonUtility.FromJson<PassPar>(value);
            token = data.data.token;
            realName = data.data.realName;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            token = "YOUR_TOKEN";
            experimentId = "10010";
            realName = "test";
        }

    }

    private void BtnPage2Event()
    {
        WebRequestControl.RequestDataFormat(UrlData, ReturnData2(), ReturnData2);
    }

    private string ReturnData2()
    {
        ExpData data = new ExpData();
        data.experimentId = int.Parse(experimentId);
        data.username = realName;
        data.title = InputPage2[3].text;
        data.status = int.Parse(InputPage2[4].text);
        data.score = int.Parse(InputPage2[5].text);
        data.startTime = InputPage2[6].text;
        data.endTime = InputPage2[7].text;
        data.timeUsed = int.Parse(InputPage2[8].text);
        data.appid = int.Parse(InputPage2[9].text);
        data.originId = InputPage2[10].text;
        StepData[] step = new StepData[1];
        step[0] = new StepData();
        step[0].endTime = "2022/05/25 15:21:10";
        step[0].evaluation = "评价：未评价";
        step[0].expectTime = 60;
        step[0].maxScore = 100;
        step[0].remarks = "备注：无";
        step[0].repeatCount = 6;
        step[0].score = 60;
        step[0].scoringModel = "赋分模型：无";
        step[0].seq = 1;
        step[0].startTime = "2022/05/25 15:20:10";
        step[0].timeUsed = 60;
        step[0].title = "步骤1";
        data.steps = step;

        string json = JsonUtility.ToJson(data);
        return json;
    }

    public WWWForm GetSubmitData2()
    {
        ExpData data = new ExpData();
        data.experimentId = int.Parse(experimentId);
        data.username = realName;
        data.title = InputPage2[3].text;
        data.status = int.Parse(InputPage2[4].text);
        data.score = int.Parse(InputPage2[5].text);
        data.startTime = InputPage2[6].text;
        data.endTime = InputPage2[7].text;
        data.timeUsed = int.Parse(InputPage2[8].text);
        data.appid = int.Parse(InputPage2[9].text);
        data.originId = InputPage2[10].text;
        StepData[] step = new StepData[1];
        step[0] = new StepData();
        step[0].endTime = "2022/05/25 15:21:10";
        step[0].evaluation = "评价：未评价";
        step[0].expectTime = 60;
        step[0].maxScore = 100;
        step[0].remarks = "备注：无";
        step[0].repeatCount = 6;
        step[0].score = 60;
        step[0].scoringModel = "赋分模型：无";
        step[0].seq = 1;
        step[0].startTime = "2022/05/25 15:20:10";
        step[0].timeUsed = 60;
        step[0].title = "步骤1";
        data.steps = step;

        string json = JsonUtility.ToJson(data);
        WWWForm form = new WWWForm();
        form.AddField("data", json);
        return form;
    }

    private void ReturnData2(string value)
    {
        InputPage2[12].text = value;
    }

    private void BtnPage3Event()
    {
        string expName = InputPage3[1].text;
        string year = InputPage3[2].text;
        string url = UrlReport;
        url = url + "?experimentName=\"" + expName + "\"&year=\"" + year+ "\"";
        WebRequestControl.RequestDataFormatGet(url, token, ReturnData3);
    }

    private void ReturnData3(string value)
    {
        InputPage3[3].text = value;

        ReturnExpId data = JsonUtility.FromJson<ReturnExpId>(value);
        experimentId = data.data.experimentId.ToString();
    }

    private string UrlLogin;//获取用户信息接口
    private string UrlData;//上传实验数据接口
    private string UrlReport;//获取平台实验业务ID接口
    private void GetUrl()
    {
        string filePath = Application.streamingAssetsPath + "/UrlLoad.xml";
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNode rootNode = xmlDoc.FirstChild;
            XmlNodeList nodeList = rootNode.ChildNodes;
            foreach (XmlElement item in nodeList)
            {
                if (item.Name == "UrlLogin")
                {
                    UrlLogin = item.InnerText;
                }
                if (item.Name == "UrlData")
                {
                    UrlData = item.InnerText;
                }
                if (item.Name == "UrlReport")
                {
                    UrlReport = item.InnerText;
                }
            }
        }
    }
}
