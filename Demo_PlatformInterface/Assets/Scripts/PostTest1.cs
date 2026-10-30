using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class PostTest1 : MonoBehaviour
{
    //private string UrlGetData = "http://YOUR_API_HOST:800/zut/fashion_test/api/getExperimentList";
    private string UrlUpData = "http://YOUR_API_HOST:800/zut/fashion_test/api/modifyReport";
    void Start()
    {
        //裤装 单个报告修改
        //string jsonData = ReadData();
        //GetPostData2 data = JsonUtility.FromJson<GetPostData2>(jsonData);
        //AlterData(data);
        //裤装 所有报告修改
        StartCoroutine(TestStart());
    }

    int index = 0;
    private IEnumerator TestStart()
    {
        string jsonData = ReadData();

        GetPostData2 data = JsonUtility.FromJson<GetPostData2>(jsonData);
        while (index < 454)
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
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo2.txt";
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
    private void AlterData(GetPostData2 data)
    {
        int index = 0;
        for (int i = 0; i < data.data.Length; i++)
        {
            if (data.data[i].id == 1432)
            {
                index = i;
            }
        }
        Debug.Log(data.data[index].id);
        float tempDesign = 0;
        //实验设计参数分数修改
        //for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        //{
        //    bool select = false;
        //    if (data.data[index].e_data.eData.eList[i] != null)
        //    {
        //        if (data.data[index].e_data.eData.eList[i].parameter.Length >= 5)
        //        {
        //            if (data.data[index].e_data.eData.eList[i].parameter[i].name == "")
        //            {
        //                select = true;
        //            }
        //            tempDesign += 0.5f;
        //        }
        //    }
        //}
        for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        {
            bool select = false;
            for (int j = 0; j < data.data[index].e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.data[index].e_data.eData.eList[i].parameter[j].name == "")
                {
                    select = true;
                    break;
                } 
            }
            if (!select)
            {
                tempDesign += 0.5f;
            }
        }
        data.data[index].e_data.eData.eScore.design = (int)Math.Round(tempDesign, MidpointRounding.AwayFromZero);
        if (data.data[index].e_data.eData.eScore.design > 4)
        {
            data.data[index].e_data.eData.eScore.design = 4;
        }
        //实验数据填报分数修改
        float tempRecord = 0;
        for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.data[index].e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.data[index].e_data.eData.eList[i].parameter[j].angle != "")
                {
                    tempRecord += 0.5f;
                }
            }
        }
        data.data[index].e_data.eData.eScore.record = (int)Math.Round(tempRecord, MidpointRounding.AwayFromZero);
        if (data.data[index].e_data.eData.eScore.record > 22)
        {
            data.data[index].e_data.eData.eScore.record = 22;
        }
        //结论答题分数修改
        float score = 0;
        float tempScore;
        for (int i = 0; i < data.data[index].e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.data[index].e_data.eData.eList[i].topic.Length; j++)
            {
                try
                {
                    tempScore = float.Parse(data.data[index].e_data.eData.eList[i].topic[j].score);
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
                tempScore = float.Parse(data.data[index].e_data.eData.topic[i].score);
            }
            catch
            {
                tempScore = 0;
            }
            score += tempScore;
        }
        data.data[index].e_data.eData.eScore.topic = (int)Math.Round(score, MidpointRounding.AwayFromZero);
        if (data.data[index].e_data.eData.eScore.topic > 20)
        {
            data.data[index].e_data.eData.eScore.topic = 20;
        }

        Debug.Log(data.data[index].e_data.eData.eScore.design + " " +
            data.data[index].e_data.eData.eScore.record + " " +
            data.data[index].e_data.eData.eScore.topic);

        string json = JsonUtility.ToJson(data.data[index].e_data);
        Debug.Log(json);
        WebRequestControl.RequestDataFormat(UrlUpData, GetSubmitData(data.data[index].id, json), ReturnData);
    }

    //数据处理
    private void AlterData(SendData2 data)
    {
        float tempDesign = 0;
        //实验设计参数分数修改
        for (int i = 0; i < data.e_data.eData.eList.Length; i++)
        {
            bool select = false;
            for (int j = 0; j < data.e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.e_data.eData.eList[i].parameter[j].name == "")
                {
                    select = true;
                    break;
                }
            }
            if (!select)
            {
                tempDesign += 0.5f;
            }
        }
        data.e_data.eData.eScore.design = (int)Math.Round(tempDesign, MidpointRounding.AwayFromZero);
        if (data.e_data.eData.eScore.design > 4)
        {
            data.e_data.eData.eScore.design = 4;
        }
        //实验数据填报分数修改
        float tempRecord = 0;
        for (int i = 0; i < data.e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.e_data.eData.eList[i].parameter.Length; j++)
            {
                if (data.e_data.eData.eList[i].parameter[j].angle != "")
                {
                    tempRecord += 0.5f;
                }
            }
        }
        data.e_data.eData.eScore.record = (int)Math.Round(tempRecord, MidpointRounding.AwayFromZero);
        if (data.e_data.eData.eScore.record > 22)
        {
            data.e_data.eData.eScore.record = 22;
        }
        //结论答题分数修改
        float score = 0;
        float tempScore;
        for (int i = 0; i < data.e_data.eData.eList.Length; i++)
        {
            for (int j = 0; j < data.e_data.eData.eList[i].topic.Length; j++)
            {
                try
                {
                    tempScore = float.Parse(data.e_data.eData.eList[i].topic[j].score);
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
                tempScore = float.Parse(data.e_data.eData.topic[i].score);
            }
            catch
            {
                tempScore = 0;
            }
            score += tempScore;
        }
        data.e_data.eData.eScore.topic = (int)Math.Round(score, MidpointRounding.AwayFromZero);
        if (data.e_data.eData.eScore.topic > 20)
        {
            data.e_data.eData.eScore.topic = 20;
        }

        string json = JsonUtility.ToJson(data.e_data);
        Debug.Log(json);
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
