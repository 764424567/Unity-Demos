using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperlinkLogic : MonoBehaviour
{
    public HyperlinkText hyperlinkText;
    void Start()
    {
        hyperlinkText.text = "文本测试：<a link=https://blog.csdn.net/q764424567>[恬静的小魔龙]</a>";
        hyperlinkText.onLinkClick = (info) => onclick(info);
    }

    void onclick(string info)
    {
        Debug.Log(info);
    }
}