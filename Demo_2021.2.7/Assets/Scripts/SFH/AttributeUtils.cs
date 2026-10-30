using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

// 定义属性类 管理相关的函数
[System.AttributeUsage(AttributeTargets.All)]
public class SFHCall : Attribute
{
    public SFHCall(int lev)
    {
        level = lev;
    }

    public int GetLevel()
    {
        return level;
    }
    protected int level;
}
// 定义属性类 设置函数的属性
[System.AttributeUsage(AttributeTargets.All)]
public class SFHStartCall : SFHCall
{
    public SFHStartCall(int lev) : base(lev)
    {
        level = lev;
    }
}
// 管理执行对象
public class AtrributeFlagFunction
{
    public MonoBehaviour monob;
    public MethodInfo methodInfo;
}
// 属性工具类
public class AttributeUtils
{
    // 使用字典来存储所有的相关函数
    public static SortedList myFuctionList = new SortedList();
    public static void GetAllDestByProperties<T>(object[] mono) where T : SFHCall
    {
        int length = mono.Length;
        for (int i = 0; i < length; i++)
        {
            Cache<T>((MonoBehaviour)mono[i]);
        }
    }
    private static void Cache<T>(MonoBehaviour p) where T : SFHCall
    {
        var type = p.GetType();
        // 不会重复调用父类的方法了。
        var fields2 = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var field in fields2)
        {
            AtrributeFlagFunction aff = new AtrributeFlagFunction();
            var objs = field.GetCustomAttributes(typeof(T), false);
            if (objs.Length > 0)
            {
                aff.monob = p;
                aff.methodInfo = field;
                T attr = (T)objs[0];
                int value = attr.GetLevel();
                if (!myFuctionList.ContainsKey(value))
                {
                    {
                        List<AtrributeFlagFunction> AttributeList = new List<AtrributeFlagFunction>();
                        AttributeList.Add(aff);
                        myFuctionList.Add(value, AttributeList);
                    }
                }
                else
                {
                    List<AtrributeFlagFunction> mlist = (List<AtrributeFlagFunction>)myFuctionList[value];
                    mlist.Add(aff);
                }
            }
        }
    }
}