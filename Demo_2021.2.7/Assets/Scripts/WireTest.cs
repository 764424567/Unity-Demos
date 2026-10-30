using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTest : MonoBehaviour
{
    public CustomWire customWire;

    public CustomWireNode[] CustomWireNodeAlls;
    public GameObject[] GameObjectAlls;
    public Transform[] TransformsAlls;
    public Vector3[] Vector3Alls;

    void Start()
    {
        CustomWireNode node = customWire.GetNode(0);         //获取第index个节点

        customWire.AddNode();                               //在末尾添加新节点，若没有节点，则新节点为第一个节点
        customWire.AddNode(node);                           //在末尾添加指定节点，若节点为空或已存在则不添加
        customWire.AddNodeRange(CustomWireNodeAlls);        //添加节点集合
        customWire.AddNodeRange(GameObjectAlls);            //添加节点集合（重载，参数：GameObject数组）
        customWire.AddNodeRange(TransformsAlls);            //添加节点集合（重载，参数：Transform数组）
        customWire.AddNodeRange(Vector3Alls);               //添加节点集合（重载，参数：Vector3数组）

        customWire.InsertNode(0);                           //在index位置插入新节点
        customWire.InsertNode(0, true);                      //插入新节点，新节点将作为index位置节点的前置(atFront==true)/后置(atFront==false)节点
        customWire.InsertNode(0, node);                      //在index位置插入节点node
        customWire.InsertNodeRange(0, CustomWireNodeAlls);  //插入节点集合
        customWire.InsertNodeRange(0, GameObjectAlls);      //插入节点集合（重载，参数：GameObject数组）
        customWire.InsertNodeRange(0, TransformsAlls);      //插入节点集合（重载，参数：Transform数组）
        customWire.InsertNodeRange(0, Vector3Alls);         //插入节点集合（重载，参数：Vector3数组）

        customWire.RemoveNode(0);                           //删除index位置的节点
        customWire.RemoveNode(node);                        //删除指定节点
        customWire.RemoveAllNodes();                        //删除所有节点

        customWire.UpdateWire();                            //更新线段

        node.AddNode(true);                                 //在当前节点的前(atFront==true)/后(atFront==false)添加新节点
    }
}