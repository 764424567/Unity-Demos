using UnityEngine;
using SK.Framework;
using SK.Framework.Events;
using System.Collections.Generic;

public class UseEvents : MonoBehaviour
{
    Events m_Event;
    Dictionary<string, List<string>> m_Dic;

    void Start()
    {
        m_Event = SKFramework.Module<Events>();

        // 订阅
        m_Event.Subscribe(100, () => { Debug.Log("执行100事件"); });

        m_Event.Subscribe(0, (value) => { ShowInfo((InfoDataEventArgs)value); });

        m_Event.Subscribe<string, string>(102, (value1, value2) => { ShowInfo(value1, value2); });
    }

    void ShowInfo(InfoDataEventArgs args)
    {
        Debug.Log(args.UserFun());
    }

    void ShowInfo(string info1, string info2)
    {
        Debug.Log(info1 + " " + info2);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Event.Publish(100);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InfoDataEventArgs data = new InfoDataEventArgs();
            data.Info = "自定义的数据";
            m_Event.Publish(data);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Event.Publish(102, "传递的值1", "传递的值2");
        }
    }
}

public class InfoDataEventArgs : EventArgs
{
    public override int ID { get; }
    public override void OnInvoke() { }
    
    public string Info { get; set; }
    // 自定义函数
    public string UserFun()
    {
        return Info;
    }
}