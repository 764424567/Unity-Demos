/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TestPcUploadData_New
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
	/// 测试新平台pc端数据交互
	/// </summary>
	public class TestPcUploadData_New : MonoBehaviour
	{

		public InputField scoreText;
		public Button scoreBtn;
		public Button reportBtn1;

		public Texture2D texture;
		public AudioClip audioClip;

		public TextAsset textAsset;
		/// <summary>
		/// Unity Method
		/// </summary>
		void Start()
		{
			scoreBtn.onClick.AddListener(UpScoreData);

			reportBtn1.onClick.AddListener(UpReprotData1);

			OwvlabPlatformNew owvlabPc = InjectService.Get<OwvlabPlatformNew>();
			owvlabPc.Login("wanggengs", "wanggengs");

			//owvlabPc.Login("","",true); //云平台登录方式

			//直接测试报告上传图片和文字，不需要登录,从网页上拿去esid和eid
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
			OwvlabPlatformNew owvlabPc = InjectService.Get<OwvlabPlatformNew>();

			int s = int.Parse(scoreText.text);

			owvlabPc.SendScoreToWeb(s);

		}

		/// <summary>
		/// 登录之后 ,上传实验报告
		/// </summary>
		public void UpReprotData1()
		{
			OwvlabPlatformNew owvlabPc = InjectService.Get<OwvlabPlatformNew>();

			byte[] bytes = texture.EncodeToPNG();

			WWWForm form = new WWWForm();

			string str = textAsset.text;
			form.AddField("reportData", str);
			form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");
			form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");
			form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");


			form.AddField("text1", "");
			form.AddBinaryData("image1", bytes, "", "");

			owvlabPc.SendReportToWeb(form);
		}

		/// <summary>
		/// 直接测试报告上传
		/// </summary>
		/// <returns></returns>
		IEnumerator UploadPNG()
		{
			
			byte[] bytes = texture.EncodeToPNG();
			// Create a Web Form
			WWWForm form = new WWWForm();

			string str = textAsset.text;
			form.AddField("reportData", str);

			form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");
			//form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");
			//form.AddBinaryData("picFiles", bytes, "screenShot.png", "image/png");
			// Upload to a cgi script
			using (var w = UnityWebRequest.Post("http://cs.jinhao.owvlab.net/openapi/report/YOUR_REPORT_UUID/288203", form))
			{
			
				yield return w.SendWebRequest();
				if (w.isNetworkError || w.isHttpError)
				{
					print(w.error);
				}
				else
				{
					print("Finished Uploading Screenshot");
				}
				Debug.Log(w.downloadHandler.text);
			}
		}

		public byte[] AudioClipToByte(AudioClip clip)
		{
			float[] data = new float[clip.samples];
			clip.GetData(data, 0);
			int rescaleFactor = 32767; //to convert float to Int16
			byte[] outData = new byte[data.Length * 2];
			for (int i = 0; i < data.Length; i++)
			{
				short temshort = (short)(data[i] * rescaleFactor);
				byte[] temdata = BitConverter.GetBytes(temshort);
				outData[i * 2] = temdata[0];
				outData[i * 2 + 1] = temdata[1];
			}
			return outData;
		}

	}
}

