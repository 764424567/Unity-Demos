using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTest : MonoBehaviour
{
    Socket socketSend;//客户端
    string inputIp;//IP
    string inputPort;//端口
    string staInfo;//显示消息
    string recMes;//接收消息


    void Start()
    {
        inputIp = "";
        inputPort = "";
    }

    void OnGUI()
    {
        GUI.Label(new Rect(135, 10, 80, 60), staInfo);
    }

    //开启连接
    private void ClickConnect()
    {
        try
        {
            int _port = Convert.ToInt32(inputPort);             //获取端口号
            string _ip = inputIp;                               //获取ip地址

            //创建客户端Socket，获得远程ip和端口号
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(_ip);
            IPEndPoint point = new IPEndPoint(ip, _port);

            socketSend.Connect(point);
            Debug.Log("连接成功 , " + " ip = " + ip + " port = " + _port);
            staInfo = ip + ":" + _port + "  连接成功";

            Thread r_thread = new Thread(Received);             //开启新的线程，不停的接收服务器发来的消息
            r_thread.IsBackground = true;
            r_thread.Start();
        }
        catch (Exception)
        {
            Debug.Log("IP或者端口号错误......");
            staInfo = "IP或者端口号错误......";
        }
    }

    //接收消息
    void Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024 * 6];
                //实际接收到的有效字节数
                int len = socketSend.Receive(buffer);
                if (len == 0)
                {
                    break;
                }

                recMes = Encoding.UTF8.GetString(buffer, 0, len);

                Debug.Log("客户端接收到的数据 ： " + recMes);
            }
            catch { }
        }
    }

    //发送消息
    void SendInfo(string inputMes)
    {
        string msg = inputMes;
        byte[] buffer = new byte[1024 * 6];
        buffer = Encoding.UTF8.GetBytes(msg);
        socketSend.Send(buffer);
    }

    //关闭连接
    private void OnDisable()
    {
        Debug.Log("begin OnDisable()");

        if (socketSend.Connected)
        {
            try
            {
                socketSend.Shutdown(SocketShutdown.Both);    //禁用Socket的发送和接收功能
                socketSend.Close();                          //关闭Socket连接并释放所有相关资源
            }
            catch (Exception e)
            {
                print(e.Message);
            }
        }

        Debug.Log("end OnDisable()");
    }
}
