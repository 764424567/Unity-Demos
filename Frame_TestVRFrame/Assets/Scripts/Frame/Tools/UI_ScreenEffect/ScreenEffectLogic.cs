/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：ScreenEffectLogic
* 创建日期：2020-06-09 19:45:58
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Coffee.UIExtensions;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class ScreenEffectLogic : MVVMLogicBase 
	{
        private LoadStyle effectStyle = LoadStyle.Mod3;

        /// <summary>
        /// 设置转场风格（一处修改全局有效）
        /// </summary>
        public LoadStyle EffectStyle
        {
            get
            {
                return effectStyle;
            }
            set
            {
                effectStyle = value;
                SaveValue.EffectStyle = effectStyle;
                effectStyleTex = Resources.Load<Texture>("UIEffectMod" + ((int)effectStyle + 1).ToString());
                effect = transform.GetComponent<UITransitionEffect>();
                effect.transitionTexture = effectStyleTex;
            }
        }
        private Texture effectStyleTex;
        private Tween tween;
        private UITransitionEffect effect;


        private void Start()
        {
            AddEntity<ScreenEffectEntity>();
            EffectStyle = SaveValue.EffectStyle;
            effect = transform.GetComponent<UITransitionEffect>();
            effect.transitionTexture = effectStyleTex;
        }

        private void OnDestroy()
        {
            RemoveEntity<ScreenEffectEntity>();
        }

        /// <summary>
        /// 显示屏幕转场
        /// </summary>
        /// <param name="action"></param>
        public void ShowEffect(UnityAction action) {
            SetCallBackAction(action);
            GetEntity<ScreenEffectEntity>().SetScreenEffect();
        }

        public override void ProcessLogic(IEvent evt)
        {
            if (evt is MethodEvent)
            {
                //显示转场特效
                if (evt.EventName.Equals("SetScreenEffect"))
                {
                    
                    ShowEffectLogic(GetCallBackAction());
                }
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="action"></param>
        private void ShowEffectLogic(UnityAction action)
        {
            effect.effectFactor = 0;
            GetUIBehaviours(this.name).Scale = Vector3.one;
            tween = DOTween.To(() => effect.effectFactor, (x) => effect.effectFactor = x, 1, 1).OnComplete(() => {
                tween.Kill();
                if (action != null)
                {
                    action.Invoke();
                }
                HideEffectLogic();
            });
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        private void HideEffectLogic()
        {
            effect.effectFactor = 1;
            GetUIBehaviours(this.name).Scale = Vector3.one;
            tween = DOTween.To(() => effect.effectFactor, (x) => effect.effectFactor = x, 0, 1).OnComplete(() => {
                tween.Kill();
                GetUIBehaviours(this.name).Scale = Vector3.zero;
            });
        }
    }
}
