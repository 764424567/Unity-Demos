using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SendData : MonoBehaviour
{
    [DllImport("usbdll7")]
    public static extern bool OpenUsb();
    [DllImport("usbdll7")]
    public static extern void CloseUsb();
    [DllImport("usbdll7")]
    public static extern Vector3 ReadUsb();
    [DllImport("usbdll7")]
    public static extern bool SendUsb(char[] SendData);
    [DllImport("send")]
    private static extern bool GoUp();
    [DllImport("send")]
    private static extern bool GoShake();
    [DllImport("send")]
    private static extern bool GoReset();

    public Text m_TextInfoShow;

    // Use this for initialization
    void Start()
    {
        OpenUSBInit();
    }

    void OpenUSBInit()
    {
        bool isOpen;
        isOpen = OpenUsb();
        if (isOpen)
        {
            Debug.Log("打开成功");
            SendInfoShow("USB打开成功");
        }
        else
        {
            Debug.Log("打开失败");
            SendInfoShow("USB打开失败，请重新插拔USB");
        }
    }

    public void SendUsbData(int type)
    {
        Vector3 tempVe3 = new Vector3(0, 0, 0);
        char[] senddata1 = new char[3];
        switch (type)
        {
            case 0:
                tempVe3 = new Vector3(10, 0, 0);//坠物
                break;
            case 1:
                tempVe3 = new Vector3(0, 12, 0);//触电
                break;
            case 2:
                tempVe3 = new Vector3(0, 0, 14);//热风
                break;
            default:
                break;
        }
        senddata1[0] = (char)tempVe3.x;
        senddata1[1] = (char)tempVe3.y;
        senddata1[1] = (char)tempVe3.z;
        bool sendState = SendUsb(senddata1);
        if (sendState)
        {
            Debug.Log("发送成功");
            switch (type)
            {
                case 0:
                    SendInfoShow("发送成功：  坠物打击指令--->" + senddata1[0] + " " + senddata1[1] + " " + senddata1[1]);
                    break;
                case 1:
                    SendInfoShow("发送成功：  触电事故指令--->" + senddata1[0] + " " + senddata1[1] + " " + senddata1[1]);
                    break;
                case 2:
                    SendInfoShow("发送成功：  热风模拟指令--->" + senddata1[0] + " " + senddata1[1] + " " + senddata1[1]);
                    break;
                default:
                    break;
            }
        }
        else
        {
            Debug.Log("发送失败");
            SendInfoShow("数据发送失败，请再次发送");
        }
    }

    public void SendIpData(int type)
    {
        switch (type)
        {
            case 0:
                GoUp();
                SendInfoShow("发送成功：  -->台子上升<--");
                break;
            case 1:
                GoShake();
                SendInfoShow("发送成功：  -->台子晃动<--");
                break;
            case 2:
                GoReset();
                SendInfoShow("发送成功：  -->台子复原<--");
                break;
            default:
                SendInfoShow("数据发送失败，请再次发送");
                break;
        }
    }

    void SendInfoShow(string info)
    {
        m_TextInfoShow.text = info;
    }
}
