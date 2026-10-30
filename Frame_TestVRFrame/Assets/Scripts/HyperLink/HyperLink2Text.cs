using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HyperLink2Text : Text, IPointerClickHandler
{
    public Action<string> onHyperlinkClick;

    /// <summary>
    /// 超链接信息类
    /// </summary>
    private class HyperlinkInfo
    {
        public int startIndex;

        public int endIndex;

        public string name;

        public readonly List<Rect> boxes = new List<Rect>();

        public List<int> linefeedIndexList = new List<int>();
    }

    /// <summary>
    /// 解析完最终的文本
    /// </summary>
    private string m_OutputText;

    /// <summary>
    /// 超链接信息列表
    /// </summary>
    private readonly List<HyperlinkInfo> m_HrefInfos = new List<HyperlinkInfo>();

    /// <summary>
    /// 文本构造器
    /// </summary>
    protected StringBuilder s_TextBuilder = new StringBuilder();

    /// <summary>
    /// 超链接文本颜色
    /// </summary>
    private static Color32 innerTextColor = new Color32(175, 87, 44, 255);

    //计算定点信息的缓存数组
    private readonly UIVertex[] m_TempVerts = new UIVertex[4];

    /// <summary>
    /// 超链接正则
    /// </summary>
    private static readonly Regex s_HrefRegex = new Regex(@"<href=([^>\n\s]+)>(.*?)(</href>)", RegexOptions.Singleline);


    public string GetHyperlinkInfo
    {
        get { return text; }
    }

    public override void SetVerticesDirty()
    {
        base.SetVerticesDirty();

        text = GetHyperlinkInfo;
        m_OutputText = GetOutputText(text);

    }


    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        var orignText = m_Text;
        m_Text = m_OutputText;
        base.OnPopulateMesh(toFill);
        m_Text = orignText;
        UIVertex vert = new UIVertex();

        // 处理超链接包围框
        foreach (var hrefInfo in m_HrefInfos)
        {
            hrefInfo.boxes.Clear();
            hrefInfo.linefeedIndexList.Clear();
            if (hrefInfo.startIndex >= toFill.currentVertCount)
            {
                continue;
            }

            // 将超链接里面的文本顶点索引坐标加入到包围框
            toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);

            var pos = vert.position;
            var bounds = new Bounds(pos, Vector3.zero);
            hrefInfo.linefeedIndexList.Add(hrefInfo.startIndex);
            for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i++)
            {
                if (i >= toFill.currentVertCount)
                {
                    break;
                }

                toFill.PopulateUIVertex(ref vert, i);
                vert.color = innerTextColor;
                toFill.SetUIVertex(vert, i);

                pos = vert.position;

                bool needEncapsulate = true;

                if (i > 4 && (i - hrefInfo.startIndex) % 4 == 0)
                {
                    UIVertex lastV = new UIVertex();
                    toFill.PopulateUIVertex(ref lastV, i - 4);
                    var lastPos = lastV.position;

                    if (pos.x < lastPos.x && pos.y < lastPos.y) // 换行重新添加包围框
                    {
                        hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                        hrefInfo.linefeedIndexList.Add(i);
                        bounds = new Bounds(pos, Vector3.zero);
                        needEncapsulate = false;
                    }
                }
                if (needEncapsulate)
                {
                    bounds.Encapsulate(pos); // 扩展包围框
                }
            }
            hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
        }

        //添加下划线
        //一行行的划 文本拉伸边缘渐变 不好看
        //Vector2 extents = rectTransform.rect.size;
        //var settings = GetGenerationSettings(extents);
        //TextGenerator underlineText = new TextGenerator();
        //underlineText.Populate("_", settings);
        //IList<UIVertex> tut = underlineText.verts;
        //foreach (var hrefInfo in m_HrefInfos)
        //{
        //    if (hrefInfo.startIndex >= toFill.currentVertCount)
        //    {
        //        continue;
        //    }

        //    for (int i = 0; i < hrefInfo.boxes.Count; i++)
        //    {
        //        //计算下划线的位置
        //        Vector3[] ulPos = new Vector3[4];
        //        ulPos[0] = hrefInfo.boxes[i].position + new Vector2(0, fontSize * 0.2f);
        //        ulPos[1] = ulPos[0] + new Vector3(hrefInfo.boxes[i].width, 0.0f);
        //        ulPos[2] = hrefInfo.boxes[i].position + new Vector2(hrefInfo.boxes[i].width, 0f);
        //        ulPos[3] = hrefInfo.boxes[i].position;

        //        //绘制下划线
        //        for (int j = 0; j < 4; j++)
        //        {
        //            m_TempVerts[j] = tut[j];
        //            m_TempVerts[j].color = new Color(104, 86, 80, 255);
        //            m_TempVerts[j].position = ulPos[j];
        //        }
        //        toFill.AddUIVertexQuad(m_TempVerts);
        //    }
        //}

        //一个字一个字的划 效率差 而且字与字之间容易有接缝
        DrawUnderLine(toFill);
    }

    private void DrawUnderLine(VertexHelper vh)
    {
        UIVertex vert = new UIVertex();
        List<Vector3> startPosList = new List<Vector3>();
        List<Vector3> endPosList = new List<Vector3>();
        foreach (var hrefInfo in m_HrefInfos)
        {
            if (hrefInfo.startIndex >= vh.currentVertCount)
            {
                continue;
            }

            float minY = float.MaxValue;
            for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i += 4)
            {
                if (i >= vh.currentVertCount)
                {
                    break;
                }

                if (hrefInfo.linefeedIndexList.Contains(i))
                {
                    for (int j = 0; j < startPosList.Count; j++)
                    {
                        MeshUnderLine(vh, new Vector2(startPosList[j].x, minY), new Vector2(endPosList[j].x, minY));
                    }
                    startPosList.Clear();
                    endPosList.Clear();
                }

                vh.PopulateUIVertex(ref vert, i + 3);
                startPosList.Add(vert.position);
                vh.PopulateUIVertex(ref vert, i + 2);
                endPosList.Add(vert.position);

                if (vert.position.y < minY)
                {
                    minY = vert.position.y;
                }
            }

            for (int j = 0; j < startPosList.Count; j++)
            {
                MeshUnderLine(vh, new Vector2(startPosList[j].x, minY), new Vector2(endPosList[j].x, minY));
            }
            startPosList.Clear();
            endPosList.Clear();

        }
    }

    private void MeshUnderLine(VertexHelper vh, Vector2 startPos, Vector2 endPos)
    {
        Vector2 extents = rectTransform.rect.size;
        var setting = GetGenerationSettings(extents);

        TextGenerator underlineText = new TextGenerator();
        underlineText.Populate("—", setting);

        IList<UIVertex> lineVer = underlineText.verts;/*new UIVertex[4];*///"_"的的顶点数组

        Vector3[] pos = new Vector3[4];
        pos[0] = startPos + new Vector2(-1f, 0);
        pos[3] = startPos + new Vector2(-1f, 4f);
        pos[2] = endPos + new Vector2(1f, 4f);
        pos[1] = endPos + new Vector2(1f, 0);


        UIVertex[] tempVerts = new UIVertex[4];
        for (int i = 0; i < 4; i++)
        {
            tempVerts[i] = lineVer[i];
            tempVerts[i].color = innerTextColor;
            tempVerts[i].position = pos[i];
        }

        vh.AddUIVertexQuad(tempVerts);
    }

    /// <summary>
    /// 获取超链接解析后的最后输出文本
    /// </summary>
    /// <returns></returns>
    protected virtual string GetOutputText(string outputText)
    {
        s_TextBuilder.Length = 0;
        m_HrefInfos.Clear();
        var indexText = 0;
        int count = 0;
        foreach (Match match in s_HrefRegex.Matches(outputText))
        {
            string appendStr = outputText.Substring(indexText, match.Index - indexText);

            s_TextBuilder.Append(appendStr);

            //空格和回车没有顶点渲染，所以要去掉
            //s_TextBuilder = s_TextBuilder.Replace(" ", "");
            //s_TextBuilder = s_TextBuilder.Replace("\n", "");
            count += appendStr.Length - appendStr.Replace(" ", "").Replace("\n", "").Length;
            int startIndex = (s_TextBuilder.Length - count) * 4;
            var group = match.Groups[1];
            var hrefInfo = new HyperlinkInfo
            {
                startIndex = startIndex, // 超链接里的文本起始顶点索引
                endIndex = startIndex + (match.Groups[2].Length * 4),
                //endIndex = (s_TextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
                name = group.Value
            };
            m_HrefInfos.Add(hrefInfo);

            s_TextBuilder.Append(match.Groups[2].Value);
            indexText = match.Index + match.Length;
        }
        s_TextBuilder.Append(outputText.Substring(indexText, outputText.Length - indexText));
        return s_TextBuilder.ToString();
    }

    /// <summary>
    /// 点击事件检测是否点击到超链接文本
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 lp = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out lp);

        foreach (var hrefInfo in m_HrefInfos)
        {
            var boxes = hrefInfo.boxes;
            for (var i = 0; i < boxes.Count; ++i)
            {
                if (boxes[i].Contains(lp))
                {
                    ShowName(hrefInfo.name);
                    return;
                }
            }
        }
    }

    private void ShowName(string info)
    {
        Debug.Log(info);
    }
}