/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: IPointerOver.cs
  Author:张辰       Version :1.0          Date: 2017-12-5
  Description:EventSystem判断捕获object
************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// EventSystem IsPointerOverGameObject方法扩展工具类
    /// </summary>
    public static class IPointerOver
    {
        /// <summary>
        /// EventSystem有无检测到物体
        /// </summary>
        /// <returns></returns>
        public static bool IsPointerOverGameObject()
        {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(tmpPointerEventData, tmpResults);
            return tmpResults.Count > 0;
        }

        /// <summary>
        /// EventSystem有无检测到UI
        /// </summary>
        /// <param name="canvas">挂有UI射线的canvas</param>
        /// <returns></returns>
        public static bool IsPointerOverUI(GameObject canvas)
        {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            GraphicRaycaster tmpGraphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            tmpGraphicRaycaster.Raycast(tmpPointerEventData, tmpResults);
            return tmpResults.Count > 0;
        }

        /// <summary>
        /// EventSystem有无检测到3D物体
        /// </summary>
        /// <param name="camera">挂有物理射线的camera</param>
        /// <returns></returns>
        public static bool IsPointerOverPhysicsGameObject(GameObject camera)
        {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            PhysicsRaycaster tmpPhysicsRaycaster = camera.GetComponent<PhysicsRaycaster>();
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            tmpPhysicsRaycaster.Raycast(tmpPointerEventData, tmpResults);
            return tmpResults.Count > 0;
        }

        /// <summary>
        /// EventSystem有无检测到指定UI
        /// </summary>
        /// <param name="canvas">目标Canvas</param>
        /// <param name="target">指定物体</param>
        /// <returns></returns>
        public static bool IsPointerOverSelectUI(GameObject canvas, GameObject target)
        {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            GraphicRaycaster tmpGraphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            tmpGraphicRaycaster.Raycast(tmpPointerEventData, tmpResults);
            foreach (var item in tmpResults)
            {
                if (item.gameObject.Equals(target))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 鼠标停留对象
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public static GameObject CurrentPointerOverGameObject(GameObject canvas) {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            GraphicRaycaster tmpGraphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            tmpGraphicRaycaster.Raycast(tmpPointerEventData, tmpResults);
            if (tmpResults.Count != 0)
            {
                return tmpResults[0].gameObject;
            }
            return null;
        }

        /// <summary>
        /// 鼠标停留对象
        /// </summary>
        /// <returns></returns>
        public static GameObject CurrentPointerOverGameObject()
        {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(tmpPointerEventData, tmpResults);
            if (tmpResults.Count != 0)
            {
                return tmpResults[0].gameObject;
            }
            return null;
        }

        /// <summary>
        /// 鼠标停留对象
        /// </summary>
        /// <param name="mainCamera">发出射线的相机</param>
        /// <returns></returns>
        public static GameObject CurrentPointerOverGameObject(Camera mainCamera) {
            PointerEventData tmpPointerEventData = new PointerEventData(EventSystem.current);
            tmpPointerEventData.position = Input.mousePosition;
            PhysicsRaycaster tmpPhysicsRaycaster = mainCamera.GetComponent<PhysicsRaycaster>();
            List<RaycastResult> tmpResults = new List<RaycastResult>();
            tmpPhysicsRaycaster.Raycast(tmpPointerEventData, tmpResults);
            if (tmpResults.Count != 0)
            {
                return tmpResults[0].gameObject;
            }
            return null;
        }
    }
}

