using System.Collections.Generic;

public static class SubmitData
{
    public static string username { get; set; }
    public static string usertype { get; set; }
    public static string status { get; set; }
    public static string score { get; set; }
    public static string startDate { get; set; }
}
[System.Serializable]
public class RootData//根节点
{
    public ExpData expData;
}
[System.Serializable]
public class ExpData//实验数据类
{
    public string ExpModule;//实验模块 1/2/3
    public RFIDData[] RFIDData; //RFID实验数据
    public STM32Data[] STM32Data;//STM32实验数据
    public SensorData[] SensorData;//传感器布设实验数据
}
[System.Serializable]//RFID实验数据
public class RFIDData
{
    public int index;//题目下标
    public int score;//该题目分数 
    public string answer;//改题目选择项 A、B
}
[System.Serializable]
public class STM32Data
{
    public List<CommonTopic> CommonTopic;//普通题目 选择、填空、判断
    public List<LinklineTopic> LinklineTopic;//引脚连线题
}
[System.Serializable]
public class CommonTopic
{
    public int index;
    public int score;
    public string answer;
}
[System.Serializable]
public class LinklineTopic
{
    public int score;//该引脚 得分0 或者1
    public string leftlead;//左边的引脚连线。格式：“电源电路：VCC3.3”
    public string rightlead;//右边的引脚连线。格式：“最小系统电源电路：VCC3.3”
}

[System.Serializable]
public class SensorData
{
    public int index;
    public int score;
    public string answer;
}