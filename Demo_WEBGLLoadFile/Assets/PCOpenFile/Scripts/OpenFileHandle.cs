using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpenFileHandle : MonoBehaviour
{
    public Button BtnOpenFile;
    public Image showImg;

    //打开文件
    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofd);

    void Start()
    {
        BtnOpenFile.onClick.AddListener(BtnOpenFileEvent);
    }

    void BtnOpenFileEvent()
    {
        OpenFileName path = new OpenFileName();
        if (GetOpenFileName(path))
        {
            string filepath = path.file;

            StartCoroutine(ReadTexture(filepath, LoadImg));
        }
    }

    /// <summary>
    /// 读取图片
    /// </summary>
    /// <param name="path"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    IEnumerator ReadTexture(string path, UnityAction<Texture> action)
    {
        Debug.Log(path);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            byte[] imgdata = request.downloadHandler.data;

            action(DownloadHandlerTexture.GetContent(request));
        }
    }

    /// <summary>
    /// 加载图片
    /// </summary>
    /// <param name="texture"></param>
    void LoadImg(Texture texture)
    {
        Sprite ImgSprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        showImg.sprite = ImgSprite;
    }
}
/// <summary>
/// 文件日志类
/// </summary>
// [特性(布局种类.有序,字符集=字符集.自动)]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenFileName
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public String filter = null;
    public String customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public String file = null;
    public int maxFile = 0;
    public String fileTitle = null;
    public int maxFileTitle = 0;
    public String initialDir = null;
    public String title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public String defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public String templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;

    public OpenFileName()
    {
        this.structSize = Marshal.SizeOf(this);
        this.filter = "Texure Files(*图片文件)\0*.png;*.jpg;*.bmp;*.jpeg\0";
        this.file = new string(new char[256]);
        this.maxFile = this.file.Length;
        this.fileTitle = new string(new char[64]);
        this.maxFileTitle = this.fileTitle.Length;
        this.initialDir = "C:\\"; //默认路径
        this.title = "打开项目";
        this.defExt = "JPG";
        this.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
    }
}

