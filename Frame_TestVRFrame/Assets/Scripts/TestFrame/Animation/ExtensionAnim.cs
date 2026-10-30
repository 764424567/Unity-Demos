/*******************************************************************************
* 版权声明：
* 版本声明：v1.0.0
* 类 名 称：ExtensionAnim
* 创建日期：2023-06-07 10:59:42
* 作者名称：张尧
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：实现动画的开始和结束控制
******************************************************************************/

using UnityEngine;
using System.Collections;
using System;

namespace Com.Frame.ZY
{
    /// <summary>
    /// 
    /// </summary>
	public static class ExtensionAnim
    {
        // 封装函数
        public static void Play(this Animation animation, string clipName, Action startAct = null, Action endAct = null)
        {
            MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
            mono.StartCoroutine(PlayAnimationItor(animation, clipName, startAct, endAct));
        }

        /// <summary>
        /// Animation动画播放迭代器
        /// </summary>
        /// <param name="animation">Animation组件</param>
        /// <param name="clipName">clip片段名</param>
        /// <param name="startAct">委托函数</param>
        /// <param name="endAct">委托函数</param>
        /// <returns></returns>
        private static IEnumerator PlayAnimationItor(Animation animation, string clipName, Action startAct, Action endAct)
        {
            startAct?.Invoke();

            AnimationState animationState = animation[clipName];
            animation.Play(clipName);
            MonoBehaviour mono = UnityEngine.Object.FindObjectOfType<MonoBehaviour>();
            yield return mono.StartCoroutine(new WaitForEndOfAnim(animationState));

            endAct?.Invoke();
        }
    }
}

