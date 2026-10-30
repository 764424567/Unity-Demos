using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    [SerializeField]
    private GameObject otherPanel;
    [SerializeField]
    private GameObject selectPanel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSelect(int index)
    {
        switch(index)
        {
            case 0://进入选择课程界面
                SceneManager.LoadScene(1);
                break;
            case 1://返回主课程界面
                otherPanel.SetActive(false);
                break;
            case 2://进入辅课程界面
                otherPanel.SetActive(true);
                break;
            case 3://进入语文课程
                break;
            case 4://进入数学课程
                break;
            case 5://进入英语课程
                break;
            case 6://进入化学课程
                break;
            case 7://进入物理课程
                break;
            case 8://进入体育课程
                break;
            case 9://进入音乐课程
                break;
        }
        if (index >= 3)
        {
            //selectPanel.SetActive(false);//进入课程学习
            SceneManager.LoadScene(index - 1);
        } 
        else
        {
        }
    }
}
