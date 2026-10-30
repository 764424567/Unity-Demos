/*******************************************************************************
* 版权所有：北京润尼尔网络科技有限公司
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.Buskit3D
* 类 名 称：StorageSystem
* 创建日期：2019/11/13 下午 05:03:58
* 作者名称: 王庚
* 功能描述：存储系统初始化配置
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

//是否可用
#define UNUSE_STORAGE

# if USE_STORAGE

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 存储系统初始化配置
    /// </summary>
    public class StorageConfigSettings 
    {

        /// <summary>
        /// 在Awake之后start之前初始化 存储系统需要处理的业务逻辑
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            //初始化事件对象池
            if (InjectService.Get<EventPool>() == null)
            {
                InjectService.RegisterSingleton(new EventPool());
            }

            if (InjectService.Get<StorageSystem>() == null)
            {
                //创建StorageSystem实例，或者是继承自StorageSystem的子类 
                InjectService.RegisterSingleton(new StorageSystem());
                //初始化根节点
                StorageSystem.rootObj = new GameObject("Buskit3D#Root");
                StorageSystem.rootObj.AddComponent<DondestoryOnLoad>();
                StorageSystem.rootObj.AddComponent<UIStorageView>();

                //云渲染开启
                //QualitySettings.vSyncCount = 1;
                //Application.targetFrameRate = 60;
            }
        }
    }

}
#endif