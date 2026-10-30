using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebData
{
    private static WebData _instance;
    public static WebData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WebData();
            }
            return _instance;
        }
    }

    private WebData()
    {
        expData = new RetunUserData();
        expData.access_token = "";
        expData.class_name = "";
        expData.code = 0;
        expData.course_id = "";
        expData.create_time = 0;
        expData.create_time_display = "";
        expData.dis = "";
        expData.experiment_id = "";
        expData.expires_time = 0;
        expData.expires_time_display = "";
        expData.progress_id = "";
        expData.role = 0;
        expData.school_id = "";
        expData.un = "";
        expData.user_id = "";

        updateData = new UpdateData();
        updateData.username = "";
        updateData.title = "";
        updateData.timeUsed = 0;
        updateData.status = 1;
        updateData.startTime = 0;
        updateData.endTime = 0;
        updateData.score = 0;
        updateData.steps = new List<ExpDataSteps>();

        steps = new List<ExpDataSteps>();


        for (int i = 1; i < 13; i++)
        {
            ExpDataSteps newSteps = new ExpDataSteps();
            newSteps.seq = i;//步骤号
            int index = i;
            switch (index)
            {
                case 1:
                    newSteps.title = "实验简介";//步骤名称
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 120;//合理时间 秒
                    newSteps.maxScore = 5;//满分 百分制
                    newSteps.score = 5;//得分 百分制
                    newSteps.repatCount = 0;//重复次数
                    newSteps.ecaluation = "";//评价
                    newSteps.scoringModel = "";//赋分模型
                    break;
                case 2:
                    newSteps.title = "实验目的";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 120;
                    newSteps.maxScore = 5;
                    newSteps.score = 5;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 3:
                    newSteps.title = "实验原理";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 120;
                    newSteps.maxScore = 5;
                    newSteps.score = 5;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 4:
                    newSteps.title = "习题模块";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 300;
                    newSteps.maxScore = 5;
                    newSteps.score = 5;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 5:
                    newSteps.title = "地黄总RNA提取";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 6:
                    newSteps.title = "RNA纯度及浓度检测";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 7:
                    newSteps.title = "RNA反转录";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 8:
                    newSteps.title = "RgPR1基因克隆及纯化";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 9:
                    newSteps.title = "RgPR1基因连接转化及菌液阳性检测和测序";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 10:
                    newSteps.title = "原核表达载体的构建";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 120;
                    newSteps.maxScore = 8;
                    newSteps.score = 8;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 11:
                    newSteps.title = "RgPR1重组蛋白的诱导表达和纯化";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                case 12:
                    newSteps.title = "蛋白质电泳分析";
                    newSteps.startTime = 0;
                    newSteps.endTime = 0;
                    newSteps.usedTime = 0;
                    newSteps.experctTime = 600;
                    newSteps.maxScore = 10;
                    newSteps.score = 10;
                    newSteps.repatCount = 0;
                    newSteps.ecaluation = "";
                    newSteps.scoringModel = "";
                    break;
                default:
                    break;
            }
            steps.Add(newSteps);
        }
    }
    public RetunUserData expData;
    public UpdateData updateData;
    public List<ExpDataSteps> steps;
    public bool firstLogin = true;//首次登陆
    public long startTime = 0;
    public long endTime = 0;
}
#region 自定义类
[System.Serializable]
public class WebPassPar
{
    public string tokenid;
    public string progressId;
    public string ticket;
}
[System.Serializable]
public class GetUser
{
    public string ticket;
    public string appid;
    public string signature;
}
[System.Serializable]
public class UpdateData
{
    public string username;
    public string title;
    public int status;
    public int score;
    public long startTime;
    public long endTime;
    public int timeUsed;
    public List<ExpDataSteps> steps;
}
[System.Serializable]
public class ExpDataSteps
{
    public int seq;     //步骤号
    public string title;     //步骤名称
    public long startTime;       //开始操作时间 时间戳
    public long endTime;         //结束操作时间 时间戳
    public int usedTime;        //操作时长 秒
    public int experctTime;     //合理时间 秒
    public int maxScore;        //满分 百分制
    public int score;           //得分 百分制
    public int repatCount;      //重复次数
    public string ecaluation;   //评价
    public string scoringModel; //赋分模型
    public string remarks; //备注
    public int done; //赋分模型
}
[System.Serializable]
public class RetunUserData
{
    public int code;
    public string access_token;
    public int create_time;
    public string create_time_display;
    public int expires_time;
    public string expires_time_display;
    public string user_id;
    public string un;
    public string dis;
    public string school_id;
    public string experiment_id;
    public string course_id;
    public string progress_id;
    public string class_name;
    public int role;
}
#endregion
