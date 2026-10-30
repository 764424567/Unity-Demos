/*******************************************************************************
* 版权所有：北京润尼尔网络科技有限公司
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.Buskit3D
* 类 名 称：StorageSystem
* 创建日期：2016/11/13 下午 05:03:58
* 作者名称: 王志远
* 功能描述：存储系统
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit.Unity.Architecture.Messaging;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{

    /// <summary>
    /// 存储系统
    /// </summary>
    public class StorageSystem
    {
        /// <summary>
        /// 事件对象池
        /// </summary>
        private EventPool _eventPool;

        /// <summary>
        /// 存储系统物体的根节点
        /// </summary>
        public static GameObject rootObj;

        /// <summary>
        /// 存储系统
        /// </summary>
        public StorageSystem()
        {
        }

        /// <summary>
        /// 将EventPool中的子节点全部序列化为string
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            JObject jo = new JObject();

            _eventPool = InjectService.Get<EventPool>();

            _eventPool.PreSave();

            _eventPool.Foreach((i, buf) =>
            {
                jo[i.ToString()] = buf;
            });

            jo["LastKeyFrame"] = _eventPool.lastKeyFrame;
            jo["EventCount"] = _eventPool.eventNumber;

            return jo.ToString();
        }

        /// <summary>
        /// 将数据写入到EventPool的子节点中
        /// </summary>
        /// <param name="result"></param>
        public void Deserialize(string result)
        {
            JObject jo = JObject.Parse(result);

            _eventPool = InjectService.Get<EventPool>();

            _eventPool.Clear();

            int length = jo.Count;

            for (int i = 0; i < length - 2; i++)
            {
                _eventPool.RegisterObject(jo[i.ToString()].ToString());
            }

            _eventPool.lastKeyFrame = jo["LastKeyFrame"].ToObject<int>();
            _eventPool.eventNumber = jo["EventCount"].ToObject<int>();

            InitReplay();
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="evt"></param>
        public void Push(AbstractEvent evt)
        {
            if (_eventPool == null)
            {
                _eventPool = InjectService.Get<EventPool>();

                if (_eventPool == null)
                {
                    InjectService.RegisterSingleton(new EventPool());
                }
            }
            _eventPool.Push(evt);
        }

        /// <summary>
        /// 处理保存场景数据指令
        /// </summary>
        public virtual void BeginSave()
        {
#if LOCAL_MODE
            string objName = "Buskit3D#DataHandler";
            Transform trans = rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject(objName);
                obj.transform.SetParent(rootObj.transform);
                LocalDataHandler local = obj.AddComponent<LocalDataHandler>();
                local.Write(Serialize());
            }
            else
            {
                trans.GetComponent<LocalDataHandler>().Write(Serialize());
            }
#elif LAB_MODE
            string objName = "LabInterSystem";
            
            Transform trans= rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject("Buskit3D#DataHandler");
                obj.transform.SetParent(rootObj.transform);
                NetDataHandler net = obj.AddComponent<NetDataHandler>();
                net.Write(Serialize());
            }
            else
            {
                trans.GetComponent<NetDataHandler>().Write(Serialize());
            }
#endif
        }

        /// <summary>
        /// 处理加载场景数据指令
        /// </summary>
        public virtual void BeginLoad()
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
                LocalDataHandler local = obj.AddComponent<LocalDataHandler>();
                local.Read();
            }
            else
            {
                trans.GetComponent<LocalDataHandler>().Read();
            }


#elif LAB_MODE
             string objName = "LabInterSystem";
           
            Transform trans = rootObj.transform.Find(objName);

            if (trans == null)
            {
                GameObject obj = new GameObject("Buskit3D#DataHandler");
                obj.transform.SetParent(rootObj.transform);
                NetDataHandler net = obj.AddComponent<NetDataHandler>();
                net.Read();
            }
            else
            {
                trans.GetComponent<NetDataHandler>().Read();
            }
#endif
        }

        /// <summary>
        /// 执行回放准备工作
        /// </summary>
        protected virtual void InitReplay()
        {
            //创建UI控制
            //创建播放器
            string objName = "Buskit3D#VideoHandler";
            Transform videoTrans = rootObj.transform.Find(objName);

            if (videoTrans == null)
            {
                GameObject videoObj = new GameObject(objName);
                videoObj.transform.SetParent(rootObj.transform);
                VideoHandler videoHandler = videoObj.AddComponent<VideoHandler>();
                UIReplayView uIReplayView = videoObj.AddComponent<UIReplayView>();
                //绑定监听
                uIReplayView.AddEventListener(videoHandler);
            }
            else
            {

            }
        }
    }
}
