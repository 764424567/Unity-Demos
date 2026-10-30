using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 用于Text的打字机效果组件。
/// </summary>
[RequireComponent(typeof(Text))]
public class TextWriter : MonoBehaviour
{
    /// <summary>
    /// 打字机效果状态。
    /// </summary>
    public enum TypewriterState
    {
        /// <summary>
        /// 已完成输出。
        /// </summary>
        Completed,

        /// <summary>
        /// 正在输出。
        /// </summary>
        Outputting,

        /// <summary>
        /// 输出被中断。
        /// </summary>
        Interrupted
    }
    /// <summary>
    /// 打字机效果用时
    /// </summary>
    private float useTime;

    /// <summary>
    /// 打字机效果状态。
    /// </summary>
    private TypewriterState state = TypewriterState.Completed;

    /// <summary>
    /// Text组件。
    /// </summary>
    private Text tmpText;

    /// <summary>
    /// 文本内容。
    /// </summary>
    string words;

    /// <summary>
    /// 显示间隔。
    /// </summary>
    int charsSecond;

    /// <summary>
    /// 用于输出字符的协程。
    /// </summary>
    private Coroutine outputCoroutine;

    /// <summary>
    /// 字符输出结束时的回调。
    /// </summary>
    private UnityAction outputEndCallback;


    void Awake()
    {
        tmpText = GetComponent<Text>();
    }

    private void Start()
    {
        OutputText("123456", 12, () => {

            Debug.Log("用12秒显示6个字");
        });
    }

    void OnDisable()
    {
        // 中断输出
        if (state == TypewriterState.Outputting)
        {
            state = TypewriterState.Interrupted;
            StopCoroutine(outputCoroutine);
            OnOutputEnd(true);
        }
    }

    /// <summary>
    /// 输出文字。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="onOutputEnd"></param>
    public void OutputText(string text, float time, UnityAction onOutputEnd = null)
    {
        // 如果当前正在执行字符输出，将其中断
        if (state == TypewriterState.Outputting)
        {
            StopCoroutine(outputCoroutine);

            state = TypewriterState.Interrupted;
            OnOutputEnd(false);
        }

        tmpText.text = text;
        useTime = time;
        outputEndCallback = onOutputEnd;
        words = text;

        // 如果对象未激活，直接完成输出
        if (!isActiveAndEnabled)
        {
            state = TypewriterState.Completed;
            OnOutputEnd(true);
            return;
        }
        outputCoroutine = StartCoroutine(OutputText());
    }

    /// <summary>
    /// 以不带淡入效果输出字符的协程。
    /// </summary>
    /// <param name="skipFirstCharacter"></param>
    /// <returns></returns>
    private IEnumerator OutputText()
    {
        state = TypewriterState.Outputting;

        // 先隐藏所有字符
        tmpText.text = "";

        // 按时间逐个显示字符
        float timer = 0f;
        Text textInfo = tmpText;
        float speed = useTime / words.Length;//计算出出现文字的间隔
        while (charsSecond < words.Length)
        {
            timer += Time.deltaTime;
            if (timer >= speed)
            {
                timer = 0;
                charsSecond++;
                tmpText.text = words.Substring(0, charsSecond);
            }
            yield return null;
        }

        // 输出过程结束
        state = TypewriterState.Completed;
        OnOutputEnd(false);
    }

    /// <summary>
    /// 完成正在进行的打字机效果，将所有文字显示出来。
    /// </summary>
    public void CompleteOutput()
    {
        if (state == TypewriterState.Outputting)
        {
            state = TypewriterState.Completed;
            StopCoroutine(outputCoroutine);
            OnOutputEnd(true);
        }
    }

    /// <summary>
    /// 处理输出结束逻辑。
    /// </summary>
    /// <param name="isShowAllCharacters"></param>
    private void OnOutputEnd(bool isShowAllCharacters)
    {
        // 清理协程
        outputCoroutine = null;

        // 将所有字符显示出来
        if (isShowAllCharacters)
        {
            tmpText.text = words;
        }

        // 触发输出完成回调
        if (outputEndCallback != null)
        {
            var temp = outputEndCallback;
            outputEndCallback = null;
            temp.Invoke();
        }
    }
}