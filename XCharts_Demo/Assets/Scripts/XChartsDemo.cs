using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XCharts.Runtime;

public class XChartsDemo : MonoBehaviour
{
    public GameObject XChartObj;
    void Start()
    {
        string jsonData = ReadData();
        Debug.Log(jsonData);
        RootData m_PersonData = JsonUtility.FromJson<RootData>(jsonData);


        List<string> xAxisValue = new List<string>();
        List<float> yAxisValue = new List<float>();
        for (int i = 0; i < m_PersonData.Value.Length; i++)
        {
            xAxisValue.Add(m_PersonData.Value[i].Name);
            yAxisValue.Add(m_PersonData.Value[i].Grade);
        }
        CreateLine(XChartObj,m_PersonData.TableName,m_PersonData.TableType,m_PersonData.YUnit, xAxisValue, yAxisValue);
    }

    //读取文件
    public string ReadData()
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

    private void CreateLine(GameObject XChartObj,string TableName,string TableType,string YUnit, List<string> xAxisValue, List<float> yAxisValue)
    {
        // 添加LineChart
        var chart = XChartObj.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = XChartObj.AddComponent<LineChart>();
            chart.Init();
        }

        // 标题
        var title=chart.EnsureChartComponent<Title>();
        title.show = true;
        title.text = TableName;

        // y轴，设置单位
        var yAxis=chart.EnsureChartComponent<YAxis>();
        yAxis.axisName.show = true;
        yAxis.axisName.name = YUnit;
        LabelStyle ls = new LabelStyle();
        ls.offset = new Vector3(0,25,0);
        yAxis.axisName.labelStyle = ls;
        // 清空默认数据，添加Line类型的Serie用于接收数据：
        chart.RemoveData();
        //添加x轴的值
        for (int i = 0; i < xAxisValue.Count; i++)
        {
            chart.AddXAxisData(xAxisValue[i]);
        }
        // 数据集类型
        switch (TableType)
        {
            case "折线图":
                chart.AddSerie<Line>("line");
                break;
            case "柱状图":
                chart.AddSerie<Bar>("bar");
                break;
        }
        foreach (float item in yAxisValue)
        {
            chart.AddData(0, item);
        }
    }
}