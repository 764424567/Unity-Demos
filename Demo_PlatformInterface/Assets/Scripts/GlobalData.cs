using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    private static GlobalData _instance;
    public static GlobalData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalData();
            }
            return _instance;
        }
    }
    public GlobalData()
    {
        LoginData = new ExpLoginData();
    }

    public ExpLoginData LoginData { get; set; }//登录数据
}
[Serializable]
public class ExpLoginData
{
    public string token;        //凭证
    public string experimentId; //当前实验业务ID
    public string realName;     //用户名称
    public string refurl;       //做完实验后需要跳转平台地址
}
[Serializable]
public class UserInfo
{
    public string userFlag;
    public string eid;
    public string userName;
}
//返回类
public class BaseRes
{
    public int code { get; set; }
    public string msg { get; set; }
    public BaseResData data { get; set; }
}

//返回data
public class BaseResData
{
    /// <summary>
    /// 用户id
    /// </summary>
    public string userId;
    /// <summary>
    /// 昵称
    /// </summary>
    public string userName;
    /// <summary>
    /// 性别
    /// </summary>
    public string gender;
    /// <summary>
    /// 出生日期
    /// </summary>
    public string birthday;
    /// <summary>
    /// 单位类别
    /// </summary>
    public string deptType;
    /// <summary>
    /// 单位id
    /// </summary>
    public string deptId;
    /// <summary>
    /// 身份类别
    /// </summary>
    public string identityType;
    /// <summary>
    /// 职级
    /// </summary>
    public string rank;
    /// <summary>
    /// 职称
    /// </summary>
    public string jobTitle;
    /// <summary>
    /// 学历
    /// </summary>
    public string education;
    /// <summary>
    /// 邮箱
    /// </summary>
    public string email;
    /// <summary>
    /// 用户头像
    /// </summary>
    public string userImg;
}
//学习进度请求
public class StudyPercentReq
{
    /// <summary>
    /// 用户id
    /// </summary>
    public string userId;
    /// <summary>
    /// 课程id
    /// </summary>
    public string courseId;
    /// <summary>
    /// 当前学习章节  当前正在学习的课程章节名称，格式为“章名称;节名称”，例如“第一章：xxx;第一节：xxx”
    /// </summary>
    public string currentChapterName;
    /// <summary>
    /// 总体学习进度 (0-100整型)百分比进度,如传40  ，代表进度为40%。如果传1.8，代表进度为1.8%
    /// </summary>
    public float progress;
    /// <summary>
    /// 此次在线练习时长 单位精度为秒。
    /// </summary>
    public int studyLength;
    /// <summary>
    /// 调用接口的时间 当前时间戳
    /// </summary>
    public long uploadTime;
    ///// <summary>
    ///// 目前得分  每次更新进度的当前得分情况
    ///// </summary>
    public float score;
}
//学习进度返回
public class StudyPercentRes
{
    public int code;
    public string msg;
    public object data;
}
//保存课程成绩
public class SaveScoreReq
{
    /// <summary>
    /// 用户id
    /// </summary>
    public string userId;
    /// <summary>
    /// 课程id
    /// </summary>
    public string courseId;
    /// <summary>
    /// 是否重新学习 是否是补考，不传默认为0，正常考试。  1为补考。 如果课程结业了。默认值情况下是不会更新学习进度。
    /// </summary>
    public int repair;
    /// <summary>
    /// 最后得分  每次更新进度的当前得分情况
    /// </summary>
    public float score;
}
//上传课程结构信息
public class CatalogueReq
{
    /// <summary>
    /// 课程id
    /// </summary>
    public string courseId;
    /// <summary>
    /// 课程学时，按课程技术标准有关规定进行传参。
    /// </summary>
    public int classHour;
    /// <summary>
    /// 课程的结构目录。
    /// </summary>
    public List<CatalogueItem> catalogue;
}
//请求参数 catalogue 字典描述
public class CatalogueItem
{
    /// <summary>
    /// 单元节点
    /// </summary>
    public string uninNodeName;
    /// <summary>
    /// 单元节点排序
    /// </summary>
    public int sort;
    /// <summary>
    /// 课程的结构目录。
    /// </summary>
    public List<ClistItem> clist;
}
//请求参数 clist 字典描述
public class ClistItem
{
    /// <summary>
    /// 单元节点
    /// </summary>
    public string courseNodeName;
    /// <summary>
    /// 单元节点排序
    /// </summary>
    public int sort;
    /// <summary>
    /// 课程的结构目录。
    /// </summary>
    public List<ClistItem> clist;
}
//用户登录 发送数据
[System.Serializable]
public class UserIData       //账号密码（请求）
{
    public string account;
    public string password;
}

