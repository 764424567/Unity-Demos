using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Video;
using System.IO;
using XCharts.Runtime;

#region 图表数据格式
[System.Serializable]
class CarData //设备故障统计
{
    public string Name;//姓名
    public string CatNum;//车牌号
    public string Time;//进出场时间
}
[System.Serializable]
class FailureData //设备故障统计
{
    public string Name;
    public float Value1;
    public float Value2;
}
[System.Serializable]
class EnergyData//能耗检测
{
    public string Name;
    public float Value1;
}
[System.Serializable]
class WarnData //警告统计
{
    public string Name;
    public float Value1;
}
[System.Serializable]
class FlowData //人流统计的json
{
    public string Name;
    public float Value1;
    public float Value2;
}
[System.Serializable]
class ChartData1
{
    public FlowData[] Data;
}
[System.Serializable]
class ChartData2
{
    public WarnData[] Data;
}
[System.Serializable]
class ChartData3
{
    public EnergyData[] Data;
}
[System.Serializable]
class ChartData4
{
    public FailureData[] Data;
}
[System.Serializable]
class ChartData5
{
    public CarData[] Data;
}
#endregion
public class MainControl : MonoBehaviour
{
    [Header("图表")]
    public XCharts.Runtime.LineChart Chart1;//图表1 人流统计
    public XCharts.Runtime.BarChart Chart2;//图表2 警告统计
    public XCharts.Runtime.PieChart Chart3;//图表3 能耗检测
    public XCharts.Runtime.LineChart Chart4;//图表4 设备故障统计
    [Header("车辆检测")]
    public Transform Chart5Content;//图表4 车辆检测 父节点
    public GameObject ItemInfo;//车辆信息预制体
    [Header("实时监测")]
    public VideoPlayer Chart6;//图表6 实时监控的播放器

    // UI部分
    [Header("底部的按钮")]
    public Button[] BtnMain;
    public Sprite[] SpriteMain;
    private int nextIndexMain = -1;
    public GameObject BtnDiskPar;
    public Button[] BtnDisk;
    public Sprite[] Spriteisk;
    private int nextIndexDisk = -1;
    [Header("园区控制")]
    public GameObject[] BareWall;//光墙，用来演示分区效果
    public Transform[] Point;
    public GameObject FPS;

    void Start()
    {
        ChartInit();        // 图表初始化
        UIInit();           // UI初始化
    }
    void UIInit()
    {
        for (int i = 0; i < BtnMain.Length; i++)
        {
            int index = i;
            BtnMain[i].onClick.AddListener(() => BtnMainEvent(index));
        }
        for (int i = 0; i < BtnDisk.Length; i++)
        {
            int index = i;
            BtnDisk[i].onClick.AddListener(() => BtnDiskEvent(index));
        }
        BtnDiskPar.SetActive(false);
        nextIndexMain = 0;
    }

    void BtnMainEvent(int index)
    {
        if (nextIndexMain != -1 && nextIndexMain != index)
        {
            BtnMain[nextIndexMain].GetComponent<Image>().sprite = SpriteMain[0];
        }
        nextIndexMain = index;
        BtnMain[index].GetComponent<Image>().sprite = SpriteMain[1];

        // 隐藏分区按钮
        BtnDiskPar.SetActive(false);
        if (nextIndexDisk != -1)
            BareWall[nextIndexDisk].SetActive(false);
        nextIndexDisk = -1;
        // 控制相机上的组件
        FPS.GetComponent<Animation>().enabled = false;
        FPS.GetComponent<CameraMoveGround>().isMove = false;

        switch (index)
        {
            case 0:
                FPS.transform.position = Point[0].position;
                FPS.transform.rotation = Point[0].rotation;
                FPS.GetComponent<CameraRotate>().isEnable = true;
                break;
            case 1:
                FPS.GetComponent<Animation>().enabled = true;
                FPS.GetComponent<Animation>().Play("漫游动画");
                FPS.GetComponent<CameraRotate>().isEnable = false;
                break;
            case 2:
                FPS.transform.position = Point[1].position;
                FPS.transform.rotation = Point[1].rotation;
                FPS.GetComponent<CameraMoveGround>().isMove = true;
                FPS.GetComponent<CameraRotate>().isEnable = false;
                break;
            case 3:
                FPS.transform.position = Point[0].position;
                FPS.transform.rotation = Point[0].rotation;
                FPS.GetComponent<CameraRotate>().isEnable = true;
                BtnDiskPar.SetActive(true);
                break;
            default:
                break;
        }
    }

    void BtnDiskEvent(int index)
    {
        if (nextIndexDisk != -1 && nextIndexDisk != index)
        {
            BareWall[nextIndexDisk].SetActive(false);
        }
        nextIndexDisk = index;
        BareWall[index].SetActive(true);
    }

