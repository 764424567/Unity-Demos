/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： VideoHandler
* 创建日期：2019-08-26 10:56:31
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

namespace Com.Rainier.Buskit3D.Storage
{
    /// <summary>
    /// 回放播放器
    /// </summary>
	public class VideoHandler : MonoBehaviour, IEventListener
    {

        /// <summary>
        /// 帧计数器
        /// </summary>
        private int _frameIndex = 0;

        /// <summary>
        /// 总长度
        /// </summary>
        private int _length;

        /// <summary>
        /// 事件帧列表
        /// </summary>
        private List<int> _eventFrame = new List<int>();

        //eventpool中eventbuffer的index
        private int _bufferIndex = 0;

        // 已播放过的事件数量
        private int _usedEventCount = 0;

        //eventbuffer中even的index编号0-255
        private int _eventIndex = 0;

        //eventbuffer列表
        public EventBuffer[] eventBuffers;

        /// <summary>
        /// 播放进度
        /// </summary>
        private float _percent = 0;
        public float Percent
        {
            get
            {
                return (float)_frameIndex / _length;
            }
            set
            {
                _percent = value;
            }
        }

        /// <summary>
        /// 播放状态 
        /// </summary>
        public bool playState = false;

        private void FixedUpdate()
        {
            if (playState)
            {
                EventPlay();
            }
        }


        /// <summary>
        /// 事件播放器
        /// </summary>
        private void EventPlay()
        {
            int value = _eventFrame[_eventIndex];

            if (value == _frameIndex)
            {
                eventBuffers[_bufferIndex].FromJson(_eventIndex).InokeEventSource();

            //条件1：处理数组越界
            //条件2：如果下一个节点的值与上一个节点的帧值相等，则继续播放一个事件
            //label
            NEXTFRAME:
                if (_eventIndex < eventBuffers[_bufferIndex].Count())
                {

                    _eventIndex += 1;
                    _usedEventCount++;
                    //如果达到了列表最大值
                    if (_eventIndex == eventBuffers[_bufferIndex].Count())
                    {

                        _usedEventCount += _eventIndex;
                        //清除前一个buffer
                        eventBuffers[_bufferIndex].Clear();

                        //进入下一个eventbuffer，开始遍历
                        _bufferIndex += 1;

                        //新的eventBuffer从0开始
                        _eventIndex = 0;

                        //如果是最后一帧，则结束
                        if (_bufferIndex == eventBuffers.Length)
                        {
                            AfterPlay();
                            return;
                        }
                        else
                        {
                            GetBuffer(_bufferIndex);

                        }
                    }

                    //与下一个事件的帧编号相同
                    if (_eventFrame[_eventIndex] == _frameIndex)
                    {
                        eventBuffers[_bufferIndex].FromJson(_eventIndex).InokeEventSource();
                        goto NEXTFRAME;
                    }
                }
            }

            if (Percent == 1)
            {
                AfterPlay();
            }

            _frameIndex += 1;
        }

        /// <summary>
        /// 回放之前事件
        /// </summary>
        private void BeforePlay()
        {

            ScreenMask.ShowMask(new Color(1, 1, 1, 0), MaskType.Image);
            EventPool eventPool = InjectService.Get<EventPool>();

            int maxCount = eventPool.Count();

            eventBuffers = new EventBuffer[maxCount];

            GetBuffer(0);

            //设置长度
            _length = eventPool.lastKeyFrame;
        }

        /// <summary>
        /// 获取一个回放可用的buffer序列
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private void GetBuffer(int index)
        {

            EventPool eventPool = InjectService.Get<EventPool>();
            string item = eventPool.Get(index);
#if UseCompress
            item = ZipUtility.GZipDecompressString(item);
#endif
            EventBuffer buf = new EventBuffer();
            JArray ja = JArray.Parse(item);
            _eventFrame.Clear();
            foreach (var jo in ja)
            {
                buf.RegisterObject(jo as JObject);
                _eventFrame.Add(jo["Frame"].ToObject<int>());
            }
            eventBuffers[index] = buf;
        }

        /// <summary>
        /// 播放结束事件
        /// </summary>
        private void AfterPlay()
        {

            ScreenMask.HideMask();
            EventPool.EnableRecord = true;

            Time.timeScale = 1;

            //结束播放
            playState = false;
            _usedEventCount = 0;
            _eventIndex = 0;
            _bufferIndex = 0;
            InjectService.Get<EventPool>().replayFrameCout = Time.frameCount;

            //删除播放器物体
            Destroy(gameObject, 1f);

            Debug.Log("播放结束");
        }

        /// <summary>
        /// 接收UI事件
        /// </summary>
        /// <param name="evt"></param>
        public void OnEvent(IEvent evt)
        {
            if (evt.EventName.Equals("Enable"))
            {
                Debug.Log("播放器初始化");

                BeforePlay();
            }
            else if (evt.EventName.Equals("Play"))
            {
                //播放
                playState = true;
            }
            else if (evt.EventName.Equals("Pause"))
            {
                //暂停
                playState = false;
            }
            else if (evt.EventName.Equals("Percent"))
            {
                //进度
                MethodEvent mevt = evt as MethodEvent;
                UIReplayView uIReplayView = mevt.Argments[0] as UIReplayView;
                uIReplayView.Percent = this.Percent;
            }
            else if (evt.EventName.Equals("Speed"))
            {
                //速度
                PropertyEvent pevt = evt as PropertyEvent;
                Debug.Log(pevt.NewValue);
                Time.timeScale = (int)pevt.NewValue;
            }
        }
    }
}

