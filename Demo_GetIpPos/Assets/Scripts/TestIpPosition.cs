using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIpPosition : MonoBehaviour
{
    /// <summary>
    /// 获取位置信息
    /// </summary>
    string Posurl = "http://api.map.baidu.com/location/ip?ak=bretF4dm6W5gqjQAXuvP0NXW6FeesRXb&coor=bd09ll";

    /// <summary>
    /// 获取天气
    /// </summary>
    string Weatherurl = "http://t.weather.sojson.com/api/weather/city/";

    void Start()
    {
        //获取位置
        //StartCoroutine(RequestPos());
        //获取天气
        Debug.Log(weatherTool.GetWeatherId("北京市"));
        StartCoroutine(RequestWeather(weatherTool.GetWeatherId("北京市")));
    }


    IEnumerator RequestPos()
    {
        WWW www = new WWW(Posurl);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            positionTool.ResponseBody t = LitJson.JsonMapper.ToObject<positionTool.ResponseBody>(www.text);
            Debug.Log(t.content.address_detail.city);
            //获取天气
            StartCoroutine(RequestWeather(weatherTool.GetWeatherId(t.content.address_detail.city)));
        }
    }

    IEnumerator RequestWeather(int id)
    {
        WWW www = new WWW(Weatherurl + id.ToString());
        Debug.Log(Weatherurl + id.ToString());
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.text);
            weatherTool.WeathBody t = LitJson.JsonMapper.ToObject<weatherTool.WeathBody>(www.text);
            Debug.Log(t.data.forecast[0].type);
        }
    }

    IEnumerator RequestWeather()
    {
        WWW www = new WWW(Weatherurl);
        Debug.Log(Weatherurl);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.text);
            weatherTool.WeathBody t = LitJson.JsonMapper.ToObject<weatherTool.WeathBody>(www.text);
            Debug.Log(t.data.forecast[0].type);
        }
    }
}
