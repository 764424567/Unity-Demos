using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public List<UIBase> UIList;

    // 使用栈的后进先出的特性，实现UI的后显示先隐藏的功能
    Stack<GameObject> uiQueue;

    void Start()
    {
        // 初始化UI
        UIInit();
        // 初始化参数
        uiQueue = new Stack<GameObject>();
    }

    void UIInit()
    {
        // 排序
        UIList.Sort((x, y) => x.StartOrder.CompareTo(y.StartOrder));
        // 设置初始化顺序
        for (int i = 0; i < UIList.Count; i++)
        {
            Debug.Log(UIList[i].StartOrder);
            UIList[i].OnStart();
            UIList[i].UniqueID = 1000 + i;
        }
        // 排序
        UIList.Sort((x, y) => x.LayerOrder.CompareTo(y.LayerOrder));
        // 设置层级顺序
        for (int i = 0; i < UIList.Count; i++)
        {
            Debug.Log(UIList[i].LayerOrder);
            UIList[i].transform.SetSiblingIndex(UIList[i].LayerOrder);
        }
    }

    /// <summary>
    /// 显示UI
    /// </summary>
    /// <param name="UniqueID"></param>
    public void ShowPanel(int UniqueID)
    {
        UIBase uiObj = UIList.Find(value => value.UniqueID == UniqueID);
        if (uiObj != null)
        {
            uiObj.ShowInfo(true);
            uiQueue.Push(uiObj.gameObject);
        }
    }

    /// <summary>
    /// 隐藏UI 适用于多个UI重叠 点击任意位置关闭UI的情况
    /// </summary>
    public void HidePanel()
    {
        GameObject ui = uiQueue.Pop();
        ui.GetComponent<UIBase>().ShowInfo(false);
    }
}