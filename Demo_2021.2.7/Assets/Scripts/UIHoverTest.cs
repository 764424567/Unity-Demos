using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverTest : MonoBehaviour
{
    //偏移值
    [SerializeField] float offsetX = 0;
    [SerializeField] float offsety = 0;
    //显示名字
    public string showName = "";
    //显示文字UI
    public GameObject showNameTip;

    /// <summary>
    /// 控制UI的位置
    /// </summary>
    void Update()
    {
        if (showNameTip.activeSelf)
        {
            showNameTip.transform.position = Input.mousePosition + new Vector3(offsetX, offsety, 0);
        }
    }

    /// <summary>
    /// 鼠标进入到模型  这个脚本需要挂载在模型上 否则检测不到
    /// </summary>
    public void OnMouseEnter()
    {
        if (showName != "" && !EventSystem.current.IsPointerOverGameObject())
        {
            ShowNameTip(showName);
        }
    }

    /// <summary>
    /// 鼠标离开模型
    /// </summary>
    public void OnMouseExit()
    {
        HideNameTip();
    }

    /// <summary>
    /// 显示文字
    /// </summary>
    /// <param name="name"></param>
    public void ShowNameTip(string name)
    {
        showNameTip.SetActive(true);
        showNameTip.GetComponentInChildren<Text>().text = name;
    }

    /// <summary>
    /// 隐藏文字
    /// </summary>
    public void HideNameTip()
    {
        showNameTip.SetActive(false);
        showNameTip.GetComponentInChildren<Text>().text = "";
    }
}
