
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class LoadAllpic : MonoBehaviour
{
    public GameObject StoreObj;

    // 储存获取到的图片  
    List<Texture2D> allTex2d = new List<Texture2D>();

    // Use this for initialization  
    void Start()
    {
        load();
        for (int i = 0; i < allTex2d.Count; i++)
        {
            GameObject temp = GameObject.Instantiate(StoreObj, StoreObj.transform.position, Quaternion.identity);
            temp.GetComponent<Transform>().SetParent(StoreObj.transform.parent);
            Sprite sprite = Sprite.Create(allTex2d[i], new Rect(0, 0, allTex2d[i].width, allTex2d[i].height), new Vector2(0.5f, 0.5f));
            temp.GetComponent<Image>().sprite = sprite;
            temp.transform.name = "Element" + i;
        }
        StoreObj.SetActive(false);
    }


    void load()
    {
        List<string> filePaths = new List<string>();
        string imgtype = "*.BMP|*.JPG|*.GIF|*.PNG";
        string[] ImageType = imgtype.Split('|');
        for (int i = 0; i < ImageType.Length; i++)
        {
            //获取Application.dataPath文件夹下所有的图片路径  
            string[] dirs = Directory.GetFiles(@"C:\\Users\13981\Pictures\Screenshots", ImageType[i]);
            for (int j = 0; j < dirs.Length; j++)
            {
                filePaths.Add(dirs[j]);
            }
        }

        for (int i = 0; i < filePaths.Count; i++)
        {
            Texture2D tx = new Texture2D(100, 100);
            tx.LoadImage(getImageByte(filePaths[i]));
            allTex2d.Add(tx);
        }
    }

    /// <summary>  
    /// 根据图片路径返回图片的字节流byte[]  
    /// </summary>  
    /// <param name="imagePath">图片路径</param>  
    /// <returns>返回的字节流</returns>  
    private static byte[] getImageByte(string imagePath)
    {
        FileStream files = new FileStream(imagePath, FileMode.Open);
        byte[] imgByte = new byte[files.Length];
        files.Read(imgByte, 0, imgByte.Length);
        files.Close();
        return imgByte;
    }
  

}
