/*******************************************************************************
* 版权所有：北京润尼尔网络科技有限公司
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.Buskit3D
* 类 名 称：AssociatedRecordPool
* 创建日期：2016/11/13 下午 05:03:58
* 作者名称: 王志远
* 功能描述：事件池
* 修改记录：
* 日期 描述 更新功能
******************************************************************************/

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 事件缓存
    /// </summary>
    public class EventBuffer : ObjectPool<JObject>
    {
        /// <summary>
        /// 每个节点的最大长度
        /// </summary>
        public static int EventBufferMaxSize = 256;

        /// <summary>
        ///讲jojbect序列化为JArray数组 
        /// </summary>
        /// <returns></returns>
        public JArray ToJson()
        {
            JArray ja = new JArray();
            this.Foreach((i, item) => ja.Add(item));
            return ja;
        }

        /// <summary>
        /// 反序列化一个事件对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractEvent FromJson(int index)
        {

            JObject jObject = objects[index];
            string evtType = objects[index]["EventType"].ToString();


            if (evtType.Equals("Com.Rainier.Buskit3D.PropertyEvent"))
            {
                PropertyEvent pevt = new PropertyEvent();
                pevt.FromJson(jObject);
#if LOCAL_MODE
                Debug.Log(string.Format("还原第 [{0}] 事件， 事件源：{1}，PropertyEvent 属性名称：{2}", index, pevt.EventSource.ToString(), pevt.EventName));
#endif
                return pevt;
            }
            else if (evtType.Equals("Com.Rainier.Buskit3D.MethodEvent"))
            {
                MethodEvent mevt = new MethodEvent();
                mevt.FromJson(jObject);
#if LOCAL_MODE
                Debug.Log(string.Format("还原第 [{0}] 事件，事件源：{1} ，MethodEvent 方法名称：{2}", index, mevt.EventSource.ToString(), mevt.EventName));
#endif
                return mevt;
            }
            throw new Buskit3DException("EventBuffer:FromJson:json format error");
        }

    }

    /// <summary>
    /// 事件池
    /// </summary>
    public class EventPool : ObjectPool<string>
    {
        /// <summary>
        /// 标志是否可以记录事件
        /// </summary>
        public static bool EnableRecord = true;

        /// <summary>
        /// 最后一个事件的关键帧
        /// </summary>
        public int lastKeyFrame = 0;

        /// <summary>
        /// 回放所用的总帧数
        /// </summary>
        public int replayFrameCout = 0;

        /// <summary>
        /// 事件数量
        /// </summary>
        public int eventNumber = 0;

        /// <summary>
        /// 当前正在使用的EventBuffer
        /// </summary>
        public EventBuffer Current
        {
            get
            {
                return _current;
            }
        }
        private EventBuffer _current = new EventBuffer();

        /// <summary>
        /// 获取上一个Buffer
        /// </summary>
        public EventBuffer Previous
        {
            get
            {
                return _previous;
            }
        }
        private EventBuffer _previous = null;

        /// <summary>
        /// Push事件对象
        /// </summary>
        /// <param name="evt"></param>
        public void Push(AbstractEvent evt)
        {
            if (!EnableRecord)
            {
                return;
            }
            JObject obj = evt.ToJson();

            // 首次录制，则为 Time.frameCount, 多次，则追加上次的最后帧数，并减去回放所用帧数
            obj["Frame"] = Time.frameCount + lastKeyFrame - replayFrameCout;
            if (_current.Count() == EventBuffer.EventBufferMaxSize)
            {
                //创建新的buffer
                _previous = _current;
                _current = new EventBuffer();

                //将当前节点存入新的buffer
                _current.RegisterObject(obj);

                string str = _previous.ToJson().ToString();
#if UseCompress
                  //压缩buffer,并存储到内存当中
                str= ZipUtility.GZipCompressString(str);
#endif
                //将buffer加入对象池 
                this.RegisterObject(str);
                return;
            }

            //添加事件
            _current.RegisterObject(obj);
            eventNumber++;
        }

        /// <summary>
        /// 保存场景之前事件
        /// </summary>
        public void PreSave()
        {
            JArray ja = Current.ToJson();
            lastKeyFrame = ja[ja.Count - 1]["Frame"].ToObject<int>();

            string str = ja.ToString();
#if UseCompress
                  //压缩buffer,并存储到内存当中
                str= ZipUtility.GZipCompressString(str);
#endif
            //将buffer加入对象池
            this.RegisterObject(str);

        }

        /// <summary>
        /// 清理所有内容
        /// </summary>
        public override void Clear()
        {
            //foreach(string buf in this.objects)
            //{
            //    buf.Clear();
            //}
            //base.Clear();
            this.objects.Clear();
        }
    }
}
