/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：LoadSceneLogic
* 创建日期：2020-06-03 11:49:23
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：跳转场景功能脚本
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using DG.Tweening;
using Coffee.UIExtensions;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 跳转场景过渡动画种类（具体参考Artworks/Frame/Resources里的模板）
    /// </summary>
    public enum LoadStyle {
        Mod1 = 0,
        Mod2 ,
        Mod3 ,
        Mod4 ,
        Mod5 ,
        Mod6
    }


	/// <summary>
    /// 
    /// </summary>
	public class LoadSceneLogic : MVVMLogicBase 
	{
        private LoadStyle loadStyle = LoadStyle.Mod6;

        /// <summary>
        /// 设置跳场景转换风格（一处修改全局有效）
        /// </summary>
        public LoadStyle LoadStyle {
            get {
                return loadStyle;
            }
            set {
                loadStyle = value;
                SaveValue.LoadStyle = loadStyle;
                loadStyleTex = Resources.Load<Texture>("UIEffectMod" + ((int)loadStyle + 1).ToString());
                effect = transform.GetChild(0).GetComponent<UITransitionEffect>();
                effect.transitionTexture = loadStyleTex;
            }
        }

        private Texture loadStyleTex ;
        private Tween tween;
        private UITransitionEffect effect;

        private AsyncOperation async;
        private bool isLoadScene = false;
        private float tmpProcess = 0f;
        private float nowProcess = 0f;


        private void Start()
        {
            LoadStyle = LoadStyle.Mod5;
            LoadStyle = SaveValue.LoadStyle;
            effect = transform.GetChild(0).GetComponent<UITransitionEffect>();
            effect.transitionTexture = loadStyleTex;
            if (SaveValue.IsUseAsync && !SaveValue.IsFristOpen)
            {
                HideBG();
            }
            SaveValue.IsFristOpen = false;
        }

        private void Update()
        {
            if (isLoadScene)
            {
                if (async.progress < 0.9f)
                {
                    tmpProcess = (int)(async.progress * 100);
                }
                else
                {
                    tmpProcess = 100;
                }
                if (nowProcess < tmpProcess)
                {
                    nowProcess++;
                }
                GetViewModel<SliderViewModel>("LoadSceneSlider").Value = nowProcess / 100f;
                if (nowProcess == 100)
                {
                    isLoadScene = false;
                    async.allowSceneActivation = true;
                    HideBG();
                }
            }
            
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

            //显示进度
            if (vm.name.Equals("LoadSceneSlider"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                GetViewModel<TextViewModel>("LoadSceneText").Value = ((int)(newValue * 100)).ToString() + "%";
            }
        }

        private void ShowBG(UnityAction action) {
            effect.effectFactor = 0;
            GetUIBehaviours("LoadSceneBG").Scale = Vector3.one;
            tween = DOTween.To(() => effect.effectFactor, (x) => effect.effectFactor = x, 1, 1).OnComplete(()=> {
                GetUIBehaviours("LoadSceneBG2").Scale = Vector3.one;
                action();
                tween.Kill();
            }); 
        }

        private void HideBG() {
            effect.effectFactor = 1;
            GetUIBehaviours("LoadSceneBG").Scale = Vector3.one;
            GetUIBehaviours("LoadSceneBG2").Scale = Vector3.zero;
            tween = DOTween.To(() => effect.effectFactor, (x) => effect.effectFactor = x, 0, 1).OnComplete(() => {
                tween.Kill();
                GetUIBehaviours("LoadSceneBG").Scale = Vector3.zero;
            });
        }

        /// <summary>
        /// 异步跳场景
        /// </summary>
        /// <param name="sceneName">场景名</param>
        public void LoadSceneAsync(string sceneName)
        {
            ResetValue();
            SaveValue.IsUseAsync = true;
            ShowBG(()=> {
                GetUIBehaviours("LoadSceneBG2").Scale = Vector3.one;
                isLoadScene = true;
                StartCoroutine(LoadSceneWaitTime(sceneName));
            });
            
            
        }

        private IEnumerator LoadSceneWaitTime(string sceneName)
        {
            async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;
            yield return async;
        }

        /// <summary>
        /// 同步跳场景
        /// </summary>
        /// <param name="sceneName">场景名</param>
        public void LoadScene(string sceneName)
        {
            SaveValue.IsUseAsync = false;
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 重置进度
        /// </summary>
        private void ResetValue() {
            tmpProcess = 0;
            nowProcess = 0;
        }
    }
}
