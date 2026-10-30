using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class LocalDeepSeek : MonoBehaviour
{
    string url = "http://127.0.0.1:11434/api/chat";
    string ur2 = "http://127.0.0.1:11434/v1/chat/completions";
    /// <summary>
    /// 缓存对话
    /// </summary>
    [SerializeField] public List<SendData> m_DataList = new List<SendData>();

    /// <summary>
    /// api key
    /// </summary>
    [SerializeField] private string api_key;
    /// <summary>
    /// AI设定
    /// </summary>
    public string m_SystemSetting = string.Empty;
    /// <summary>
    /// 模型名称
    /// </summary>
    public string m_ModelName = "deepseek-r1:8b";//使用本地安装的模型

    private void Start()
    {
        //运行时，添加AI设定
        m_DataList.Add(new SendData("system", m_SystemSetting));
    }

    ///// <summary>
    ///// 发送消息
    ///// </summary>
    ///// <returns></returns>
    public void PostMsg(string _msg, Action<string> _callback)
    {
        //缓存发送的信息列表
        m_DataList.Add(new SendData("user", _msg));

        StartCoroutine(Request(_callback));
    }

    /// <summary>
    /// 调用接口
    /// </summary>
    /// <param name="_postWord"></param>
    /// <param name="_callback"></param>
    /// <returns></returns>
    public IEnumerator Request(System.Action<string> _callback)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            Debug.Log("url:" + url);
            Debug.Log("m_ModelName:" + m_ModelName);
            PostData _postData = new PostData
            {
                model = m_ModelName,
                messages = m_DataList,
                stream = false
            };

            string _jsonText = JsonUtility.ToJson(_postData);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(_jsonText);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(data);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(api_key))
            {
                request.SetRequestHeader("Authorization", string.Format("Bearer {0}", api_key));
            }
            Debug.Log("发送数据:" + DateTime.Now);
            yield return request.SendWebRequest();
            Debug.Log("发送数据:" + DateTime.Now);

            if (request.responseCode == 200)
            {
                string _msgBack = request.downloadHandler.text;
                Debug.Log(_msgBack);
                MessageBack2 _textback = JsonUtility.FromJson<MessageBack2>(_msgBack);

                string _backMsg = _textback.message.content;

                // 使用正则表达式提取
                Match match = Regex.Match(_backMsg, @"</think>\n\n(.*?)$", RegexOptions.Singleline);
                if (match.Success)
                {
                    string extractedText = match.Groups[1].Value.Trim();
                    _backMsg = extractedText;
                }
                Debug.Log(_msgBack);
                m_DataList.Add(new SendData("assistant", _backMsg));
                _callback(_backMsg);//返回接收的消息
            }
            else
            {
                string _msgBack = request.downloadHandler.text;
                Debug.LogError(_msgBack);
            }
        }
    }

    #region 数据包

    [Serializable]
    public class PostData
    {
        public string model;
        public List<SendData> messages;
        public bool stream = false;
    }


    [Serializable]
    public class MessageBack
    {
        public string id;
        public string created;
        public string model;
        public List<MessageBody> choices;
    }
    [Serializable]
    public class MessageBack2
    {
        public string model;
        public string created;
        public Message message;
    }
    [Serializable]
    public class MessageBody
    {
        public Message message;
        public string finish_reason;
        public string index;
    }
    [Serializable]
    public class Message
    {
        public string role;
        public string content;
    }
    [Serializable]
    public class SendData
    {
        [SerializeField] public string role;
        [SerializeField] public string content;
        public SendData() { }
        public SendData(string _role, string _content)
        {
            role = _role;
            content = _content;
        }
    }
    #endregion
}

