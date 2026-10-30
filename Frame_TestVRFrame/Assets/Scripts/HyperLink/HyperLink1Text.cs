using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Text拓展
/// </summary>
[ExecuteInEditMode]
public class HyperLink1Text : Text, IPointerClickHandler
{

    /// <summary>
    /// 正则表达式MOI
    /// </summary>
    private static readonly string m_RegexTag = @"\<([0-9A-Za-z]+)=(.+?)(#(.+?))?((\|[0-9]+){0,2})(##(.+?))?(#color((\|[0-9A-Za-z]+){0,2}))?\/>";
    private static readonly Regex m_Regex = new Regex(m_RegexTag, RegexOptions.Singleline);
    /// <summary>
    /// 文本转换
    /// </summary>
    private static readonly StringBuilder m_TextBuilder = new StringBuilder();
    /// <summary>
    /// 顶点列表
    /// </summary>
    private readonly UIVertex[] m_TempVerts = new UIVertex[4];
    /// <summary>
    /// 输出文本
    /// </summary>
    private string m_OutputText;

    private bool m_IsHaveGap;

    #region 超链接

    /// <summary>
    /// 是否存在超链接
    /// </summary>
    [SerializeField] protected bool isHaveHref = false;

    /// <summary>
    /// 超链接数据
    /// </summary>
    private readonly List<HrefInfo> m_HrefInfos = new List<HrefInfo>();

    /// <summary>
    /// 超链接点击事件
    /// </summary>
    [Serializable] public class HrefClickEvent : UnityEvent<string, string, string> { }
    /// <summary>
    /// 超链接事件
    /// </summary>
    public HrefClickEvent onHrefClick = new HrefClickEvent();

    private LineInfo m_HrefLineInfo = null;

    /// <summary>
    /// 线偏移位置
    /// </summary>
    public float m_HrefLineOffset = 1f;
    /// <summary>
    /// 线宽度
    /// </summary>
    public float m_HrefLineHeight = 4f;
    /// <summary>
    /// 单线长度
    /// </summary>
    public float m_HrefLineLength = 10f;
    /// <summary>
    /// 虚线比例
    /// </summary> 
    [Range(0.1f, 1.2f)]
    public float m_HrefLineRario = 1f;
    #endregion

    /// <summary>
    /// 文本宽度
    /// </summary>
    public override float preferredWidth
    {
        get
        {
            var settings = GetGenerationSettings(Vector2.zero);
            float width = cachedTextGeneratorForLayout.GetPreferredWidth(m_OutputText, settings) / pixelsPerUnit;
            ContentSizeFitter fitter = GetComponent<ContentSizeFitter>();
            bool horizontalFit = fitter != null && fitter.horizontalFit == ContentSizeFitter.FitMode.PreferredSize;
            return horizontalFit ? width : width < rectTransform.sizeDelta.x || horizontalOverflow == HorizontalWrapMode.Overflow ? width : rectTransform.sizeDelta.x;
        }
    }
    /// <summary>
    /// 文本高度
    /// </summary>
    public override float preferredHeight
    {
        get
        {
            var settings = GetGenerationSettings(new Vector2(rectTransform.rect.size.x, 0.0f));
            float height = cachedTextGeneratorForLayout.GetPreferredHeight(m_OutputText, settings) / pixelsPerUnit;
            ContentSizeFitter fitter = GetComponent<ContentSizeFitter>();
            bool verticalFit = fitter != null && fitter.verticalFit == ContentSizeFitter.FitMode.PreferredSize;
            return verticalFit ? height : height < rectTransform.sizeDelta.y || verticalOverflow == VerticalWrapMode.Overflow ? height : rectTransform.sizeDelta.y;
        }
    }

    /// <summary>
    /// 字符宽度
    /// </summary>
    public float CharWidth { get; private set; }
    /// <summary>
    /// 字符高度
    /// </summary>
    public float CharHeight { get; private set; }

    /// <summary>
    /// 线长度
    /// </summary>
    private float currentLineLength = 0;

