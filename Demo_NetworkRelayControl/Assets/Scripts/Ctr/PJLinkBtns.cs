using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PJLinkBtns : MonoBehaviour {

    //public StopBits stopBits = StopBits.One;       //停止位
    //public Parity parity = Parity.None;             //检验位
    //public int baudRate = 9600;                     //波特率
    //public int dataBits = 8;                        //数据位
    //public string strPort = "COM3";
    //SerialPort sp;

    public string[] strPorts;
    string[] jsonStr = new string[] { "com1", "com2", "com3", "com4", "com5","Num" };
    public List<string> jsonToString;
    int comsCount;

    byte[] openByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x4E, 0x0D};
    byte[] closeByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x46,0x46,0x0D};

    //string openASCII = "PWR ON\r\n";
    //string closeASCII = "PWR OFF\r\n";

    private void Awake()
    {
        jsonToString = Config.ReadJson(jsonStr);
        comsCount = int.Parse(jsonToString[5]);
        if (comsCount>=jsonToString.Count-1)
        {
            comsCount = jsonToString.Count - 1;
        }
        Debug.Log("COMS总数： "+comsCount);
    }
    // Use this for initialization
    void Start () {
        for (int i = 0; i < comsCount; i++)
        {
            PJLinkPort pJLinkPort = new PJLinkPort(jsonToString[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

  

    public void OpenPort()
    {
        //SendData(openByte, sp);
        //SendData(openASCII, sp);
        Other.OnOpenPJLink(OpenOrColse.OPEN);
    }

    public void ClosePort()
    {
        Other.OnOpenPJLink(OpenOrColse.CLOSE);
        //SendData(closeByte, sp);
        //SendData(closeASCII, sp);
    }

    void SendData(byte[] data, SerialPort sp)
    {
        sp.Write(data, 0, data.Length);
        Debug.Log("--------发送数据" + data);
    }


    void SendData(string data, SerialPort sp)
    {
        sp.Write(data);
        Debug.Log("--------发送数据" + data);
    }
}
