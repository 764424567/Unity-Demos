/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: AddCollider.cs
  Author:张辰       Version :1.0          Date: 2018-9-18
  Description:模型加碰撞体（选中要加碰撞体的物体然后……加）
************************************************************/
using System;
using UnityEngine;
using UnityEditor;

public class AddCollider:Editor {
    [MenuItem("Tools/AddBoxCollider")]
    public static void AddBoxCollider()
    {
        Transform parent = Selection.activeGameObject.transform;
        //记录坐标
        Vector3 postion = parent.position;
        Quaternion rotation = parent.rotation;
        Vector3 scale = parent.localScale;
        //坐标归零
        parent.position = Vector3.zero;
        parent.rotation = Quaternion.Euler(Vector3.zero);
        parent.localScale = Vector3.one;
        //删除子物体碰撞体
        Collider[] colliders = parent.GetComponentsInChildren<Collider>();
        foreach (Collider child in colliders)
        {
            DestroyImmediate(child);
        }
        //取中心点平均值
        Vector3 center = Vector3.zero;
        Renderer[] renders = parent.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in renders)
        {
            center += child.bounds.center;
        }
        center /= parent.GetComponentsInChildren<Renderer>().Length;
        //确定包围盒
        Bounds bounds = new Bounds(center, Vector3.zero);
        foreach (Renderer child in renders)
        {
            bounds.Encapsulate(child.bounds);
        }
        BoxCollider boxCollider = parent.gameObject.AddComponent<BoxCollider>();
        boxCollider.center = bounds.center;
        boxCollider.size = bounds.size;

        //计算完成物体归位
        parent.position = postion;
        parent.rotation = rotation;
        parent.localScale = scale;
    }

}



