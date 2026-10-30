using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine.Diagnostics;
using UnityEngine.Networking;
using UnityEditor.PackageManager.Requests;
using UnityEngine.Rendering;

/// <summary>
/// 地图图片管理
/// </summary>
public class MapTextureManager : MonoBehaviour
{
    //避免重复加载  搞一个缓存
    private Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();
    public MapAxesTransfer mapAxesTransfer;
    private List<LoadTextureInfo> LoadInfos = new List<LoadTextureInfo>();

    /// <summary>
    /// 图片地址拼接
    /// </summary>
    /// <param name="zoom">层级</param>
    /// <param name="pieceX">行数</param>
    /// <param name="pieceY">列数</param>
    /// <returns></returns>
    string StitchingPath(int zoom, float pieceX, float pieceY)
    {
        //return "D:/MapData/ImageBaiduData/" + zoom + "/" + (int)pieceX + "/" + (int)pieceY + ".png";
        return @"file://D:/MapData/ImageBaiduData/" + zoom + "/" + (int)pieceX + "/" + (int)pieceY + ".png";
    }
    /// <summary>
    /// 预加载
    /// </summary>
    /// <param name="Pieces">加载中心的块坐标</param>
    public void Preload(Dictionary<int, List<Vector2>> Pieces)
    {
        //先加载小层级
        Dictionary<int, Vector4> zoomToLRPiece = mapAxesTransfer.ZoomToLRPiece(3, 10);
        foreach (var key in zoomToLRPiece.Keys)
        {
            Vector4 bound = zoomToLRPiece[key];
            Vector2 left = new Vector2(bound.x, bound.y);
            Vector2 right = new Vector2(bound.z, bound.w);
            for (int i = (int)left.x; i < right.x + 1; i++)
            {
                for (int j = (int)left.y; j < right.y + 1; j++)
                {
                    string path = StitchingPath(key, i, j);
                    LoadTextureInfo info = new LoadTextureInfo(path, null);
                    LoadInfos.Add(info);
                }
            }
        }
        //加载附近层级以及大层级
        foreach (int zoom in Pieces.Keys)
        {
            foreach (var piece in Pieces[zoom])
            {
                string path = StitchingPath(zoom, piece.x, piece.y);
                LoadTextureInfo info = new LoadTextureInfo(path, null);
                LoadInfos.Add(info);
            }
        }
        LoadSingle();
    }

    /// <summary>
    /// 队列内添加一个加载任务
    /// </summary>
    public void AddLoadTask(int zoom, float pieceX, float pieceY, Action<Sprite> setSprite)
    {
        string path = StitchingPath(zoom, pieceX, pieceY);
        if (Sprites.ContainsKey(path))
        {
            setSprite(Sprites[path]);
        }
        else
        {
            LoadTextureInfo info = new LoadTextureInfo(path, setSprite);
            if (LoadInfos.Count == 0)
            {
                if (!LoadInfos.Contains(info))
                {
                    LoadInfos.Add(info);
                    LoadSingle();
                }
            }
            else
            {
                LoadInfos.Add(info);
            }
        }


    }
    /// <summary>
    /// 开始加载
    /// </summary>
    void LoadSingle()
    {
        if (LoadInfos.Count > 0)
        {
            //StartCoroutine(LoadSpritebywww(LoadInfos[0]));
            //LoadSprite(LoadInfos[0]);
            StartCoroutine(LoadSpriteWebRequest(LoadInfos[0]));
        }
        else
            Resources.UnloadUnusedAssets();
    }

    private IEnumerator LoadSpritebywww(LoadTextureInfo info)
    {
        Debug.Log(info.path);
        using (WWW www = new WWW(info.path))
        {
            yield return www;
            if (www.isDone)
            {
                Debug.Log(www.error);
                if (string.IsNullOrEmpty(www.error))
                {
                    var sprite = Sprite.Create(www.texture, new Rect(0, 0, 256, 256), new Vector2(0, 0), 100);
                    if (info.setSprite != null)
                        info.setSprite(sprite);
                    Sprites[info.path] = sprite;
                }
                else
                {
                    //WD_Debug._Print("错误:  " + www.error);
                }
                if (LoadInfos.Count > 0) LoadInfos.RemoveAt(0);
                LoadSingle();
            }
        }
    }


    private IEnumerator LoadSpriteWebRequest(LoadTextureInfo info)
    {
        Debug.Log(info.path);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(info.path);
        yield return req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(req.error);
        }
        if (req.isDone)
        {
            var sprite = Sprite.Create(DownloadHandlerTexture.GetContent(req), new Rect(0, 0, 256, 256), new Vector2(0, 0), 100);
            if (info.setSprite != null)
                info.setSprite(sprite);
            Sprites[info.path] = sprite;
            if (LoadInfos.Count > 0) LoadInfos.RemoveAt(0);
            LoadSingle();
        }
    }

    private void LoadSprite(LoadTextureInfo info)
    {
        Debug.Log(info.path);
        try
        {
            using (FileStream fileStream = new FileStream(info.path, FileMode.Open, FileAccess.Read))
            {
                //创建文件长度缓冲区
                byte[] bytes = new byte[fileStream.Length];
                //读取文件
                fileStream.Read(bytes, 0, (int)fileStream.Length);
                //释放文件读取流
                fileStream.Close();
                //创建Texture
                int width = 300;
                int height = 372;
                Texture2D texture = new Texture2D(width, height);
                texture.LoadImage(bytes);

                var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), new Vector2(0, 0), 100);
                if (info.setSprite != null)
                    info.setSprite(sprite);
                Sprites[info.path] = sprite;
                if (LoadInfos.Count > 0) LoadInfos.RemoveAt(0);
                LoadSingle();
            }
        }
        catch (Exception e)
        {
            Debug.Log("没有这个文件");
        }
    }

    public class LoadTextureInfo
    {
        public string path;
        public Action<Sprite> setSprite;
        public LoadTextureInfo(string path, Action<Sprite> act)
        {
            this.path = path;
            setSprite = act;
        }
    }
}