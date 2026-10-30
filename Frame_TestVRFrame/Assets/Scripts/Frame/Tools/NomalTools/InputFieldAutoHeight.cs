/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: Test.cs
  Author:张辰       Version :1.0          Date: 2018-3-2
  Description:InputField根据内容多少高度自适应（挂在InputField上）
************************************************************/
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(InputField))]
public class InputFieldAutoHeight : MonoBehaviour, ILayoutElement
{
    /// <summary>
    /// 计算优先级
    /// </summary>
    private int priority = 1;

    /// <summary>
    /// inputfield尺寸
    /// </summary>
    private RectTransform targetRect;

    /// <summary>
    /// 需要适配的inputfield
    /// </summary>
    private InputField target;

    /// <summary>
    /// 渲染Text用
    /// </summary>
    private TextGenerator targetTextRender;

    /// <summary>
    /// 原始尺寸
    /// </summary>
    private Vector2 orgSize;

    /// <summary>
    /// 高度差值
    /// </summary>
    private float i;

    private void Awake()
    {
        targetRect = transform.GetComponent<RectTransform>();
        target = transform.GetComponent<InputField>();
        target.lineType = InputField.LineType.MultiLineNewline;
#if UNITY_5_6_1_OR_NEWER
        priority = target.layoutPriority + 1;
#endif
        orgSize = targetRect.sizeDelta;
        i = targetRect.rect.size.y - target.textComponent.rectTransform.rect.size.y;
        target.onValueChanged.AddListener(OnInputFieldValueChange);
        targetTextRender = new TextGenerator();
    }


    /// <summary>
    /// 获取Text显示设置
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    private TextGenerationSettings GetTextGenerationSettings(Vector2 size) {
        TextGenerationSettings settings = target.textComponent.GetGenerationSettings(size);
        settings.generateOutOfBounds = true;
        return settings;
    }


    public void OnInputFieldValueChange(string value) {
        targetRect.SetSizeWithCurrentAnchors((RectTransform.Axis)1, LayoutUtility.GetPreferredSize(targetRect, 1));
    }

#region 实现接口
    /// <summary>
    /// 弹性高度
    /// </summary>
    public float flexibleHeight
    {
        get { return -1; }
    }

    /// <summary>
    /// 弹性宽度
    /// </summary>
    public float flexibleWidth
    {
        get { return -1; }
    }

    /// <summary>
    /// layout计算优先级（需要比inputfield大）
    /// </summary>
    public int layoutPriority
    {
        get
        {
            return priority;
        }
    }

    /// <summary>
    /// 最小高度
    /// </summary>
    public float minHeight
    {
        get { return 0; }
    }

    /// <summary>
    /// 最小宽度
    /// </summary>
    public float minWidth
    {
        get { return 0; }
    }

    /// <summary>
    /// 最佳高度
    /// </summary>
    public float preferredHeight
    {
        get
        {
            TextGenerationSettings settings = GetTextGenerationSettings(new Vector2(target.textComponent.GetPixelAdjustedRect().size.x, 0));
            return Mathf.Max(orgSize.y, i + (targetTextRender.GetPreferredHeight(target.text, settings) / target.textComponent.pixelsPerUnit));
        }
    }

    /// <summary>
    /// 最佳宽度
    /// </summary>
    public float preferredWidth
    {
        get
        {
            TextGenerationSettings settings = GetTextGenerationSettings(Vector2.zero);
            return Mathf.Max(orgSize.x, targetTextRender.GetPreferredWidth(target.text, settings) / target.textComponent.pixelsPerUnit );
        }
    }
    public void CalculateLayoutInputHorizontal(){}
    public void CalculateLayoutInputVertical(){}
#endregion
}
