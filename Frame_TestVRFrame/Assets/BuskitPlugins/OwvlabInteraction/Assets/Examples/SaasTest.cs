/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： SaasTest
* 创建日期：2021-01-22 15:41:22
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit3D.Owvlab;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit3D.Storage;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace RainierHub
{
    /// <summary>
    /// 
    /// </summary>
	public class SaasTest : MonoBehaviour 
	{
		public Texture2D texture;
		public AudioClip audioClip;
		private OwvlabSaas owvlab;

		/// <summary>
        /// Unity Method
        /// </summary>
		void Start () 
		{
			owvlab = GetComponent<OwvlabSaas>();
		}

		/// <summary>
		/// 上传媒体文件
		/// </summary>
		public void SendFile()
		{
			Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();
			files.Add("image1.png", texture.EncodeToPNG());
			files.Add("image2.png", texture.EncodeToPNG());
			owvlab.SendMediaFile(files);
		}

		/// <summary>
		/// 上传文本文件
		/// </summary>
		public void SendText()
		{

			JObject repdata = new JObject();
			repdata["text1"] = "这是啥阿三大苏打实打实的123";
			repdata["text2"] = "sssssssssssssssfafadasd";

			JArray socre = new JArray();
			JObject jsonStr = new JObject();
			jsonStr["moduleFlag"] = "实验成绩";
			jsonStr["questionNumber"] = 1;
			jsonStr["questionStem"] = "学生操作成绩";
			jsonStr["score"] = 80;
			jsonStr["trueOrFalse"] = "True";
			socre.Add(jsonStr);

			//实验回放数据内容填充
//			JObject reply = new JObject();

//			StorageSystem storage = InjectService.Get<StorageSystem>();
//			string str = storage.Serialize();
//#if UseCompress
//            str = ZipUtility.GZipCompressString(str);
//#endif

			JObject result = new JObject();

			result["reportData"] = repdata;
			result["expScoreDetails"] = socre;
			//实验回放数据内容填充
			//result["expScriptContent"] = str;

			owvlab.SendText(result);
		}


		public void GetData()
		{
			owvlab.GetData(ProcessData, "expScript");
		}

		private void ProcessData(string str)
		{
			//实验回放数据回调
//			StorageSystem storage = InjectService.Get<StorageSystem>();
//#if UseCompress
//			str = ZipUtility.GZipDecompressString(str);
//#endif
//			storage.Deserialize(str);
		}
	}
}

