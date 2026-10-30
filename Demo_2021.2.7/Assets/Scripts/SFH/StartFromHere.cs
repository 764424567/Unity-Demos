using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;

public class StartFromHere : MonoBehaviour
{
    void Start()
    {
        //初始化 获取所有的相关函数 并执行
        InitialStart();
    }

    private void InitialStart()
    {
        MonoBehaviour[] testMono = FindObjectsOfType<MonoBehaviour>();
        AttributeUtils.GetAllDestByProperties<SFHStartCall>(testMono);
        for (int i = 0; i < AttributeUtils.myFuctionList.Count; i++)
        {
            List<AtrributeFlagFunction> mlist = (List<AtrributeFlagFunction>)AttributeUtils.myFuctionList.GetByIndex(i);
            for (int j = 0; j < mlist.Count; j++)
            {
                AtrributeFlagFunction item = mlist[j];
                MonoBehaviour monob = item.monob;
                object result = item.methodInfo.Invoke((object)monob, new object[] { });
                if (item.methodInfo.ReturnType == typeof(IEnumerator))
                {
                    monob.StartCoroutine((IEnumerator)result);
                }
            }
        }
    }
}