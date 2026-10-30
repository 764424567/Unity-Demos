/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UIBehaviours
* 创建日期：2020-05-26 11:30:21
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Coffee.UIExtensions;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class UIBehaviours : MonoBehaviour 
	{
        
        private MVVMLogicBase tmpBase;

        

        private void Awake()
        {
            tmpBase = gameObject.GetComponentInParent<MVVMLogicBase>();
            try
            {
                InjectService.Get<UIManager>().SaveGameObject(tmpBase.name, transform.name, this);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("请检查是否初始化IOC");
            }
        }

        private void OnDestroy()
        {
            InjectService.Get<UIManager>().DeleteGameObject(tmpBase.name,transform.name);
        }

        #region UI特效
        /// <summary>
        /// 初始化高亮特效
        /// </summary>
        private void InitializeUIHighlight() {
            UIEffect effect;
            UIShadow shadow;
            if (!GetComponent<UIEffect>())
            {
                gameObject.AddComponent<UIEffect>();
            }
            if (!GetComponent<UIShadow>())
            {
                gameObject.AddComponent<UIShadow>();
            }
            effect = GetComponent<UIEffect>();
            shadow = GetComponent<UIShadow>();
            effect.effectMode = EffectMode.None;
            effect.colorMode = ColorMode.Fill;
            effect.colorFactor = 0f;
            effect.blurMode = BlurMode.DetailBlur;
            effect.blurFactor = 0f;
            effect.advancedBlur = false;
            shadow.style = ShadowStyle.Outline8;
            shadow.effectDistance = new Vector2(2, 2);
            shadow.effectColor = new Color(SaveValue.HighlightColor.r, SaveValue.HighlightColor.g, SaveValue.HighlightColor.b, 0f);
            shadow.useGraphicAlpha = false;
            shadow.blurFactor = 1;
        }

        private Tween tweenerColor;
        private Tween tweenerDistance;

        /// <summary>
        /// 设置UI高亮
        /// </summary>
        /// <param name="isLight"></param>
        public void SetUIHighlight(bool isLight) {
            Color tweenColor = new Color(SaveValue.HighlightColor.r, SaveValue.HighlightColor.g, SaveValue.HighlightColor.b, 0.6f);
            if (!GetComponent<UIEffect>())
            {
                InitializeUIHighlight();
            }
            UIShadow shadow = GetComponent<UIShadow>();
            if (isLight)
            {
                tweenerColor = DOTween.To(() => shadow.effectColor, (x) => shadow.effectColor = x, tweenColor, 1).SetLoops(-1, LoopType.Yoyo);
                tweenerDistance = DOTween.To(() => shadow.effectDistance, (x) => shadow.effectDistance = x, new Vector2(4, 4), 1).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                tweenerColor.Kill();
                tweenerDistance.Kill();
                Destroy(shadow);
                Destroy(GetComponent<UIEffect>());
            }
        }

        private GameObject uiFrame;
        private Tween tween;

        /// <summary>
        /// 设置UI框高亮
        /// </summary>
        /// <param name="isLight"></param>
        public void SetUIFrameHighlight(bool isLight)
        {
            if (isLight)
            {
                if (uiFrame == null)
                {
                    uiFrame = LoadUIHighlightFrame("UIHighLight");
                    uiFrame.transform.SetParent(this.transform, false);
                    uiFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(WidthAndHeight.x + 2, WidthAndHeight.y + 2); 
                    uiFrame.transform.localPosition = Vector3.zero;
                    uiFrame.transform.localEulerAngles = Vector3.zero;
                }
                tween = uiFrame.GetComponent<Image>().DOColor(SaveValue.HighlightColor, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                if (uiFrame != null)
                {
                    tween.Pause();
                    tween.Kill();
                    Destroy(uiFrame);
                }
            }
        }

        /// <summary>
        /// 加载UI框
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private GameObject LoadUIHighlightFrame(string path) {
            GameObject loadObject = Instantiate(Resources.Load<GameObject>(path));
            loadObject.name = loadObject.name.Remove(loadObject.name.Length - 7);
            loadObject.transform.SetParent(tmpBase.transform, false);
            return loadObject;
        }

        #endregion

        #region Animator

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animeName">动画名称</param>
        public void PlayAnime(string animeName)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, 0);
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="action">回调</param>
        public void PlayAnime(string animeName, UnityAction action)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = 1;
            float animeTime = GetAnimeClipTime(tmpAni, animeName);
            tmpAni.Play(animeName, 0, 0);
            StartCoroutine(WaitTime(tmpAni, animeTime, action));
        }

        /// <summary>
        /// 播放动画（可调倍速，速度大于等于0）
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="speed">速度</param>
        /// <param name="action">回调</param>
        public void PlayAnime(string animeName, float speed, UnityAction action)
        {
            if (speed < 0)
            {
                Debug.Log("此方法不适用倒播动画。");
                return;
            }
            Animator tmpAni = transform.GetComponent<Animator>();
            tmpAni.speed = speed;
            float animeTime = GetAnimeClipTime(tmpAni, animeName) / speed;
            tmpAni.Play(animeName, 0, 0);
            StartCoroutine(WaitTime(tmpAni, animeTime, action));
        }

        /// <summary>
        /// 播放动画片段
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName);
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time));
        }

        /// <summary>
        /// 播放动画帧
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="normalized">所在百分比(0-1)</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame, float normalized)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            normalized = Mathf.Clamp(normalized, 0, 1f);
            float stateNormalized = (startFrame + ((endFrame - startFrame) * normalized)) / GetAnimeClipFrame(tmpAni, animeName);
            tmpAni.speed = 0;
            tmpAni.Play(animeName, 0, stateNormalized);
        }

        /// <summary>
        /// 播放动画片段
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="action">回调</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame, UnityAction action)
        {
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName);
            tmpAni.speed = 1;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time, action));
        }

        /// <summary>
        /// 播放动画片段（可调倍速，速度大于等于0）
        /// </summary>
        /// <param name="animeName">动画名称</param>
        /// <param name="startFrame">开始帧数</param>
        /// <param name="endFrame">结束帧数</param>
        /// <param name="speed">播放速度（不能为负）</param>
        /// <param name="action">回调</param>
        public void PlayAnimePart(string animeName, float startFrame, float endFrame, float speed, UnityAction action)
        {
            if (speed < 0)
            {
                Debug.Log("此方法不适用倒播动画。");
                return;
            }
            Animator tmpAni = transform.GetComponent<Animator>();
            float normalized = startFrame / GetAnimeClipFrame(tmpAni, animeName);
            float time = (Mathf.Abs(endFrame - startFrame) * GetAnimeClipSPF(tmpAni, animeName)) / speed;
            tmpAni.speed = speed;
            tmpAni.Play(animeName, 0, normalized);
            StartCoroutine(WaitTime(tmpAni, time, action));
        }

        /// <summary>
        /// 等待时间
        /// </summary>
        /// <param name="tmpani">动画组件</param>
        /// <param name="time">时间</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        private IEnumerator WaitTime(Animator tmpani, float time, UnityAction func)
        {
            yield return new WaitForSeconds(time);
            tmpani.speed = 0;
            if (func != null)
            {
                func();
            }
        }

        /// <summary>
        /// 等待时间
        /// </summary>
        /// <param name="tmpani">动画组件</param>
        /// <param name="time">时间</param>
        /// <returns></returns>
        private IEnumerator WaitTime(Animator tmpani, float time)
        {
            yield return new WaitForSeconds(time);
            tmpani.speed = 0;
        }

        /// <summary>
        /// 获取动画片段总帧数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private float GetAnimeClipFrame(Animator animator, string name)
        {
            float frame = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return frame = clips[i].frameRate * clips[i].length;
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取动画片段秒率(帧率分之一)
        /// </summary>
        /// <param name="name">动画片段名</param>
        /// <returns></returns>
        private float GetAnimeClipSPF(Animator animator, string name)
        {
            float spf = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return spf = 1 / clips[i].frameRate;
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取动画片段时长
        /// </summary>
        /// <param name="name">动画名</param>
        /// <returns></returns>
        private float GetAnimeClipTime(Animator animator, string name)
        {
            float time = 0;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(name))
                {
                    return time = clips[i].length;
                }
            }
            return 0;
        }
        #endregion

        #region Button组件
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="action">方法</param>
        public void AddButtonListener(UnityAction action)
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                tmpButton.onClick.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }

        /// <summary>
        /// 移除指定按键点击事件
        /// </summary>
        /// <param name="action"></param>
        public void RemoveButtonListener(UnityAction action)
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                tmpButton.onClick.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }

        /// <summary>
        /// 移除所有点击事件
        /// </summary>
        public void RemoveButtonListener()
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                tmpButton.onClick.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }

        /// <summary>
        /// 替换按钮点击过度图片
        /// </summary>
        /// <param name="highlighted">触碰时的图片</param>
        /// <param name="pressed">按下时的图片</param>
        /// <param name="disabled">禁用时的图片</param>
        public void ChangeButtonClickSprite(Sprite highlighted, Sprite pressed, Sprite disabled)
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                if (tmpButton.transition.Equals(Selectable.Transition.SpriteSwap))
                {
                    SpriteState tmpspriteState = new SpriteState();
                    tmpspriteState.highlightedSprite = highlighted;
                    tmpspriteState.pressedSprite = pressed;
                    tmpspriteState.disabledSprite = disabled;
                    tmpButton.spriteState = tmpspriteState;
                }
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }

        /// <summary>
        /// 设置按键点击过度为图片替换模式
        /// </summary>
        /// <param name="highlighted">触碰时的图片</param>
        /// <param name="pressed">按下时的图片</param>
        /// <param name="disabled">禁用时的图片</param>
        public void ChangeButtonTransitionWithSpriteSwap(Sprite highlighted, Sprite pressed, Sprite disabled)
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                tmpButton.transition = Selectable.Transition.SpriteSwap;
                SpriteState tmpspriteState = new SpriteState();
                tmpspriteState.highlightedSprite = highlighted;
                tmpspriteState.pressedSprite = pressed;
                tmpspriteState.disabledSprite = disabled;
                tmpButton.spriteState = tmpspriteState;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }

        /// <summary>
        /// 设置button是否可用
        /// </summary>
        /// <param name="isActive">是否</param>
        public void SetButtonActive(bool isActive)
        {
            Button tmpButton = transform.GetComponent<Button>();
            try
            {
                tmpButton.interactable = isActive;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Button组件");
            }
        }
        #endregion

        #region InputField组件
        /// <summary>
        /// InputField事件
        /// </summary>
        /// <param name="action">方法</param>
        public void AddInputEditEndListener(UnityAction<string> action)
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onEndEdit.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// 移除InputField事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveInputEditEndListener(UnityAction<string> action)
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onEndEdit.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// 移除所有InputField事件
        /// </summary>
        public void RemoveInputEditEndListener()
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onEndEdit.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// InputField事件
        /// </summary>
        /// <param name="action">方法</param>
        public void AddInputValueChangedListener(UnityAction<string> action)
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onValueChanged.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// 移除InputField事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveInputValueChangedListener(UnityAction<string> action)
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onValueChanged.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// 移除所有InputField事件
        /// </summary>
        public void RemoveInputValueChangedListener()
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.onValueChanged.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }

        /// <summary>
        /// 设置InputField内容
        /// </summary>
        /// <param name="text">内容</param>
        public string InputFieldText
        {
            get { return transform.GetComponent<InputField>().text; }
            set { transform.GetComponent<InputField>().text = value; }
        }

        /// <summary>
        /// 设置InputField读写
        /// </summary>
        public bool InputFieldReadOnly
        {
            get { return transform.GetComponent<InputField>().readOnly; }
            set { transform.GetComponent<InputField>().readOnly = value; }
        }

        /// <summary>
        /// 设置InputField是否可用
        /// </summary>
        /// <param name="isActive">是否可用</param>
        public void SetInputFieldActive(bool isActive)
        {
            InputField tmpInputField = transform.GetComponent<InputField>();
            try
            {
                tmpInputField.interactable = isActive;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在InputField组件");
            }
        }
        #endregion

        #region Slider组件
        /// <summary>
        /// Slider事件
        /// </summary>
        /// <param name="action">方法</param>
        public void AddSliderListener(UnityAction<float> action)
        {
            Slider tmpSlider = transform.GetComponent<Slider>();
            try
            {
                tmpSlider.onValueChanged.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Slider组件");
            }
        }

        /// <summary>
        /// 移除指定Slider事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveSliderListener(UnityAction<float> action)
        {
            Slider tmpSlider = transform.GetComponent<Slider>();
            try
            {
                tmpSlider.onValueChanged.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Slider组件");
            }
        }

        /// <summary>
        /// 移除所有Slider事件
        /// </summary>
        public void RemoveSliderListener()
        {
            Slider tmpSlider = transform.GetComponent<Slider>();
            try
            {
                tmpSlider.onValueChanged.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Slider组件");
            }
        }

        /// <summary>
        /// Slider的值
        /// </summary>
        public float SliderValue
        {
            get { return transform.GetComponent<Slider>().value; }
            set { transform.GetComponent<Slider>().value = value; }
        }

        /// <summary>
        /// 设置Slider是否可用
        /// </summary>
        /// <param name="isActive"></param>
        public void SetSliderActive(bool isActive)
        {
            Slider tmpSlider = transform.GetComponent<Slider>();
            try
            {
                tmpSlider.interactable = isActive;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Slider组件");
            }
        }

        /// <summary>
        /// Slider最大值
        /// </summary>
        public float SliderMaxValue
        {
            get { return transform.GetComponent<Slider>().maxValue; }
            set { transform.GetComponent<Slider>().maxValue = value; }
        }

        /// <summary>
        /// Slider最小值
        /// </summary>
        public float SliderMinValue
        {
            get { return transform.GetComponent<Slider>().minValue; }
            set { transform.GetComponent<Slider>().minValue = value; }
        }

        #endregion

        #region Toggle组件
        /// <summary>
        /// Toggle事件
        /// </summary>
        /// <param name="action">方法</param>
        public void AddToggleListener(UnityAction<bool> action)
        {
            Toggle tmpToggle = transform.GetComponent<Toggle>();
            try
            {
                tmpToggle.onValueChanged.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Toggle组件");
            }
        }

        /// <summary>
        /// 移除指定Toggle事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveToggleListener(UnityAction<bool> action)
        {
            Toggle tmpToggle = transform.GetComponent<Toggle>();
            try
            {
                tmpToggle.onValueChanged.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Toggle组件");
            }
        }

        /// <summary>
        /// 移除所有toggle事件
        /// </summary>
        public void RemoveToggleListener()
        {
            Toggle tmpToggle = transform.GetComponent<Toggle>();
            try
            {
                tmpToggle.onValueChanged.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Toggle组件");
            }
        }

        /// <summary>
        /// 添加ToggleGroup
        /// </summary>
        /// <param name="group">ToggleGroup对象</param>
        public void AddToggleGroup(GameObject group)
        {
            Toggle tmpToggle = transform.GetComponent<Toggle>();
            try
            {
                tmpToggle.group = group.GetComponent<ToggleGroup>();

            }
            catch (System.NullReferenceException)
            {
                if (!tmpToggle.Equals(null))
                {
                    tmpToggle.group = null;
                }
                else
                {
                    Debug.LogError("该对象不存在Toggle组件");
                }

            }
        }

        /// <summary>
        /// ToggleGroup是否允许全不选
        /// </summary>
        public bool ToggleGroupSwitchOff
        {
            get { return transform.GetComponent<ToggleGroup>().allowSwitchOff; }
            set { transform.GetComponent<ToggleGroup>().allowSwitchOff = value; }
        }

        /// <summary>
        /// toggle值
        /// </summary>
        public bool ToggleIsOn
        {
            get { return transform.GetComponent<Toggle>().isOn; }
            set { transform.GetComponent<Toggle>().isOn = value; }
        }

        /// <summary>
        /// 设置Toggle是否可用
        /// </summary>
        /// <param name="isActive">是否可用</param>
        public void SetToggleActive(bool isActive)
        {
            Toggle tmpToggle = transform.GetComponent<Toggle>();
            try
            {
                tmpToggle.interactable = isActive;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Toggle组件");
            }
        }
        #endregion

        #region Dropdown组件
        /// <summary>
        /// Dropdown事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddDropdownListener(UnityAction<int> action)
        {
            Dropdown tmpDropdown = transform.GetComponent<Dropdown>();
            try
            {
                tmpDropdown.onValueChanged.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Dropdown组件");
            }
        }

        /// <summary>
        /// 移除指定Dropdown事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveDropdownListener(UnityAction<int> action)
        {
            Dropdown tmpDropdown = transform.GetComponent<Dropdown>();
            try
            {
                tmpDropdown.onValueChanged.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Dropdown组件");
            }
        }

        /// <summary>
        /// 移除所有Dropdown事件
        /// </summary>
        public void RemoveDropdownListener()
        {
            Dropdown tmpDropdown = transform.GetComponent<Dropdown>();
            try
            {
                tmpDropdown.onValueChanged.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Dropdown组件");
            }
        }
        #endregion

        #region ScrollRect组件

        /// <summary>
        /// ScrollView纵向位置
        /// </summary>
        public float VerticalPosition
        {
            get { return transform.GetComponent<ScrollRect>().verticalNormalizedPosition; }
            set { transform.GetComponent<ScrollRect>().verticalNormalizedPosition = value; }
        }

        /// <summary>
        /// ScrollView横向位置
        /// </summary>
        public float HorizontalPosition
        {
            get { return transform.GetComponent<ScrollRect>().horizontalNormalizedPosition; }
            set { transform.GetComponent<ScrollRect>().horizontalNormalizedPosition = value; }
        }

        /// <summary>
        /// 移动ScrollView纵向位置
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="time">时长</param>
        public void VerticalMoveScrollView(float value, float time)
        {
            try
            {
                DOTween.To(() => VerticalPosition, (x) => VerticalPosition = x, value, time);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在ScrollRect组件");
            }
        }

        /// <summary>
        /// ScrollView横向位置
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="time">时长</param>
        public void HorizontalMoveScrollView(float value, float time)
        {
            try
            {
                DOTween.To(() => HorizontalPosition, (x) => HorizontalPosition = x, value, time);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在ScrollRect组件");
            }
        }

        /// <summary>
        /// ScrollView是否使用纵向滑动
        /// </summary>
        public bool IsUseVertical
        {
            get { return transform.GetComponent<ScrollRect>().vertical; }
            set { transform.GetComponent<ScrollRect>().vertical = value; }
        }

        /// <summary>
        /// ScrollRect事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddScrollRectListener(UnityAction<Vector2> action)
        {
            ScrollRect tmpScrollRect = transform.GetComponent<ScrollRect>();
            try
            {
                tmpScrollRect.onValueChanged.AddListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在ScrollRect组件");
            }
        }

        /// <summary>
        /// 移除指定ScrollRect事件
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveScrollRectListener(UnityAction<Vector2> action)
        {
            ScrollRect tmpScrollRect = transform.GetComponent<ScrollRect>();
            try
            {
                tmpScrollRect.onValueChanged.RemoveListener(action);
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在ScrollRect组件");
            }
        }

        /// <summary>
        /// 移除所有ScrollRect事件
        /// </summary>
        public void RemoveScrollRectListener()
        {
            ScrollRect tmpScrollRect = transform.GetComponent<ScrollRect>();
            try
            {
                tmpScrollRect.onValueChanged.RemoveAllListeners();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在ScrollRect组件");
            }
        }
        #endregion

        #region ScrollBar 组件
        /// <summary>
        /// 设置Scrollbar的value值
        /// </summary>
        /// <param name="value">值</param>
        public void ChangeBarValue(float value)
        {
            Scrollbar tmpScrollbar = transform.GetComponent<Scrollbar>();
            try
            {
                tmpScrollbar.value = value;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Scrollbar组件");
            }
        }
        #endregion

        #region Text组件
        /// <summary>
        /// Text内容修改（默认排版）
        /// </summary>
        public string Text
        {
            get
            {
                return transform.GetComponent<Text>().text;
            }
            set
            {
                transform.GetComponent<Text>().text = value;
            }
        }

        /// <summary>
        /// Text排版
        /// </summary>
        public TextAnchor Alignment
        {
            get { return transform.GetComponent<Text>().alignment; }
            set { transform.GetComponent<Text>().alignment = value; }
        }

        /// <summary>
        /// 获取Text文字总宽度
        /// </summary>
        /// <returns></returns>
        public int GetTextLength()
        {
            Text tmpText = transform.GetComponent<Text>();
            Font tmpFont = tmpText.font;
            tmpFont.RequestCharactersInTexture(tmpText.text, tmpText.fontSize, FontStyle.Normal);
            CharacterInfo tmpCharacterInfo = new CharacterInfo();
            int textLength = 0;
            for (int i = 0; i < tmpText.text.Length; i++)
            {
                tmpFont.GetCharacterInfo(tmpText.text[i], out tmpCharacterInfo, tmpText.fontSize);
                textLength += tmpCharacterInfo.advance;
            }
            return textLength;
        }

        /// <summary>
        /// Text修改内容（不用排版）
        /// </summary>
        /// <param name="text">内容</param>
        public void ChangeTextNotLayout(string text)
        {
            Text tmpText = transform.GetComponent<Text>();
            try
            {
                if (text.Contains(" "))
                {
                    text = text.Replace(" ", "\u00A0");
                }
                tmpText.text = text;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Text组件");
            }
        }

        /// <summary>
        /// Text修改内容（使用智能排版）
        /// </summary>
        /// <param name="text">内容</param>
        public void ChangeTextUseLayout(string text)
        {
            if (!transform.GetComponent<TextLayout>())
            {
                gameObject.AddComponent<TextLayout>();
            }
            transform.GetComponent<TextLayout>().Text = text;
        }

        /// <summary>
        /// Text修改颜色
        /// </summary>
        /// <param name="color">颜色</param>
        public void ChangeTextColor(Color color)
        {
            Text tmpText = transform.GetComponent<Text>();
            try
            {
                tmpText.color = color;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Text组件");
            }
        }

        /// <summary>
        /// 打字机效果显示文字
        /// </summary>
        /// <param name="text">文字内容</param>
        /// <param name="time">时间</param>
        /// <param name="action">结束后执行方法</param>
        public void DoTweenText(string text, float time, UnityAction action)
        {
            Text tmpText = transform.GetComponent<Text>();
            tmpText.text = string.Empty;
            try
            {
                Tweener tweener = tmpText.DOText(text, time, true, ScrambleMode.None, null);
                tweener.SetEase(Ease.Linear);
                tweener.OnComplete(() => { action(); });
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Text组件");
            }
        }
        #endregion

        #region Image组件
        /// <summary>
        /// Image修改图片
        /// </summary>
        /// <param name="png">图片</param>
        public Sprite ImageSprite
        {
            get
            {
                return transform.GetComponent<Image>().sprite;
            }
            set
            {
                transform.GetComponent<Image>().sprite = value;
            }

        }

        /// <summary>
        /// Image修改图片颜色
        /// </summary>
        /// <param name="color">颜色</param>
        public void ChangeImageColor(Color color)
        {
            Image tmpImage = transform.GetComponent<Image>();
            try
            {
                tmpImage.color = color;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Image组件");
            }
        }

        /// <summary>
        /// Image修改贴图
        /// </summary>
        /// <param name="clickedSprite"></param>
        public void ChangeImageSprite(Sprite clickedSprite)
        {
            Image tempImage = transform.GetComponent<Image>();
            try
            {
                tempImage.sprite = clickedSprite;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Image组件");
            }
        }
        /// <summary>
        /// Image是否接收射线检测
        /// </summary>
        /// <param name="isTarget">是否射线检测</param>
        public void SetImageRayCast(bool isTarget)
        {
            Image tmpImage = transform.GetComponent<Image>();
            try
            {
                tmpImage.raycastTarget = isTarget;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在Image组件");
            }
        }

        /// <summary>
        /// 获取Image的FillAmount
        /// </summary>
        public float ImageFillAmount
        {
            get { return transform.GetComponent<Image>().fillAmount; }
            set { transform.GetComponent<Image>().fillAmount = value; }
        }
        #endregion

        #region RawImage组件

        /// <summary>
        /// RawImage图片
        /// </summary>
        public Texture RawImageTexture
        {
            get { return transform.GetComponent<RawImage>().texture; }
            set { transform.GetComponent<RawImage>().texture = value; }
        }


        /// <summary>
        /// RawImage修改图片颜色
        /// </summary>
        /// <param name="color">颜色</param>
        public void ChangeRawImageColor(Color color)
        {
            RawImage tmpRawImage = transform.GetComponent<RawImage>();
            try
            {
                tmpRawImage.color = color;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在RawImage组件");
            }
        }
        #endregion

        #region Transform组件
        /// <summary>
        /// 坐标
        /// </summary>
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        /// <summary>
        /// 本地坐标
        /// </summary>
        public Vector3 LocalPosition
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        /// <summary>
        /// 旋转
        /// </summary>
        public Vector3 Rotation
        {
            get { return transform.eulerAngles; }
            set { transform.eulerAngles = value; }
        }

        /// <summary>
        /// 本地旋转
        /// </summary>
        public Vector3 LocalRotation
        {
            get { return transform.localEulerAngles; }
            set { transform.localEulerAngles = value; }
        }

        /// <summary>
        /// 缩放
        /// </summary>
        public Vector3 Scale
        {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        /// <summary>
        /// 设置激活或取消激活
        /// </summary>
        /// <param name="isActive">是否激活</param>
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public bool IsActive()
        {
            return gameObject.activeSelf;
        }

        /// <summary>
        /// 此物体是第几个子物体
        /// </summary>
        public int ChildNumber
        {
            get { return transform.GetSiblingIndex(); }
            set { transform.SetSiblingIndex(value); }
        }

        /// <summary>
        /// 父物体
        /// </summary>
        public Transform Parent
        {
            get { return transform.parent; }
            set { transform.parent = value; }
        }
        #endregion

        #region CanvasRenderer组件
        /// <summary>
        /// 渲染UI
        /// </summary>
        public void UseRenderer()
        {
            CanvasRenderer tmpCanvasRenderer = transform.GetComponent<CanvasRenderer>();
            try
            {
                tmpCanvasRenderer.cull = false;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在CanvasRenderer组件");
            }
        }

        /// <summary>
        /// 不渲染UI
        /// </summary>
        public void UnuseRenderer()
        {
            CanvasRenderer tmpCanvasRenderer = transform.GetComponent<CanvasRenderer>();
            try
            {
                tmpCanvasRenderer.cull = true;
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在CanvasRenderer组件");
            }
        }
        #endregion

        #region DoTween插件
        /// <summary>
        /// 正播DT动画
        /// </summary>
        public void PlayDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPlayForward();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 倒播DT动画
        /// </summary>
        public void PlayDTAnimeBack()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPlayBackwards();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 正播DT动画结束后执行方法
        /// </summary>
        /// <param name="action">方法</param>
        public void PlayDTAnime(UnityAction action)
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.tween.OnStepComplete(() => {
                    tmpAnime.tween.OnStepComplete(null);
                    action();
                });
                tmpAnime.DOPlayForward();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 倒播DT动画结束后执行方法
        /// </summary>
        /// <param name="action">方法</param>
        public void PlayDTAnimeBack(UnityAction action)
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.tween.OnStepComplete(() => {
                    tmpAnime.tween.OnStepComplete(null);
                    action();
                });
                tmpAnime.DOPlayBackwards();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 停止DT动画
        /// </summary>
        public void PauseDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DOPause();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 重播DT动画
        /// </summary>
        public void ReplayDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DORestart();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }

        /// <summary>
        /// 重置动画回初始状态
        /// </summary>
        public void RewindDTAnime()
        {
            DOTweenAnimation tmpAnime = transform.GetComponent<DOTweenAnimation>();
            try
            {
                tmpAnime.DORewind();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("该对象不存在DOTweenAnimation组件");
            }
        }


        #endregion

        #region RectTransform组件
        /// <summary>
        /// UI的宽高
        /// </summary>
        /// <param name="pos">宽高</param>
        public Vector2 WidthAndHeight
        {
            get
            {
                return transform.GetComponent<RectTransform>().sizeDelta;
            }
            set
            {
                transform.GetComponent<RectTransform>().sizeDelta = value;
            }
        }

        /// <summary>
        /// UI的中心点
        /// </summary>
        public Vector2 Pivot
        {
            get { return transform.GetComponent<RectTransform>().pivot; }
            set { transform.GetComponent<RectTransform>().pivot = value; }
        }

        /// <summary>
        /// 获取宽 X
        /// </summary>
        public float Width
        {
            get { return transform.GetComponent<RectTransform>().rect.width; }
        }

        /// <summary>
        /// 获取高 Y
        /// </summary>
        public float Height
        {
            get { return transform.GetComponent<RectTransform>().rect.height; }
        }

        /// <summary>
        /// 刷新UI
        /// </summary>
        public void ReFreshLayout()
        {
            StartCoroutine(RefreshLayout());
        }

        private IEnumerator RefreshLayout()
        {
            RectTransform tmptransform = transform.GetComponent<RectTransform>();
            LayoutRebuilder.ForceRebuildLayoutImmediate(tmptransform);
            yield return new WaitForEndOfFrame();
            while (tmptransform.rect.width == 0)
            {
                Debug.Log("未刷新成功");
                LayoutRebuilder.ForceRebuildLayoutImmediate(tmptransform);
                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// UI坐标
        /// </summary>
        public Vector3 UIPosition
        {
            get { return transform.GetComponent<RectTransform>().anchoredPosition3D; }
            set { transform.GetComponent<RectTransform>().anchoredPosition3D = value; }
        }
        #endregion

        #region DownTrigger组件
        /// <summary>
        /// 添加鼠标按下监听
        /// </summary>
        /// <param name="action">事件</param>
        public void AddDownTriggerListener(UnityAction action)
        {
            if (!transform.GetComponent<DownTrigger>())
            {
                gameObject.AddComponent<DownTrigger>();
            }
            transform.GetComponent<DownTrigger>().OnMouseDown.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标按下监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveDownTriggerListener(UnityAction action)
        {
            if (transform.GetComponent<DownTrigger>())
            {
                transform.GetComponent<DownTrigger>().OnMouseDown.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标按下监听
        /// </summary>
        public void RemoveDownTriggerListener()
        {
            if (transform.GetComponent<DownTrigger>())
            {
                transform.GetComponent<DownTrigger>().OnMouseDown.RemoveAllListeners();
            }
        }
        #endregion

        #region UpTrigger组件
        /// <summary>
        /// 添加鼠标抬起监听
        /// </summary>
        /// <param name="action"></param>
        public void AddUpTriggerListener(UnityAction action)
        {
            if (!transform.GetComponent<UpTrigger>())
            {
                gameObject.AddComponent<UpTrigger>();
            }
            transform.GetComponent<UpTrigger>().OnMouseUp.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标抬起监听
        /// </summary>
        /// <param name="action"></param>
        public void RemoveUpTriggerListener(UnityAction action)
        {
            if (transform.GetComponent<UpTrigger>())
            {
                transform.GetComponent<UpTrigger>().OnMouseUp.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标抬起监听
        /// </summary>
        public void RemoveUpTriggerListener()
        {
            if (transform.GetComponent<UpTrigger>())
            {
                transform.GetComponent<UpTrigger>().OnMouseUp.RemoveAllListeners();
            }
        }
        #endregion

        #region EnterTrigger组件
        /// <summary>
        /// 添加鼠标进入监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddEnterTriggerListener(UnityAction action)
        {
            if (!transform.GetComponent<EnterTrigger>())
            {
                gameObject.AddComponent<EnterTrigger>();
            }
            transform.GetComponent<EnterTrigger>().OnMouseEnter.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标进入监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveEnterTriggerListener(UnityAction action)
        {
            if (transform.GetComponent<EnterTrigger>())
            {
                transform.GetComponent<EnterTrigger>().OnMouseEnter.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标进入监听
        /// </summary>
        public void RemoveEnterTriggerListener()
        {
            if (transform.GetComponent<EnterTrigger>())
            {
                transform.GetComponent<EnterTrigger>().OnMouseEnter.RemoveAllListeners();
            }
        }
        #endregion

        #region ExitTrigger组件
        /// <summary>
        /// 添加鼠标离开监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddExitTriggerListener(UnityAction action)
        {
            if (!transform.GetComponent<ExitTrigger>())
            {
                gameObject.AddComponent<ExitTrigger>();
            }
            transform.GetComponent<ExitTrigger>().OnMouseExit.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标离开监听
        /// </summary>
        /// <param name="action"></param>
        public void RemoveExitTriggerListener(UnityAction action)
        {
            if (transform.GetComponent<ExitTrigger>())
            {
                transform.GetComponent<ExitTrigger>().OnMouseExit.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标离开监听
        /// </summary>
        public void RemoveExitTriggerListener()
        {
            if (transform.GetComponent<ExitTrigger>())
            {
                transform.GetComponent<ExitTrigger>().OnMouseExit.RemoveAllListeners();
            }
        }
        #endregion

        #region BeginDragTrigger组件
        /// <summary>
        /// 添加鼠标开始拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddBeginDragListener(UnityAction action)
        {
            if (!transform.GetComponent<BeginDragTrigger>())
            {
                gameObject.AddComponent<BeginDragTrigger>();
            }
            transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标开始拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveBeginDragListener(UnityAction action)
        {
            if (transform.GetComponent<BeginDragTrigger>())
            {
                transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标开始拖拽监听
        /// </summary>
        public void RemoveBeginDragListener()
        {
            if (transform.GetComponent<BeginDragTrigger>())
            {
                transform.GetComponent<BeginDragTrigger>().OnMouseBeginDrag.RemoveAllListeners();
            }
        }
        #endregion

        #region DragTrigger组件
        /// <summary>
        /// 添加鼠标拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddDragListener(UnityAction action)
        {
            if (!transform.GetComponent<DragTrigger>())
            {
                gameObject.AddComponent<DragTrigger>();
            }
            transform.GetComponent<DragTrigger>().OnMouseDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveDragListener(UnityAction action)
        {
            if (transform.GetComponent<DragTrigger>())
            {
                transform.GetComponent<DragTrigger>().OnMouseDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标拖拽监听
        /// </summary>
        public void RemoveDragListener()
        {
            if (transform.GetComponent<DragTrigger>())
            {
                transform.GetComponent<DragTrigger>().OnMouseDrag.RemoveAllListeners();
            }
        }

        #endregion

        #region EndDragTrigger组件
        /// <summary>
        /// 添加鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddEndDragListener(UnityAction action)
        {
            if (!transform.GetComponent<EndDragTrigger>())
            {
                gameObject.AddComponent<EndDragTrigger>();
            }
            transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveEndDragListener(UnityAction action)
        {
            if (transform.GetComponent<EndDragTrigger>())
            {
                transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标结束拖拽监听
        /// </summary>
        public void RemoveEndDragListener()
        {
            if (transform.GetComponent<EndDragTrigger>())
            {
                transform.GetComponent<EndDragTrigger>().OnMouseEndDrag.RemoveAllListeners();
            }
        }
        #endregion

        #region DropTrigger组件
        /// <summary>
        /// 添加鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddDropListener(UnityAction action)
        {
            if (!transform.GetComponent<DropTrigger>())
            {
                gameObject.AddComponent<DropTrigger>();
            }
            transform.GetComponent<DropTrigger>().OnMouseDrop.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标结束拖拽监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveDropListener(UnityAction action)
        {
            if (transform.GetComponent<DropTrigger>())
            {
                transform.GetComponent<DropTrigger>().OnMouseDrop.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标结束拖拽监听
        /// </summary>
        public void RemoveDropListener()
        {
            if (transform.GetComponent<DropTrigger>())
            {
                transform.GetComponent<DropTrigger>().OnMouseDrop.RemoveAllListeners();
            }
        }
        #endregion

        #region ScrollTrigger组件
        /// <summary>
        /// 添加鼠标滚轮监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddScrollListener(UnityAction action)
        {
            if (!transform.GetComponent<ScrollTrigger>())
            {
                gameObject.AddComponent<ScrollTrigger>();
            }
            transform.GetComponent<ScrollTrigger>().OnMouseScroll.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标滚轮监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemoveScrollListener(UnityAction action)
        {
            if (transform.GetComponent<ScrollTrigger>())
            {
                transform.GetComponent<ScrollTrigger>().OnMouseScroll.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标滚轮监听
        /// </summary>
        public void RemoveScrollListener()
        {
            if (transform.GetComponent<ScrollTrigger>())
            {
                transform.GetComponent<ScrollTrigger>().OnMouseScroll.RemoveAllListeners();
            }
        }
        #endregion

        #region PressTrigger组件
        /// <summary>
        /// 添加鼠标按住监听
        /// </summary>
        /// <param name="action">方法</param>
        public void AddPressListener(UnityAction action)
        {
            if (!transform.GetComponent<PressTrigger>())
            {
                gameObject.AddComponent<PressTrigger>();
            }
            transform.GetComponent<PressTrigger>().OnMousePress.AddListener(action);
        }

        /// <summary>
        /// 移除指定鼠标按住监听
        /// </summary>
        /// <param name="action">方法</param>
        public void RemovePressListener(UnityAction action)
        {
            if (transform.GetComponent<PressTrigger>())
            {
                transform.GetComponent<PressTrigger>().OnMousePress.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除所有鼠标按住监听
        /// </summary>
        public void RemovePressListener()
        {
            if (transform.GetComponent<PressTrigger>())
            {
                transform.GetComponent<PressTrigger>().OnMousePress.RemoveAllListeners();
            }
        }
        #endregion

        #region ClickTrigger组件

        /// <summary>
        /// 添加物体点击事件
        /// </summary>
        /// <param name="action">事件</param>
        public void AddClickListener(UnityAction action)
        {
            if (!transform.GetComponent<ClickTrigger>())
            {
                gameObject.AddComponent<ClickTrigger>();
            }
            if (!transform.GetComponent<Collider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
            transform.GetComponent<ClickTrigger>().OnMouseClick.AddListener(action);
        }

        /// <summary>
        /// 移除物体指定点击事件
        /// </summary>
        /// <param name="action">事件</param>
        public void RemoveClickListener(UnityAction action)
        {
            if (transform.GetComponent<ClickTrigger>())
            {
                transform.GetComponent<ClickTrigger>().OnMouseClick.RemoveListener(action);
            }
        }

        /// <summary>
        /// 移除物体所有点击事件
        /// </summary>
        public void RemoveClickListener()
        {
            if (transform.GetComponent<ClickTrigger>())
            {
                transform.GetComponent<ClickTrigger>().OnMouseClick.RemoveAllListeners();
            }
        }

        #endregion
    }
}

