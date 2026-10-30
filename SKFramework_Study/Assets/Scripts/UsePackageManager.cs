using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using SK.Framework;
using System.Collections.Generic;
using System;
using System.Text;

public class UsePackageManager : MonoBehaviour
{
    //void Start()
    //{
    //    //WriteTest();
    //    //ReadTest();

    //    ReadTest2();
    //}

    //void WriteTest()
    //{
    //    List<PackageInfoDetail> packages = new List<PackageInfoDetail>();
    //    PackageInfoDetail fsmDemo = new PackageInfoDetail();
    //    fsmDemo.author = "张尧";
    //    fsmDemo.description = "测试内容";
    //    fsmDemo.documentationUrl = "https://blog.csdn.net/q764424567";
    //    fsmDemo.releaseDate = DateTime.Now.ToString("D");
    //    packages.Add(fsmDemo);
    //    using (FileStream fs = new FileStream(Application.streamingAssetsPath + "/demo2.txt", FileMode.OpenOrCreate))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        bf.Serialize(fs, packages);
    //        //using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
    //        //{
    //        //    string json = JsonUtility.ToJson(packages);
    //        //    sw.WriteLine(json);
    //        //}
    //    }
    //    Debug.LogError("write done");
    //}



    //// 反序列化：打开待反序列化的二进制文件，通过二进制格式器将文件解析成对象demo，并输出到控制台。
    //void ReadTest()
    //{
    //    List<PackageInfoDetail> packages;
    //    using (FileStream fs = new FileStream(Application.streamingAssetsPath + "/demo.bin", FileMode.Open))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        packages = bf.Deserialize(fs) as List<PackageInfoDetail>;
    //    }
    //    for (int i = 0; i < packages.Count; i++)
    //    {
    //        Debug.Log(packages[i].author);
    //    }
    //}

    //void ReadTest2()
    //{
    //    List<PackageInfoDetail> packages;
    //    using (FileStream fs = new FileStream(Application.streamingAssetsPath + "/manifest.dat", FileMode.Open))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        packages = bf.Deserialize(fs) as List<PackageInfoDetail>;
    //    }

    //    PackageInfoDetail fsmDemo = new PackageInfoDetail();
    //    fsmDemo.author = "张尧";
    //    fsmDemo.description = "测试内容";
    //    fsmDemo.documentationUrl = "https://blog.csdn.net/q764424567";
    //    fsmDemo.releaseDate = DateTime.Now.ToString("D");
    //    packages.Add(fsmDemo);

    //    using (FileStream fs = new FileStream(Application.streamingAssetsPath + "/manifest2.dat", FileMode.OpenOrCreate))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        bf.Serialize(fs, packages);
    //    }
    //}
}