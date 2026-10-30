/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: MouseClickType.cs
  Author:张辰       Version :1.0          Date: 2017-11-15
  Description:设置鼠标点击监听（非UI）（左键，右键，中键，左
  键双击，右键双击，中键双击）
************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.Rainier.ZC_Frame
{

    /// <summary>
    /// 鼠标点击种类
    /// </summary>
    public class MouseClickType  
    {
        /// <summary>
        /// 鼠标点击枚举
        /// </summary>
        public enum MouseInput
        {
            leftKey = 0,
            rightKey,
            middleKey,
            leftdDobbleKey,
            rightDobbleKey,
            middleDobbleKey,
        }

        private static MouseClickType instance = new MouseClickType();

        public static MouseClickType current
        {
            get { return instance; }
        }

        protected MouseClickType() { }

        /// <summary>
        /// 判断鼠标是否点击（个别独立判断）
        /// </summary>
        /// <param name="mouseInputType">鼠标点击种类</param>
        /// <param name="tmpPoint"></param>
        /// <returns></returns>
        public bool MouseInputJudgment(MouseInput mouseInputType, PointerEventData tmpPoint)
        {
            switch (mouseInputType)
            {
                case MouseInput.leftKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Left))
                    {
                        return true;
                    }
                    return false;
                #endregion
                case MouseInput.rightKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Right))
                    {
                        return true;
                    }
                    return false;
                #endregion
                case MouseInput.middleKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Middle))
                    {
                        return true;
                    }
                    return false;
                #endregion
                case MouseInput.leftdDobbleKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Left) && tmpPoint.clickCount.Equals(2))
                    {
                        return true;
                    }
                    return false;
                #endregion
                case MouseInput.rightDobbleKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Right) && tmpPoint.clickCount.Equals(2))
                    {
                        return true;
                    }
                    return false;
                #endregion
                case MouseInput.middleDobbleKey:
                    #region
                    if (tmpPoint.button.Equals(PointerEventData.InputButton.Middle) && tmpPoint.clickCount.Equals(2))
                    {
                        return true;
                    }
                    return false;
                #endregion
                default:
                    return false;
            }
        }

    }
}






