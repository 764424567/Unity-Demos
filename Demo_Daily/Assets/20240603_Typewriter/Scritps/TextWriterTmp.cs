using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tools
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
    /// 用于TextMeshPro的打字机效果组件。
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextWriterTmp : MonoBehaviour
    {
        /// <summary>
        /// 打字机效果用时
        /// </summary>
        private float useTime;

        /// <summary>
        /// 打字机效果状态。
        /// </summary>
        private TypewriterState state = TypewriterState.Completed;

        /// <summary>
        /// TextMeshPro组件。
        /// </summary>
        private TMP_Text tmpText;

        /// <summary>
        /// 用于输出字符的协程。
        /// </summary>
        private Coroutine outputCoroutine;

        /// <summary>
        /// 字符输出结束时的回调。
        /// </summary>
        private UnityAction outputEndCallback;

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

        private void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            OutputText("123456", 6, () => 
            {
                Debug.Log("用6秒显示6个字");
            });
        }

        private void OnDisable()
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
        /// 以不带淡入效果输出字符的协程。
        /// </summary>
        /// <param name="skipFirstCharacter"></param>
        /// <returns></returns>
        private IEnumerator OutputText(bool skipFirstCharacter = false)
        {
            state = TypewriterState.Outputting;

            // 先隐藏所有字符
            tmpText.maxVisibleCharacters = skipFirstCharacter ? 1 : 0;
            tmpText.ForceMeshUpdate();

            // 按时间逐个显示字符
            float timer = 0f;
            TMP_TextInfo textInfo = tmpText.textInfo;
            float speed = useTime / textInfo.characterCount;
            while (tmpText.maxVisibleCharacters < textInfo.characterCount)
            {
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    timer = 0;
                    tmpText.maxVisibleCharacters++;
                }
                yield return null;
            }

            // 输出过程结束
            state = TypewriterState.Completed;
            OnOutputEnd(false);
        }



        /// <summary>
        /// 设置字符的顶点颜色Alpha值。
        /// </summary>
        /// <param name="index"></param>
        /// <param name="alpha"></param>
        private void SetCharacterAlpha(int index, byte alpha)
        {
            var materialIndex = tmpText.textInfo.characterInfo[index].materialReferenceIndex;
            var vertexColors = tmpText.textInfo.meshInfo[materialIndex].colors32;
            var vertexIndex = tmpText.textInfo.characterInfo[index].vertexIndex;

            vertexColors[vertexIndex + 0].a = alpha;
            vertexColors[vertexIndex + 1].a = alpha;
            vertexColors[vertexIndex + 2].a = alpha;
            vertexColors[vertexIndex + 3].a = alpha;
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
                var textInfo = tmpText.textInfo;
                for (int i = 0; i < textInfo.characterCount; i++)
                {
                    SetCharacterAlpha(i, 255);
                }

                tmpText.maxVisibleCharacters = textInfo.characterCount;
                tmpText.ForceMeshUpdate();
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
}