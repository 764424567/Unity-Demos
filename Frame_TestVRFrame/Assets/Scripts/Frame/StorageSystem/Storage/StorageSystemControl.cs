/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StorageSystemControl
* 创建日期：2021-04-14 14:40:22
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：回放系统总控脚本
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D.Storage;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class StorageSystemControl : StorageSystem 
	{

        /// <summary>
        /// 存档数据处理
        /// </summary>
        public override void BeginSave()
        {
#if LOCAL_MODE
            string objName = "Buskit3D#DataHandler";
            Transform trans = rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject(objName);
                obj.transform.SetParent(rootObj.transform);
                LocalDataController local = obj.AddComponent<LocalDataController>();
                local.Write(Serialize());
            }
            else
            {
                trans.GetComponent<LocalDataController>().Write(Serialize());
            }
#elif LAB_MODE
            string objName = "LabInterSystem";
            
            Transform trans= rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject("Buskit3D#DataHandler");
                obj.transform.SetParent(rootObj.transform);
                WebDataController net = obj.AddComponent<WebDataController>();
                net.Write(Serialize());
            }
            else
            {
                trans.GetComponent<WebDataController>().Write(Serialize());
            }
#endif
        }

        /// <summary>
        /// 初始化回放
        /// </summary>
        public override void BeginLoad()
        {
            EventPool.EnableRecord = false;
#if LOCAL_MODE
            string objName = "Buskit3D#DataHandler";

            GameObject obj = null;
            Transform trans = rootObj.transform.Find(objName);
            if (trans == null)
            {
                obj = new GameObject(objName);
                obj.transform.SetParent(rootObj.transform);
                LocalDataController local = obj.AddComponent<LocalDataController>();
                local.Read();
            }
            else
            {
                trans.GetComponent<LocalDataController>().Read();
            }


#elif LAB_MODE
             string objName = "LabInterSystem";
           
            Transform trans = rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject("Buskit3D#DataHandler");
                obj.transform.SetParent(rootObj.transform);
                WebDataController net = obj.AddComponent<WebDataController>();
                net.Read();
            }
            else
            {
                trans.GetComponent<WebDataController>().Read();
            }
#endif
        }

        /// <summary>
        /// 回放系统控制初始化
        /// </summary>
        protected override void InitReplay()
        {
            

            RePlayLogic replayPanel = InjectService.Get<UIManager>().GetUIBehaviours("RePlayPanel", "RePlayPanel").GetComponent<RePlayLogic>();
            replayPanel.OpenRePlayPanel();


            //创建UI控制
            //创建播放器
            //string objName = "RePlayPanel";
            //Transform videoTrans = rootObj.transform.Find(objName);

            //if (videoTrans == null)
            //{
                //GameObject videoObj = new GameObject(objName);
                //videoObj.transform.SetParent(rootObj.transform);
                //VideoHandler videoHandler = videoObj.AddComponent<VideoHandler>();
                //UIReplayView uIReplayView = videoObj.AddComponent<UIReplayView>();
                //绑定监听
                //uIReplayView.AddEventListener(videoHandler);
            //}
            //else
            //{

            //}
        }
    }
}

