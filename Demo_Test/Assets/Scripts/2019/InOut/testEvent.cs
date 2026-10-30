using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class testEvent : MonoBehaviour
{

    FadeInOutControl fadeInOutControl;

    delegate void BackupGroundDelegate(bool b);//委托

    BackupGroundDelegate dele;

    void Start()
    {

        fadeInOutControl = GameObject.FindWithTag("UI_Manager").GetComponent<FadeInOutControl>();

        dele = fadeInOutControl.BackGroundControl;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))//事件触发

            dele(true);

        if (Input.GetKeyDown(KeyCode.C))//事件触发

            dele(false);

    }

}