/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WebDataController
* 创建日期：2021-04-19 15:45:32
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：网络回放数据存储脚本
******************************************************************************/

using UnityEngine;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Collections;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class WebDataController : MonoBehaviour 
	{

        /// <summary>
        /// 读档
        /// </summary>
        public void Read()
        {
            StorageSystemControl storage = InjectService.Get<StorageSystemControl>();
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

