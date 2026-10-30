using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using LitJson;

public class Config
{



    


    /// <summary>
    ///  ReadJson/读取配置文件
    /// </summary>
    public static List<string> ReadJson(string[] strArray)
    {
        List<string> strList = new List<string>();
        string path = Application.streamingAssetsPath + @"/配置文件/config.json";
        Debug.Log(path);
        if (!File.Exists(path))
        {

            
        }
        else
        {
            StreamReader streamreader = new StreamReader(path);
            string str = streamreader.ReadToEnd();
            JsonData jd = JsonMapper.ToObject(str);
            for (int i = 0; i < strArray.Length; i++)
            {
                strList.Add(jd[strArray[i]].ToString());
                //Debug.LogError(strList[i]);
            }
        }

        return strList;
    }


   


}
