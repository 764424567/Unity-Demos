using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test01 : MonoBehaviour
{
    //图片名字
    string imageName;
    //预制体对象
    GameObject part;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //如果获取到对象的话
            if (OnePointColliderObject() != null)
            {
                //给图片名字赋值
                imageName = OnePointColliderObject().name;
                //创建对象
                InstantObject();
            }
        }
    }

    /// <summary>
    /// 点击对象
    /// </summary>
    /// <returns>点击对象获取到对象的名字</returns>
    public GameObject OnePointColliderObject()
    {
        //存有鼠标或者触摸数据的对象
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //当前指针位置
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //射线命中之后的反馈数据
        List<RaycastResult> results = new List<RaycastResult>();
        //投射一条光线并返回所有碰撞
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //返回点击到的物体
        if (results.Count > 0)
            return results[0].gameObject;
        else
            return null;
    }

    public void InstantObject()
    {
        switch (imageName)
        {
            case "Image_1":
                GameObject obj01 = (GameObject)Resources.Load("Cube");
                part = Instantiate(obj01, Vector3.zero, obj01.transform.rotation);
                break;
            case "Image_2":
                GameObject obj02 = (GameObject)Resources.Load("Sphere");
                part = Instantiate(obj02, Vector3.up, obj02.transform.rotation);
                break;
            default:
                break;
        }
    }
}
