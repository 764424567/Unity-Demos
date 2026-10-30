/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: UIRayMask.cs
  Author:张辰       Version :1.0          Date: 2018-6-28
  Description:UI点击遮罩脚本，此脚本挂在大Image上，需要两张
  Image，一张全屏挂UIPanel材质，另一张为遮罩挂UIMask材质，小
  Image区域为可点击区域，小Image层级需要在大Image前，两个
  Image无父子关系
************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
[ExecuteInEditMode]

public class UIRayMask : MonoBehaviour, ICanvasRaycastFilter
{
    public Transform maskUI;
    private RectTransform rectTransform;
    private List<Vector3> innerVertices;
    private List<Vector3> outterVertices;

    private Vector3 pos;
    private Vector2 size;

    private void Awake()
    {
        rectTransform = transform.GetComponent<RectTransform>();
        maskUI.GetComponent<Image>().raycastTarget = false;
        transform.GetComponent<Image>().raycastTarget = true;
        innerVertices = new List<Vector3>();
        outterVertices = new List<Vector3>();
    }

    private void Start()
    {
        Refresh();
        pos = maskUI.localPosition;
        size = maskUI.GetComponent<RectTransform>().sizeDelta;
    }

    private void Update()
    {
        if (pos != maskUI.localPosition || size != maskUI.GetComponent<RectTransform>().sizeDelta)
        {
            Refresh();
            pos = maskUI.localPosition;
            size = maskUI.GetComponent<RectTransform>().sizeDelta;
        }
        
    }


    private void Refresh()
    {
        innerVertices.Clear();
        outterVertices.Clear();
        float tw = rectTransform.rect.width;
        float th = rectTransform.rect.height;
        float tw2 = maskUI.GetComponent<RectTransform>().rect.width;
        float th2 = maskUI.GetComponent<RectTransform>().rect.height;
        float outerRadiusX = rectTransform.pivot.x * tw;
        float outerRadiusY = rectTransform.pivot.y * th;
        float tmpX = maskUI.GetComponent<RectTransform>().localPosition.x;
        float tmpY = maskUI.GetComponent<RectTransform>().localPosition.y;
        float innerRadiusX = maskUI.GetComponent<RectTransform>().pivot.x * tw2;
        float innerRadiusY = maskUI.GetComponent<RectTransform>().pivot.y * th2;

        outterVertices.Add(new Vector2(-outerRadiusX, outerRadiusY));
        outterVertices.Add(new Vector2(outerRadiusX, outerRadiusY));
        outterVertices.Add(new Vector2(outerRadiusX, -outerRadiusY));
        outterVertices.Add(new Vector2(-outerRadiusX, -outerRadiusY));

        innerVertices.Add(new Vector2(-innerRadiusX + tmpX, innerRadiusY + tmpY));
        innerVertices.Add(new Vector2(innerRadiusX + tmpX, innerRadiusY + tmpY));
        innerVertices.Add(new Vector2(innerRadiusX + tmpX, -innerRadiusY + tmpY));
        innerVertices.Add(new Vector2(-innerRadiusX + tmpX, -innerRadiusY + tmpY));
    }

    private bool Contains(Vector2 p, List<Vector3> outterVertices, List<Vector3> innerVertices)
    {
        return IsInPolygon(p, outterVertices) && !IsInPolygon(p, innerVertices);
    }

    private bool IsInPolygon(Vector2 checkPoint, List<Vector3> polygonPoints)
    {
        bool inside = false;
        int pointCount = polygonPoints.Count;
        Vector2 p1, p2;
        for (int i = 0, j = pointCount - 1; i < pointCount; j = i, i++)
        {
            p1 = polygonPoints[i];
            p2 = polygonPoints[j];
            if (checkPoint.y < p2.y)
            { 
                if (p1.y <= checkPoint.y)
                {
                    if ((checkPoint.y - p1.y) * (p2.x - p1.x) > (checkPoint.x - p1.x) * (p2.y - p1.y)) 
                    {
                        inside = (!inside);
                    }
                }
            }
            else if (checkPoint.y < p1.y)
            {
                if ((checkPoint.y - p1.y) * (p2.x - p1.x) < (checkPoint.x - p1.x) * (p2.y - p1.y))
                {
                    inside = (!inside);
                }
            }
        }
        return inside;
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, sp, eventCamera, out local);
        return Contains(local, outterVertices, innerVertices);
    }
}
