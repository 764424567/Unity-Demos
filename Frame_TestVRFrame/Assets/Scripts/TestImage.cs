using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImage : Image
{
    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        //原来是通过响应射线来判断点击到Image
        //return base.IsRaycastLocationValid(screenPoint, eventCamera);
        //改成通过射线判断点击到Collider2D
        return GetComponent<Collider2D>().OverlapPoint(screenPoint);
    }
}
