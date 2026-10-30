using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UnityCallJs : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);


    public Text InfoShow;

    void Start()
    {
        Debug.Log("Unity调用JS");
        Hello();
        HelloString("This is a string.");
    }

    public void JSCallUnity1()
    {
        Debug.Log("调用无参函数");
        InfoShow.text = "调用无参函数";
    }
    public void JSCallUnity2(string msg)
    {
        Debug.Log("接收到消息：" + msg);
        InfoShow.text = msg;
    }
}
