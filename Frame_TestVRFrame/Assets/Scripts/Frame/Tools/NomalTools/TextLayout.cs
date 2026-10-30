/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: CanvasLogic.cs
  Author:张辰       Version :1.0.4 Beta       Date: 2018-3-12
  Description:Text内容中英文混排智能排版
  传入字符串到TextLayout.Text会自动排版到Text.text;
  反之从TextLayout.Text获取原始字符串。
  暂不支持富文本 Ps：以后也不支持
  1.0.3 Beta新增
  修复了粗体斜体不能排版的问题
  新增了括号判断格式
  1.0.4 Beta新增
  添加了左括号+空格+右括号结尾的格式判断
************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;


[RequireComponent(typeof(Text))]
public class TextLayout : MonoBehaviour
{
    private TextLayout() { }
    private Text targetText;
    private float targetWidth = 0;
    [TextArea(3, 10)]
    [SerializeField]
    private string text = string.Empty;
    /// <summary>
    /// 需要排版的文本
    /// </summary>
    public string Text {
        get { return text; }
        set {
            if (string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(text))
                    return;
                text = "";
            }
            else if (text != value)
            {
                text = value;
                targetText.text = ChAndEnTextLayout(text);
            }
        }
    }
    private void Awake()
    {
        targetText = transform.GetComponent<Text>();
        targetText.horizontalOverflow = HorizontalWrapMode.Overflow;
        targetWidth = transform.GetComponent<RectTransform>().rect.size.x;
        if (!string.IsNullOrEmpty(text)) {
            targetText.text = ChAndEnTextLayout(text);
        }
    }

    /// <summary>
    /// 中英文文本混排
    /// </summary>
    /// <param name="targetWidth">文本框宽度</param>
    /// <param name="message">文本</param>
    private string ChAndEnTextLayout(string message)
    {
        StringBuilder outPutSB = new StringBuilder();
        int totalLength = 0;
        int start = 0;
        int offset = 0;
        Font tmpFont = targetText.font; 
        tmpFont.RequestCharactersInTexture(message, targetText.fontSize, FontStyle.Normal);
        CharacterInfo characterInfo = new CharacterInfo();
        for (; offset < message.Length; offset++)
        {
            tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
            totalLength += characterInfo.advance;
            if (totalLength < targetWidth)
            {
                if (message[offset] == '\n') //文本有换行符
                {
                    outPutSB.Append(message.Substring(start, offset + 1 - start));
                    totalLength = 0;
                    start = offset + 1;
                    continue;
                }
            }
            else
            {
                totalLength = 0;
                #region 中文结尾
                if (CharIs(message[offset - 1], @"^[\u4e00-\u9fa5]+$"))//末尾是中文
                {
                    //Debug.Log("中文结尾");
                    //outPutSB.Append(message.Substring(start,offset - start));
                    if (CharIs(message[offset], @"^[\u4e00-\u9fa5a-zA-Z0-9(（]+$")) //换行后的第一位如果是中文或英文或数字
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        LineEnd(ref outPutSB);
                        start = offset;
                        tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                    }
                    else if (CharIs(message[offset], @"^[)）]+$"))
                    {
                        //outPutSB.Append(message[offset]);
                        if (offset + 1 > message.Length)
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            outPutSB.Append(message[offset]);
                            if (CharIs(message[offset + 1], @"^[\u4e00-\u9fa5a-zA-Z0-9(（]+$")) //换行后的第一位如果是中文或英文或数字或前括号
                            {
                                start = offset + 1;
                            }
                            else
                            {
                                start = offset + 2;
                            }
                            LineEnd(ref outPutSB);
                        }
                        
                    }
                    else
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        outPutSB.Append(message[offset]);
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                    }
                    continue;
                }
                #endregion
                #region 不完整英文结尾
                else if (CharIs(message[offset - 1], @"^[a-zμA-Z/]+$") && CharIs(message[offset], @"^[a-zA-Z0-9/\-]+$"))//末尾是不完整英文
                {
                    //Debug.Log("不完整英文结尾");
                    if (message[offset + 1] == ' ')//如果卡行的字母后面是空格或中文，勉强放进去下一个再换行
                    {
                        outPutSB.Append(message.Substring(start, offset + 1 - start));
                        LineEnd(ref outPutSB);
                        tmpFont.GetCharacterInfo(message[offset + 1], out characterInfo, targetText.fontSize);
                        totalLength -= characterInfo.advance;
                        start = offset + 2;
                        continue;
                    }
                    else if (CharIs(message[offset + 1], @"^[\u4e00-\u9fa5]+$"))
                    {
                        outPutSB.Append(message.Substring(start, offset + 1 - start));
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                        continue;
                    }
                    for (int j = offset - 1; j >= start; j--)
                    {
                        if (CharIs(message[j], @"^[\u4e00-\u9fa5'。，、,?!？！ …:;)）]+$"))//反向遍历到第一个中文或符号
                        {
                            outPutSB.Append(message.Substring(start, j + 1 - start));
                            LineEnd(ref outPutSB);
                            start = j + 1;
                            for (int k = j + 1; k <= offset; k++)
                            {
                                tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                totalLength += characterInfo.advance;
                            }
                            j = -1;
                        }
                        else if (CharIs(message[j], @"^[(（]+$")) //反向遍历到第一个正括号在正括号前换行
                        {
                            outPutSB.Append(message.Substring(start, j - start));
                            LineEnd(ref outPutSB);
                            start = j;
                            for (int k = j; k <= offset; k++)
                            {
                                tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                totalLength += characterInfo.advance;
                            }
                            j = -1;
                        }
                        else if(j == start) //一整行装不下一个完整单词
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            LineEnd(ref outPutSB);
                            start = offset;
                            tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                            totalLength += characterInfo.advance;
                        }
                    }
                    continue;
                }
                #endregion
                #region 完整英文结尾
                else if (CharIs(message[offset - 1], @"^[a-zA-Z]+$") && !CharIs(message[offset], @"^[a-zA-Z]+$")) //末尾是整好的单词
                {
                    //Debug.Log("完整英文结尾");
                    outPutSB.Append(message.Substring(start,offset - start));
                    if (CharIs(message[offset], @"^[\u4e00-\u9fa5a-zA-Z0-9(（]+$") ) //换行后的第一位如果是中文或英文或数字
                    {
                        LineEnd(ref outPutSB);
                        start = offset;
                        tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                    }
                    else if (CharIs(message[offset], @"^[）)]+$"))//换行后是后括号，要留在上一行最后
                    {
                        outPutSB.Append(message[offset]);
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                    }
                    else //其他情况，舍弃字符
                    {
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                    }
                    continue;
                }
                #endregion
                #region 结尾是数字
                else if (CharIs(message[offset - 1], @"^[0-9]+$"))//末尾是数字
                {
                    //Debug.Log("结尾是数字");
                    if (message[offset] == ' ')
                    {
                        outPutSB.Append(message.Substring(start, offset  - start));
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                        continue;
                    }
                    else if (CharIs(message[offset], @"^[\u4e00-\u9fa5]+$"))
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        LineEnd(ref outPutSB);
                        tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                        start = offset;
                        continue;
                    }
                    if (message[offset + 1] == ' ')//如果卡行的数字后面是空格或中文，勉强放进去下一个再换行
                    {
                        outPutSB.Append(message.Substring(start, offset + 1 - start));
                        LineEnd(ref outPutSB);
                        tmpFont.GetCharacterInfo(message[offset + 1], out characterInfo, targetText.fontSize);
                        totalLength -= characterInfo.advance;
                        start = offset + 2;
                        continue;
                    }
                    else if (CharIs(message[offset + 1], @"^[\u4e00-\u9fa5]+$"))
                    {
                        outPutSB.Append(message.Substring(start, offset + 1 - start));
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                        continue;
                    }
                    for (int j = offset - 1; j >= start; j--)
                    {
                        if (CharIs(message[j], @"^[\u4e00-\u9fa5'。，、,?!？！ …;)）]+$")) //反向遍历到中文或空格
                        {
                            if (message[j] == ' ') //有空格区分数字
                            {
                                outPutSB.Append(message.Substring(start, j - start));
                                LineEnd(ref outPutSB);
                                start = j + 1;
                                for (int k = j + 1; k <= offset; k++)
                                {
                                    tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                    totalLength += characterInfo.advance;
                                }
                                j = -1;
                            }
                            else //无空格区分数字
                            {
                                outPutSB.Append(message.Substring(start, j + 1 - start));
                                LineEnd(ref outPutSB);
                                start = j + 1;
                                for (int k = j + 1; k <= offset; k++)
                                {
                                    tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                    totalLength += characterInfo.advance;
                                }
                                j = -1;
                            }
                        }
                        else if (CharIs(message[j], @"^[(（]+$")) //反向遍历到第一个正括号在正括号前换行
                        {
                            outPutSB.Append(message.Substring(start, j - start));
                            LineEnd(ref outPutSB);
                            start = j;
                            for (int k = j; k <= offset; k++)
                            {
                                tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                totalLength += characterInfo.advance;
                            }
                            j = -1;
                        }
                        else if(j == start) //一整行装不下一个完整数字
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            LineEnd(ref outPutSB);
                            start = offset;
                            tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                            totalLength += characterInfo.advance;
                        }
                    }
                    continue;
                }
                #endregion
                #region 空格结尾
                else if (message[offset - 1] == ' ') //末尾是空格
                {
                    //Debug.Log("空格结尾");
                    //outPutSB.Append(message.Substring(start, offset - start));
                    //LineEnd(ref outPutSB);
                    if (CharIs(message[offset], @"^[\u4e00-\u9fa5a-zA-Z0-9]+$")) //换行后的第一位如果是中文或英文
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        LineEnd(ref outPutSB);
                        start = offset;
                        tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                    }
                    //**
                    else if (CharIs(message[offset], @"^[)）]+$"))//换行后的第一位如果是后括号,要留在上一行
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        outPutSB.Append(message[offset]);
                        LineEnd(ref outPutSB);
                        if (CharIs(message[offset + 1], @"^[\u4e00-\u9fa5a-zA-Z0-9（(]+$")) //换行后的第一位如果是中文或英文或数字或前括号
                        {
                            start = offset + 1;
                        }
                        else
                        {
                            start = offset + 2;
                        }
                    }
                    //**
                    else
                    {
                        outPutSB.Append(message.Substring(start, offset - start));
                        LineEnd(ref outPutSB);
                        start = offset + 1;
                    }
                    continue;
                }
                #endregion
                #region 数字间的英文.:结尾
                else if (CharIs(message[offset - 1], @"^[.:：]+$") && CharIs(message[offset], @"^[0-9]+$" )&& CharIs(message[offset - 2], @"^[0-9]+$"))
                {
                    //Debug.Log("数字间的英文.:结尾");
                    for (int j = offset - 2; j >= start; j--)
                    {
                        if (CharIs(message[j], @"^[\u4e00-\u9fa5'。，.,?!？！ …;]+$"))//反向遍历到第一个中文或符号
                        {
                            outPutSB.Append(message.Substring(start, j + 1 - start));
                            LineEnd(ref outPutSB);
                            start = j + 1;
                            for (int k = j + 1; k <= offset; k++)
                            {
                                tmpFont.GetCharacterInfo(message[k], out characterInfo, targetText.fontSize);
                                totalLength += characterInfo.advance;
                            }
                            j = -1;
                        }
                        if (j == start) //一整行装不下一个完整数字
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            LineEnd(ref outPutSB);
                            start = offset;
                            tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                            totalLength += characterInfo.advance;
                        }
                    }
                    continue;
                }
                #endregion
                #region 符号结尾或其他东西结尾
                else //末尾是符号或其他东西 Ps:结尾是offset-1
                {
                    //Debug.Log("符号结尾或其他东西结尾");
                    if (CharIs(message[offset - 1], @"^[(（]+$"))
                    {
                        outPutSB.Append(message.Substring(start, offset - 1 - start));
                        LineEnd(ref outPutSB);
                        start = offset - 1;
                        tmpFont.GetCharacterInfo(message[offset - 1], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                        tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                        totalLength += characterInfo.advance;
                    } 
                    else
                    {
                        if (CharIs(message[offset], @"^[\u4e00-\u9fa5a-zA-Z0-9（(]+$")) //换行后的第一位如果是中文或英文或数字或前括号
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            LineEnd(ref outPutSB);
                            start = offset;
                            tmpFont.GetCharacterInfo(message[offset], out characterInfo, targetText.fontSize);
                            totalLength += characterInfo.advance;
                        }
                        else if (CharIs(message[offset], @"^[)）]+$"))//后括号要留在这一个行
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            outPutSB.Append(message[offset]);
                            LineEnd(ref outPutSB);
                            if (CharIs(message[offset + 1], @"^[\u4e00-\u9fa5a-zA-Z0-9（(]+$")) //换行后的第一位如果是中文或英文或数字或前括号
                            {
                                start = offset + 1;
                            }
                            else
                            {
                                start = offset + 2;
                            }
                        }
                        else
                        {
                            outPutSB.Append(message.Substring(start, offset - start));
                            LineEnd(ref outPutSB);
                            start = offset + 1;
                        }
                    }
                    continue;
                }
                #endregion
            }
        }
        outPutSB.Append(message.Substring(start, offset - start));
        return outPutSB.ToString();
    }


    private void LineEnd(ref StringBuilder sb) {
        int i = sb.Length - 1;
        if (sb[i] == ' ')
        {
            sb[i] = '\n';
        }
        else
        {
            sb.Append('\n');
        }
    }

    private bool CharIs(char ch, string pattern) {
        bool charIs = false;
        charIs = Regex.IsMatch(ch.ToString(), pattern);
        return charIs;
    }
}

