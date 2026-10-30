using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//获取物体中心点
public class Position_pAnds : MonoBehaviour
{
   public Vector3 Test(GameObject thisobj)
    {
        Transform parent = thisobj.transform;
        Vector3 center = Vector3.zero;
        //如果父物体有Renderer组件，GetComponentsInChildren是包含父物体Renderer的！我们要去除这个才能保证中心点准确！
        Renderer[] rendersArr = parent.GetComponentsInChildren<Renderer>();
        List<Renderer> renders = new List<Renderer>();
        for (int i = 0; i < rendersArr.Length; i++)
        {
            renders.Add(rendersArr[i]);
        }
        if (parent.GetComponent<Renderer>() != null)
        {
            renders.RemoveAt(0);//去除父物体的Renderer!
        }
        //计算所有子物体bounds中心点的平均值
        foreach (Renderer child in renders)
        {
            center += child.bounds.center;
        }
        center /= rendersArr.Length;
        //根据center和子物体bounds通过Encapsulate方法计算一个恰好容纳子物体们的容器bounds
        Bounds bounds = new Bounds(center, Vector3.zero);
        foreach (Renderer child in renders)
        {
            bounds.Encapsulate(child.bounds);
        }
        //注意!!center != bounds.center（已测试），我想应该是center仅仅是提供一个参考坐标，
        //而经过上面Encapsulate计算后bounds.center已经改变成最佳的

        //**********************这里可以注释掉，下面添加BoxCollider可注释
        //BoxCollider box = parent.gameObject.GetComponent<BoxCollider>();
        //if (box == null)
        //{
        //    box = parent.gameObject.AddComponent<BoxCollider>();
        //}
        //box.center = Vector3.zero;
        //box.size = bounds.size;
        //********************上面可注释

        //一个世界坐标系上的三维向量：父物体->[恰好容纳子物体们的容器中心点]
        Vector3 parentToCenter = bounds.center - parent.position;
        //一个世界坐标系上的三维向量：[恰好容纳子物体们的容器中心点]->父物体
        Vector3 centerToParent = -parentToCenter;

        //*******至此，拿到了2个向量，我们开始进行偏移！************
        //①.开始偏移子物体们将子物体从自身位置+centerToParent向量，从而偏移到父物体附近
        //可能到这里会有些疑问：子物体偏移过去了，那位置不就变了吗？这可不行啊！
        //无需担心，因为子物体偏移后还有另一个物体要进行偏移,仔细看②
        //foreach (Transform t in parent)
        //{
        //    t.position = t.position + centerToParent;
        //}
        //②.父物体加上parentToCenter偏移到中心点
       // parent.transform.position = parent.position + parentToCenter;
        return parent.position + parentToCenter;
        //PS:
        //如果不理解这个过程，可以放到Unity上试试，观察子物体位置变化和父物体位置变化；
        //可以注释掉parent.transform.position = parent.position + parentToCenter;代码进行观察①情况
        //再取消注释测试完整代码，是不是父物体移动到了中心点...还是不懂的话，可能没救了..
    }
}
