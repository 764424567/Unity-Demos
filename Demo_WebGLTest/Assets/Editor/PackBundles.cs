using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PackBundles : Editor
{
    [MenuItem("AssetBundle/Build_BuildMap_AssetBundles")]
    //单独打包
    static void BuildMapABs()
    {
        //将这些资源包放在一个名为ABs的目录下
        string assetBundleDirectory = "D:\\Frank\\Software\\PHPStudy\\phpstudy_pro\\WWW\\UpLoad\\ABs";
        // 创建映射数组
        AssetBundleBuild[] buildMap = new AssetBundleBuild[9];

        string[] setp4_01 = new string[1];
        setp4_01[0] = "Assets/Prefabs/setp4_01.prefab";
        buildMap[0].assetBundleName = "setp4_01";
        buildMap[0].assetNames = setp4_01;

        string[] setp4_02 = new string[1];
        setp4_02[0] = "Assets/Prefabs/setp4_02.prefab";
        buildMap[1].assetBundleName = "setp4_02";
        buildMap[1].assetNames = setp4_02;

        string[] setp4_03 = new string[1];
        setp4_03[0] = "Assets/Prefabs/setp4_03.prefab";
        buildMap[2].assetBundleName = "setp4_03";
        buildMap[2].assetNames = setp4_03;

        string[] setp4_04 = new string[1];
        setp4_04[0] = "Assets/Prefabs/setp4_04.prefab";
        buildMap[3].assetBundleName = "setp4_04";
        buildMap[3].assetNames = setp4_04;

        string[] setp4_05 = new string[1];
        setp4_05[0] = "Assets/Prefabs/setp4_05.prefab";
        buildMap[4].assetBundleName = "setp4_05";
        buildMap[4].assetNames = setp4_05;

        string[] setp4_06 = new string[1];
        setp4_06[0] = "Assets/Prefabs/setp4_06.prefab";
        buildMap[5].assetBundleName = "setp4_06";
        buildMap[5].assetNames = setp4_06;

        string[] setp4_07 = new string[1];
        setp4_07[0] = "Assets/Prefabs/setp4_07.prefab";
        buildMap[6].assetBundleName = "setp4_07";
        buildMap[6].assetNames = setp4_07;

        string[] setp4_08 = new string[1];
        setp4_08[0] = "Assets/Prefabs/setp4_08.prefab";
        buildMap[7].assetBundleName = "setp4_08";
        buildMap[7].assetNames = setp4_08;

        string[] setp4_09 = new string[1];
        setp4_09[0] = "Assets/Prefabs/setp4_09.prefab";
        buildMap[8].assetBundleName = "setp4_09";
        buildMap[8].assetNames = setp4_09;

        //修改assetBundleName第二个

        //assetBundleName = "herobundle"下的所有资源名称数组
        //string[] heroAssets = new string[1];
        //heroAssets[0] = "Assets/Textures/wall3.jpg";
        //buildMap[1].assetBundleName = "herobundle";
        //buildMap[1].assetNames = heroAssets;

        //如果目录不存在，就创建一个目录
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, buildMap, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows);
        AssetDatabase.Refresh();
    }

    //创建编辑器菜单目录    
    [MenuItem("AssetBundle/Build_All_AssetBundles")]
    //全部打包
    static void BuildABs()
    {
        //将这些资源包放在一个名为ABs的目录下        
        string assetBundleDirectory = "D:\\Frank\\Software\\PHPStudy\\phpstudy_pro\\WWW\\UpLoad\\ABs";
        //如果目录不存在，就创建一个目录        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.WebGL);
        AssetDatabase.Refresh();
    }
}
