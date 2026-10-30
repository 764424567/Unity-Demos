using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class PostTest : MonoBehaviour
{
    //private string UrlGetData = "http://YOUR_API_HOST:800/zut/fashion_test/api/getExperimentList";
    private string UrlUpData = "http://YOUR_API_HOST:800/zut/fashion_test/api/modifyReport";
    void Start()
    {
        //上衣 单个报告修改
        //string jsonData = ReadData();
        //GetPostData data = JsonUtility.FromJson<GetPostData>(jsonData);
        //for (int i = 0; i < data.data.Length; i++)
        //{
        //    AlterData(data.data[i]);
        //}
        //AlterData(data);
        //上衣 所有报告修改
        //StartCoroutine(TestStart());
    }

    int index = 0;
    private IEnumerator TestStart()
    {
        string jsonData = ReadData();

        GetPostData data = JsonUtility.FromJson<GetPostData>(jsonData);
        while (index < 468)
        {
            yield return new WaitForSeconds(1.0f);
            AlterData(data.data[index]);
            index++;
        }
    }

    //读取文件
    private string ReadData()
    {
        //string类型的数据常量
        string readData;
        //获取到路径
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo.txt";
        //读取文件
        using (StreamReader sr = File.OpenText(fileUrl))
        {
            //数据保存
            readData = sr.ReadToEnd();
            sr.Close();
        }
        //返回数据
        return readData;
    }

    //数据处理
    private void AlterData(GetPostData data)
    {
        int index = 0;
        for (int i = 0; i < data.data.Length; i++)
        {
            if (data.data[i].id == 1033)
            {
                index = i;
            }
        }
        Debug.Log(data.data[index].id);
        int tempDesign = 0;
        //实验设计参数分数修改
        if (data.data[index].e_data.eData.eList[0] != null)
        {
            if (data.data[index].e_data.eData.eList[0].parameter.Length >= 3)
            {
                if (data.data[index].e_data.eData.eList[0].parameter[0].name != ""
                && data.data[index].e_data.eData.eList[0].parameter[1].name != ""
                && data.data[index].e_data.eData.eList[0].parameter[2].name != "")
                {
                    tempDesign += 2;
                }
                if (data.data[index].e_data.eData.eList[0].parameter.Length >= 12)
                {
                    data.data[index].e_data.eData.eList[0].parameter[11].angle1 =
                        data.data[index].e_data.eData.eList[0].parameter[10].angle1;
                    data.data[index].e_data.eData.eList[0].parameter[11].angle2 =
                        data.data[index].e_data.eData.eList[0].parameter[10].angle2;
                }
            }
        }
        if (data.data[index].e_data.eData.eList[1] != null)
        {
            if (data.data[index].e_data.eData.eList[1].parameter.Length >= 4)
            {
                if (data.data[index].e_data.eData.eList[1].parameter[0].name != ""
                && data.data[index].e_data.eData.eList[1].parameter[1].name != ""
                && data.data[index].e_data.eData.eList[1].parameter[2].name != ""
                && data.data[index].e_data.eData.eList[1].parameter[3].name != "")
                {
                    tempDesign += 2;
                }
                if (data.data[index].e_data.eData.eList[1].parameter.Length >= 5)
                {
                    data.data[index].e_data.eData.eList[1].parameter[4].angle1 =
                        data.data[index].e_data.eData.eList[1].parameter[3].angle1;
                    data.data[index].e_data.eData.eList[1].parameter[4].angle2 =
                        data.data[index].e_data.eData.eList[1].parameter[3].angle2;
                }
            }
        }
        if (data.data[index].e_data.eData.eList[2] != null)
        {
            if (data.data[index].e_data.eData.eList[2].parameter.Length >= 3)
            {
                if (data.data[index].e_data.eData.eList[2].parameter[0].name != ""
                && data.data[index].e_data.eData.eList[2].parameter[1].name != ""
                && data.data[index].e_data.eData.eList[2].parameter[2].name != "")
                {
                    tempDesign += 2;
                }
                if (data.data[index].e_data.eData.eList[2].parameter.Length >= 9)
                {
                    data.data[index].e_data.eData.eList[2].parameter[8].angle1 =
                        data.data[index].e_data.eData.eList[2].parameter[7].angle1;
                    data.data[index].e_data.eData.eList[2].parameter[8].angle2 =
                        data.data[index].e_data.eData.eList[2].parameter[7].angle2;
                }
            }
        }
        if (data.data[index].e_data.eData.eList[3] != null)
        {
            if (data.data[index].e_data.eData.eList[3].parameter.Length >= 4)
            {
                if (data.data[index].e_data.eData.eList[3].parameter[0].name != ""
                && data.data[index].e_data.eData.eList[3].parameter[1].name != ""
                && data.data[index].e_data.eData.eList[3].parameter[2].name != ""
                && data.data[index].e_data.eData.eList[3].parameter[3].name != "")
                {
                    tempDesign += 2;
                }
                if (data.data[index].e_data.eData.eList[3].parameter.Length >= 5)
                {
                    data.data[index].e_data.eData.eList[3].parameter[4].angle1 =
                        data.data[index].e_data.eData.eList[3].parameter[3].angle1;
                    data.data[index].e_data.eData.eList[3].parameter[4].angle2 =
                        data.data[index].e_data.eData.eList[3].parameter[3].angle2;
                }
            }
        }
        data.data[index].e_data.eData.eScore.design = tempDesign;
        //实验数据填报分数修改
        float tempRecord = 0;
        for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.data[index].e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.data[index].e_data.eData.eList[i].parameter[j].angle1 != "")
                {
                    tempRecord += 0.5f;
                }
                if (data.data[index].e_data.eData.eList[i].parameter[j].angle2 != "")
                {
                    tempRecord += 0.5f;
                }
            }
        }
        int record = Convert.ToInt32(tempRecord);
        if (record >= 15)
        {
            record = 15;
        }
        data.data[index].e_data.eData.eScore.record = record;
        //结论答题分数修改
        int score = 0;
        int tempScore;
        for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.data[index].e_data.eData.eList[i].topic.Length; j++)
            {
                try
                {
                    tempScore = int.Parse(data.data[index].e_data.eData.eList[i].topic[j].score);
                }
                catch
                {
                    tempScore = 0;
                }
                score += tempScore;
            }
        }
        for (int i = 0; i < data.data[index].e_data.eData.topic.Length; i++)
        {
            try
            {
                tempScore = int.Parse(data.data[index].e_data.eData.topic[i].score);
            }
            catch
            {
                tempScore = 0;
            }
            score += tempScore;
        }
        if (score >= 23)
        {
            score = 23;
        }
        data.data[index].e_data.eData.eScore.topic = score;
        //Debug.Log(data.data[index].e_data.eData.eScore.design);
        //Debug.Log(data.data[index].e_data.eData.eScore.record);
        //Debug.Log(data.data[index].e_data.eData.eScore.topic);

        string json = JsonUtility.ToJson(data.data[index].e_data);
        Debug.Log(json);
        WebRequestControl.RequestDataFormat(UrlUpData, GetSubmitData(data.data[index].id, json), ReturnData);
    }

    //数据处理
    private void AlterData(SendData data)
    {
        int tempDesign = 0;
        //实验设计参数分数修改
        if (data.e_data.eData.eList[0] != null)
        {
            if (data.e_data.eData.eList[0].parameter.Length >= 3)
            {
                if (data.e_data.eData.eList[0].parameter[0].name != ""
                && data.e_data.eData.eList[0].parameter[1].name != ""
                && data.e_data.eData.eList[0].parameter[2].name != "")
                {
                    tempDesign += 2;
                }
                if (data.e_data.eData.eList[0].parameter.Length >= 12)
                {
                    data.e_data.eData.eList[0].parameter[11].angle1 =
                        data.e_data.eData.eList[0].parameter[10].angle1;
                    data.e_data.eData.eList[0].parameter[11].angle2 =
                        data.e_data.eData.eList[0].parameter[10].angle2;
                }
            }
        }
        if (data.e_data.eData.eList[1] != null)
        {
            if (data.e_data.eData.eList[1].parameter.Length >= 4)
            {
                if (data.e_data.eData.eList[1].parameter[0].name != ""
                && data.e_data.eData.eList[1].parameter[1].name != ""
                && data.e_data.eData.eList[1].parameter[2].name != ""
                && data.e_data.eData.eList[1].parameter[3].name != "")
                {
                    tempDesign += 2;
                }
                if (data.e_data.eData.eList[1].parameter.Length >= 5)
                {
                    data.e_data.eData.eList[1].parameter[4].angle1 =
                        data.e_data.eData.eList[1].parameter[3].angle1;
                    data.e_data.eData.eList[1].parameter[4].angle2 =
                        data.e_data.eData.eList[1].parameter[3].angle2;
                }
            }
        }
        if (data.e_data.eData.eList[2] != null)
        {
            if (data.e_data.eData.eList[2].parameter.Length >= 3)
            {
                if (data.e_data.eData.eList[2].parameter[0].name != ""
                && data.e_data.eData.eList[2].parameter[1].name != ""
                && data.e_data.eData.eList[2].parameter[2].name != "")
                {
                    tempDesign += 2;
                }
                if (data.e_data.eData.eList[2].parameter.Length >= 9)
                {
                    data.e_data.eData.eList[2].parameter[8].angle1 =
                        data.e_data.eData.eList[2].parameter[7].angle1;
                    data.e_data.eData.eList[2].parameter[8].angle2 =
                        data.e_data.eData.eList[2].parameter[7].angle2;
                }
            }
        }
        if (data.e_data.eData.eList[3] != null)
        {
            if (data.e_data.eData.eList[3].parameter.Length >= 4)
            {
                if (data.e_data.eData.eList[3].parameter[0].name != ""
                && data.e_data.eData.eList[3].parameter[1].name != ""
                && data.e_data.eData.eList[3].parameter[2].name != ""
                && data.e_data.eData.eList[3].parameter[3].name != "")
                {
                    tempDesign += 2;
                }
                if (data.e_data.eData.eList[3].parameter.Length >= 5)
                {
                    data.e_data.eData.eList[3].parameter[4].angle1 =
                        data.e_data.eData.eList[3].parameter[3].angle1;
                    data.e_data.eData.eList[3].parameter[4].angle2 =
                        data.e_data.eData.eList[3].parameter[3].angle2;
                }
            }
        }
        data.e_data.eData.eScore.design = tempDesign;
        //实验数据填报分数修改
        float tempRecord = 0;
        for (int i = 0; i < data.e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.e_data.eData.eList[i].parameter[j].angle1 != "")
                {
                    tempRecord += 0.5f;
                }
                if (data.e_data.eData.eList[i].parameter[j].angle2 != "")
                {
                    tempRecord += 0.5f;
                }
            }
        }
        int record = Convert.ToInt32(tempRecord);
        if (record >= 15)
        {
            record = 15;
        }
        data.e_data.eData.eScore.record = record;
        //结论答题分数修改
        int score = 0;
        int tempScore;
        for (int i = 0; i < data.e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.e_data.eData.eList[i].topic.Length; j++)
            {
                try
                {
                    tempScore = int.Parse(data.e_data.eData.eList[i].topic[j].score);
                }
                catch
                {
                    tempScore = 0;
                }
                score += tempScore;
            }
        }
        for (int i = 0; i < data.e_data.eData.topic.Length; i++)
        {
            try
            {
                tempScore = int.Parse(data.e_data.eData.topic[i].score);
            }
            catch
            {
                tempScore = 0;
            }
            score += tempScore;
        }
        if (score >= 23)
        {
            score = 23;
        }
        data.e_data.eData.eScore.topic = score;
        //Debug.Log(data.e_data.eData.eScore.design);
        //Debug.Log(data.e_data.eData.eScore.record);
        //Debug.Log(data.e_data.eData.eScore.topic);

        string json = JsonUtility.ToJson(data.e_data);
        Debug.Log(data.id + " " + json);
        WebRequestControl.RequestDataFormat(UrlUpData, GetSubmitData(data.id, json), ReturnData);
    }


    public WWWForm GetSubmitData(int id, string json)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("data", json);
        return form;
    }

    private void ReturnData(string value)
    {
        Debug.Log(value);
    }
}
