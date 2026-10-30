using UnityEngine;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
public class read : MonoBehaviour
{
	public Vector3 readKml(string StringPath)
	{
		Vector3 v3 = new Vector3(0,0,0);
		//Debug.Log(Directory.GetParent(readuipath.Instance.StringPath));
		//string a = "https://www.so.com/s/sss";无法获取 https://
		string a = StringPath;
		Debug.Log(a + "/metadata.xml");
		//IO判断xml文件是否存在
		if (File.Exists(a + "/metadata.xml"))
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(a + "/metadata.xml");
			XmlElement xmlnodelist = xml.DocumentElement;//根节点
			XmlNode dataNode = xmlnodelist.SelectSingleNode("SRSOrigin");
			string Innertext = dataNode.InnerText.ToString();
			double bb = Convert.ToDouble(Innertext.Split(',')[0]);
			v3 = new Vector3(Convert.ToSingle(Innertext.Split(',')[0]) / 100, Convert.ToSingle(Innertext.Split(',')[2]), Convert.ToSingle(Innertext.Split(',')[1]) / 100);
		}
		else
		{
			Debug.Log("无kml文件");
		}
		return v3;
	}
}
