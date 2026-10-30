/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TestPcUploadData
* 创建日期：2020-03-24 13:11:52
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.Video;
using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Com.Rainier.Buskit3D.Owvlab
{
	/// <summary>
	/// 测试旧平台上传实验数据
	/// </summary>
	public class TestPcUploadData : MonoBehaviour
	{

		public InputField scoreText;
		public Button scoreBtn;
		public Button reportBtn1;
		public Button reportBtn2;
		public Button reportBtn3;

		public Texture2D texture;
		public AudioClip audioClip;

		/// <summary>
		/// Unity Method
		/// </summary>
		void Start()
		{
			scoreBtn.onClick.AddListener(UpScoreData);

			reportBtn1.onClick.AddListener(UpReprotData1);
			

			reportBtn2.onClick.AddListener(UpReprotData2);

			reportBtn3.onClick.AddListener(UpReprotData3);

			OwvlabPlatform owvlabPc = InjectService.Get<OwvlabPlatform>();
			owvlabPc.Login("xuesheng", "12345678");

			//owvlabPc.Login();//云平台登录

			//StartCoroutine(UploadPNG());
		}

		/// <summary>
		/// Unity Method
		/// </summary>
		void Update()
		{

		}


		public void UpScoreData()
		{
			OwvlabPlatform owvlabPc = InjectService.Get<OwvlabPlatform>();

			int s = int.Parse(scoreText.text);

			owvlabPc.SendScoreToWeb(s);

		}


		public void UpReprotData1()
		{
			OwvlabPlatform owvlabPc = InjectService.Get<OwvlabPlatform>();

			JObject js = new JObject();
			js["eid"] = owvlabPc.EID;

			JArray jaText = new JArray();
			JObject item1 = new JObject();
			item1["text"] = "这是一次测试代码";
			item1["color"] = "red";

			JObject item2 = new JObject();
			item2["text"] = "这是一次测试代码";
			item2["color"] = "red";

			jaText.Add(item1);
			jaText.Add(item2);

			js["text1"] = jaText;

			owvlabPc.SendReportToWeb(js.ToString());
		}

		public void UpReprotData2()
		{
			OwvlabPlatform owvlabPc = InjectService.Get<OwvlabPlatform>();

			JObject js = new JObject();
			js["eid"] = owvlabPc.EID;

			JArray jaText = new JArray();
			JObject item1 = new JObject();
			item1["text"] = "这是一次测试代码";
			item1["color"] = "red";

			JObject item2 = new JObject();
			item2["text"] = "这是一次测试代码";
			item2["color"] = "red";

			jaText.Add(item1);
			jaText.Add(item2);

			js["text1"] = jaText;


			JArray jaudio = new JArray();
			JObject item = new JObject();

			item["src"] = System.Convert.ToBase64String( AudioClipToByte(audioClip));
			item["extend"] = "mp3";
			jaudio.Add(item);

			Debug.Log(System.Convert.ToBase64String(AudioClipToByte(audioClip)));
			js["Voice1"] = jaudio;

			owvlabPc.SendReportToWeb(js.ToString());
		}

		public void UpReprotData3()
		{
			OwvlabPlatform owvlabPc = InjectService.Get<OwvlabPlatform>();

			JObject js = new JObject();
			js["eid"] = owvlabPc.EID;

			JArray jaText = new JArray();
			JObject item1 = new JObject();
			item1["text"] = "这是一次测试代码";
			item1["color"] = "red";

			JObject item2 = new JObject();
			item2["text"] = "这是一次测试代码";
			item2["color"] = "red";

			jaText.Add(item1);
			jaText.Add(item2);

			js["text1"] = jaText;


			JArray jaudio = new JArray();
			JObject item = new JObject();
			item["src"] = System.Convert.ToBase64String( AudioClipToByte(audioClip));
			item["extend"] = "mp3";
			jaudio.Add(item);
			js["voice1"] = jaudio;

			JArray jpicture = new JArray();
			JObject item3 = new JObject();
			item3["src"] = System.Convert.ToBase64String( texture.EncodeToJPG());
			item3["extend"] = "jpg";
			item3["widht"] = "400px";
			item3["height"] = "400px";
			jpicture.Add(item3);
			js["picture1"] = jpicture;

			owvlabPc.SendReportToWeb(js.ToString());
		}


		public byte[] AudioClipToByte(AudioClip clip)
		{
			
			float[] floatData = new float[clip.samples * clip.channels];
			clip.GetData(floatData, 0);
			byte[] outData = new byte[floatData.Length];
			Buffer.BlockCopy(floatData, 0, outData, 0, outData.Length);
			return outData;
		}

	}
}

