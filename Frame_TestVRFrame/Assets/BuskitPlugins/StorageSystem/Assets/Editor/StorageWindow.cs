
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StorageWindow
* 创建日期：2019-03-27 14:30:24
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 设置相关属性
    /// </summary>
	public class StorageWindow : EditorWindow
    {

        private string url1 = string.Empty;
        private string url2 = string.Empty;
        private string url3 = string.Empty;

        /// <summary>
        /// 绘制窗口条目.
        /// </summary>
        private void OnGUI()
        {

            //绘制URL信息 
            url1 = EditorGUILayout.TextField("URL1", url1);
            url2 = EditorGUILayout.TextField("URL2", url2);
            url3 = EditorGUILayout.TextField("URL3", url3);
            GUILayout.Space(20);
            if (GUILayout.Button("Ok"))
            {
                Close();
            }
        }
    }

    /// <summary>
    /// 设置相关宏.
    /// </summary>
    public class DefineMenu
    {
        /// <summary>
        /// 本地存储模式
        /// </summary>
        private const string LocalMode = "LOCAL_MODE";

        /// <summary>
        /// 本地存储带有测试文件
        /// </summary>
        //private const string LocalDebugMode = "Local_Mode_Debug";

        /// <summary>
        /// 平台存储模式
        /// </summary>
        private const string LabMode = "LAB_MODE";


        /// <summary>
        /// 设置宏定义
        /// </summary>
        /// <param name="defineStr"></param>
        public static void SaveMacro(string defineStr)
        {

#if UNITY_STANDALONE
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defineStr);
#endif
#if UNITY_WEBGL
             PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL,defineStr);
#endif
#if UNITY_WEBPLAYER
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer, defineStr);
#endif
        }

        /// <summary>
        /// 设置宏定义
        /// </summary>
        /// <param name="defineStr"></param>
        public static void SaveMacro(string[] defineStr)
        {

            string Macro = "";


            foreach (var item in defineStr)
            {
                Macro += string.Format("{0};", item);
            }
#if UNITY_STANDALONE
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, Macro);
#endif
#if UNITY_WEBGL
             PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL,Macro);
#endif
#if UNITY_WEBPLAYER
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer, Macro);
#endif
        }

        /// <summary>
        /// 获取当前宏定义
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMacro()
        {
            string macro = "";

#if UNITY_STANDALONE
            macro = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
#endif
#if UNITY_WEBGL
            macro= PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL);
#endif
#if UNITY_WEBPLAYER
             macro= PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer);
#endif
            if (string.IsNullOrEmpty(macro))
            {
                return new List<string>();
            }
            if (macro.Contains(";"))
            {
                return new List<string>(macro.Split(';'));
            }
            return new List<string>() { macro };
        }

        #region 设置存储宏定义
        [MenuItem("Rainier/StorageSystem/数据存储/本地")]
        public static void ToLocalModeRelease()
        {
            //string[] marco = DeleteMarco(new string[] { LabMode, LocalMode });

            List<string> marco = GetMacro();

            if (marco.Contains(LabMode))
            {
                marco.Remove(LabMode);
            }
            if (marco.Contains(LocalMode))
            {
                marco.Remove(LocalMode);
            }
            marco.Add(LocalMode);

            SaveMacro(marco.ToArray());
        }

        [MenuItem("Rainier/StorageSystem/数据存储/平台")]
        public static void ToLabMode()
        {
            List<string> marco = GetMacro();

            if (marco.Contains(LabMode))
            {
                marco.Remove(LabMode);
            }
            if (marco.Contains(LocalMode))
            {
                marco.Remove(LocalMode);
            }
            marco.Add(LabMode);

            SaveMacro(marco.ToArray());
        }


#if UseCompress
         [MenuItem("Rainier/StorageSystem/数据存储/测试版")]
        public static void ToReleaseMode()
        {
            //DeleteMarco("UseCompress");
            List<string> marco = GetMacro();

            if (marco.Contains("UseCompress"))
            {
                marco.Remove("UseCompress");
            }

            SaveMacro(marco.ToArray());
        }
#else
        [MenuItem("Rainier/StorageSystem/数据存储/发布版")]
        public static void ToReleaseMode()
        {
            List<string> marco = GetMacro();

            if (marco.Contains("UseCompress"))
            {
                marco.Remove("UseCompress");
            }

            marco.Add("UseCompress");
            SaveMacro(marco.ToArray());
        }
#endif
        #endregion

    }
}

