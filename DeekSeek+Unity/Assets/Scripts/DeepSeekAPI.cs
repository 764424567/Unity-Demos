using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeepSeekAPI : MonoBehaviour
{
    [Header("API Settings")]

    [SerializeField] private AIConfig aiConfig;


    // 对话参数
    [Header("Dialogue Settings")]
    [Range(0, 2)] public float temperature = 0.5f;// 控制生成文本的随机性（0-2，值越高越随机）
    [Range(1, 1000)] public int maxTokens = 100;// 生成的最大令牌数（控制回复长度）

    // 角色设定
    [System.Serializable]
    public class NPCCharacter
    {
        public string name = "Unity-助手";
        [TextArea(3, 10)]
        public string personalityPrompt = "你是Unity-助手，擅长Unity和C#编程知识。";// 角色设定提示词
    }
    [SerializeField] public NPCCharacter npcCharacter;
    // 回调委托，用于异步处理API响应
    public delegate void DialogueCallback(string content, bool isSuccess);
    // Start is called before the first frame update
    void Start()
    {
        //SendMessageToDeepSeek("你好啊", null);
    }
    public void SendMessageToDeepSeek(string message, DialogueCallback callback)
    {
        StartCoroutine(PostRequest(message, callback));
    }

    private DownloadHandlerBuffer downloadHandler;
    /// <summary>
    ///  处理对话请求的协程
    /// </summary>
    /// <param name="message">玩家的输入内容<</param>
    /// <param name="callback">回调函数，用于处理API响应</param>
    /// <returns></returns>
    IEnumerator PostRequest(string message, DialogueCallback callback)
    {
        // 构建消息列表，包含系统提示和用户输入
        List<Message> messages = new List<Message>
        {
            new Message { role = "system", content = npcCharacter.personalityPrompt },// 系统角色设定
            new Message { role = "user", content = message }// 用户输入
        };

        // 构建请求体
        ChatRequest requestBody = new ChatRequest
        {
            model = aiConfig.modelName,// 模型名称
            messages = messages,// 消息列表
            temperature = temperature,// 温度参数
            max_tokens = maxTokens// 最大令牌数
        };


        // 使用Newtonsoft.Json序列化
        //string jsonBody = JsonConvert.SerializeObject(requestBody);
        string jsonBody = JsonUtility.ToJson(requestBody);

        Debug.Log(jsonBody);

        // 创建UnityWebRequest
        UnityWebRequest request = CreateWebRequest(jsonBody);

        //downloadHandler = new DownloadHandlerBuffer();
        //request.downloadHandler = downloadHandler;

        //UnityWebRequestAsyncOperation operation = request.SendWebRequest();
        //while (!operation.isDone)
        //{
        //    Debug.Log(1);
        //    byte[] data = new byte[request.downloadedBytes];
        //    Debug.Log(request.downloadedBytes);
        //    data = downloadHandler.data;
        //    Debug.Log(data.Length);
        //    Debug.Log(data.GetValue(0));
        //    if (data != null)
        //    {
        //        Debug.Log(System.Text.Encoding.UTF8.GetString(data));
        //    }
        //    data = null;

        //    yield return null;
        //}

        //operation.completed += (asyncOperation) =>
        //{
        //    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        //    {
        //        Debug.LogError(request.error);
        //    }
        //    else
        //    {
        //        Debug.Log("请求成功: " + request.downloadHandler.text);
        //    }
        //};


        Debug.Log("发送数据:" + DateTime.Now);
        yield return request.SendWebRequest();
        Debug.Log("发送数据:" + DateTime.Now);

        if (IsRequestError(request))
        {
            if (request.responseCode == 429) // 速率限制
            {
                Debug.LogWarning("速率限制达到，延迟重试中...");
                yield return new WaitForSeconds(5); // 延迟5秒后重试
                StartCoroutine(PostRequest(message, callback));
                yield break;
            }
            else
            {
                Debug.LogError($"API Error: {request.responseCode}\n{request.downloadHandler.text}");
                callback?.Invoke($"API请求失败：{request.downloadHandler.text}", false);
                yield break;
            }
        }

        Debug.Log(request.downloadHandler.text);
        DeepSeekResponse response = ParseResponse(request.downloadHandler.text);

        if (response != null && response.choices.Length > 0)
        {
            Debug.Log("Reply " + request.downloadHandler.text);
            string npcReply = response.choices[0].message.content;
            Debug.Log(npcReply);
            callback?.Invoke(npcReply, true);
        }
        else
        {
            callback?.Invoke(name + "（陷入沉默）", false);
        }
        request.Dispose(); // 确保释放UnityWebRequest
    }

    /// <summary>
    /// 创建UnityWebRequest对象
    /// </summary>
    /// <param name="jsonBody">请求体的JSON字符串</param>
    /// <returns>配置好的UnityWebRequest对象</returns>
    private UnityWebRequest CreateWebRequest(string jsonBody)
    {
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        UnityWebRequest request = new UnityWebRequest(aiConfig.apiUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);// 设置上传处理器
        request.downloadHandler = new DownloadHandlerBuffer();// 设置下载处理器
        request.SetRequestHeader("Content-Type", "application/json");// 设置请求头
        request.SetRequestHeader("Authorization", $"Bearer {aiConfig.apiKey}");// 设置认证头
        request.SetRequestHeader("Accept", "application/json");// 设置接受类型
        return request;
    }
    /// <summary>
    /// 检查请求是否出错
    /// </summary>
    /// <param name="request">UnityWebRequest对象</param>
    /// <returns>如果请求出错返回true，否则返回false</returns>
    private bool IsRequestError(UnityWebRequest request)
    {
        return request.result == UnityWebRequest.Result.ConnectionError ||
               request.result == UnityWebRequest.Result.ProtocolError ||
               request.result == UnityWebRequest.Result.DataProcessingError;
    }
    /// <summary>
    /// 解析API响应
    /// </summary>
    /// <param name="jsonResponse">API响应的JSON字符串</param>
    /// <returns>解析后的DeepSeekResponse对象</returns>
    private DeepSeekResponse ParseResponse(string jsonResponse)
    {
        try
        {
            DeepSeekResponse response = JsonUtility.FromJson<DeepSeekResponse>(jsonResponse);
            if (response == null || response.choices == null || response.choices.Length == 0)
            {
                Debug.LogError("API响应格式错误或未包含有效数据。");
                return null;
            }
            return response;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"JSON解析失败: {e.Message}\n响应内容：{jsonResponse}");
            return null;
        }
    }



    // 可序列化数据结构
    [System.Serializable]
    private class ChatRequest
    {
        public string model;// 模型名称
        public List<Message> messages;// 消息列表
        public float temperature;// 温度参数
        public int max_tokens;// 最大令牌数
    }

    [System.Serializable]
    public class Message
    {
        public string role;// 角色（system/user/assistant）
        public string content;// 消息内容

    }

    [System.Serializable]
    private class Choice
    {
        public Message message;// 生成的消息
    }

    [System.Serializable]
    private class DeepSeekResponse
    {
        public Choice[] choices;// 生成的选择列表
    }
}
