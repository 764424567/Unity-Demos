using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other
{
    /// <summary>
    /// 选择朝代
    /// </summary>
    /// <param name="index">第几个朝代</param>
    public delegate void DynastyChooseHandle(int index);
    public static event DynastyChooseHandle DynastyChooseEvent;
    public static void OnDynastyChoose(int index)
    {
        if (DynastyChooseEvent != null)
        {
            DynastyChooseEvent(index);
        }
    }

    //关闭所有线程
    public delegate void CloseAllThreadHandle();
    public static event CloseAllThreadHandle CloesAllThreadEvent;
    public static void OnCloseAllThread()
    {
        if (CloesAllThreadEvent != null)
        {
            CloesAllThreadEvent();
        }
    }

    public delegate void ReloadCtrOpenHandle(int index);
    public static event ReloadCtrOpenHandle ReloadCtrOpenEvent;
    public static void OnReloadCtrOpen(int index)
    {
        if (ReloadCtrOpenEvent != null)
        {
            ReloadCtrOpenEvent(index);
        }
    }

    public delegate void ReloadCtrCloseHandle(int index);
    public static event ReloadCtrCloseHandle ReloadCtrCloseEvent;
    public static void OnReloadCtrClose(int index)
    {
        if (ReloadCtrCloseEvent != null)
        {
            ReloadCtrCloseEvent(index);
        }
    }

    public delegate void ReloadCtrAllHandle(string openOrClose);
    public static event ReloadCtrAllHandle ReloadCtrAllEvent;
    public static void OnReloadCtrAll(string openOrColse)
    {
        if (ReloadCtrAllEvent != null)
        {
            ReloadCtrAllEvent(openOrColse);
        }
    }

    public delegate void OpenPJLinkHandle(OpenOrColse openOrColse);
    public static event OpenPJLinkHandle OpenPJLinkEvent;
    public static void OnOpenPJLink(OpenOrColse openOrColse)
    {
        if (OpenPJLinkEvent != null)
        {
            OpenPJLinkEvent(openOrColse);
        }
    }

    public delegate void BtnClickHandle(GameObject obj);
    public static event BtnClickHandle BtnClickEvent;
    public static void OnBtnClick(GameObject obj)
    {
        if (BtnClickEvent!= null)
        {
            BtnClickEvent(obj);
        }
    }




    public static void Clear()
    {
        DynastyChooseEvent = null;
        CloesAllThreadEvent = null;
    }
}

public enum OpenOrColse
{
    OPEN,
    CLOSE
}

/*
/// <summary>
/// 朝代
/// </summary>
public enum Dynasty
{
    
    Zhou,       //大周
    Qin,        //大秦
    Han,        //汉
    Tang,       //唐
    Ming,       //明
    Qing,       //清朝
    Min,        //民国
    Modern,     //现代
    None
}

/// <summary>
/// 六类
/// </summary>
public enum SexClass
{
    Drawing,    //绘画
    Artware,    //工艺品
    Building,   //建筑
    Costume,    //服饰
    DanceMusic, //舞蹈音乐
    Sculpture,  //雕塑
    None
}

/// <summary>
/// 六类里面具体类目
/// </summary>
public enum SexClassSix
{
    one,   
    Two,    
    Three,   
    Four,    
    Five, 
    Six,  
    None
}

public enum State
{
    Await,      //待机
    Arrive      //到达
}

public struct ListTexture
{
    public List<Texture2D> specimenTex2D;
    public List<Texture2D> specimenTex2DBig;
    public List<Texture2D> presentationTex2D_Costume;
}

public enum PosIndex
{
    Pos1,
    Pos2,
    Pos3,
    Pos4,
    Pos5,
    Pos6,
    None
}
*/