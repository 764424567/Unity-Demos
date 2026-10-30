/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LocalDataHandler
* 创建日期：2019-08-12 15:02:48
* 作者名称：王庚
* 功能描述：
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System;
using System.IO;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;
using System.Collections;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 本地文件存储，包含pc端以及网页端
    /// </summary>
	public class LocalDataHandler : MonoBehaviour
    {
        /// <summary>
        /// 文件路径名
        /// </summary>
        public string filePath = "Exp.txt";

        /// <summary>
        /// Web接口
        /// </summary>
        [Inject]
        private IWebGlWebAPIService _webGlWebAPI;

        public void Awake()
        {
            this.filePath = Path.Combine(Application.dataPath, filePath);

            if (InjectService.Get<IWebGlWebAPIService>() == null)
            {
                //初始化web接口
                WebGLWebAPIServiceWapper webApi = new WebGLWebAPIServiceWapper();
                webApi.Initialize();
            }
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 从文本中读取数据内容
        /// </summary>
        /// <returns></returns>
        public void Read()
        {
            string str = "";

#if UNITY_EDITOR || UNITY_STANDALONE
            if (!File.Exists(filePath))
            {
                Debug.Log("文件不存在");
                return;
            }
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(stream);
                str = reader.ReadToEnd();
                reader.Close();
            }
#if UseCompress
            str = ZipUtility.GZipDecompressString(str);
#endif

            //StorageSystem storage = InjectService.Get<StorageSystem>();
            //storage.Deserialize(str);

            StorageSystemControl storage = InjectService.Get<StorageSystemControl>();
            storage.Deserialize(str);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
            _webGlWebAPI.ReadFileFromLocal(gameObject.name, "ReadWebDocument");
#endif
        }

        /// <summary>
        /// 读取web端数据内容
        /// </summary>
        /// <param name="webStr"></param>
        protected void ReadWebDocument(string webStr)
        {
#if UseCompress
            webStr = ZipUtility.GZipDecompressString(webStr);
#endif
            StorageSystem storage = InjectService.Get<StorageSystem>();
            storage.Deserialize(webStr);
        }

        /// <summary>
        /// 将字符串写入文本中
        /// </summary>
        /// <param name="str"></param>
        public void Write(string str)
        {

#if UseCompress
            str = ZipUtility.GZipCompressString(str);
#endif

#if UNITY_EDITOR || UNITY_STANDALONE


            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(str);
                writer.Close();
            }
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
            _webGlWebAPI.SaveStringToLocalFile(str, "Experment.json");
#endif
        }

        private void OnDestroy()
        {
            InjectService.Unregister<WebGLWebAPIServiceWapper>();
        }
    }
}

