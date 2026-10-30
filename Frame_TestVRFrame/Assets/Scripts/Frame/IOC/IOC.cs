/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： IOC
* 创建日期：2020-05-26 11:53:14
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

//是否使用保存回放系统
#define UNUSE_STORAGESYSTEM

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.Storage;
using Com.Rainier.Buskit3D;
using UnityEngine;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class IOC: MonoBehaviour
    {
        private void Awake()
        {
            if (InjectService.Get<UIManager>() == null)
            {
                InjectService.RegisterSingleton(new UIManager());
            }
            if (InjectService.Get<ObjManager>() == null)
            {
                InjectService.RegisterSingleton(new ObjManager());
            }
            if (InjectService.Get<StepManager>() == null)
            {
                InjectService.RegisterSingleton(new StepManager());
            }
            if (InjectService.Get<ExamManager>() == null)
            {
                InjectService.RegisterSingleton(new ExamManager());
            }
            if (InjectService.Get<WebStepInforManager>() == null)
            {
                InjectService.RegisterSingleton(new WebStepInforManager());
            }
#if USE_STORAGESYSTEM
            //回放系统
            if (InjectService.Get<EventPool>() == null)
            {
                InjectService.RegisterSingleton(new EventPool());
            }
            if (InjectService.Get<StorageSystemControl>() == null)
            {
                InjectService.RegisterSingleton(new StorageSystemControl());

                StorageSystem.rootObj = Instantiate(Resources.Load<GameObject>("Buskit3D#Root"));
                StorageSystem.rootObj.name = "Buskit3D#Root";
                StorageSystem.rootObj.AddComponent<DondestoryOnLoad>();
            }
#endif
#if UNITY_ANDROID || UNITY_IOS
            if (InjectService.Get<TouchManager>() == null)
            {
                InjectService.RegisterSingleton(new TouchManager());
            }
#endif
        }

        private void Start()
        {
            GameObject[] childTrans = GameObject.FindGameObjectsWithTag(ObjectTag.Tag);
            for (int i = 0; i < childTrans.Length; i++)
            {
                if (!childTrans[i].GetComponent<ObjBehaviours>())
                {
                    childTrans[i].AddComponent<ObjBehaviours>();
                }
            }
        }

        private void Update()
        {
#if USE_STORAGESYSTEM
            if (Input.GetKeyDown(KeyCode.P))
            {
                InjectService.Get<UIManager>().GetUIBehaviours("StoragePanel", "StoragePanel").GetComponent<StoragePanelLogic>().OpenStoragePanel();
            }
#endif
        }
    }
}

