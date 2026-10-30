/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： MobileSetting
* 创建日期：2021-01-19 09:48:45
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：移动端固定设置(屏幕常亮，自动转屏)
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class MobileSetting : MonoBehaviour 
	{
        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            Screen.orientation = ScreenOrientation.LandscapeRight;
#endif
        }

        private void Start()
        {
            AutoRotationScreen();
            AlwaysDisplay();
        }


        /// <summary>
        /// 自动转屏
        /// </summary>
        private void AutoRotationScreen()
        {
#if UNITY_ANDROID || UNITY_IOS
            Screen.orientation = ScreenOrientation.AutoRotation;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
#endif
        }

        /// <summary>
        /// 永不休眠
        /// </summary>
        private void AlwaysDisplay()
        {
#if UNITY_ANDROID || UNITY_IOS
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
        }
    }
}

