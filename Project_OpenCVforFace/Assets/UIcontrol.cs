using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour {

	public GameObject[] ui; //数组特效

	
	void Start () {
		
	}
	

	void Update () {
		
	}

	public void XianShi(GameObject obj) //逻辑界面的隐藏
	{
		for (int i = 0; i < ui.Length; i++) {
			ui [i].SetActive (false);
		}
		obj.SetActive (true);

	}
}
