/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： OwvlabSaas
* 创建日期：2021-01-22 10:00:34
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：Saas平台的数据交互接口
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using System;

namespace Com.Rainier.Buskit3D.Owvlab
{
    /// <summary>
    /// 润易享平台数据对接
    /// </summary>
	public class OwvlabSaas : MonoBehaviour 
	{
		/// <summary>
		/// 实验唯一标识（token前半部分）
		/// </summary>
		private  string appId = "";

		/// <summary>
		/// 用户信息（token后半部分）
		/// </summary>
		private  string expId = "";

		/// <summary>
		/// 实验主页
		/// </summary>
		private  string host = "";

        private UnityAction<string,string,string> loginCallback;
        private UnityAction<string> sendMessageToPlatformCallBack;

		/// <summary>
        /// Unity Method
        /// </summary>
		void Start () 
		{
			GetUserInfo();
		}
	
		/// <summary>
		/// WebGL获取用户信息
		/// </summary>
		private void GetUserInfo()
		{
#if UNITY_WEBGL && !UNITY_EDITOR
            Application.ExternalCall("getExpId", this.gameObject.name, "Saas_JsCallBack");
#elif UNITY_STANDALONE
			MyCloudLogin();
#endif
		}

		/// <summary>
		/// 云渲染获取用户信息
		/// </summary>
		private void MyCloudLogin()
		{
			string[] args = Environment.GetCommandLineArgs();
			expId = args[1].Split('_')[1];
		}

		/// <summary>
		/// Js 回调函数
		/// </summary>
		/// <param name="json"></param>
		private void Saas_JsCallBack(string json)
		{
			Debug.Log("平台回传消息："+json);
			JObject jo = JObject.Parse(json);
			appId = jo["appId"].ToString();
			expId = jo["expId"].ToString();
			host=jo["host"].ToString();
            loginCallback.Invoke(appId, expId, host);
        }

        /// <summary>
        /// 登陆后回调
        /// </summary>
        /// <param name="callback"></param>
        public void AddLoginCallBack(UnityAction<string,string,string> callback) {
            loginCallback = callback;
        }

		/// <summary>
		/// 上传媒体文件
		/// </summary>
		/// <param name="files"></param>
		public void SendMediaFile(Dictionary<string,byte[]> files)
		{
			string url = host + "/openapi/upload_file";
			WWWForm data = new WWWForm();
			data.AddField("appId", appId);
			data.AddField("expId", expId);
            foreach (var item in files)
            {
				data.AddBinaryData("fileList", item.Value,item.Key);
            }
			IEnumerator Send()
			{
				UnityWebRequest req = UnityWebRequest.Post(url, data);
				var op=  req.SendWebRequest(); 
				yield return op;
				Debug.Log(op.webRequest.downloadHandler.text);
                

            }

			StartCoroutine(Send());
		}

        /// <summary>
		/// 上传文本文件
		/// </summary>
		/// <param name="result"></param>
		public void SendText(JObject result)
        {
            string url = host + "/openapi/data_upload";
            result["appId"] = appId;
            result["expId"] = expId;
            IEnumerator Send()
            {
                UnityWebRequest req = UnityWebRequest.Post(url, result.ToString());
                req.SetRequestHeader("Content-Type", "Application/json");
                var op = req.SendWebRequest();
                yield return op;
                Debug.Log(op.webRequest.downloadHandler.text);
            }
            StartCoroutine(Send());
        }

        /// <summary>
        /// 上传文本文件
        /// </summary>
        /// <param name="result"></param>
        public void SendText(JObject result,UnityAction<string> callback) 
		{
			string url = host+ "/openapi/data_upload";
			result["appId"] = appId;
			result["expId"] = expId;
			IEnumerator Send()
			{
				UnityWebRequest req = UnityWebRequest.Post(url, result.ToString());
				req.SetRequestHeader("Content-Type", "Application/json");
				var op = req.SendWebRequest();
				yield return op;
				Debug.Log(op.webRequest.downloadHandler.text);
                callback.Invoke(op.webRequest.downloadHandler.text);
            }
			StartCoroutine(Send());
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <param name="callback"></param>
		/// <param name="dataType"></param>
		public void GetData(System.Action<string> callback,string dataType)
		{
			string url = string.Format("{0}/openapi/data_get?appId={1}&expId={2}&dataType={3}",
				host,appId,expId, dataType); 

			IEnumerator Get()
			{
				UnityWebRequest req = UnityWebRequest.Get(url);
				var op = req.SendWebRequest();
				yield return op;
				Debug.Log(op.webRequest.downloadHandler.text);
				if (callback != null)
				{
					JObject jo = JObject.Parse(op.webRequest.downloadHandler.text);
					callback(jo["data"]["context"].ToString());
				}
			}

			StartCoroutine(Get());
		}

	}
}

