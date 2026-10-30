using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PostTest2 : MonoBehaviour
{
    //private string UrlJW = "www.mooc.mtn/VirtualCourse/";
    private string UrlgetUserInfo = "http://YOUR_API_HOST:8002/VirtualCourse/api/api-course/ums/getUserInfo";
    private string UrlupProgress = "http://YOUR_API_HOST:8002/VirtualCourse/api/api-course/cou/updateOrSaveProgress";
    private string UrlSaveScore = "http://YOUR_API_HOST:8002/VirtualCourse/api/api-course/cou/saveScore";
    private string Urlcatalogue = "http://YOUR_API_HOST:8002/VirtualCourse/api/api-course/cou/catalogue";

    string data = "";
    string token = "";
    string json = "";
    string textArea = "";
    string userID = "";
    string CourseID = "d50991fd7a768010a5d0c71281007240";

    void Start()
    {
        ReadData();
        ParseData();
    }

    //读取数据
    private void ReadData()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\TextRead.txt";
        textArea += "路径：" + path + "\r\n\r\n";
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);//读取数据
        }
        else
        {
            textArea += "路径不存在";
        }
        if (data != "")
        {
            textArea += "Token：" + data + "\r\n\r\n";
        }
        else
        {
            textArea += "没有数据";
        }
        //File.WriteAllText(path, "");//数据置空
    }

    //解析数据
    private void ParseData()
    {
        if (!string.IsNullOrEmpty(data))
        {
            //截取课程ID的开始位置
            int cid_startPosition = data.IndexOf(".");

            //截取课程ID的结束位置
            int cid_endPosition = data.IndexOf(":");

            //MessageBox.Show(string.Format("CID的开始位置：{0},结束位置：{1}", cid_startPosition, cid_endPosition));
            string cid = data.Substring(cid_startPosition + 1, cid_endPosition - cid_startPosition - 1);
            //截取参数的开始位置
            int param_startPosition = data.IndexOf("//");

            //截取参数的结束位置
            int param_endPosition = data.LastIndexOf("/");

            //MessageBox.Show(string.Format("参数的开始位置：{0},结束位置：{1}", param_startPosition, param_endPosition));
            string param = data.Substring(param_startPosition + 2, param_endPosition - param_startPosition - 2);

            //多个参数用,隔开
            string[] paramarr = param.Split(',');
            if (paramarr.Length > 0)
            {
                for (int i = 0; i < paramarr.Length; i++)
                {
                    string realparam = paramarr[i].ToString();
                    string[] realparamarr = realparam.Split(':');
                    if (realparamarr.Length >= 2)
                    {
                        if (realparamarr[0].ToLower() == "token")
                        {
                            token = realparamarr[1].ToString();
                            Debug.Log(token);
                            textArea += "解析Token：" + token + "\r\n\r\n";
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(token))
            {
                json = getJson(token, "3d990d2276917dfac04467df11fff26d");
                Debug.Log(json);
                textArea += "验证Token：" + json + "\r\n\r\n";
            }
        }
    }

    //解释token,验证token正确性
    public static string getJson(string token, string secretKey)
    {
        string json;
        try
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            var provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

            json = decoder.Decode(token, secretKey, verify: true);
        }
        catch (FormatException)
        {
            json = ("非法base64url字符串");
        }
        catch (TokenExpiredException)
        {
            json = ("Token has expired");
        }
        catch (SignatureVerificationException)
        {
            json = "Token has invalid signature";
        }
        return json;
    }

    /// <summary>
    /// 取时间戳，高并发情况下会有重复。想要解决这问题请使用sleep线程睡眠1毫秒。
    /// </summary>
    /// <param name="AccurateToMilliseconds">精确到毫秒</param>
    /// <returns>返回一个长整数时间戳</returns>
    public static long GetTimeStamp(bool AccurateToMilliseconds = false)
    {
        if (AccurateToMilliseconds)
        {

            // 使用当前时间计时周期数（636662920472315179）减去1970年01月01日计时周期数（621355968000000000）除去（删掉）后面4位计数（后四位计时单位小于毫秒，快到不要不要）再取整（去小数点）。

            //备注：DateTime.Now.ToUniversalTime不能缩写成DateTime.Now.Ticks，会有好几个小时的误差。

            //621355968000000000计算方法 long ticks = (new DateTime(1970, 1, 1, 8, 0, 0)).ToUniversalTime().Ticks;

            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

        }
        else
        {

            //上面是精确到毫秒，需要在最后除去（10000），这里只精确到秒，只要在10000后面加三个0即可（1秒等于1000毫米）。
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(300, 10, 120, 20), "获取用户信息"))
        {
            //Debug.Log("被点击了");
            getUserInfo();
        }
        if (GUI.Button(new Rect(300, 40, 120, 20), "上传课程进度"))
        {
            //Debug.Log("被点击了");
            updateOrSaveProgress();
        }
        if (GUI.Button(new Rect(300, 70, 120, 20), "上传课程结构"))
        {
            //Debug.Log("被点击了");
            catalogue();
        }
        if (GUI.Button(new Rect(300, 100, 120, 20), "保存课程结业成绩"))
        {
            //Debug.Log("被点击了");
            saveScore();
        }
        textArea = GUI.TextArea(new Rect(300, 130, 400, 400), textArea, 5000);
    }

    //获取用户信息
    private void getUserInfo()
    {
        try
        {
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(json);
            if (userInfo != null)
            {
                textArea += "用户ID：" + userInfo.eid + "\r\n";
                userID = userInfo.eid;
                if (!string.IsNullOrEmpty(userInfo.eid))
                {
                    WebRequestControl.RequestDataFormat(UrlgetUserInfo, getUserInfo_WWWFrom(userInfo.eid), getUserInfo_Return);
                }
            }
        }
        catch (Exception e)
        {
            //lblError.Text = json;
            Debug.Log(e);
            textArea += e + "\r\n";
        }
    }

    private WWWForm getUserInfo_WWWFrom(string userId)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", userId);
        return form;
    }

    private void getUserInfo_Return(string json)
    {
        BaseRes res = JsonConvert.DeserializeObject<BaseRes>(json);
        if (res != null && res.code == 200)
        {
            BaseResData data = res.data;
            if (data != null)
            {
                string content = "用户名：" + data.userName + " 性别：" + data.gender + " 生日：" + data.birthday + " 单位类别：" + data.deptType + " 单位ID：" + data.deptId;
                Debug.Log(content);
                textArea += content + "\r\n\r\n";
            }
        }
    }

    //上传课程进度
    private void updateOrSaveProgress()
    {
        WebRequestControl.RequestDataFormat(UrlupProgress, updateOrSaveProgress_Json(), updateOrSaveProgress_Return);
    }

    private string updateOrSaveProgress_Json()
    {
        StudyPercentReq entity = new StudyPercentReq();
        entity.userId = userID;
        entity.courseId = CourseID;
        entity.currentChapterName = "第一章：航空学;第一节：引言";
        entity.progress = 80;
        entity.studyLength = 60;
        entity.uploadTime = GetTimeStamp(true);
        entity.score = 60;
        string json = JsonUtility.ToJson(entity);
        return json;
    }

    private void updateOrSaveProgress_Return(string json)
    {
        StudyPercentRes res = JsonConvert.DeserializeObject<StudyPercentRes>(json);
        if (res != null && res.code == 200)
        {
            Debug.Log("提交学习进度成功！");
        }
        else
        {
            Debug.Log("提交学习进度失败：" + res?.msg);
        }
    }

    //保存课程结业成绩
    private void saveScore()
    {
        WebRequestControl.RequestDataFormat(UrlSaveScore, saveScore_Json(), saveScore_Return);
    }

    private string saveScore_Json()
    {
        SaveScoreReq entity = new SaveScoreReq();
        entity.userId = userID;
        entity.courseId = CourseID;
        entity.repair = 1;
        entity.score = 100;
        string json = JsonUtility.ToJson(entity);
        return json;
    }

    private void saveScore_Return(string json)
    {
        Debug.Log(json);
        StudyPercentRes res = JsonConvert.DeserializeObject<StudyPercentRes>(json);
        if (res != null && res.code == 200)
        {
            Debug.Log("保存课程结业成绩成功！");
        }
        else
        {
            Debug.Log("保存课程结业成绩失败：" + res?.msg);
        }
    }

    //上传课程结构信息
    private void catalogue()
    {
        WebRequestControl.RequestDataFormat(Urlcatalogue, catalogue_Json(), catalogue_Return);
    }

    private string catalogue_Json()
    {
        CatalogueReq catalogue = new CatalogueReq();
        catalogue.courseId = CourseID;
        catalogue.classHour = 600;
        catalogue.catalogue = new List<CatalogueItem>();

        CatalogueItem cataItem1 = new CatalogueItem();
        cataItem1.uninNodeName = "第一单元";
        cataItem1.sort = 1;
        cataItem1.clist = new List<ClistItem>();
        ClistItem clist1_1 = new ClistItem();
        clist1_1.courseNodeName = "1.初识xxx训练";
        clist1_1.sort = 1;
        clist1_1.clist = new List<ClistItem>();
        ClistItem clist1_1_1 = new ClistItem();
        clist1_1_1.courseNodeName = "1.子成xxx训练";
        clist1_1_1.sort = 1;
        clist1_1_1.clist = null;
        ClistItem clist1_1_2 = new ClistItem();
        clist1_1_2.courseNodeName = "2.子成xxx训练2";
        clist1_1_2.sort = 2;
        clist1_1_2.clist = null;
        clist1_1.clist.Add(clist1_1_1);
        clist1_1.clist.Add(clist1_1_2);
        ClistItem clist1_2 = new ClistItem();
        clist1_2.courseNodeName = "2.完成xxx训练";
        clist1_2.sort = 1;
        clist1_2.clist = null;
        ClistItem clist1_3 = new ClistItem();
        clist1_3.courseNodeName = "3.完成xxx训练";
        clist1_3.sort = 1;
        clist1_3.clist = null;
        cataItem1.clist.Add(clist1_1);
        cataItem1.clist.Add(clist1_2);
        cataItem1.clist.Add(clist1_3);
        CatalogueItem cataItem2 = new CatalogueItem();
        cataItem2.uninNodeName = "第一单元";
        cataItem2.sort = 1;
        cataItem2.clist = new List<ClistItem>();
        ClistItem clist2_1 = new ClistItem();
        clist2_1.courseNodeName = "1.进阶xxx训练";
        clist2_1.sort = 1;
        clist2_1.clist = null;
        ClistItem clist2_2 = new ClistItem();
        clist2_2.courseNodeName = "2.进阶xxx训练";
        clist2_2.sort = 1;
        clist2_2.clist = null;
        ClistItem clist2_3 = new ClistItem();
        clist2_3.courseNodeName = "3.进阶xxx训练";
        clist2_3.sort = 1;
        clist2_3.clist = new List<ClistItem>();
        cataItem2.clist.Add(clist2_1);
        cataItem2.clist.Add(clist2_2);
        cataItem2.clist.Add(clist2_3);
        catalogue.catalogue.Add(cataItem1);
        catalogue.catalogue.Add(cataItem2);
        string json = JsonUtility.ToJson(catalogue);
        return json;
    }

    private void catalogue_Return(string json)
    {
        StudyPercentRes res = JsonConvert.DeserializeObject<StudyPercentRes>(json);
        if (res != null && res.code == 200)
        {
            Debug.Log("上传课程结构信息成功！");
        }
        else
        {
            Debug.Log("上传课程结构信息失败：" + res?.msg);
        }
    }
}
