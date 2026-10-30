/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：VideoPanelLogic
* 创建日期：2020-06-04 16:11:53
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：视频显示界面
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class VideoPanelLogic : MVVMLogicBase 
	{
        private VideoSystemLogic video;


        /// <summary>
        /// 打开视频面板
        /// </summary>
        protected virtual void OpenVideoPanel() {
            GetUIBehaviours(this.name).Scale = Vector3.one;
        }

        /// <summary>
        /// 关闭视频面板
        /// </summary>
        protected virtual void CloseVideoPanel() {
            GetUIBehaviours(this.name).Scale = Vector3.zero;
        }

        private void Start()
        {
            video = InjectService.Get<ObjManager>().GetGameObject("Video", "Video").GetComponent<VideoSystemLogic>();
            GetUIBehaviours("VideoValue").AddDownTriggerListener(OnPointerDown);
            GetUIBehaviours("VideoValue").AddUpTriggerListener(OnPointerUp);
        }

        private void OnPointerDown() {
            video.IsSetToUIValue = false;
            video.IsSetToObjValue = true;
        }

        private void OnPointerUp() {
            video.IsSetToUIValue = true;
            video.IsSetToObjValue = false;
        }

        /// <summary>
        /// 加载视频
        /// </summary>
        /// <param name="name"></param>
        public void LoadVideo(string name) {
            OpenVideoPanel();
            GetUIBehaviours("Video").RawImageTexture = video.videoTexture;
            video.LoadVideo(name);
        }

        /// <summary>
        /// 加载视频并自动播放
        /// </summary>
        public void LoadVideoAndPlay(string name) {
            OpenVideoPanel();
            GetUIBehaviours("Video").RawImageTexture = video.videoTexture;
            video.LoadVideo(name,()=> {
                video.PlayOrPause(true);
            });
        }

        /// <summary>
        /// 设置点击关闭键后的回调
        /// </summary>
        /// <param name="endAction"></param>
        public void SetEndAction(UnityAction endAction) {
            SetCallBackAction(endAction);
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
            if (!(evt.EventSource is ViewModel))	return;

			//获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

            //视频播放暂停
            if (vm.name.Equals("VideoSwitch")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                bool newValue = (bool)propertyEvent.NewValue;
                video.PlayOrPause(newValue);
            }
            //视频进度条
            if (vm.name.Equals("VideoValue")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                if (video.IsSetToObjValue)
                {
                    video.VideoTime = newValue * video.VideoMaxTime;
                }
            }
            //关闭按键点击
            if (vm.name.Equals("VideoCloseButton")) {
                CloseVideoPanel();
                video.PlayOrPause(false);
                video.DestoryVideo();
                InvokeCallBackAction();
            }
        }
    }
}
