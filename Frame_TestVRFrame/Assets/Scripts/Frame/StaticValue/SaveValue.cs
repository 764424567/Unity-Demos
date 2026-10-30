/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： SaveValue
* 创建日期：2020-06-04 09:13:39
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public static class SaveValue  
	{
        #region 加载场景相关

        private static bool isFristOpen = true;

        /// <summary>
        /// 是否是第一次打开应用
        /// </summary>
        public static bool IsFristOpen {
            get { return isFristOpen; }
            set { isFristOpen = value; }
        }

        private static bool isUseAsync = true;

        /// <summary>
        /// 是否使用异步加载场景
        /// </summary>
        public static bool IsUseAsync {
            get { return isUseAsync; }
            set { isUseAsync = value; }
        }

        private static LoadStyle loadStyle = LoadStyle.Mod3;

        /// <summary>
        /// 异步加载模板
        /// </summary>
        public static LoadStyle LoadStyle {
            get { return loadStyle; }
            set { loadStyle = value; }
        }

        #endregion

        #region 音频设置相关

        private static float stepAudioVolume = 1f;

        /// <summary>
        /// 步骤画外音音量
        /// </summary>
        public static float StepAudioVolume {
            get { return stepAudioVolume; }
            set { stepAudioVolume = value; }
        }

        private static bool bgmAudioSwitch = true;

        /// <summary>
        /// 背景音乐开关
        /// </summary>
        public static bool BGMAudioSwitch {
            get { return bgmAudioSwitch; }
            set { bgmAudioSwitch = value; }
        }

        private static float bgmAudioVolume = 1f;

        /// <summary>
        /// 背景音乐音量
        /// </summary>
        public static float BGMAudioVolume {
            get { return bgmAudioVolume; }
            set { bgmAudioVolume = value; }
        }

        #endregion

        #region 人物移动设置相关

        private static float moveSpeed = 5f;

        /// <summary>
        /// 人物移动速度
        /// </summary>
        public static float MoveSpeed {
            get { return moveSpeed; }
            set { moveSpeed = value; }
        }

        private static float rotateSpeed = 2f;

        /// <summary>
        /// 相机旋转速度
        /// </summary>
        public static float RotateSpeed {
            get { return rotateSpeed; }
            set { rotateSpeed = value; }
        }

        #endregion

        #region 切屏特效相关

        private static LoadStyle effectStyle = LoadStyle.Mod2;

        /// <summary>
        /// 异步加载模板
        /// </summary>
        public static LoadStyle EffectStyle
        {
            get { return effectStyle; }
            set { effectStyle = value; }
        }

        #endregion

        #region 物体高亮相关

        /// <summary>
        /// 物体高亮颜色(默认青蓝色)
        /// </summary>
        private static Color highlithtColor = new Color(0f, 1f, 1f, 1f);

        /// <summary>
        /// 物体高亮颜色
        /// </summary>
        public static Color HighlightColor {
            get { return highlithtColor; }
            set { highlithtColor = value; }
        }

        #endregion

        #region 回放系统相关

        /// <summary>
        /// 当前是否是回放模式
        /// </summary>
        private static bool storageState = false;

        /// <summary>
        /// 当前是否是回放模式
        /// </summary>
        public static bool StorageState {
            get { return storageState; }
            set { storageState = value; }
        }

        #endregion
    }
}

