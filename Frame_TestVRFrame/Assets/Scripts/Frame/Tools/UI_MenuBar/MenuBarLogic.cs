/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：MenuBarLogic
* 创建日期：2020-06-03 09:55:58
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：菜单栏逻辑
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.Buskit3D.WebGLInputField;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class MenuBarLogic : MVVMLogicBase 
	{
        public Sprite fullScreenSprite1;
        public Sprite fullScreenSprite2;
        public Sprite fullScreenSprite3;
        public Sprite fullScreenSprite4;

        private string fullScreenName = "Fullscreen";

        private void Start()
        {
#if UNITY_ANDROID || UNITY_IOS
            GetUIBehaviours(fullScreenName).SetActive(false);//移动端无全屏键
#elif UNITY_STANDALONE || UNITY_WEBGL
            if (Screen.fullScreen)
            {
                GetUIBehaviours(fullScreenName).ImageSprite = fullScreenSprite3;
                GetUIBehaviours(fullScreenName).ChangeButtonClickSprite(fullScreenSprite4, fullScreenSprite4, null);
            }
            else
            {
                GetUIBehaviours(fullScreenName).ImageSprite = fullScreenSprite1;
                GetUIBehaviours(fullScreenName).ChangeButtonClickSprite(fullScreenSprite2, fullScreenSprite2, null);
            }
#endif


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

            //设置全屏
            if (vm.name.Equals("Fullscreen"))
            {
                if (Screen.fullScreen)
                {
                    if (Application.platform == RuntimePlatform.WebGLPlayer)
                        WebGLFullScreen.WebSmallScreen();//webGL输入中文的全屏控制
                    Screen.SetResolution(960, 540, false);
                    GetUIBehaviours(fullScreenName).ImageSprite = fullScreenSprite1;
                    GetUIBehaviours(fullScreenName).ChangeButtonClickSprite(fullScreenSprite2, fullScreenSprite2, null);
                }
                else
                {
                    if (Application.platform == RuntimePlatform.WebGLPlayer)
                        WebGLFullScreen.WebFullScreen();
                    Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                    GetUIBehaviours(fullScreenName).ImageSprite = fullScreenSprite3;
                    GetUIBehaviours(fullScreenName).ChangeButtonClickSprite(fullScreenSprite4, fullScreenSprite4, null);
                }
            }
            //设置界面
            if (vm.name.Equals("Setting"))
            {
                GetUIBehaviours("SettingBG").Scale = Vector3.one;
                GetViewModel<SliderViewModel>("StepAudioSlider").Value = SaveValue.StepAudioVolume;
                GetViewModel<SliderViewModel>("BGMAudioSlider").Value = SaveValue.BGMAudioVolume;
                GetViewModel<ToggleViewModel>("BGMAudioToggle").Value = SaveValue.BGMAudioSwitch;

                GetViewModel<SliderViewModel>("MoveSlider").Value = SaveValue.MoveSpeed/5f;
                GetViewModel<SliderViewModel>("RotateSlider").Value = SaveValue.RotateSpeed/2f;
            }
            //设置界面关闭
            if (vm.name.Equals("CloseButton"))
            {
                GetUIBehaviours("SettingBG").Scale = Vector3.zero;
            }
            //帮助界面
            if (vm.name.Equals("Help"))
            {
                GetUIBehaviours("HelpBG").Scale = Vector3.one;
            }
            //帮助界面关闭
            if (vm.name.Equals("HelpCloseButton"))
            {
                GetUIBehaviours("HelpBG").Scale = Vector3.zero;
            }
            //返回首页
            if (vm.name.Equals("HomePage"))
            {
                GetUILogic<LoadSceneLogic>("LoadScene").LoadSceneAsync("StartScene");
            }
            #region 音频设置
            //步骤提示音频音量设置
            if (vm.name.Equals("StepAudioSlider"))
            {
                SliderViewModel slider = vm as SliderViewModel;
                GetObjLogic<AudioSystemLogic>("StepAudio").Volume = slider.Value;
                SaveValue.StepAudioVolume = slider.Value;
            }
            //背景音乐开关
            if (vm.name.Equals("BGMAudioToggle"))
            {
                ToggleViewModel toggle = vm as ToggleViewModel;
                GetObjLogic<AudioSystemLogic>("BGMAudio").IsPlay = toggle.Value;
                SaveValue.BGMAudioSwitch = toggle.Value;
            }
            //背景音乐音量
            if (vm.name.Equals("BGMAudioSlider"))
            {
                SliderViewModel slider = vm as SliderViewModel;
                GetObjLogic<AudioSystemLogic>("BGMAudio").Volume = slider.Value;
                SaveValue.BGMAudioVolume = slider.Value;
            }

            #endregion

            #region 控制设置

            //移动速度设置
            if (vm.name.Equals("MoveSlider"))
            {
                SliderViewModel slider = vm as SliderViewModel;
                if (FindObjectOfType<TPSLogic>())
                {
                    
                    GetObjLogic<TPSLogic>("TPS").MoveSpeed = slider.Value * 5f;
                }
                if (FindObjectOfType<FPSLogic>())
                {
                    GetObjLogic<FPSLogic>("FPS").MoveSpeed = slider.Value * 5f;
                }
                SaveValue.MoveSpeed = slider.Value * 5f;
            }
            //旋转速度设置
            if (vm.name.Equals("RotateSlider"))
            {
                SliderViewModel slider = vm as SliderViewModel;
                if (FindObjectOfType<TPSLogic>())
                {
                    GetObjLogic<TPSLogic>("TPS").RotateSpeed = slider.Value * 2f;
                }
                if (FindObjectOfType<FPSLogic>())
                {

                    GetObjLogic<FPSLogic>("FPS").RotateSpeed = slider.Value * 2f;
                }
                SaveValue.RotateSpeed = slider.Value * 2f;
            }

            #endregion
        }
    }
}
