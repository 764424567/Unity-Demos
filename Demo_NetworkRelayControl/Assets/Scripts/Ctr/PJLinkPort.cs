using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PJLinkPort
{
    //端口信息
    public StopBits stopBits = StopBits.One;       //停止位
    public Parity parity = Parity.None;             //检验位
    public int baudRate = 9600;                     //波特率
    public int dataBits = 8;
    public string strPort;
    SerialPort sp;

    //byte[] openByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x4E, 0x0D };
    //byte[] closeByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x46, 0x46, 0x0D };

    byte[] openByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x4E, 0x0D};
    byte[] closeByte = new byte[] { 0x50, 0x57, 0x52, 0x20, 0x4F, 0x46,0x46,0x0D};

    //string openASCII = "PWR ON\r\n";
    //string closeASCII = "PWR OFF\r\n";

    public PJLinkPort(string strPort)
    {
        //串口信息
        this.strPort = strPort;
        sp = new SerialPort(strPort, baudRate, parity, dataBits, stopBits);
        sp.Open();

        Other.OpenPJLinkEvent += SendMsg;
    }

    void SendMsg(OpenOrColse openOrColse)
    {
        switch (openOrColse)
        {
            case OpenOrColse.OPEN:
                SendData(openByte, sp);
                break;
            case OpenOrColse.CLOSE:
                SendData(closeByte, sp);
                break;
            default:
                break;
        }
    }

    //public void OpenPort()
    //{
    //    //SendData(openByte, sp);
    //    SendData(openASCII, sp);
    //}

    //public void ClosePort()
    //{
    //    //SendData(closeByte, sp);
    //    SendData(closeASCII, sp);
    //}

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
