using System.IO;
using UnityEngine;

[System.Serializable]
class Person
{
    public string Name;
    public int Grade;
}
[System.Serializable]
class Data
{
    public Person Person;
}
[System.Serializable]
class Data1
{
    public Person[] Persons;
}

public class TestToJson : MonoBehaviour
{
    void Start()
    {
        //WriteData2();
        //WriteData3();

        //string jsonData = ReadData();
        //Debug.Log(jsonData);

        //Data m_PersonData = JsonUtility.FromJson<Data>(jsonData);
        //Debug.Log(m_PersonData.Person.Name);
        //Debug.Log(m_PersonData.Person.Grade);

        string jsonData = ReadData();
        Debug.Log(jsonData);
        Data1 m_PersonData1 = JsonUtility.FromJson<Data1>(jsonData);
        foreach (var item in m_PersonData1.Persons)
        {
            Debug.Log(item.Name);
            Debug.Log(item.Grade);
        }
    }


    //读取文件
    public string ReadData()
    {
        string readData = "";
        string fileUrl = Application.streamingAssetsPath+ "\\jsonInfo3.txt";
        StreamReader str = File.OpenText(fileUrl);
        readData = str.ReadToEnd();
        str.Close();
        return readData;
    }

    //写数据
    public void WriteData2()
    {
        Person m_Person = new Person();
        m_Person.Name = "User1";
        m_Person.Grade = 13;
        Data m_Data = new Data();
        m_Data.Person = m_Person;
        string js = JsonUtility.ToJson(m_Data);
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo2.txt";
        StreamWriter sw = new StreamWriter(fileUrl);
        sw.WriteLine(js);
        sw.Close();
    }

    //写数据
    public void WriteData3()
    {
        Data1 m_Data = new Data1();
        m_Data.Persons = new Person[5];
        for (int i = 0; i < 5; i++)
        {
            Person m_Person = new Person();
            m_Person.Name = "User" + i;
            m_Person.Grade = i + 50;
            m_Data.Persons[i] = m_Person;
        }
        string js = JsonUtility.ToJson(m_Data);
        string fileUrl = Application.streamingAssetsPath + "\\jsonInfo3.txt";
        StreamWriter sw = new StreamWriter(fileUrl);
        sw.WriteLine(js);
        sw.Close();
    }
}
