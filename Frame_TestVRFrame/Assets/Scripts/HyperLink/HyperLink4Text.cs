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
/// TextHyperlink 支持Unity超链接富文本语法
/// 例如<a href=https://aws.amazon.com/privacy/>https://aws.amazon.com/privacy/</a>
/// 带颜色的超链接：
/// <a href=https://aws.amazon.com/privacy/><color=#FF0000>https://aws.amazon.com/privacy/</color></a>
/// </summary>
public class HyperLink4Text : Text, IPointerClickHandler
{
    /// <summary>
    /// 超链接信息类
    /// </summary>
    private class HyperlinkInfo
    {
        //起始Index
        public int StartIndex;
        //结束Index
        public int EndIndex;
        //内容
        public string Name;
        //包围框
        public List<Rect> BoxList = new List<Rect>();
        public List<int> linefeedIndexList = new List<int>();
    }
    //超链接正则
    private static Regex _hrefRegex = new Regex(@"<a href=([^>\n\s]+)>(.*?)(</a>)", RegexOptions.Singleline);
    //颜色正则
    private static Regex _colorRegex = new Regex(@"<color=([^>\n\s]+)>(.*?)(</color>)", RegexOptions.Singleline);
    //超链接信息列表
    private List<HyperlinkInfo> _hyperlinkInfoList = new List<HyperlinkInfo>();
    //显示包围盒范围，想用的话输入true
    private bool _showTestBound = true;

    /// <summary>
    /// 超链接文本颜色
    /// </summary>
    private static Color32 innerTextColor = new Color32(0, 0, 1, 1);

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        base.OnPopulateMesh(toFill);

        InitHyperlinkInfo();

        InitHyperlinkBox(toFill);
    }

    protected override void Start()
    {
        //这个代码要在InitHyperlinkInfo();执行后才能执行，如果包围盒显示不出来就需要注意一下时序对不对。
        if (_showTestBound)
        {
            AddVisibleBound();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);

        foreach (HyperlinkInfo hyperlinkInfo in _hyperlinkInfoList)
        {
            var boxeList = hyperlinkInfo.BoxList;
            for (var i = 0; i < boxeList.Count; ++i)
            {
                if (boxeList[i].Contains(localPoint))
                {
                    ShowName(hyperlinkInfo.Name);
                    return;
                }
            }
        }
    }

    private void ShowName(string info)
    {
        Debug.Log(info);
    }

    /// <summary>
    /// 初始化连接信息
    /// </summary>
    private void InitHyperlinkInfo()
    {
        //这个值不用,就是个存根。要的是执行后面那个方法
        string m_OutputText = GetOutputText(text);
    }

    /// <summary>
    /// 初始化连接包围框
    /// </summary>
    /// <param name="toFill"></param>
    private void InitHyperlinkBox(VertexHelper toFill)
    {
        UIVertex vert = new UIVertex();

        // 处理超链接包围框
        foreach (var hrefInfo in _hyperlinkInfoList)
        {
            hrefInfo.BoxList.Clear();
            hrefInfo.linefeedIndexList.Clear();

            //一个字符是四个顶点，所以Index要乘以4
            int startVertex = hrefInfo.StartIndex * 4;
            int endVertex = hrefInfo.EndIndex * 4;

            if (startVertex >= toFill.currentVertCount)
            {
                continue;
            }

            // 将超链接里面的文本顶点索引坐标加入到包围框
            toFill.PopulateUIVertex(ref vert, startVertex);
            var pos = vert.position;
            var bounds = new Bounds(pos, Vector3.zero);
            hrefInfo.linefeedIndexList.Add(hrefInfo.StartIndex);
            for (int i = startVertex; i < endVertex; i++)
            {
                if (i >= toFill.currentVertCount)
                {
                    break;
                }

                toFill.PopulateUIVertex(ref vert, i);
                pos = vert.position;
                if (pos.x < bounds.min.x) // 换行重新添加包围框
                {
                    hrefInfo.BoxList.Add(new Rect(bounds.min, bounds.size));
                    hrefInfo.linefeedIndexList.Add(i);
                    bounds = new Bounds(pos, Vector3.zero);
                }
                else
                {
                    bounds.Encapsulate(pos); // 扩展包围框
                }
            }

            hrefInfo.BoxList.Add(new Rect(bounds.min, bounds.size));
        }
    }

    /// <summary>
    /// 获取超链接解析后的最后输出文本
    /// </summary>
    /// <returns></returns>
    private string GetOutputText(string outputText)
    {
        StringBuilder stringBuilder = new StringBuilder();

        _hyperlinkInfoList.Clear();

        int strIndex = 0;

        foreach (Match match in _hrefRegex.Matches(outputText))
        {
            string appendStr = outputText.Substring(strIndex, match.Index - strIndex);
            stringBuilder.Append(appendStr);

            //空格和回车没有顶点渲染，所以要去掉
            stringBuilder = stringBuilder.Replace(" ", "");
            stringBuilder = stringBuilder.Replace("\n", "");

            int startIndex = stringBuilder.Length;

            //第一个是连接url,第二个是连接文本，跳转用url，计算index用文本
            Group urlGroup = match.Groups[1];
            Group titleGroup = match.Groups[2];

            //如果有Color语法嵌套，则还要继续扒，知道吧最终文本扒出来
            Match colorMatch = _colorRegex.Match(titleGroup.Value);

            if (colorMatch.Groups.Count > 3)
            {
                titleGroup = colorMatch.Groups[2];
            }

            stringBuilder.Append(titleGroup.Value);

            HyperlinkInfo hyperlinkInfo = new HyperlinkInfo
            {
                StartIndex = startIndex,
                EndIndex = (startIndex + titleGroup.Length),
                Name = urlGroup.Value
            };

            strIndex = match.Index + match.Length;
            _hyperlinkInfoList.Add(hyperlinkInfo);
        }
        stringBuilder.Append(outputText.Substring(strIndex, outputText.Length - strIndex));
        return stringBuilder.ToString();
    }

    /// <summary>
    /// 添加可视包围框（测试用方法）
    /// </summary>
    private void AddVisibleBound()
    {
        int index = 0;

        foreach (var hyperLinkInfo in _hyperlinkInfoList)
        {
            Color color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 0.2f);
            index++;
            foreach (Rect rect in hyperLinkInfo.BoxList)
            {
                GameObject gameObject = new GameObject();
                gameObject.name = string.Format("GOBoundBox[{0}]", hyperLinkInfo.Name);
                //gameObject.SetParent(this.gameObject);//替换成下面这个方法
                gameObject.transform.SetParent(this.gameObject.transform, false);

                RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
                rectTransform.sizeDelta = rect.size;
                rectTransform.localPosition = new Vector3(rect.position.x + rect.size.x / 2, rect.position.y + rect.size.y / 2, 0);

                Image image = gameObject.AddComponent<Image>();
                image.color = color;
                image.raycastTarget = false;
            }
        }
    }
}