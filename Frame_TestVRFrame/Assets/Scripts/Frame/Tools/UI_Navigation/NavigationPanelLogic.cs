/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：NavigationPanelLogic
* 创建日期：2020-12-01 09:30:31
* 作者名称：周新彭
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：界面导航逻辑
******************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationPanelLogic : MVVMLogicBase
    {
        private UnityAction clickAction;
        private RectGuidance rectGuid;
        private CircleGuidance circleGuid;

        private void Start()
        {
            rectGuid = transform.GetComponentInChildren<RectGuidance>(true);
            circleGuid = transform.GetComponentInChildren<CircleGuidance>(true);
            AddEntity<NavigationPanelEntity>();
        }

        private void OnDestroy()
        {
            RemoveEntity<NavigationPanelEntity>();
        }

        /// <summary>
        /// 设置导航UI和结束事件
        /// </summary>
        /// <param name="image">UI</param>
        /// <param name="endAction">结束事件</param>
        public void SetRectNavigationImageAndAction(Image image,UnityAction endAction=null)
        {
            GetEntity<NavigationPanelEntity>().SetNavigationImage(image, endAction);
        }

        /// <summary>
        /// 设置导航UI和结束事件
        /// </summary>
        /// <param name="image">UI</param>
        /// <param name="endAction">结束事件</param>
        public void SetCircleNavigationImageAndAction(Image image, UnityAction endAction = null)
        {
            GetEntity<NavigationPanelEntity>().SetCirleNavigationImage(image, endAction);
        }

        /// <summary>
        /// 导航按钮点击事件
        /// </summary>
        public void DoClickAction()
        {
            if (clickAction!=null)
            {
                clickAction.Invoke();
                clickAction = null;
            }
        }

        /// <summary>
        /// 设置导航UI和结束事件（方形）
        /// </summary>
        /// <param name="image">UI</param>
        /// <param name="endAction">结束事件</param>
        private void SetNavigationImage(Image image, UnityAction endAction)
        {
            rectGuid.gameObject.SetActive(true);
            rectGuid.Init(image);
            clickAction = endAction;
        }

        /// <summary>
        /// 设置导航UI和结束事件（圆形）
        /// </summary>
        /// <param name="image">UI</param>
        /// <param name="endAction">结束事件</param>
        private void SetCircleNavigationImage(Image image, UnityAction endAction)
        {
            circleGuid.gameObject.SetActive(true);
            circleGuid.Init(image);
            clickAction = endAction;
        }

        public override void ProcessLogic(IEvent evt)
        {
            //忽略所有属性初始化事件、OnDiable事件、有OnDestroy事件、有OnEnable事件
            if ((evt is PropertyInitEvent) || evt.EventName.Equals("OnDisable") || evt.EventName.Equals("OnDestroy") || evt.EventName.Equals("OnEnable")) return;

            if (evt.EventSource is ViewModel)
            {
                //获取事件源
                ViewModel vm = evt.EventSource as ViewModel;
                if (vm.name.Equals("NavigationButton"))
                {
                    SetRectNavigationImageAndAction(GetUIBehaviours("NavigationButton").GetComponent<Image>());
                }
                if (vm.name.Equals("NavigationButton2"))
                {
                    SetCircleNavigationImageAndAction(GetUIBehaviours("NavigationButton2").GetComponent<Image>());
                }
            }

            if (evt is MethodEvent)
            {
                //方形
                if (evt.EventName.Equals("SetNavigationImage"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    Image image = (Image)data[0];
                    UnityAction endAction = (UnityAction)data[1];
                    SetNavigationImage(image,endAction);
                }
                //圆形
                if (evt.EventName.Equals("SetCirleNavigationImage"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    Image image = (Image)data[0];
                    UnityAction endAction = (UnityAction)data[1];
                    SetCircleNavigationImage(image, endAction);
                }
            }
        }
    }
}
