using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PutBundles : Editor
{
    [MenuItem("AssetBundle/Alone Bundle")] //在菜单中给出选项
    //单独打包
    static void PutBundleAssetes()
    {
        List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
        //新建一个资源包
        AssetBundleBuild build = new AssetBundleBuild();
        //资源包名字
        build.assetBundleName = "test.unity3d";
        //资源路径
        build.assetNames = new[] { "Assets/Textures/huajianghu.jpg" };
        //添加资源，可以添加多个资源一起打包
        buildMap.Add(build);
        //打包后的资源路径
        BuildPipeline.BuildAssetBundles("Assets/ABs", buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        Debug.Log("打包成功");
    }

    [MenuItem("AssetBundle/All Bundle")] //在菜单中给出选项
    //全部打包
    static void PutBundleAssetes2()
    {
        //路径设置
        BuildPipeline.BuildAssetBundles("Assets/ABs", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

    //创建编辑器菜单目录    
    [MenuItem("AssetBundle/Build Asset Bundles")]
    //全部打包
    static void BuildABs()
    {
        //将这些资源包放在一个名为ABs的目录下        
        string assetBundleDirectory = "Assets/ABs";
        //如果目录不存在，就创建一个目录        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    [MenuItem("AssetBundle/Build Asset Bundles Using BuildMap")]
    //单独打包
    static void BuildMapABs()
    {
        // 创建映射数组
        AssetBundleBuild[] buildMap = new AssetBundleBuild[2];

        //修改assetBundleName第一个
        buildMap[0].assetBundleName = "enemybundle";
        //assetBundleName = "enemybundle"下的所有资源名称数组
        string[] enemyAssets = new string[2];
        enemyAssets[0] = "Assets/Textures/wall1.jpg";
        enemyAssets[1] = "Assets/Textures/wall2.jpg";
        buildMap[0].assetNames = enemyAssets;

        //修改assetBundleName第二个
        buildMap[1].assetBundleName = "herobundle";
        //assetBundleName = "herobundle"下的所有资源名称数组
        string[] heroAssets = new string[1];
        heroAssets[0] = "Assets/Textures/wall3.jpg";
        buildMap[1].assetNames = heroAssets;

        //将这些资源包放在一个名为ABs的目录下
        string assetBundleDirectory = "Assets/ABs";
        //如果目录不存在，就创建一个目录
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    /// <summary>
    /// 将符合条件的全部分包打包（基本没什么卵用）
    /// </summary>
    /// 
    [MenuItem("AssetBundle/GreatBundle")]
    static void GreatBundle()
    {
        Object[] selects = Selection.objects;
        foreach (Object item in selects)
        {
            Debug.Log(item);
            BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets/Manany", BuildAssetBundleOptions.None, BuildTarget.Android);
            AssetDatabase.Refresh();//打包后刷新，不加这行代码的话要手动刷新才可以看得到打包后的Assetbundle包
        }
    }
    /// <summary>
    /// 将选定的多个游戏对象打包一个
    /// </summary>
    /// 
    [MenuItem("AssetBundle/GreatAllBundle")]
    static void GreatAllBundle()
    {
        AssetBundleBuild[] builds = new AssetBundleBuild[1];
        Object[] selects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        string[] TestAsset = new string[selects.Length];
        for (int i = 0; i < selects.Length; i++)
        {
            TestAsset[i] = AssetDatabase.GetAssetPath(selects[i]);
            Debug.Log(TestAsset[i]);
        }
        builds[0].assetNames = TestAsset;
        builds[0].assetBundleName = selects[0].name;
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets/One", builds, BuildAssetBundleOptions.None, BuildTarget.Android);
        AssetDatabase.Refresh();
    }

    [MenuItem("AssetBundle/SetAssetBundleNameExtension")]  //将选定的资源进行统一设置AssetBundle名
    static void SetBundleName()
    {
        Object[] selects = Selection.objects;
        foreach (Object item in selects)
        {
            string path = AssetDatabase.GetAssetPath(item);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            asset.assetBundleName = item.name;//设置Bundle文件的名称
            asset.assetBundleVariant = "asset";//设置Bundle文件的扩展名
            asset.SaveAndReimport();
        }
        AssetDatabase.Refresh();
    }

    //更新资源
    public void Refresh()
    {
        AssetDatabase.Refresh();
    }

    //创建文件夹
    public void CreateFolder(string folderName)
    {
        //没有这个文件就创建
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
        }
    }
}
