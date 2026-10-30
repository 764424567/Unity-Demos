using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{
    private Transform cantrans;//Canvas
    private Text text;//text
    private Button button;//按钮
    private AndroidJavaObject jo = null;
    private InputField input1;
    private InputField input2;

    // Use this for initialization
    void Start()
    {
        //固定写法
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        cantrans = GameObject.Find("Canvas").transform;
        text = cantrans.Find("Text").GetComponent<Text>();
        button = cantrans.Find("Button").GetComponent<Button>();
        input1 = cantrans.Find("InputField").GetComponent<InputField>();
        input2 = cantrans.Find("InputField2").GetComponent<InputField>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //按钮方法
    public void OnClick()
    {
        text.text = "";
        int res = jo.Call<int>("Add", int.Parse(input1.text), int.Parse(input2.text));
        text.text = res.ToString();
    }
}
