using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteJson : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        WriteData();

    }

    // Update is called once per frame
    void Update()
    {

    }
    //写数据
    public void WriteData()
    {
        //新建一个数据类
        RootData rootData = new RootData();
        ExpData m_Data = new ExpData();
        //新建一个字段类 进行赋值
        m_Data.RFIDData = new RFIDData[5];
        for (int i = 0; i < 5; i++)
        {
            RFIDData m_RFIDData = new RFIDData();
            m_RFIDData.index = 0;
            m_RFIDData.score = 0;
            m_RFIDData.answer = "A";
        }
        rootData.expData = m_Data;
        //将数据转成json
        string js = JsonUtility.ToJson(rootData);
        //获取到项目路径
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo.txt";
        //打开或者新建文档
        StreamWriter sw = new StreamWriter(fileUrl);
        //保存数据
        sw.WriteLine(js);
        //关闭文档
        sw.Close();
    }
}
