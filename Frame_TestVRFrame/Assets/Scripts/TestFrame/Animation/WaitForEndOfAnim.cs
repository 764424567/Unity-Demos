/*******************************************************************************
* 版权声明：
* 版本声明：v1.0.0
* 类 名 称： WaitForEndOfAnim
* 创建日期：2023-06-07 10:46:37
* 作者名称：张尧
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：实现WaitForEndOfAnim迭代器
******************************************************************************/


using System.Collections;
using UnityEngine;

namespace Com.Frame.ZY
{
    public class WaitForEndOfAnim : IEnumerator
    {
        AnimationState m_animState;

        public WaitForEndOfAnim(AnimationState animState)
        {
            m_animState = animState;
        }
        public object Current
        {
            get
            {
                return null;
            }
        }
        public bool MoveNext()
        {
            return m_animState.enabled;
        }
        public void Reset()
        {
        }
    }
}

