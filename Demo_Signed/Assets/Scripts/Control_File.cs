using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Control_File : MonoBehaviour
{
    private int imageName { get; set; }
    int tempInt = 0;
    [HideInInspector]
    public List<string> allPath = new List<string>();
    public GameObject previewPrefab;
    public Transform savePreview;
    int _index;
    int _allPage;
    int _resudue;
    public GameObject[] m_TempImg;
    public Image m_ImageRect;
    int m_ImgNameKey = 0;

    private void Start()
    {
        _index = 0;
        //ScreenTexture(new Rect(0, 0, 700, 500), "C:\\TempImg");
        //FileDelect("C:\\TempImg\\02.png");
    }

    /// <summary>
    /// 将RenderTexture保存成一张png图片  
    /// </summary>
    /// <param name="rt">RenderTexture</param>
    /// <param name="contents">路径</param>
    /// <param name="pngName">图片名字</param>
    /// <returns></returns>
    public bool SaveRenderTextureToPNG(RenderTexture rt, string contents)
    {
        RenderTexture prev = RenderTexture.active;
        RenderTexture.active = rt;
        Texture2D png = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
        png.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        byte[] bytes = png.EncodeToPNG();
        if (!Directory.Exists(contents))
            Directory.CreateDirectory(contents);

        FileStream file = File.Open(contents + "/" + imageName + ".png", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(bytes);
        file.Close();
        Texture2D.DestroyImmediate(png);
        png = null;
        RenderTexture.active = prev;
        return true;
    }

    public void FileDelect(string path)
    {
        File.Delete(path);
    }


    //区域截图
    public void ScreenTexture(Rect m_rect, string contents)
    {
        //需要正确设置好图片保存格式
        Texture2D t = new Texture2D((int)m_rect.width, (int)m_rect.height, TextureFormat.RGB24, true);
        //按照设定区域读取像素；注意是以左下角为原点读取
        t.ReadPixels(m_rect, 0, 0, false);
        t.Apply();
        //二进制转换
        byte[] byt = t.EncodeToPNG();
        int name = GetImageName_Key();
        string imageName = "";
        if (name < 10)
        {
            imageName = "0" + name;
        }
        else
        {
            imageName = name.ToString();
        }
        File.WriteAllBytes(contents + "/" + imageName + ".png", byt);
    }


    //获取文件名字
    public int GetImageName()
    {
        tempInt++;
        return tempInt;
    }

    public int GetImageName_Key()
    {
        object tempInt = "";
        int tempImgName = 0;
        //创建键值对
        RegistryKey RootKey, RegKeyRoot, RegKey;
        //项名为：HKEY_CURRENT_USER
        RootKey = Registry.CurrentUser;
        //判断子项UserSetting
        if ((RegKeyRoot = RootKey.OpenSubKey("UserSetting", true)) == null)
        {
            //创建子项
            RootKey.CreateSubKey("UserSetting");
            RegKeyRoot = RootKey.OpenSubKey("UserSetting", true);
            //如果没有UserSetting子项，说明是第一次运行，那么就先获取当前最后一个文件名
            string path = "C:\\TempImg";
            if (Directory.Exists(path))
            {
                //获取文件信息
                DirectoryInfo direction = new DirectoryInfo(path);
                FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    m_ImgNameKey = int.Parse(files[files.Length - 1].Name);
                }
                else
                {
                    m_ImgNameKey = 0;
                }
            }
            //打开子项：HKEY_CURRENT_USER\UserSetting\ImgName
            if ((RegKey = RegKeyRoot.OpenSubKey("ImgNameSetting", true)) == null)
            {
                //创建子项
                RegKeyRoot.CreateSubKey("ImgNameSetting");
                //打开键值
                RegKey = RegKeyRoot.OpenSubKey("ImgNameSetting", true);
                //获取键值
                tempImgName = m_ImgNameKey + 1;
                RegKey.SetValue("ImgName", tempImgName);
                tempInt = RegKey.GetValue("ImgName");
            }
            else
            {
                //获取键值
                tempImgName = m_ImgNameKey + 1;
                RegKey.SetValue("ImgName", tempImgName);
                tempInt = RegKey.GetValue("ImgName");
            }
        }
        else
        {
            RegKey = RegKeyRoot.OpenSubKey("ImgNameSetting", true);
            //获取键值
            tempInt = RegKey.GetValue("ImgName");
            tempImgName = int.Parse(tempInt.ToString()) + 1;
            RegKey.SetValue("ImgName", tempImgName);
        }
        return tempImgName;
    }

    //获取所有的图片
    public void GetScanceImage()
    {
        string path = "C:\\TempImg";
        if (Directory.Exists(path))
        {
            //获取文件信息
            DirectoryInfo direction = new DirectoryInfo(path);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            for (int i = files.Length - 1; i >= 0; i--)
            {
                allPath.Add(files[i].Name);
            }
            foreach (string str in allPath)
            {
                LoadByIO(str);
            }
            _allPage = allPath.Count / 8;
            _resudue = allPath.Count % 8;
            Invoke("InvokeFindTag", 1f);
        }
    }

    public void InvokeFindTag()
    {
        m_TempImg = GameObject.FindGameObjectsWithTag("TempImg");
    }

    //下一页
    public void ImageNextClothes()
    {
        int end = _index * 8 + 8;
        if (_index == _allPage)
        {
            end = _index * 8 + _resudue;
        }
        for (int i = _index * 8; i < end; i++)
        {
            m_TempImg[i].SetActive(false);
        }
        if (_index >= _allPage - 1)
        {
            _index = _allPage - 1;
        }
        else
        {
            _index++;
        }
    }
    //上一页
    public void ImageBackClothes()
    {
        int end = _index * 8 + 8;
        if (_index == _allPage)
        {
            end = _index * 8 + _resudue;
        }
        for (int i = _index * 8; i < end; i++)
        {
            m_TempImg[i].SetActive(true);
        }
        if (_index <= 0)
        {
            _index = 0;
        }
        else
        {
            _index--;
        }
    }

    //销毁对象
    public void DestroyTempImg()
    {
        allPath.Clear();
        for (int i = 0; i < m_TempImg.Length; i++)
        {
            Destroy(m_TempImg[i]);
        }
    }

    private void LoadByIO(string curpath)
    {
        // double startTime = (double)Time.time;
        //创建文件读取流
        FileStream fileStream = new FileStream("C:\\TempImg/" + curpath, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;
        //创建Texture
        int width = 390;
        int height = 290;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        //创建Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GameObject go = Instantiate(previewPrefab, savePreview);
        go.tag = "TempImg";
        go.GetComponent<Image>().sprite = sprite;
        go.name = Path.GetFileNameWithoutExtension(curpath);
    }
}