    public override string text
    {
        get
        {
            return base.text;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(m_Text))
                    return;
                m_Text = string.Empty;
#if !UNITY_EDITOR
                    m_OutputText = GetOutputText();
#endif
                SetVerticesDirty();
            }
            else if (m_Text != value)
            {
                base.text = value;
#if !UNITY_EDITOR
                    m_OutputText = GetOutputText();
#endif
                SetVerticesDirty();
                SetLayoutDirty();
            }
        }
    }

    #region 内部方法
    protected override void Awake()
    {
        InitInfo();

#if !UNITY_EDITOR
        m_OutputText = GetOutputText();
#endif
        Invoke("SetVerticesDirty", 0.2f);
        base.Awake();
    }

    protected override void OnEnable()
    {
        supportRichText = true;
        base.OnEnable();
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        InitInfo();
        SetVerticesDirty();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
#endif

    public override void SetVerticesDirty()
    {
#if UNITY_EDITOR
        m_OutputText = GetOutputText();
#endif
        base.SetVerticesDirty();
    }

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        if (font == null)
            return;

        // We don't care if we the font Texture changes while we are doing our Update.
        // The end result of cachedTextGenerator will be valid for this instance.
        // Otherwise we can get issues like Case 619238.
        m_DisableFontTextureRebuiltCallback = true;

        Vector2 extents = rectTransform.rect.size;
        var settings = GetGenerationSettings(extents);
        cachedTextGenerator.Populate(m_OutputText, settings);

        // Apply the offset to the vertices
        IList<UIVertex> verts = cachedTextGenerator.verts;
        float unitsPerPixel = 1 / pixelsPerUnit;
        //Last 4 verts are always a new line... (\n) 空格不进行顶点计算
        //int vertCount = verts.Count - 4;
        int vertCount = verts.Count;
        // We have no verts to process just return (case 1037923)
        if (vertCount <= 0)
        {
            toFill.Clear();
            return;
        }

        Vector2 roundingOffset = new Vector2(verts[0].position.x, verts[0].position.y) * unitsPerPixel;
        roundingOffset = PixelAdjustPoint(roundingOffset) - roundingOffset;
        toFill.Clear();

        List<Vector3> _vertsPosList = new List<Vector3>();
        if (roundingOffset != Vector2.zero)
        {
            for (int i = 0; i < vertCount; ++i)
            {
                int tempVertsIndex = i & 3;
                m_TempVerts[tempVertsIndex] = verts[i];
                m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                m_TempVerts[tempVertsIndex].position.x += roundingOffset.x;
                m_TempVerts[tempVertsIndex].position.y += roundingOffset.y;
                if (tempVertsIndex == 3)
                    toFill.AddUIVertexQuad(m_TempVerts);
                _vertsPosList.Add(m_TempVerts[tempVertsIndex].position);
            }
        }
        else
        {
            for (int i = 0; i < vertCount; ++i)
            {
                int tempVertsIndex = i & 3;
                m_TempVerts[tempVertsIndex] = verts[i];
                m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                if (tempVertsIndex == 3)
                    toFill.AddUIVertexQuad(m_TempVerts);
                _vertsPosList.Add(m_TempVerts[tempVertsIndex].position);
            }
        }

        CalculateBoundBoxInfo(_vertsPosList, m_HrefInfos);
        DrawUnderLine(toFill, settings, m_HrefInfos, m_HrefLineInfo);

        m_DisableFontTextureRebuiltCallback = false;
    }

    /// <summary>
    /// 初始化数据信息
    /// </summary>
    private void InitInfo()
    {
        m_HrefLineInfo = new LineInfo()
        {
            m_LineOffset = m_HrefLineOffset,
            m_LineHeight = m_HrefLineHeight,
            m_SingleLineLength = m_HrefLineLength,
            m_BrokenLineRario = m_HrefLineRario,
            m_SingleLineRatio = 1.2f,
            m_LineRatio = 0.1f,
            m_OffsetRatio = 0f,
        };
    }

    protected string GetOutputText()
    {

        #region 初始化数据

        m_HrefInfos.Clear();
        isHaveHref = false;

        m_TextBuilder.Length = 0;
        var unMatchIndex = 0;

        #endregion

        if (string.IsNullOrEmpty(text))
            return string.Empty;

        string inputText = text;

        Vector2 extents = rectTransform.rect.size;
        TextGenerationSettings settings = GetGenerationSettings(extents);

        CharWidth = cachedTextGeneratorForLayout.GetPreferredWidth(inputText, settings) / this.pixelsPerUnit;
        if (cachedTextGeneratorForLayout.GetCharactersArray().Length > 0)
            CharWidth = cachedTextGeneratorForLayout.GetCharactersArray()[0].charWidth;

        CharHeight = cachedTextGeneratorForLayout.GetPreferredHeight(inputText, settings) / this.pixelsPerUnit;
        if (cachedTextGeneratorForLayout.GetLinesArray().Length > 0)
            CharHeight = cachedTextGeneratorForLayout.GetLinesArray()[0].height;

        int startIndex = 0;
        int tempIndex = 0;
        int endIndex = 0;
        foreach (Match match in m_Regex.Matches(inputText))
        {

            #region 解析数据

            var _type = match.Groups[1].Value;
            MatchType _matchType = MatchType.none;
            if (Enum.IsDefined(typeof(MatchType), _type))
                _matchType = (MatchType)Enum.Parse(typeof(MatchType), _type);
            else
                _matchType = MatchType.none;

            var _id = match.Groups[2].Value;

            string _name = string.Empty;
            if (match.Groups[4].Success)
                _name = match.Groups[4].Value;
            else
                _name = string.Empty;

            float width = 0f;
            float height = 0f;
            if (match.Groups[5].Success)
            {
                string _size = match.Groups[5].Value;
                string[] _sizes = _size.Split('|');
                width = _sizes.Length > 1 ? float.Parse(_sizes[1]) : CharHeight;
                height = _sizes.Length == 3 ? float.Parse(_sizes[2]) : width;
            }
            else
            {
                width = CharHeight;
                height = CharHeight;
            }

            string _content = string.Empty;
            if (match.Groups[4].Success)
                _content = match.Groups[8].Value;
            else
                _content = string.Empty;

            string _color1 = string.Empty;
            string _color2 = string.Empty;
            if (match.Groups[10].Success)
            {
                string _color = match.Groups[10].Value;
                string[] _colors = _color.Split('|');
                _color1 = _colors.Length > 1 ? _colors[1] : string.Empty;
                _color2 = _colors.Length == 3 ? _colors[2] : string.Empty;
            }
            else
            {
                _color1 = string.Empty;
                _color2 = string.Empty;
            }

            #endregion

            isHaveHref = true;
            Color _contentColor = GetColor(_color1, Color.blue);
            Color _lineColor = GetColor(_color1, Color.blue);
            string color1 = GetColor(_contentColor);

            string unMatchContent = inputText.Substring(unMatchIndex, match.Index - unMatchIndex);
            m_TextBuilder.Append(unMatchContent);
            int space = GetSpaceCount(unMatchContent);
            startIndex = (m_TextBuilder.Length - space) * 4 - tempIndex + endIndex;
            if (_id.Contains("S"))
            {
                m_TextBuilder.Append("<color=#");
                m_TextBuilder.Append(color1);
                m_TextBuilder.Append(">[</color>");
            }
            else if (_id.Contains("s"))
            {
                m_TextBuilder.Append("<color=#");
                m_TextBuilder.Append(color1);
                m_TextBuilder.Append(">(</color>");
            }

            m_TextBuilder.Append("<color=#");
            m_TextBuilder.Append(color1);
            m_TextBuilder.Append(">");
            tempIndex = m_TextBuilder.Length * 4;
            m_TextBuilder.Append(_content);
            space = GetSpaceCount(_content);
            endIndex = (m_TextBuilder.Length - space) * 4 - tempIndex + startIndex;
            m_TextBuilder.Append("</color>");

            if (_id.Contains("S"))
            {
                m_TextBuilder.Append("<color=#");
                m_TextBuilder.Append(color1);
                m_TextBuilder.Append(">]</color>");
            }
            else if (_id.Contains("s"))
            {
                m_TextBuilder.Append("<color=#");
                m_TextBuilder.Append(color1);
                m_TextBuilder.Append(">)</color>");
            }

            tempIndex = m_TextBuilder.Length * 4;

            var href = new HrefInfo()
            {
                id = _id,
                startIndex = startIndex,
                endIndex = endIndex,
                name = _name,
                color = _lineColor,
                url = _content,
            };
            m_HrefInfos.Add(href);

            unMatchIndex = match.Index + match.Length;
        }

        m_TextBuilder.Append(inputText.Substring(unMatchIndex, inputText.Length - unMatchIndex));
        return m_TextBuilder.ToString();
    }

    /// <summary>
    /// 计算包围框数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vertsPosList"></param>
    /// <param name="boxInfo"></param>
    private void CalculateBoundBoxInfo<T>(List<Vector3> vertsPosList, List<T> boxInfo)
      where T : BoxInfo
    {
        foreach (var boundInfo in boxInfo)
        {
            boundInfo.boxes.Clear();
            Debug.LogError(boundInfo.startIndex + "  " + vertsPosList.Count);
            if (boundInfo.startIndex >= vertsPosList.Count)
                continue;

            // 将文本顶点索引坐标加入到包围框  
            var pos = vertsPosList[boundInfo.startIndex];
            var bounds = new Bounds(pos, Vector3.zero);

            for (int i = boundInfo.startIndex, m = boundInfo.endIndex; i < m; i++)
            {
                if (i >= vertsPosList.Count)
                    break;
                pos = vertsPosList[i];
                if ((i - 1) >= 0 && pos.x < vertsPosList[i - 1].x && pos.y < vertsPosList[i - 1].y)
                {
                    // 换行重新添加包围框
                    boundInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                    bounds = new Bounds(pos, Vector3.zero);
                }
                else
                {
                    bounds.Encapsulate(pos); // 扩展包围框
                }
            }
            //添加包围框
            boundInfo.boxes.Add(new Rect(bounds.min, bounds.size));
        }
    }

    /// <summary>
    /// 画线- 多条线 实线-虚线
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="toFill"></param>
    /// <param name="settings"></param>
    /// <param name="boxInfo"></param>
    /// <param name="info"></param>
    private void DrawUnderLine<T>(VertexHelper toFill, TextGenerationSettings settings, List<T> boxInfo, LineInfo info)
      where T : BoxInfo
    {
        if (boxInfo.Count <= 0)
            return;

        #region 添加下划线
        TextGenerator _lineTextGenerator = new TextGenerator();
        _lineTextGenerator.Populate("_", settings);
        IList<UIVertex> _verts = _lineTextGenerator.verts;

        #region 初始化线数据

        float _lineOffset = info.m_LineOffset;
        float _lineHeight = info.m_LineHeight;
        float _singleLineLength = info.m_SingleLineLength;
        float _brokenLineRario = info.m_BrokenLineRario;
        float _singleLineRatio = info.m_SingleLineRatio;
        float _lineRatio = info.m_LineRatio;
        float _offsetRatio = info.m_OffsetRatio;

        #endregion

        float singleRatio = _singleLineRatio;
        float offsetRatio = _offsetRatio;
        Vector3[] _ulPos = new Vector3[4];

        foreach (var item in boxInfo)
        {
            for (int i = 0; i < item.boxes.Count; i++)
            {
                currentLineLength = 0;
                float singleLength = _singleLineLength;

                int count = (int)Math.Ceiling(item.boxes[i].width / _singleLineLength);
                if (count == 1)
                    singleRatio = _singleLineRatio;
                else
                    singleRatio = _singleLineRatio + _lineRatio;

                for (int m = 0; m < count; m++)
                {
                    if (m == 0)
                        offsetRatio = _offsetRatio;
                    else
                        offsetRatio = (singleRatio - 1) / 2f;

                    if (m == count - 1)
                    {
                        if (item.boxes[i].width - m * _singleLineLength < _singleLineLength)
                        {
                            singleLength = item.boxes[i].width - m * _singleLineLength - 1.5f * singleRatio;
                        }
                    }

                    //Debug.Log("count   " + count + "  偏移率   " + offsetRatio + "  singleLength  " + singleLength + "singleLineLength   " + singleLineLength + " singleRatio  " + singleRatio+ "  currentLineLength " + currentLineLength);

                    //计算下划线的位置
                    Vector3 _pos = item.boxes[i].position + new Vector2(currentLineLength, 0.0f) + new Vector2(0, _lineOffset);
                    _ulPos[0] = _pos + new Vector3(-1 * singleLength * offsetRatio, 0.0f);
                    _ulPos[1] = _ulPos[0] + new Vector3(singleLength * singleRatio, 0.0f) * _brokenLineRario;
                    _ulPos[2] = _ulPos[0] + new Vector3(singleLength * singleRatio, 0.0f) * _brokenLineRario + new Vector3(0.0f, -_lineHeight);
                    _ulPos[3] = _ulPos[0] + new Vector3(0.0f, -_lineHeight);

                    currentLineLength += singleLength;

                    //绘制下划线
                    for (int j = 0; j < 4; j++)
                    {
                        m_TempVerts[j] = _verts[j];
                        m_TempVerts[j].color = item.color;
                        m_TempVerts[j].position = _ulPos[j];
                        if (j == 3)
                            toFill.AddUIVertexQuad(m_TempVerts);
                    }

                }

            }
        }

        _lineTextGenerator = null;
        #endregion
    }

    #endregion

    #region 点击事件相关

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!isHaveHref)
            return;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);

        foreach (var hrefInfo in m_HrefInfos)
        {
            var boxes = hrefInfo.boxes;
            for (var i = 0; i < boxes.Count; ++i)
            {
                if (boxes[i].Contains(localPoint))
                {
                    onHrefClick.Invoke(hrefInfo.id, hrefInfo.name, hrefInfo.url);
                    return;
                }
            }
        }
    }

    #endregion

    #region 辅助相关

    /// <summary>
    /// 获取颜色
    /// </summary>
    /// <param name="color">16进制字符/颜色</param>
    /// <param name="oldColor"></param>
    /// <returns></returns>
    private Color GetColor(string color, Color oldColor)
    {
        Color newColor = oldColor;
        if (!string.IsNullOrEmpty(color))
        {
            bool IsDefined = ColorUtility.TryParseHtmlString(color, out newColor);
            if (IsDefined == false)
            {
                IsDefined = ColorUtility.TryParseHtmlString("#" + color, out newColor);
            }
            if (!IsDefined)
                newColor = base.color;
        }
        return newColor;
    }
    /// <summary>
    /// 获取16进制颜色
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private string GetColor(Color color)
    {
        return ColorUtility.ToHtmlStringRGB(color);
    }

    /// <summary>
    /// 获取文本空格数据
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    private int GetSpaceCount(string content)
    {
        int count = 0;
        if (content.Contains(" "))
        {
            string[] spaces = content.Split(' ');
            count = spaces.Length - 1;
        }
        return count;
    }

    #endregion

    #region 信息类
    /// <summary>
    /// 匹配类型
    /// </summary>
    private enum MatchType
    {
        none,
        /// <summary>
        /// 填空
        /// </summary>
        gap,
        /// <summary>
        /// 超链接
        /// </summary>
        href,
        /// <summary>
        /// 图标
        /// </summary>
        icon,
        /// <summary>
        /// 线
        /// </summary>
        line,
    }

    /// <summary>
    /// 线类型
    /// </summary>
    protected enum LineType
    {
        /// <summary>
        /// 直线
        /// </summary>
        straight,
        /// <summary>
        /// 波浪线
        /// </summary>
        wavy,
    }

    /// <summary>
    /// 线信息类
    /// </summary>
    [Serializable]
    protected class LineInfo
    {
        /// <summary>
        /// 线垂直偏移位置
        /// </summary>
        public float m_LineOffset = 0f;
        /// <summary>
        /// 线宽度
        /// </summary>
        public float m_LineHeight = 4;
        /// <summary>
        /// 单线长度
        /// </summary>
        public float m_SingleLineLength = 20;
        /// <summary>
        /// 虚线比例
        /// </summary>
        [Range(0.1f, 1.2f)]
        public float m_BrokenLineRario = 1f;
        /// <summary>
        /// 单线比例
        /// </summary>
        public float m_SingleLineRatio = 1.2f;
        /// <summary>
        /// 单线修正比例
        /// </summary>
        public float m_LineRatio = 0.1f;
        /// <summary>
        /// 水平偏移比例
        /// </summary>
        public float m_OffsetRatio = 0.1f;

        /// <summary>
        /// 线类型
        /// </summary>
        protected LineType m_LineType = LineType.straight;
    }

    /// <summary>
    /// 超链接信息类
    /// </summary>
    private class HrefInfo : BoxInfo
    {
        public string url;
    }

    /// <summary>
    /// 边界信息类
    /// </summary>
    private class BoxInfo
    {
        public string id;

        public int startIndex;

        public int endIndex;

        public string name;

        public Color color;

        public readonly List<Rect> boxes = new List<Rect>();
    }
    #endregion

}
