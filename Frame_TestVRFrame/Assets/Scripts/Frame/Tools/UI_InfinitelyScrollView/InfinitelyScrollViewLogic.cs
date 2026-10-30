/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：InfinitelyScrollViewLogic
* 创建日期：2021-04-30 16:04:05
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：无限滚动UI
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class InfinitelyScrollViewLogic : MVVMLogicBase 
	{
        private EnhanceScrollView enhanceScrollView;

        private void Start()
        {
            AddEntity<InfinitelyScrollViewEntity>();
            enhanceScrollView = transform.GetComponentInChildren<EnhanceScrollView>();
        }

        private void OnDestroy()
        {
            RemoveEntity<InfinitelyScrollViewEntity>();
        }

        /// <summary>
        /// 拖拽中
        /// </summary>
        /// <param name="position"></param>
        public void OnItemDrag(Vector2 position) {
            GetEntity<InfinitelyScrollViewEntity>().OnDrag(position);
        }

        /// <summary>
        /// 拖拽结束
        /// </summary>
        public void OnItemDragEnd() {
            GetEntity<InfinitelyScrollViewEntity>().OnDragEnd();
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
            if (evt.EventSource is ViewModel) {
                //获取事件源
                ViewModel vm = evt.EventSource as ViewModel;

                if (vm.name.Equals("LeftButton"))
                {
                    enhanceScrollView.OnBtnLeftClick();
                }
                else if (vm.name.Equals("RightButton"))
                {
                    enhanceScrollView.OnBtnRightClick();
                }
            }
            if (evt is MethodEvent) {
                if (evt.EventName.Equals("OnDrag"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    Vector2 position = (Vector2)data[0];
                    enhanceScrollView.OnDragEnhanceViewMove(position);
                }
                else if (evt.EventName.Equals("OnDragEnd"))
                {
                    enhanceScrollView.OnDragEnhanceViewEnd();
                }
            }



        }
    }
}
