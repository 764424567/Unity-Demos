using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    private string postUrl = "http://api.map.baidu.com/location/ip?ak=tkAJ8NXqE2FzjUh2npcJufk88GFUHyq9&coor=bd09ll";
    /// <summary>
    /// 获取天气信息
    /// </summary>
    string Weatherurl = "http://t.weather.itboy.net/api/weather/city/";
    public static Dictionary<string, string> PosToId = new Dictionary<string, string>();
    public static bool initDic = false;

    // UI显示
    public Text m_TextCityName;           //城市名
    public Text m_TextQuality;            //空气质量
    public Text m_TextNotice;             //提示
    public Image[] m_ImageType;           //天气图标，3个
    // 今天
    public Text m_TextTodayDate;          //今天日期
    public Text m_TextTodayType;          //今天类型
    public Text m_TextTodayTemperature;   //今天温度
    public Text m_TextTodayfx;            //今天风向
    // 明天
    public Text m_TextTomorrowDate;         //明天日期
    public Text m_TextTomorrowType;         //明天类型
    public Text m_TextTomorrowTemperature;  //明天温度
    public Text m_TextTomorrowfx;           //明天风向
    // 后天
    public Text m_TextAcquiredDate;         //后天日期
    public Text m_TextAcquiredType;         //后天类型
    public Text m_TextAcquiredTemperature;  //后天温度
    public Text m_TextAcquiredfx;           //后天风向

    void Start()
    {
        //获取位置
        StartCoroutine(RequestPos());
    }


    IEnumerator RequestPos()
    {
        UnityWebRequest request = UnityWebRequest.Get(postUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            CityData data = JsonUtility.FromJson<CityData>(request.downloadHandler.text);
            Debug.Log(data.content.address_detail.city);
            //获取city_code
            string city_code = GetWeatherId("郑州");
            Debug.Log(city_code);
            //获取天气信息
            StartCoroutine(RequestWeatherData("101180101"));
        }
    }
    public static string GetWeatherId(string name)
    {
        string city_code = "";
        if (!initDic)
        {
            initDic = true;
            TextAsset city = Resources.Load<TextAsset>("city");
            List<CityCode> cityCode = JsonUtility.FromJson<List<CityCode>>(city.text);
            foreach (CityCode t in cityCode)
            {
                PosToId[t.city_name] = t.city_code;
            }
        }
        for (int i = 1; i < name.Length; i++)
        {
            string tn = name.Substring(0, i);
            if (PosToId.ContainsKey(tn))
            {
                city_code = PosToId[tn];
            }
        }
        return city_code;
    }
    IEnumerator RequestWeatherData(string cicy_code)
    {
        UnityWebRequest request = UnityWebRequest.Get(Weatherurl + cicy_code);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            //WeatherData t = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);
            ////天气信息
            //Debug.Log(t.data.forecast[0].date);
            //Debug.Log(t.data.forecast[0].high);
            //Debug.Log(t.data.forecast[0].low);
            //Debug.Log(t.data.forecast[0].ymd);
            //Debug.Log(t.data.forecast[0].week);
            //Debug.Log(t.data.forecast[0].sunrise);
            //Debug.Log(t.data.forecast[0].sunset);
            //Debug.Log(t.data.forecast[0].aqi);
            //Debug.Log(t.data.forecast[0].fx);
            //Debug.Log(t.data.forecast[0].fl);
            //Debug.Log(t.data.forecast[0].type);
            //Debug.Log(t.data.forecast[0].notice);

            WeatherData t = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);
            //UI显示数据
            WeatherData_UIShow(t);
        }
    }

    public void WeatherData_UIShow(WeatherData _weatherData)
    {
        m_TextCityName.text = _weatherData.cityInfo.city;
        m_TextQuality.text = _weatherData.data.quality;
        m_TextNotice.text = _weatherData.data.forecast[0].notice;
        string[] data = WeatherData_Parse(_weatherData);
        //今天
        m_TextTodayDate.text = data[0];
        m_TextTodayType.text = data[1];
        m_TextTodayTemperature.text = data[2];
        m_TextTodayfx.text = data[3];
        //明天
        m_TextTomorrowDate.text = data[4];
        m_TextTomorrowType.text = data[5];
        m_TextTomorrowTemperature.text = data[6];
        m_TextTomorrowfx.text = data[7];
        //后天
        m_TextAcquiredDate.text = data[8];
        m_TextAcquiredType.text = data[9];
        m_TextAcquiredTemperature.text = data[10];
        m_TextAcquiredfx.text = data[11];
    }

    public string[] WeatherData_Parse(WeatherData _weatherData)
    {
        string[] data = new string[12];
        for (int i = 0; i < 3; i++)
        {
            //图片显示
            string path = "weather/" + _weatherData.data.forecast[i].type;
            m_ImageType[i].sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
            //数据计算
            string temperatureLow = _weatherData.data.forecast[i].low;
            string temperatureHigh = _weatherData.data.forecast[i].high;
            temperatureLow = temperatureLow.Substring(3, temperatureLow.Length - 3);
            temperatureHigh = temperatureHigh.Substring(3, temperatureHigh.Length - 3);
            //String数组存一下拼接好的字符串
            data[i * 4 + 0] = _weatherData.data.forecast[i].date + "日   " + _weatherData.data.forecast[i].week;
            data[i * 4 + 1] = _weatherData.data.forecast[i].type;
            data[i * 4 + 2] = temperatureLow + " ~ " + temperatureHigh;
            data[i * 4 + 3] = _weatherData.data.forecast[i].fx;
        }
        return data;
    }
}
#region 天气数据类
[System.Serializable]
public class WeatherData
{
    public string message;
    public int status;
    public string date;
    public string time;
    public CityInfo cityInfo;
    public WeathData data;
}
[System.Serializable]
public class CityInfo
{
    public string city;
    public string cityId;
    public string parent;
    public string updateTime;
}
[System.Serializable]
public class WeathData
{
    public string shidu;
    public double pm25;
    public double pm10;
    public string quality;
    public string wendu;
    public string ganmao;
    public WeathDetailData[] forecast;
    public WeathDetailData yesterday;
}
[System.Serializable]
public class WeathDetailData
{
    public string date;
    public string sunrise;
    public string high;
    public string low;
    public string sunset;
    public double aqi;
    public string ymd;
    public string week;
    public string fx;
    public string fl;
    public string type;
    public string notice;
}
#endregion
#region 城市的city_code编号代码
public class CityCode
{
    public int id;
    public int pid;
    public string city_code;
    public string city_name;
    public string post_code;
    public string area_code;
    public string ctime;
}
#endregion
#region 返回的城市名字等数据类
[System.Serializable]
public class CityData
{
    public string address;
    public Content content;
    public int status;
}
[System.Serializable]
public class Content
{
    public string address;
    public Address_Detail address_detail;
    public Point point;
}
[System.Serializable]
public class Address_Detail
{
    public string city;
    public int city_code;
    public string district;
    public string province;
    public string street;
    public string street_number;
}
[System.Serializable]
public class Point
{
    public string x;
    public string y;
}
#endregion