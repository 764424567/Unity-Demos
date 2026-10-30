/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: ModeSelect.cs
  Author:张辰       Version :1.0          Date: 2018-1-22
  Description:演练考核模式选择脚本
************************************************************/
using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    public static class ModeSelect
    {

        public enum Mode
        {
            /// <summary>
            /// 学习模式
            /// </summary>
            Study = 0,
            /// <summary>
            /// 考核模式
            /// </summary>
            Exam
        }

        /// <summary>
        /// 实验模式
        /// </summary>
        private static Mode programMode = Mode.Study;

        /// <summary>
        /// 实验模式
        /// </summary>
        public static Mode ProgramMode
        {
            get { return programMode; }
            set { programMode = value; }
        }

    }
}

