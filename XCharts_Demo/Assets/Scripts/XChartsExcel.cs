using Excel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using XCharts.Runtime;

public class XChartsExcel : MonoBehaviour
{
    public GameObject XChartObj;
    void Start()
    {
        DataSet excelData = ReadData();
        int columns = excelData.Tables[0].Columns.Count;
        int rows = excelData.Tables[0].Rows.Count;
        Debug.Log($"列数：{columns},行数：{rows}");


        List<string> xAxisValue = new List<string>();
        List<float> yAxisValue = new List<float>();
        for (int i = 0; i < columns - 1; i++)
        {
            xAxisValue.Add(excelData.Tables[0].Rows[0][i + 1].ToString());
        }
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < columns - 1; j++)
            {
                //获取表中的数值
                string value = excelData.Tables[0].Rows[i + 1][j + 1].ToString();
                yAxisValue.Add(int.Parse(value));
            }
        }
        CreateLine(XChartObj, "业务收入变化", "柱状图", "单位：万元", xAxisValue, yAxisValue);
    }

    //读取文件
    public DataSet ReadData()
    {
        //这里设置需要读取的文件的路径
        string FilePath = Application.streamingAssetsPath + "/ValueDate.xlsx";
        //读取该文件
        FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
        //读取Excel文件
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();

        return result;
    }

    private void CreateLine(GameObject XChartObj, string TableName, string TableType, string YUnit, List<string> xAxisValue, List<float> yAxisValue)
    {
        // 添加LineChart
        var chart = XChartObj.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = XChartObj.AddComponent<LineChart>();
            chart.Init();
        }

        // 标题
        var title = chart.EnsureChartComponent<Title>();
        title.show = true;
        title.text = TableName;

        // y轴，设置单位
        var yAxis = chart.EnsureChartComponent<YAxis>();
        yAxis.axisName.show = true;
        yAxis.axisName.name = YUnit;
        LabelStyle ls = new LabelStyle();
        ls.offset = new Vector3(0, 25, 0);
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