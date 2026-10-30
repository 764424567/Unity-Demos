using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextWriterDoTween : MonoBehaviour
{
    private void Start()
    {
        DoTweenText("123456", 6, () => 
        {
            Debug.Log("用6秒显示6个字");
        });
    }
    /// <summary>
    /// 打字机效果显示文字
    /// </summary>
    /// <param name="text">文字内容</param>
    /// <param name="time">时间</param>
    /// <param name="action">结束后执行方法</param>
    void DoTweenText(string text, float time, UnityAction action)
    {
        Text tmpText = transform.GetComponent<Text>();
        tmpText.text = string.Empty;
        try
        {
            tmpText.DOText(text, time, true, ScrambleMode.None, null).SetEase(Ease.Linear).OnComplete(() => { action(); });
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("该对象不存在Text组件");
        }
    }
}
