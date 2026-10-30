using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class Panel3Logic : UIBase
{
    GameObject currentObj;
    Button BtnSure;
    Action endAction;

    public override void OnStart()
    {
        currentObj = transform.Find("UIControl").gameObject;
        currentObj.SetActive(false);

        BtnSure = currentObj.transform.Find("BtnSure").GetComponent<Button>();
        BtnSure.onClick.AddListener(BtnSureEvent);
    }

    /// <summary>
    /// 显示隐藏面板
    /// </summary>
    /// <param name="ison"></param>
    public void ShowInfo(bool ison)
    {
        currentObj.SetActive(ison);
    }

    /// <summary>
    /// 设置委托函数
    /// </summary>
    /// <param name="ison"></param>
    /// <param name="endAction"></param>
    public void ShowInfo(bool ison, Action endAction)
    {
        currentObj.SetActive(ison);
        this.endAction = endAction;
    }

    /// <summary>
    /// 点击确定的时候，关闭面板，并且执行委托函数
    /// </summary>
    void BtnSureEvent()
    {
        currentObj.SetActive(false);
        endAction?.Invoke();
    }
}