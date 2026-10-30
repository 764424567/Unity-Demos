using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotate : MonoBehaviour
{
    private int halfSize;
    private GameObject[] gameObjects;
    /// <summary>
    /// 圆半径
    /// </summary>
    private int r = 300;
    /// <summary>
    /// 相间角度
    /// </summary>
    private int angle;

    private void Start()
    {
        //初始化数组
        var childCount = transform.childCount;
        //计算出中点
        halfSize = (childCount - 1) / 2;
        //求出圆内角度
        angle = 360 / childCount;
        //初始
        gameObjects = new GameObject[childCount];
        for (var i = 0; i < childCount; i++)
        {
            gameObjects[i] = transform.GetChild(i).gameObject;
            SetPosition(i);
            SetDeepin(i);
        }
    }

    /// <summary>
    /// 设置物体位置
    /// </summary>
    private void SetPosition(int index)
    {
        float x = 0;
        float z = 0;
        if (index < halfSize)
        {
            int id = halfSize - index;
            x = r * Mathf.Sin(angle * id);
            z = -r * Mathf.Cos(angle * id);
        }
        else if (index > halfSize)
        {
            int id = index - halfSize;
            x = -r * Mathf.Sin(angle * id);
            z = -r * Mathf.Cos(angle * id);
        }
        else
        {
            x = 0;
            z = -r;
        }
        Tweener tweener = gameObjects[index].GetComponent<RectTransform>().DOLocalMove(new Vector3(x, 0, z), 1);
    }

    private void SetDeepin(int index)
    {
        //计算图片深度也就是z轴的距离,离摄像机的远近
        int deepin = 0;
        if (index < halfSize)
        {
            deepin = index;
        }
        else if (index > halfSize)
        {
            deepin = gameObjects.Length - (1 + index);
        }
        else
        {
            deepin = halfSize;
        }
        gameObjects[index].GetComponent<RectTransform>().SetSiblingIndex(deepin);
    }

    /// <summary>
    /// 向左滑动
    /// </summary>
    public void OnLeftDrag()
    {
        var length = gameObjects.Length;
        for (var i = 0; i < length; i++)
        {
            var temp = gameObjects[i];
            gameObjects[i] = gameObjects[length - 1];
            gameObjects[length - 1] = temp;
        }
        for (var i = 0; i < length; i++)
        {
            SetPosition(i);
            SetDeepin(i);
        }
    }

    /// <summary>
    /// 向右滑动
    /// </summary>
    public void OnRightDrag()
    {
        var length = gameObjects.Length;
        for (var i = 0; i < length - 1; i++)
        {
            var temp = gameObjects[i];
            gameObjects[i] = gameObjects[i + 1];
            gameObjects[i + 1] = temp;
        }
        for (var i = 0; i < length; i++)
        {
            SetPosition(i);
            SetDeepin(i);
        }
    }

    private Vector2 touchFirst = Vector2.zero;//手指开始按下的位置
    private Vector2 touchSecond = Vector2.zero;//手指拖动的位置

    void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            touchFirst = Event.current.mousePosition;//记录开始按下的位置
        }
        if (Event.current.type == EventType.MouseUp)
        {
            touchSecond = Event.current.mousePosition;//记录拖动的位置
            if (touchSecond.x < touchFirst.x)
            {
                OnLeftDrag();//向左滑动
            }

            if (touchSecond.x > touchFirst.x)
            {
                OnRightDrag();//向右滑动
            }
            touchFirst = touchSecond;
        }
    }
}