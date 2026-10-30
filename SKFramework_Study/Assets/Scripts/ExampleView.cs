using SK.Framework.UI;
using UnityEngine;

public class ExampleView : MonoBehaviour, IUIView
{
    public string viewName { get; set; }

    public void OnClose()
    {
        Debug.Log("关闭UI");
    }

    public void OnLoad(object data)
    {
        Debug.Log("加载UI");
    }

    public void OnOpen(object data)
    {
        Debug.Log("打开UI");
    }

    public void OnUnload()
    {
        Debug.Log("卸载UI");
    }
}