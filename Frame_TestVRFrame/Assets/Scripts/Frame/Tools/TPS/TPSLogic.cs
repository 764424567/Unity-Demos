/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TPSLogic
* 创建日期：2020-06-08 11:46:22
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：第三人称人物移动相机控制
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class TPSLogic : ObjLogicBase
    {
        #region 人物相关

        public Transform lookCamera;

        private CharacterController controller;

        /// <summary>
        /// 移动速度
        /// </summary>
        private float moveSpeed = 5f;

        /// <summary>
        /// 人物移动速度
        /// </summary>
        public float MoveSpeed {
            get { return GetEntity<TPSEntity>().MoveSpeed; }
            set { GetEntity<TPSEntity>().MoveSpeed = value; }
        }

        public GameObject canvas;

        /// <summary>
        /// 旋转方向
        /// </summary>
        private Vector3 direction;

        /// <summary>
        /// 人物是否是平衡状态
        /// </summary>
        private bool isNomalState = true;

        #endregion

        #region 相机相关

        /// <summary>
        /// 相机观察高度
        /// </summary>
        public float playerHeight = 1.4f;

        /// <summary>
        /// 人物与相机间距
        /// </summary>
        public float distance = 1.5f;

        /// <summary>
        /// Y旋转限制
        /// </summary>
        public float yMinLimit = -50, yMaxLimit = 50;

        /// <summary>
        /// 相机旋转平滑度
        /// </summary>
        [Range(1f, 5f)]
        public float rotateLerpValue = 3f;

        private float rotateSpeed = 2f;

        /// <summary>
        /// 相机旋转速度
        /// </summary>
        public float RotateSpeed {
            get { return GetEntity<TPSEntity>().RotateSpeed; }
            set { GetEntity<TPSEntity>().RotateSpeed = value; }
        }

        private float x = 0.0f;
        private float y = 0.0f;
        private Quaternion rotation;
        private Vector3 position;
        private float tempDistance;
        private float tempDistance1;
        private float tempDistance2;
        private float tempDistance3;
        private float tempDistance4;
        private float tempDistance5;
        private float tempPos = 0.01f;

        #endregion

        #region 触屏相关
        /// <summary>
        /// 是否使用旋转
        /// </summary>
        private bool isFingerRotate = false;
        #endregion

        /// <summary>
        /// 人物静止
        /// </summary>
        protected virtual void PeopleNomal() { Debug.Log("站立状态"); }

        /// <summary>
        /// 人物走路
        /// </summary>
        protected virtual void PeopleWalk() { Debug.Log("走路状态"); }

        private void Awake()
        {

            if (canvas == null)
            {
                Canvas[] canvass = FindObjectsOfType<Canvas>();
                for (int i = 0; i < canvass.Length; i++)
                {
                    if (canvass[i].renderMode == RenderMode.ScreenSpaceOverlay && !canvass[i].name.Equals("Buskit3D#Root"))
                    {
                        canvas = canvass[i].gameObject;
                        break;
                    }
                }
            }
            if (lookCamera == null)
            {
                lookCamera = GameObject.Find("Main Camera").transform;
            }
        }

        private void OnEnable()
        {
            if (lookCamera != null)
            {
                x = lookCamera.eulerAngles.y;
                y = lookCamera.eulerAngles.x;
            }
        }

        private void Start()
        {
            AddEntity<TPSEntity>();
            controller = transform.GetComponent<CharacterController>();
            moveSpeed = SaveValue.MoveSpeed;
            rotateSpeed = SaveValue.RotateSpeed;

            x = lookCamera.eulerAngles.y;
            y = lookCamera.eulerAngles.x;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            rotation = Quaternion.Euler(y, x, 0f);
            position = transform.position - (rotation * Vector3.forward * distance + new Vector3(0, -playerHeight, 0));
            lookCamera.rotation = rotation;
            lookCamera.position = position;
        }

        private void FixedUpdate()
        {
            if (IPointerOver.IsPointerOverUI(canvas) && !SaveValue.StorageState)
            {
                OnMoveEnd();
                return;
            }


            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !SaveValue.StorageState)
            {
                GetEntity<TPSEntity>().TPSMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !SaveValue.StorageState)
            {
                OnMoveEnd();
            }

            if (!controller.isGrounded)
            {
                //模拟重力
                controller.Move(transform.up * Time.deltaTime * -10f);
            }
        }

        private void Update()
        {

            if (IPointerOver.IsPointerOverUI(canvas) && !SaveValue.StorageState)
            {
                return;
            }


            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //单指旋转
                if (Input.touchCount == 1 && !SaveValue.StorageState)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        isFingerRotate = true;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved && isFingerRotate)
                    {
                        GetEntity<TPSEntity>().TPSRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        isFingerRotate = false;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(1) && !SaveValue.StorageState)
                {
                    GetEntity<TPSEntity>().TPSRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                }
            }
            OnRotate(x, y);
        }

        private void OnDisable()
        {
            OnMoveEnd();
        }

        private void OnDestroy()
        {
            RemoveEntity<TPSEntity>();
        }


        public override void ProcessLogic(IEvent evt)
        {
            //移动速度
            if (evt.EventName.Equals("MoveSpeed"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                moveSpeed = newValue;
            }
            //旋转速度
            if (evt.EventName.Equals("RotateSpeed"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                rotateSpeed = newValue;
            }
            if (evt is MethodEvent)
            {
                //人物移动
                if (evt.EventName.Equals("TPSMove"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    float moveX = (float)data[0];
                    float moveZ = (float)data[1];
                    if (moveX != 0 || moveZ != 0)
                    {
                        OnMove(moveX, moveZ);
                        OnMoveSpeed(moveX, moveZ);
                    }
                }
                //相机旋转
                if (evt.EventName.Equals("TPSRotate"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    float rotateX = (float)data[0];
                    float rotateZ = (float)data[1];
                    x += rotateX * rotateSpeed ;
                    y -= rotateZ * rotateSpeed ;
                    y = ClampAngle(y, yMinLimit, yMaxLimit);
                }
                if (evt.EventName.Equals("OnMoveState")) {
                    if (isNomalState)
                    {
                        isNomalState = false;
                        PeopleWalk();
                    }
                }
                if (evt.EventName.Equals("OnMoveEnd")) {
                    if (!isNomalState)
                    {
                        isNomalState = true;
                        PeopleNomal();
                    }
                }
            }
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="valueX"></param>
        /// <param name="valueY"></param>
        private void OnMove(float valueX, float valueY)
        {
            direction = new Vector3(valueX, 0, valueY).normalized;
            transform.localEulerAngles = new Vector3(0, Quaternion.FromToRotation(Vector3.forward, direction).eulerAngles.y, 0) + new Vector3(0, lookCamera.transform.eulerAngles.y, 0);
            OnMoveState(); 
        }

        /// <summary>
        /// 移动速度
        /// </summary>
        /// <param name="valueX"></param>
        /// <param name="valueY"></param>
        private void OnMoveSpeed(float valueX, float valueY)
        {
            controller.Move(transform.forward * Time.deltaTime * (Mathf.Max(Mathf.Abs(valueX), Mathf.Abs(valueY))) * moveSpeed);
        }

        /// <summary>
        /// 移动中
        /// </summary>
        private void OnMoveState() {
            GetEntity<TPSEntity>().OnMoveState();
            
        }

        /// <summary>
        /// 移动结束
        /// </summary>
        private void OnMoveEnd()
        {
            GetEntity<TPSEntity>().OnMoveEnd();
        }

        /// <summary>
        /// 相机旋转
        /// </summary>
        /// <param name="rotateX"></param>
        /// <param name="rotateY"></param>
        private void OnRotate(float rotateX,float rotateY) {
            rotation = Quaternion.Lerp(rotation, Quaternion.Euler(rotateY, rotateX, 0f), Time.deltaTime * rotateLerpValue);
            lookCamera.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y,0) ;
            position = transform.position - (rotation * Vector3.forward * distance + new Vector3(0, -playerHeight, 0));
            lookCamera.position = position;
            //防穿墙
            RaycastHit hit1;
            RaycastHit hit2;
            RaycastHit hit3;
            RaycastHit hit4;
            RaycastHit hit5;
            Vector3 trueTargetPosition = transform.position + new Vector3(0, playerHeight, 0);
            if (Physics.Linecast(trueTargetPosition, lookCamera.position, out hit1) ||
                Physics.Linecast(trueTargetPosition + (lookCamera.right * tempPos), lookCamera.position + (lookCamera.right * tempPos), out hit2) ||
                Physics.Linecast(trueTargetPosition - (lookCamera.right * tempPos), lookCamera.position - (lookCamera.right * tempPos), out hit3) ||
                Physics.Linecast(trueTargetPosition + (lookCamera.up * tempPos), lookCamera.position + (lookCamera.up * tempPos), out hit4) ||
                Physics.Linecast(trueTargetPosition - (lookCamera.up * tempPos), lookCamera.position - (lookCamera.up * tempPos), out hit5))
            {
                tempDistance1 = distance;
                tempDistance2 = distance;
                tempDistance3 = distance;
                tempDistance4 = distance;
                tempDistance5 = distance;
                if (Physics.Linecast(trueTargetPosition, lookCamera.position, out hit1))
                {
                    tempDistance1 = Vector3.Distance(trueTargetPosition, hit1.point);
                }
                if (Physics.Linecast(trueTargetPosition + (lookCamera.right * tempPos), lookCamera.position + (lookCamera.right * tempPos), out hit2))
                {
                    tempDistance2 = Vector3.Distance(trueTargetPosition + (lookCamera.right * tempPos), hit2.point);
                }
                if (Physics.Linecast(trueTargetPosition - (lookCamera.right * tempPos), lookCamera.position - (lookCamera.right * tempPos), out hit3))
                {
                    tempDistance3 = Vector3.Distance(trueTargetPosition - (lookCamera.right * tempPos), hit3.point);
                }
                if (Physics.Linecast(trueTargetPosition + (lookCamera.up * tempPos), lookCamera.position + (lookCamera.up * tempPos), out hit4))
                {
                    tempDistance4 = Vector3.Distance(trueTargetPosition + (lookCamera.up * tempPos), hit4.point);
                }
                if (Physics.Linecast(trueTargetPosition - (lookCamera.up * tempPos), lookCamera.position - (lookCamera.up * tempPos), out hit5))
                {
                    tempDistance5 = Vector3.Distance(trueTargetPosition - (lookCamera.up * tempPos), hit5.point);
                }
                tempDistance = Mathf.Min(tempDistance1, tempDistance2, tempDistance3, tempDistance4, tempDistance5, distance);
                position = transform.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -playerHeight, 0));
                lookCamera.position = position;
            }
        }


        private static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
