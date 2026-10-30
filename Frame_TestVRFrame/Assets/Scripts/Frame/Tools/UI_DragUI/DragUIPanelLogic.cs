/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：DragUIPanelLogic
* 创建日期：2021-05-06 15:44:34
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：拖拽UI功能
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class DragUIPanelLogic : MVVMLogicBase 
	{
        /// <summary>
        /// 目标名字
        /// </summary>
        private string targetName = "Target";
        private string targetCenterName = "Target2";
        private string targetBGName = "TargetBG";

        /// <summary>
        /// 拖拽物体名字
        /// </summary>
        private string dragerName = "Drager";
        private string arrowName = "Hard";

        /// <summary>
        /// 观察物体相机
        /// </summary>
        private Camera lookCamera;

        /// <summary>
        /// 目标物体
        /// </summary>
        private Transform target;

        /// <summary>
        /// 拖拽物体
        /// </summary>
        private Transform drager;

        /// <summary>
        /// 箭头方向
        /// </summary>
        private float direction; 

        /// <summary>
        /// 叉乘结果
        /// </summary>
        private Vector3 result;  

        /// <summary>
        /// 箭头初始角度
        /// </summary>
        private Quaternion originRot;

        private bool isStartDrag = false;

        /// <summary>
        /// 拖拽物体初始位置
        /// </summary>
        private Vector3 orgPos;

        private void Start()
        {
            AddEntity<DragUIPanelEntity>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize() {
            GetUIBehaviours(name).Scale = Vector3.one;
            originRot = GetUIBehaviours(targetBGName).transform.rotation;
            GetUIBehaviours(dragerName).RemoveDownTriggerListener();
            GetUIBehaviours(dragerName).RemoveUpTriggerListener();
            GetUIBehaviours(dragerName).RemoveDragListener();
            GetUIBehaviours(dragerName).AddDownTriggerListener(PointerDown);
            GetUIBehaviours(dragerName).AddUpTriggerListener(PointerUp);
            GetUIBehaviours(dragerName).AddDragListener(PointerDrag);
            ReSetPosition();
            isStartDrag = true;
            OnDragStart();
        }

        /// <summary>
        /// 重置UI位置
        /// </summary>
        private void ReSetPosition() {
            GetUIBehaviours(targetBGName).Position = lookCamera.WorldToScreenPoint(target.position) ;
            GetUIBehaviours(dragerName).Position = lookCamera.WorldToScreenPoint(drager.position); 
        }

        private void OnDestroy()
        {
            RemoveEntity<DragUIPanelEntity>();
        }

        private void Update()
        {
            SetArrowDirection();
        }

        private void PointerDown() {
            GetEntity<DragUIPanelEntity>().PointerDown++;
        }

        private void PointerUp() {
            if (IPointerOver.CurrentPointerOverGameObject() == GetGameObject(targetName))
            {
                GetEntity<DragUIPanelEntity>().PointerUpInTarget++;
            }
            else
            {
                GetEntity<DragUIPanelEntity>().PointerUp++;
            }
            
        }

        private void PointerDrag() {
            GetEntity<DragUIPanelEntity>().DragPosition = Input.mousePosition;
            if (IPointerOver.CurrentPointerOverGameObject() == GetGameObject(targetName))
            {
                GetEntity<DragUIPanelEntity>().PointerEnter++;
            }
            else
            {
                GetEntity<DragUIPanelEntity>().PointerExit++;
            }
        }

        /// <summary>
        /// 设置箭头方向
        /// </summary>
        private void SetArrowDirection() {
            if (isStartDrag)
            {
                Vector3 forVec = drager.forward;
                Vector3 angVec = (GetUIBehaviours(targetName).Position - GetUIBehaviours(dragerName).Position).normalized;
                Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized;
                Vector3 originVec = drager.up;
                direction = Vector3.Dot(originVec, targetVec);
                result = Vector3.Cross(originVec, targetVec);
                direction = Mathf.Acos(direction) * Mathf.Rad2Deg;
                result = drager.InverseTransformDirection(result);
                GetUIBehaviours(dragerName).transform.rotation = originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (result.z > 0 ? 1 : -1)));
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
            if (evt.EventSource is ViewModel) {
                //获取事件源
                ViewModel vm = evt.EventSource as ViewModel;
            }

            if (evt.EventName.Equals("PointerDown"))
            {
                GetUIBehaviours(dragerName).SetImageRayCast(false);
                orgPos = GetUIBehaviours(dragerName).Position;
                OnPointerDown();
            }
            else if (evt.EventName.Equals("PointerUp"))
            {
                OnPointerUp();
                GetUIBehaviours(dragerName).SetImageRayCast(true);
            }
            else if (evt.EventName.Equals("PointerUpInTarget"))
            {
                isStartDrag = false;
                GetUIBehaviours(name).Scale = Vector3.zero;
                OnDragEnd();
                GetUIBehaviours(dragerName).SetImageRayCast(true);
                InvokeCallBackAction();
            }
            else if (evt.EventName.Equals("DragPosition")) {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector3 newValue = (Vector3)propertyEvent.NewValue;
                GetUIBehaviours(dragerName).Position = newValue;
            }
            else if (evt.EventName.Equals("PointerEnter"))
            {
                OnPointerEnter();
            }
            else if (evt.EventName.Equals("PointerExit"))
            {
                OnPointerExit();
            }
        }

        /// <summary>
        /// 拖拽到目标位置
        /// </summary>
        /// <param name="lookCamera">观察相机</param>
        /// <param name="target">目标点</param>
        /// <param name="drager">拖拽点</param>
        /// <param name="OnDragToTarget">回调</param>
        public void SetDragObj(Camera lookCamera , NamePair target,NamePair drager,UnityAction OnDragToTarget) {
            this.lookCamera = lookCamera;
            this.target = InjectService.Get<ObjManager>().GetGameObject(target.RootName, target.ObjName).transform;
            this.drager = InjectService.Get<ObjManager>().GetGameObject(drager.RootName, drager.ObjName).transform;
            SetCallBackAction(OnDragToTarget);
            Initialize();
        }

        /// <summary>
        /// 拖拽到目标位置
        /// </summary>
        /// <param name="target">目标点</param>
        /// <param name="drager">拖拽点</param>
        /// <param name="OnDragToTarget">回调</param>
        public void SetDragObj(NamePair target,NamePair drager,UnityAction OnDragToTarget) {
            lookCamera = Camera.main;
            this.target = InjectService.Get<ObjManager>().GetGameObject(target.RootName, target.ObjName).transform;
            this.drager = InjectService.Get<ObjManager>().GetGameObject(drager.RootName, drager.ObjName).transform;
            SetCallBackAction(OnDragToTarget);
            Initialize();
        }

        /// <summary>
        /// 开启拖拽功能（可重写）
        /// </summary>
        protected virtual void OnDragStart() {
            GetUIBehaviours(arrowName).SetActive(true);
            GetUIBehaviours(dragerName).Scale = Vector3.one;
            GetUIBehaviours(targetName).RewindDTAnime();
            GetUIBehaviours(targetCenterName).RewindDTAnime();
            GetUIBehaviours(arrowName).PlayDTAnime();
            GetUIBehaviours(targetBGName).Scale = Vector3.one;
        }

        /// <summary>
        /// 结束拖拽功能（可重写）
        /// </summary>
        protected virtual void OnDragEnd()
        {
            
        }

        /// <summary>
        /// 当按下时（可重写）
        /// </summary>
        protected virtual void OnPointerDown() {
            GetUIBehaviours(dragerName).Scale = Vector3.one * 1.5f;
            GetUIBehaviours(targetName).PlayDTAnime();
            GetUIBehaviours(targetCenterName).PlayDTAnime();
            GetUIBehaviours(arrowName).RewindDTAnime();
        }

        /// <summary>
        /// 当拖拽进入目标时（可重写）
        /// </summary>
        protected virtual void OnPointerEnter() {
            GetUIBehaviours(dragerName).Position = GetUIBehaviours(targetName).Position;
            GetUIBehaviours(arrowName).SetActive(false);
            GetUIBehaviours(targetBGName).Scale = Vector3.one * 1.5f;
        }

        /// <summary>
        /// 当拖拽离开目标时（可重写）
        /// </summary>
        protected virtual void OnPointerExit() {
            GetUIBehaviours(targetBGName).Scale = Vector3.one;
            GetUIBehaviours(arrowName).SetActive(true);
        }

        /// <summary>
        /// 当抬起时（可重写）
        /// </summary>
        protected virtual void OnPointerUp() {
            GetUIBehaviours(dragerName).Position = lookCamera.WorldToScreenPoint(drager.position);
            GetUIBehaviours(dragerName).Scale = Vector3.one;
            GetUIBehaviours(targetName).RewindDTAnime();
            GetUIBehaviours(targetCenterName).RewindDTAnime();
            GetUIBehaviours(arrowName).PlayDTAnime();
        }

    }
}
