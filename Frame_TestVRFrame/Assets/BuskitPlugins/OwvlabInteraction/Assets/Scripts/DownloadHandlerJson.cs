/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： DownloadHandlerJson
* 创建日期：2020-03-20 14:01:14
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：WebRequest 扩展
******************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System;

namespace Com.Rainier.Buskit3D.Owvlab
{
	/// <summary>
	/// WebRequest 扩展
	/// </summary>
	public class DownloadHandlerJson<T> : DownloadHandlerScript
	{
		private T obj;
		private StringBuilder builder = new StringBuilder();
		public DownloadHandlerJson() : base()
		{

		}

		public DownloadHandlerJson(byte[] buffer) : base(buffer)
		{

		}

		protected override byte[] GetData()
		{
			return null;
		}

		protected override bool ReceiveData(byte[] data, int dataLength)
		{
			if (data == null || data.Length < 1)
			{
				return false;
			}
			var context = System.Text.Encoding.UTF8.GetString(data);
			builder.Append(context);
			Debug.Log(string.Format("LoggingDownloadHandler :: ReceiveData - received {0} bytes", dataLength));
			return true;
		}

		protected override string GetText()
		{
			return base.GetText();
		}
		protected override void CompleteContent()
		{
			Debug.Log("LoggingDownloadHandler :: CompleteContent - DOWNLOAD COMPLETE!");
		}

		public T GetObject()
		{

			var text = builder.ToString();
			try
			{
				Debug.Log("正常响应结果：" + text);
				obj = JObject.Parse(text).ToObject<T>();
			}
			catch (Exception e)
			{
				if (string.IsNullOrEmpty(text))
				{
					Debug.Log("响应结果为空字符串，异常：" + e.Message);
					return default(T);
				}

				byte[] da = System.Convert.FromBase64String(text);
				text = System.Text.Encoding.UTF8.GetString(da);
				Debug.Log("异常响应结果：" + text);
				obj = JObject.Parse(text).ToObject<T>();
				Debug.Log("响应结果不为Json字符串，异常：" + e.Message);
			}

			return obj;
		}

	}

	public static class UnityWebRequestExtension
	{
		public static UnityWebRequestAsyncOperation SendWebRequest<T>(this UnityWebRequest own)
		{
			if (typeof(T) != typeof(None))
			{
				own.downloadHandler = new DownloadHandlerJson<T>();
			}

			if (own.uri.Scheme == "https")
			{
				own = own.ToHttps();
			}

			var req = own.SendWebRequest();
			return req;
		}

		public static DownloadHandlerJson<T> DownLoadHanlderJson<T>(this UnityWebRequest own)
		{
			return own.downloadHandler as DownloadHandlerJson<T>;
		}
		public static UnityWebRequest ToHttps(this UnityWebRequest own)
		{
			own.certificateHandler = new AcceptAllCertificateHandler();
			return own;
		}

		class AcceptAllCertificateHandler : CertificateHandler
		{
			protected override bool ValidateCertificate(byte[] certificateData)
			{
				// Workaround for Non-Secure web page
				// You should implement the validation when you release your service publicly.
				return true;
			}
		}
	}
	class None
	{
	}



}

