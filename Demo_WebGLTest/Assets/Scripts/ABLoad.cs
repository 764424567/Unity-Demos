using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ABLoad : MonoBehaviour
{
    GameObject go;
    bool hadLoad = false;
    GameObject sss;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(Load());
        //LoadSsetBundle();
        //LoadBundle();
        StartCoroutine(AllLoad());
        //for (int i = 1; i < 10; i++)
        //{
        //    string name = "setp4_0" + i;
        //    string path = Path.Combine("http://localhost/UpLoad/ABs/", name);
        //    StartCoroutine(AllLoad(path,name));
        //}
    }


    IEnumerator Load()
    {
        WWW www = new WWW(Path.Combine("http://localhost/UpLoad/ABs/", "cube.unity3d"));
        yield return www;
        if (www.isDone)
        {
            AssetBundle myLoadedAssetBundle = www.assetBundle;
            Debug.Log(www.assetBundle);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
            }
            AssetBundleRequest request = myLoadedAssetBundle.LoadAssetAsync("Cube.prefab", typeof(GameObject));
            go = Instantiate(request.asset as GameObject, new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
            //GameObject prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube.prefab");
            //go = Instantiate(prefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity);
            go.name = "LoadCube";
            myLoadedAssetBundle.Unload(false);
            yield return request;
            if (request.isDone)
            {
                sss = GameObject.Find("LoadCube");
                sss.GetComponent<MeshRenderer>().material.color = new Color(137/155, 128/155, 20 / 155, 155 / 155);
            }
        }
        else
        {
            Debug.Log("数据为空");
        }
    }

    IEnumerator AllLoad(string path,string name)
    {
        WWW www = new WWW(path);
        yield return www;
        if (www.isDone)
        {
            AssetBundle myLoadedAssetBundle = www.assetBundle;
            Debug.Log(www.assetBundle);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
            }
            AssetBundleRequest request = myLoadedAssetBundle.LoadAssetAsync(name, typeof(GameObject));
            go = Instantiate(request.asset as GameObject, new Vector3(0f, 0.5f, 0f), Quaternion.identity) as GameObject;
            go.name = name;
            myLoadedAssetBundle.Unload(false);
            yield return request;
        }
        else
        {
            Debug.Log("数据为空");
        }
    }

    IEnumerator AllLoad()
    {
        WWW www = new WWW(Path.Combine("http://localhost/UpLoad/ABs/", "modelfitting.unity3d"));
        yield return www;
        if (www.isDone)
        {
            AssetBundle myLoadedAssetBundle = www.assetBundle;
            Debug.Log(www.assetBundle);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("加载资产包失败!");
            }
            AssetBundleRequest request = myLoadedAssetBundle.LoadAllAssetsAsync();
            Object[] obj = request.allAssets;
            foreach (Object o in obj)
            {
                go = Instantiate(o) as GameObject;
                go.name = o.name;
            }
            myLoadedAssetBundle.Unload(false);
            yield return request;
            if (request.isDone)
            {
                sss = GameObject.Find("fenghehou");
                sss.GetComponent<MeshRenderer>().material.color=new Color(255/255,155/255,255/255,1);
            }
        }
        else
        {
            Debug.Log("数据为空");
        }
    }

    public void LoadBundle()
    {
        //从文件夹里加载包
        AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine("C:/ABs/", "cube.unity3d"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        //从Bundle包中加载名字为：MyObject的资源，加载为GameObject
        GameObject prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube.prefab");
        //实例化
        go =Instantiate(prefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        //卸载包中资源的内存
        myLoadedAssetBundle.Unload(false);
    }
}
