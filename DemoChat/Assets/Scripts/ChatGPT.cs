using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPT
{
    const string ChatgptUrl = "https://api.openai.com/v1/chat/completions";
    const string DefaultAPIKey = "替换自己的ChatGPT API Key";
    const string DefaultModel = "gpt-3.5-turbo";
    const float DefaultTemperature = 0;
    const string DefaultUserId = "user";
    string ApiKey;
    string UserId;
    List<Message> messageHistory;
    public List<Message> MessageHistory => messageHistory;
    ChatGPTRequestData requestData;
    UnityWebRequest webRequest;
    int mRequestTimeout = 60;
    public int RequestTimeout { get => mRequestTimeout; set => mRequestTimeout = Mathf.Max(value, 30); }
    public float ChatGPTRandomness { get => requestData.temperature; set { requestData.temperature = Mathf.Clamp(value, 0, 2); } }
    public bool IsRequesting => webRequest != null && !webRequest.isDone;
    public float RequestProgress => IsRequesting ? (webRequest.uploadProgress + webRequest.downloadProgress) / 2f : 0f;
    
    /// <summary>
    /// 公有构造函数，将参数进行初始化
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="userId"></param>
    /// <param name="model"></param>
    /// <param name="temperature"></param>
    public ChatGPT(string apiKey = DefaultAPIKey, string userId = DefaultUserId, string model = DefaultModel, float temperature = DefaultTemperature)
    {
        this.ApiKey = apiKey;
        this.UserId = string.IsNullOrWhiteSpace(userId) ? DefaultUserId : userId;
        messageHistory = new List<Message>();
        requestData = new ChatGPTRequestData(model, temperature);
    }

    /// <summary>
    /// 设置APIKey
    /// </summary>
    /// <param name="str"></param>
    public void SetAPIKey(string str)
    {
        this.ApiKey = str;
    }

    /// <summary>
    /// 向AI发送消息
    /// </summary>
    /// <param name="message"></param>
    /// <param name="onComplete"></param>
    /// <param name="onProgressUpdate"></param>
    public void Send(string message, Action<bool, string> onComplete = null, Action<float> onProgressUpdate = null)
    {
        EditorCoroutineUtility.StartCoroutine(Request(message, onComplete, onProgressUpdate), this);
    }

    /// <summary>
    /// 异步等待返回消息
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task<string> SendAsync(string message)
    {
        bool isCompleted = false;
        string result = string.Empty;
        Action<bool, string> onComplete = (success, str) =>
        {
            isCompleted = true;
            if (success) result = str;
        };

        EditorCoroutineUtility.StartCoroutine(Request(message, onComplete, null), this);
        while (!isCompleted)
        {
            await System.Threading.Tasks.Task.Delay(10);
        }
        return result;
    }

    /// <summary>
    /// 等待返回消息
    /// </summary>
    /// <param name="input"></param>
    /// <param name="onComplete"></param>
    /// <param name="onProgressUpdate"></param>
    /// <returns></returns>
    private IEnumerator Request(string input, Action<bool, string> onComplete, Action<float> onProgressUpdate)
    {
        var msg = new Message()
        {
            role = UserId,
            content = input,
        };
        requestData.AppendChat(msg);
        messageHistory.Add(msg);

        using (webRequest = new UnityWebRequest(ChatgptUrl, "POST"))
        {
            var jsonDt = JsonConvert.SerializeObject(requestData);
            Debug.Log(jsonDt);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonDt);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", $"Bearer {this.ApiKey}");
            webRequest.certificateHandler = new ChatGPTWebRequestCert();
            var req = webRequest.SendWebRequest();
            while (!webRequest.isDone)
            {
                onProgressUpdate?.Invoke((webRequest.downloadProgress + webRequest.uploadProgress) / 2f);
                yield return null;
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"---------ChatGPT请求失败:{webRequest.error}---------");
                onComplete?.Invoke(false, string.Empty);
            }
            else
            {
                var json = webRequest.downloadHandler.text;
                Debug.Log(json);
                try
                {
                    ChatCompletion result = JsonConvert.DeserializeObject<ChatCompletion>(json);
                    int lastChoiceIdx = result.choices.Count - 1;
                    var replyMsg = result.choices[lastChoiceIdx].message;
                    replyMsg.content = replyMsg.content.Trim();
                    messageHistory.Add(replyMsg);
                    onComplete?.Invoke(true, replyMsg.content);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"---------ChatGPT返回数据解析失败:{e.Message}---------");
                    onComplete?.Invoke(false, e.Message);
                }
            }
            webRequest.Dispose();
            webRequest = null;
        }
    }

    /// <summary>
    /// 接着上次的话题
    /// </summary>
    public void RestoreChatHistory()
    {
        var chatHistoryJson = EditorPrefs.GetString("ChatGPT.Settings.ChatHistory", string.Empty);
        var requestDataJson = EditorPrefs.GetString("ChatGPT.Settings.RequestData", string.Empty);
        if (!string.IsNullOrEmpty(chatHistoryJson))
        {
            var jsonObj = JsonConvert.DeserializeObject<ChatGPTRequestData>(requestDataJson);
            if (jsonObj != null)
            {
                requestData.messages = jsonObj.messages;
            }
        }
        if (!string.IsNullOrEmpty(requestDataJson))
        {
            var jsonObj = JsonConvert.DeserializeObject<List<Message>>(chatHistoryJson);
            if (jsonObj != null)
            {
                messageHistory = jsonObj;
            }
        }
    }

    /// <summary>
    /// 保存历史消息
    /// </summary>
    public void SaveChatHistory()
    {
        var chatHistoryJson = JsonConvert.SerializeObject(messageHistory);
        var requestDataJson = JsonConvert.SerializeObject(requestData);
        EditorPrefs.SetString("ChatGPT.Settings.ChatHistory", chatHistoryJson);
        EditorPrefs.SetString("ChatGPT.Settings.RequestData", requestDataJson);
    }

    /// <summary>
    /// 新话题
    /// </summary>
    public void NewChat()
    {
        requestData.ClearChat();
        messageHistory.Clear();
    }

    /// <summary>
    /// 是否是自己发送的消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public bool IsSelfMessage(Message msg)
    {
        return this.UserId.CompareTo(msg.role) == 0;
    }
}
class ChatGPTRequestData
{
    public List<Message> messages;
    public string model;
    public float temperature;

