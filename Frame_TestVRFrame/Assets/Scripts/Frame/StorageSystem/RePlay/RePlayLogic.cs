/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：RePlayLogic
* 创建日期：2021-04-19 09:18:52
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：回放系统播放器
******************************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;
using Com.Rainier.Buskit3D.Storage;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class RePlayLogic : MVVMLogicBase 
	{
        /// <summary>
        /// 帧计数器
        /// </summary>
        private int frameIndex = 0;

        /// <summary>
        /// 总长度
        /// </summary>
        private int length;

        /// <summary>
        /// 事件帧列表
        /// </summary>
        private List<int> eventFrame = new List<int>();

        //eventpool中eventbuffer的index
        private int bufferIndex = 0;

        // 已播放过的事件数量
        private int usedEventCount = 0;

        //eventbuffer中even的index编号0-255
        private int eventIndex = 0;

        //eventbuffer列表
        public EventBuffer[] eventBuffers;

        /// <summary>
        /// 是否在播放
        /// </summary>
        private bool isPlaying = false;

        /// <summary>
        /// 播放进度
        /// </summary>
        private float _percent = 0;
        public float Percent
        {
            get
            {
                return (float)frameIndex / length;
            }
            set
            {
                _percent = value;
            }
        }

        /// <summary>
        /// 播放状态 
        /// </summary>
        private bool playState = false;

        /// <summary>
        /// 播放状态
        /// </summary>
        public bool PlayState {
            get { return playState; }
            set { playState = value; SaveValue.StorageState = value; }
        }

        private void Start()
        {
            AddEntity<RePlayEntity>();
            GetUIBehaviours("PauseButton").Scale = Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (PlayState)
            {
                EventPlay();
            }
        }

        private void OnDestroy()
        {
            RemoveEntity<RePlayEntity>();
        }

        /// <summary>
        /// 事件播放器
        /// </summary>
        private void EventPlay()
        {
            int value = eventFrame[eventIndex];

            if (value == frameIndex)
            {
                eventBuffers[bufferIndex].FromJson(eventIndex).InokeEventSource();

            //条件1：处理数组越界
            //条件2：如果下一个节点的值与上一个节点的帧值相等，则继续播放一个事件
            //label
            NEXTFRAME:
                if (eventIndex < eventBuffers[bufferIndex].Count())
                {

                    eventIndex += 1;
                    usedEventCount++;
                    //如果达到了列表最大值
                    if (eventIndex == eventBuffers[bufferIndex].Count())
                    {

                        usedEventCount += eventIndex;
                        //清除前一个buffer
                        eventBuffers[bufferIndex].Clear();

                        //进入下一个eventbuffer，开始遍历
                        bufferIndex += 1;

                        //新的eventBuffer从0开始
                        eventIndex = 0;

                        //如果是最后一帧，则结束
                        if (bufferIndex == eventBuffers.Length)
                        {
                            AfterPlay();
                            return;
                        }
                        else
                        {
                            GetBuffer(bufferIndex);

                        }
                    }

                    //与下一个事件的帧编号相同
                    if (eventFrame[eventIndex] == frameIndex)
                    {
                        eventBuffers[bufferIndex].FromJson(eventIndex).InokeEventSource();
                        goto NEXTFRAME;
                    }
                }
            }
            GetViewModel<SliderViewModel>("ReplayValue").Value = Percent;
            if (Percent == 1)
            {
                AfterPlay();
            }

            frameIndex += 1;
        }

        /// <summary>
        /// 打开回放播放器
        /// </summary>
        public void OpenRePlayPanel() {
            BeforePlay();
            GetUIBehaviours(transform.name).Scale = Vector3.one;
        }

        /// <summary>
        /// 回放之前事件
        /// </summary>
        private void BeforePlay()
        {
            Debug.Log("播放器初始化");
            //ScreenMask.ShowMask(new Color(1, 1, 1, 0), MaskType.Image);
            EventPool eventPool = InjectService.Get<EventPool>();

            int maxCount = eventPool.Count();

            eventBuffers = new EventBuffer[maxCount];

            GetBuffer(0);

            //设置长度
            length = eventPool.lastKeyFrame;
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
            eventFrame.Clear();
            foreach (var jo in ja)
            {
                buf.RegisterObject(jo as JObject);
                eventFrame.Add(jo["Frame"].ToObject<int>());
            }
            eventBuffers[index] = buf;
        }

        /// <summary>
        /// 播放结束事件
        /// </summary>
        private void AfterPlay()
        {
            //ScreenMask.HideMask();
            EventPool.EnableRecord = true;

            Time.timeScale = 1;

            //结束播放
            PlayState = false;
            usedEventCount = 0;
            eventIndex = 0;
            bufferIndex = 0;
            InjectService.Get<EventPool>().replayFrameCout = Time.frameCount;

            //删除播放器物体
            Destroy(gameObject, 1f);

            Debug.Log("播放结束");
        }

        private void Play()
        {
            GetEntity<RePlayEntity>().Play();
        }

        private void Pause() {
            GetEntity<RePlayEntity>().Pause();
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable")|| evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable"))	return;

            //忽略除ViewModel外其他Entity发出的事件
            if (evt.EventSource is ViewModel)
            {
                ViewModel vm = evt.EventSource as ViewModel;
                if (vm.name.Equals("PlayButton"))
                {
                    if (!isPlaying)
                    {
                        isPlaying = true;
                        Play();
                        GetUIBehaviours("PlayButton").Scale = Vector3.zero;
                        GetUIBehaviours("PauseButton").Scale = Vector3.one;
                    }
                }
                else if (vm.name.Equals("PauseButton"))
                {
                    if (isPlaying)
                    {
                        isPlaying = false;
                        Pause();
                        GetUIBehaviours("PauseButton").Scale = Vector3.zero;
                        GetUIBehaviours("PlayButton").Scale = Vector3.one;
                    }
                }
                else if (vm.name.Equals("Speed1"))
                {
                    ToggleViewModel toggle = vm as ToggleViewModel;
                    if (toggle.Value)
                    {
                        Time.timeScale = 1;
                    }
                }
                else if (vm.name.Equals("Speed2"))
                {
                    ToggleViewModel toggle = vm as ToggleViewModel;
                    if (toggle.Value)
                    {
                        Time.timeScale = 2;
                    }
                }
                else if (vm.name.Equals("Speed3"))
                {
                    ToggleViewModel toggle = vm as ToggleViewModel;
                    if (toggle.Value)
                    {
                        Time.timeScale = 3;
                    }
                }
            }	
             if (evt.EventName.Equals("Play"))
            {
                //播放
                PlayState = true;
            }
            else if (evt.EventName.Equals("Pause"))
            {
                //暂停
                PlayState = false;
            }
        }
    }
}
