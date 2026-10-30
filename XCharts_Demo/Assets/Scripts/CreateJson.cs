using System;
using System.IO;
using UnityEngine;


[Serializable]
class RootData
{
    public string TableName;//表名
    public string TableType;//表类型
    public string YUnit;//Y轴单位
    public ValueData[] Value;//数据
}
[Serializable]
class ValueData
{
    public string Name;//名称
    public int Grade;//值
}
public class CreateJson : MonoBehaviour
{
    void Start()
    {
        WriteData();
    }

    //写数据
    public void WriteData()
    {
        RootData m_Data = new RootData();
        m_Data.TableName = "业务收入变化";
        m_Data.TableType = "柱状图";
        m_Data.YUnit = "单位：万元";
        m_Data.Value = new ValueData[12];
        for (int i = 1; i < 13; i++)
        {
            ValueData m_Person = new ValueData();
            m_Person.Name = i+"月";
            m_Person.Grade = UnityEngine.Random.Range(3000,8000);
            m_Data.Value[i-1] = m_Person;
        }
        string js = JsonUtility.ToJson(m_Data);
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo.txt";
        using (StreamWriter sw = new StreamWriter(fileUrl))
        {
            //保存数据
            sw.WriteLine(js);
            //关闭文档
            sw.Close();
            sw.Dispose();
        }
    }
}
