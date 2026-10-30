using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 超链接信息类
/// </summary>
/// 
[Serializable]
public class HyperlinkInfo
{
    public int startIndex;
    public int endIndex;
    public string name;
    public readonly List<Rect> boxes = new List<Rect>();
}
/// <summary>
/// 文本控件,支持超链接
/// </summary>
public class HyperlinkText : Text, IPointerClickHandler
{
    /// <summary>
    /// 解析完最终的文本
    /// </summary>
    private string m_OutputText;
    /// <summary>
    /// 超链接信息列表
    /// </summary>
    private readonly List<HyperlinkInfo> _mLinkInfos = new List<HyperlinkInfo>();
    /// <summary>
    /// 文本构造器
    /// </summary>
    protected static readonly StringBuilder s_TextBuilder = new StringBuilder();
    /// <summary>
    /// 超链接正则表达式
    /// </summary>
    private static readonly Regex s_HrefRegex = new Regex(@"<a link=([^>\n\s]+)>(.*?)(</a>)", RegexOptions.Singleline);
    /// <summary>
    /// 文本超链接控件
    /// </summary>
    private HyperlinkText mHyperlinkText;


    protected override void Awake()
    {
        base.Awake();
        mHyperlinkText = GetComponent<HyperlinkText>();
    }

    #region 回调事件
    public Action<string> onLinkClick;
    /// <summary>
    /// 点击事件检测是否点击到超链接文本
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out var lp);

        foreach (var info in _mLinkInfos)
        {
            var boxes = info.boxes;
            for (var i = 0; i < boxes.Count; ++i)
            {
                if (!boxes[i].Contains(lp)) continue;
                onLinkClick?.Invoke(info.name);
                return;
            }
        }
    }
    #endregion

    #region 生成超链接
    /// <summary>
    /// 重新渲染网格
    /// </summary>
    public override void SetVerticesDirty()
    {
        base.SetVerticesDirty();
        m_OutputText = GetOutputText(text);
    }

    /// <summary>
    /// 处理Text顶点数据
    /// </summary>
    /// <param name="toFill"></param>
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        var orignText = m_Text;
        m_Text = m_OutputText;
        base.OnPopulateMesh(toFill);
        m_Text = orignText;
        UIVertex vert = new UIVertex();

        // 处理超链接包围框
        foreach (var hrefInfo in _mLinkInfos)
        {
            hrefInfo.boxes.Clear();
            if (hrefInfo.startIndex >= toFill.currentVertCount)
            {
                continue;
            }
            // 将超链接里面的文本顶点索引坐标加入到包围框
            toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
            var pos = vert.position;
            var bounds = new Bounds(pos, Vector3.zero);
            for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i++)
            {
                if (i >= toFill.currentVertCount)
                {
                    break;
                }
                toFill.PopulateUIVertex(ref vert, i);
                pos = vert.position;
                if (pos.x < bounds.min.x) // 换行重新添加包围框
                {
                    hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                    bounds = new Bounds(pos, Vector3.zero);
                }
                else
                {
                    bounds.Encapsulate(pos); // 扩展包围框

                }
            }
            hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
        }
    }

    /// <summary>
    /// 获取超链接解析后的最后输出文本
    /// </summary>
    /// <returns></returns>
    protected virtual string GetOutputText(string outputText)
    {
        s_TextBuilder.Length = 0;
        _mLinkInfos.Clear();
        var indexText = 0;
        foreach (Match match in s_HrefRegex.Matches(outputText))
        {
            s_TextBuilder.Append(outputText.Substring(indexText, match.Index - indexText));

            string str = s_TextBuilder.ToString();
            char[] array = str.ToCharArray();                //把字符串转化成字符数组
            IEnumerator enumerator = array.GetEnumerator();         //得到枚举器
            StringBuilder stringBuilder = new StringBuilder();
            while (enumerator.MoveNext())                         //开始枚举
            {
                if ((char)enumerator.Current != ' ')         //向StringBuilder类对象添加非空格字符
                    stringBuilder.Append(enumerator.Current.ToString());
            }

            var group = match.Groups[1];
            var hrefInfo = new HyperlinkInfo
            {
                startIndex = stringBuilder.Length * 4, // 超链接里的文本起始顶点索引
                endIndex = (stringBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
                name = group.Value
            };

            _mLinkInfos.Add(hrefInfo);
            s_TextBuilder.Append("<color=blue>");  // 超链接颜色
            s_TextBuilder.Append(match.Groups[2].Value);
            s_TextBuilder.Append("</color>");
            indexText = match.Index + match.Length;
        }
        s_TextBuilder.Append(outputText.Substring(indexText, outputText.Length - indexText));
        return s_TextBuilder.ToString();
    }
    #endregion
}