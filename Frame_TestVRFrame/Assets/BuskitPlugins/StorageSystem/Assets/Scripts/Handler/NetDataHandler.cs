/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： NetDataHandler
* 创建日期：2019-08-12 15:02:48
* 作者名称：王庚
* 功能描述：
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Com.Rainier.Buskit3D.Storage
{

    /// <summary>
    /// 从网络平台上传下载实验回放数据
    /// </summary>
	public class NetDataHandler :MonoBehaviour
    {
    

        private void Awake()
        {
          

        }

        private void Start()
        {
          
        }

        /// <summary>
        /// 读档
        /// </summary>
        public void Read()
        {
            StorageSystem storage = InjectService.Get<StorageSystem>();
            string str = "";
            //str=  从接口函数中获取内容
#if UseCompress
                    str = ZipUtility.GZipDecompressString(str);
#endif
            storage.Deserialize(str);
        }

        /// <summary>
        /// 存档
        /// </summary>
        public void Write(string str)
        {
          
#if UseCompress
            str = ZipUtility.GZipCompressString(str);
#endif
           //根据不同平台调用对应的接口函数

        }
    }
}