[System.Serializable]
public class WebPassPar
{
    public string realName;
    public string token;
    public string experimentId;
}
[System.Serializable]
public class PassPar
{
    public int code;
    public PassParData data;
    public string msg;
    public string success;
}
[System.Serializable]
public class PassParData
{
    public string realName;
    public string token;
}
[System.Serializable]
public class ReturnExpId
{
    public int code;
    public ExperimentId data;
    public string msg;
    public string success;
}
[System.Serializable]
public class ExperimentId
{
    public int experimentId;
}

[System.Serializable]
public class ExpData
{
    public int experimentId;
    public string username;
    public string title;
    public int status;
    public int score;
    public string startTime;
    public string endTime;
    public int timeUsed;
    public int appid;
    public string originId;
    public StepData[] steps;
}
[System.Serializable]
public class StepData
{
    public string endTime;
    public string evaluation;
    public int expectTime;
    public int maxScore;
    public string remarks;
    public int repeatCount;
    public int score;
    public string scoringModel;
    public int seq;
    public string startTime;
    public int timeUsed;
    public string title;
}
//用户登录 发送数据
[System.Serializable]
public class GetData       //账号密码（请求）
{
    public int value;
}
//发送给服务器数据
[System.Serializable]
public class GetPostData
{
    public int status;
    public SendData[] data;
}
//发送给服务器数据
[System.Serializable]
public class SendData
{
    public int id;
    public GetExpData e_data;
}
[System.Serializable]
public class GetExpData
{
    public EDataItem eData;
}
[System.Serializable]
public class EDataItem
{
    public EDataItemList[] eList;
    public Topic[] topic;
    public EScore eScore;
    public string analyse;
}
[System.Serializable]
public class EDataItemList
{
    public ParameterItem[] parameter;
    public Topic[] topic;
}
[System.Serializable]
public class ParameterItem
{
    public string name;
    public string alias;
    public string angle1;
    public string angle2;
    public string structure;
    public string[] fitting;
}
[System.Serializable]
public class Topic
{
    public string title;
    public string option;
    public string answer;
    public string score;
}
[System.Serializable]
public class EScore
{
    public int vOperator;       //虚拟实验操作        4
    public int design;          //完成变量参数设计    4
    public int record;          //完成实验测量数据记录 22
    public int topic;           //完成结论答题        20
    public int draw;            //结构图绘制         14
    public int fitting;         //试衣图绘制         14
    public int analyse;         //实操实验分析比较      14
}

[System.Serializable]
public class GetPostData2
{
    public int status;
    public SendData2[] data;
}
[System.Serializable]
public class SendData2
{
    public int id;
    public GetExpData2 e_data;
    public string e_score;
    public string status;
}
[System.Serializable]
public class GetExpData2
{
    public EDataItem2 eData;
}
[System.Serializable]
public class EDataItem2
{
    public EDataItemList2[] eList;
    public Topic[] topic;
    public EScore eScore;
    public string analyse;
}
[System.Serializable]
public class EDataItemList2
{
    public ParameterItem2[] parameter;
    public Topic[] topic;
    public string choose;//选择的参数  0 3 6 9 12  4 8 12 16 20 24
}
[System.Serializable]
public class ParameterItem2
{
    public string name;
    public string alias;
    public string angle;
    public string[] structure;
    public string[] fitting;
}