/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：DragObjLogic
* 创建日期：2020-06-17 09:18:25
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：拖拽物体逻辑脚本(在限定为Mask的层中拖拽)
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class DragObjLogic : ObjLogicBase 
	{
        private Vector3 orgPos;
        private Vector3 screenPos;
        private Vector3 offset;

        private string targetName = string.Empty;
        private UnityAction dragEndAction;
        private UnityAction startDragAction;
        private Camera dragCamera;

        private void Start()
        {
            AddEntity<DragObjEntity>();
        }

        private void OnDestroy()
        {
            RemoveEntity<DragObjEntity>();
        }

        #region 拖拽
        private void OnObjDown() {
            GetEntity<DragObjEntity>().DownAction++;
        }

        private void OnObjUp() {
            GetEntity<DragObjEntity>().UpAction++;
        }

        private void OnObjDrag() {
            GetEntity<DragObjEntity>().DragAction++;
        }

        /// <summary>
        /// 按下
        /// </summary>
        private void DragDownAction() {
            GetComponent<Collider>().enabled = false;
            orgPos = transform.position;
            screenPos = dragCamera.WorldToScreenPoint(transform.position);   
            offset = screenPos - Input.mousePosition;
            if (startDragAction != null)
            {
                startDragAction.Invoke();
                startDragAction = null;
            }
        }

        /// <summary>
        /// 抬起
        /// </summary>
        private void DragUpAction() {
            if (targetName != string.Empty)
            {
                if (IPointerOver.CurrentPointerOverGameObject())
                {
                    if (IPointerOver.CurrentPointerOverGameObject().name == targetName)
                    {
                        if (dragEndAction != null)
                        {
                            dragEndAction.Invoke();
                            dragEndAction = null;
                        }
                        GetObjBehaviour(this.name).RemoveObjBeginDragListener(OnObjDown);
                        GetObjBehaviour(this.name).RemoveObjEndDragListener(OnObjUp);
                        GetObjBehaviour(this.name).RemoveObjDragListener(OnObjDrag);
                    }
                    else
                    {
                        transform.position = orgPos;
                    }
                }
                else
                {
                    transform.position = orgPos;
                }
            }
            else
            {
                transform.position = orgPos;
            }
            GetComponent<Collider>().enabled = true;
            
        }

        /// <summary>
        /// 拖拽
        /// </summary>
        private void DragAction() {
            GetEntity<DragObjEntity>().DragPosition = Input.mousePosition;

            
        }

        #endregion

        /// <summary>
        /// 设置拖拽目标
        /// </summary>
        /// <param name="targetName">目标名字</param>
        /// <param name="dragCamera">当前相机（null默认为主相机）</param>
        /// <param name="dragEndAction">拖拽到目标位置后执行的方法</param>
        public void SetDragTarget(string targetName,NamePair dragCamera, UnityAction dragEndAction) {
            this.targetName = targetName;
            this.dragEndAction = dragEndAction;
            if (dragCamera != null)
            {
                this.dragCamera = InjectService.Get<ObjManager>().GetGameObject(dragCamera.RootName, dragCamera.ObjName).GetComponent<Camera>();
            }
            else
            {
                this.dragCamera = Camera.main;
            }

            GetObjBehaviour(transform.name).AddObjDownListener(OnObjDown);
            GetObjBehaviour(transform.name).AddObjUpListener(OnObjUp);
            GetObjBehaviour(transform.name).AddObjDragListener(OnObjDrag);
        }

        /// <summary>
        /// 设置刚开始拖拽回调
        /// </summary>
        public void SetStartDragAction(UnityAction startDragAction) {
            this.startDragAction = startDragAction;
        }



        public override void ProcessLogic(IEvent evt)
        {
            //按下
            if (evt.EventName.Equals("DownAction"))
            {
                DragDownAction();
            }
            //抬起
            if (evt.EventName.Equals("UpAction"))
            {
                DragUpAction();
            }
            //拖动
            if (evt.EventName.Equals("DragAction"))
            {
                DragAction();
            }
            //位移
            if (evt.EventName.Equals("DragPosition"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                Vector3 newValue = (Vector3)propertyEvent.NewValue;
                Ray ray = dragCamera.ScreenPointToRay(newValue);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mask")))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Mask"))
                    {
                        transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
                }
            }
        }


        

    }
}
