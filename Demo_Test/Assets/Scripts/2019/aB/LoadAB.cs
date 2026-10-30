using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAB : MonoBehaviour
{
    GameObject go;
    bool hadLoad = false;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(Load());
        //LoadSsetBundle();
        LoadBundle();
    }


    IEnumerator Load()
    {
        //从远程服务器上进行下载和加载
        //WWW www = new WWW("ftp://123.778.**"或者"http://www.baidu.com");

        //从本地文件中加载
        //WWW www = new WWW("file://E:/Projects/Games/Resources/Assets/MyBundles/cube.unity3d");

        WWW www = new WWW("file://D:/Frank/UnityProject/Demo-1/Assets/ABs/cube01.unity3d");

        yield return www;

        AssetBundle bundle = www.assetBundle;

        AssetBundleRequest request = bundle.LoadAssetAsync("Cube.prefab", typeof(GameObject));

        go = Instantiate(request.asset as GameObject, new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;

        yield return request;

        www.Dispose();
        hadLoad = true;
    }

    public void LoadSsetBundle()
    {
        //string path2 = Application.dataPath + "/StreamimgAssets/Manany/"+ "cube.data";
        string path2 = Application.streamingAssetsPath + "/cube01.unity3d";
        //根据本地文件地址进行加载AssetBundle
        //AssetBundle ass1= AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "cube01.unity3d"));
        AssetBundle ass2 = AssetBundle.LoadFromFile(path2);
        if (ass2 != null)
        {
            //AssetBundle 加载资源，方法也有同步异步，大家也可以去看下官方文档，跟加载AssetBundle一样
            GameObject obj = ass2.LoadAsset("Cube.prefab") as GameObject;
            go = Instantiate(obj, new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
            ass2.Unload(false);
        }
        else
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
    }

    public void LoadBundle()
    {
        //从文件夹里加载包
        AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "cube01.unity3d"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        //从Bundle包中加载名字为：MyObject的资源，加载为GameObject
        GameObject prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube.prefab");
        //实例化
        Instantiate(prefab);
        //卸载包中资源的内存
        myLoadedAssetBundle.Unload(false);
    }
}
