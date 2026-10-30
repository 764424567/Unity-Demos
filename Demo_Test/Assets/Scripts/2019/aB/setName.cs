using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour
{

    public void LoadSsetBundle()
    {
        //string path2 = Application.dataPath + "/StreamimgAssets/Manany/"+ "cube.data";
        string path2 = Application.streamingAssetsPath + "cube";
        //根据本地文件地址进行加载AssetBundle
        AssetBundle ass2 = AssetBundle.LoadFromFile(path2);
        if (ass2 != null)
        {
            //AssetBundle 加载资源，方法也有同步异步，大家也可以去看下官方文档，跟加载AssetBundle一样
            GameObject obj = ass2.LoadAsset("cube") as GameObject;
            Instantiate(obj);
        }
    }
}