    void ChartInit()
    {
        // 从本地读取文档显示出来
        // 可以将这个本地读取改为从服务器获取
        StartCoroutine(RequestChartData());

        // 显示视频
        string path = Path.Combine(Application.streamingAssetsPath, "Video/BigBuckBunny.mp4");
        Chart6.url = path;
        Chart6.Play();
    }

    IEnumerator RequestChartData()
    {
        // 图表1
        string url1 = Path.Combine(Application.streamingAssetsPath, "json1.json");
        Debug.Log(url1);
        using (UnityWebRequest request = UnityWebRequest.Get(url1))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                Debug.Log(data);
                List<float> yAxisValue = new List<float>();
                List<float> yAxisValue2 = new List<float>();
                ChartData1 rootData = JsonUtility.FromJson<ChartData1>(data);
                for (int i = 0; i < rootData.Data.Length; i++)
                {
                    yAxisValue.Add(rootData.Data[i].Value1);
                    yAxisValue2.Add(rootData.Data[i].Value2);
                }
                UpateChartData(Chart1, "收入值", yAxisValue, "增加", yAxisValue2);
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
        // 图表2
        string url2 = Path.Combine(Application.streamingAssetsPath, "json2.json");
        using (UnityWebRequest request = UnityWebRequest.Get(url2))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                List<float> yAxisValue = new List<float>();
                ChartData2 rootData = JsonUtility.FromJson<ChartData2>(data);
                for (int i = 0; i < rootData.Data.Length; i++)
                {
                    WarnData tempData = rootData.Data[i];
                    yAxisValue.Add(tempData.Value1);
                }
                UpateChartData(Chart2, "项目", yAxisValue);
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
        // 图表3
        string url3 = Path.Combine(Application.streamingAssetsPath, "json3.json");
        using (UnityWebRequest request = UnityWebRequest.Get(url3))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                List<EnergyData> yAxisValue = new List<EnergyData>();
                ChartData3 rootData = JsonUtility.FromJson<ChartData3>(data);
                for (int i = 0; i < rootData.Data.Length; i++)
                {
                    EnergyData tempData = rootData.Data[i];
                    yAxisValue.Add(tempData);
                }
                UpateChartData(Chart3, "serie0", yAxisValue);
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
        // 图表4
        string url4 = Path.Combine(Application.streamingAssetsPath, "json4.json");
        using (UnityWebRequest request = UnityWebRequest.Get(url4))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                List<float> yAxisValue = new List<float>();
                List<float> yAxisValue2 = new List<float>();
                ChartData4 rootData = JsonUtility.FromJson<ChartData4>(data);
                for (int i = 0; i < rootData.Data.Length; i++)
                {
                    FailureData tempData = rootData.Data[i];
                    yAxisValue.Add(tempData.Value1);
                    yAxisValue2.Add(tempData.Value2);
                }
                UpateChartData(Chart4, "serie0", yAxisValue, "serie1", yAxisValue2);
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
        // 图表5
        string url5 = Path.Combine(Application.streamingAssetsPath, "json5.json");
        using (UnityWebRequest request = UnityWebRequest.Get(url5))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                ChartData5 rootData = JsonUtility.FromJson<ChartData5>(data);
                for (int i = 0; i < rootData.Data.Length; i++)
                {
                    CarData tempData = (CarData)rootData.Data[i];
                    GameObject Item = Instantiate(ItemInfo, Vector3.zero, Quaternion.identity, Chart5Content);
                    Item.transform.Find("TextNum").GetComponent<Text>().text = (i + 1).ToString();
                }
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
    }

    void UpateChartData(BaseChart chart, string serieName, List<float> yAxisValue, string serieName2 = "", List<float> yAxisValue2 = null)
    {
        // 区分是一个轴还是两个轴
        if (serieName2 == "")
        {
            // 清除原来的数据
            chart.GetSerie(serieName).ClearData();
            // 添加y轴的值
            foreach (float item in yAxisValue)
            {
                chart.AddData(serieName, item);
            }
        }
        else
        {
            // 清除原来的数据
            chart.GetSerie(serieName).ClearData();
            // 添加y轴的值
            foreach (float item in yAxisValue)
            {
                chart.AddData(serieName, item);
            }
            // 清除原来的数据
            chart.GetSerie(serieName2).ClearData();
            // 添加y轴的值
            foreach (float item in yAxisValue2)
            {
                chart.AddData(serieName2, item);
            }
        }
    }

    void UpateChartData(BaseChart chart, string serieName, List<EnergyData> yAxisValue)
    {
        // 清除原来的数据
        chart.GetSerie(serieName).ClearData();
        // 添加y轴的值
        foreach (EnergyData item in yAxisValue)
        {
            chart.AddData(serieName, item.Value1, item.Name);
        }
    }
}