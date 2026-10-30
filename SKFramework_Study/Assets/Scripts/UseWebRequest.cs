using SK.Framework;
using SK.Framework.Networking;
using UnityEngine;

public class UseWebRequest : MonoBehaviour
{
    public class WebInterface
    {
        public static string BaiDu
        {
            get
            {
                return "https://www.baidu.com/";
            }
        }
    }
    private void Start()
    {
        SKFramework.Module<WebRequest>().Send(WebInterface.BaiDu, WebRequestData.Allocate(WebRequestType.GET),
            onSuccess: handler => Debug.Log(handler.text),
            onFailure: error => Debug.Log(string.Format("∑¢∆Õ¯¬Á«Î«Û ß∞‹£∫{0}", error)));
    }
}