    public ChatGPTRequestData(string model, float temper)
    {
        this.model = model;
        this.temperature = temper;
        this.messages = new List<Message>();
    }

    /// <summary>
    /// 同一话题追加会话内容
    /// </summary>
    /// <param name="chatMsg"></param>
    /// <returns></returns>
    public ChatGPTRequestData AppendChat(Message msg)
    {
        this.messages.Add(msg);
        return this;
    }
    /// <summary>
    /// 清除聊天历史(结束一个话题), 相当于新建一个聊天话题
    /// </summary>
    public void ClearChat()
    {
        this.messages.Clear();
    }
}
/// <summary>
/// 消息体
/// </summary>
public class Message
{
    public string role;
    public string content;
}
/// <summary>
/// 忽略证书验证
/// </summary>
class ChatGPTWebRequestCert : UnityEngine.Networking.CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        //return base.ValidateCertificate(certificateData);
        return true;
    }
}
/// <summary>
/// 返回数据结构
/// </summary>
class ChatCompletion
{
    public string id;
    public string @object;
    public int created;
    public string model;
    public Usage usage;
    public List<Choice> choices;
}
/// <summary>
/// 使用情况
/// </summary>
class Usage
{
    public int prompt_tokens;
    public int completion_tokens;
    public int total_tokens;
}
/// <summary>
/// 选择
/// </summary>
class Choice
{
    public Message message;
    public string finish_reason;
    public int index;
}