/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：LookAtCameraLogic
* 创建日期：2020-06-15 16:10:13
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：观察物体相机
******************************************************************************/
using UnityEngine;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZhangChen
{   
	/// <summary>
    /// 
    /// </summary>
	public class LookAtCameraLogic : ObjLogicBase 
	{
        [SerializeField, Tooltip("观察目标")]
        /// <summary>
        /// 观察目标
        /// </summary>
        public Transform target;

        /// <summary>
        /// 可缩放区域
        /// </summary>
        public GameObject canvas;

        /// <summary>
        /// 距离范围
        /// </summary>
        [SerializeField, Tooltip("x:最小距离；y:最大距离")]
        public Vector2 distanceRange = new Vector2(2f, 6f);

        [SerializeField, Tooltip("距离滑动条值")]
        /// <summary>
        /// 距离滑动条值
        /// </summary>
        [Range(0f, 1f)]
        public float Distanceslider = 0.5f;

        [SerializeField, Tooltip("相机旋转速度")]
        /// <summary>
        /// 相机旋转速度
        /// </summary>
        public float RotateSpeed = 2f;

        /// <summary>
        /// 目标点移动速度
        /// </summary>
        public float MoveSpeed = 0.03f;

        /// <summary>
        /// 上下旋转限制
        /// </summary>
        [Tooltip("x:最小；y：最大")]
        public Vector2 UpDownRotateLimit = new Vector2(-20f, 80f);

        /// <summary>
        /// 相机旋转平滑度
        /// </summary>
        [Range(1f, 5f)]
        public float rotateLerpValue = 3f;

        /// <summary>
        /// 相机远近速度
        /// </summary>
        public float DistanceSpeed = 1f;

        /// <summary>
        /// 相机镜头防遮挡屏蔽层
        /// </summary>
        public string LayMaskName = "Tool";

        /// <summary>
        /// 是否使用相机焦点位移
        /// </summary>
        public bool isUseTargetCenterMove = true;
        private float targetMoveX = 0.0f;
        private float targetMoveY = 0.0f;
        private Vector3 orgTargetPos;
        private float time = 0f;

        private float mouseX = 0.0f;
        private float mouseY = 0.0f;
        private Vector3 StartAngles;
        private float StartDistanceslider;
        private float NowDistanceslider;
        private Vector3 StartPosition;
        private Vector3 pos;
        private Quaternion toRotation;
        private float tempDistance;
        private float tempDistance1;
        private float tempDistance2;
        private float tempDistance3;
        private float tempDistance4;
        private float tempDistance5;
        private float tempPos = 0.1f;
        private float clickTime = 0;
        private bool isCountDown = false;

        private Quaternion tmpRotation;

        #region 触屏相关
        /// <summary>
        /// 初始距离
        /// </summary>
        private float oldOffset;
        /// <summary>
        /// 是否使用旋转
        /// </summary>
        private bool isFingerRotate = false;
        #endregion

        private void Awake()
        {
            if (canvas == null)
            {
                Canvas[] canvass = FindObjectsOfType<Canvas>();
                for (int i = 0; i < canvass.Length; i++)
                {
                    if (canvass[i].renderMode == RenderMode.ScreenSpaceOverlay)
                    {
                        canvas = canvass[i].gameObject;
                        break;
                    }
                }
            }
        }

        private void Start()
        {
            AddEntity<LookAtCameraEntity>();
            if (!target)
            {
                target = new GameObject("Target").transform;
            }
            orgTargetPos = target.position;

            PostionInitialize();
            NowDistanceslider = Distanceslider;
            ResetPostion();

            tempDistance1 = GetCurDistance();
            tempDistance2 = GetCurDistance();
            tempDistance3 = GetCurDistance();
            tempDistance4 = GetCurDistance();
            tempDistance5 = GetCurDistance();
        }

        private void OnDestroy()
        {
            RemoveEntity<LookAtCameraEntity>();
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
                        GetEntity<LookAtCameraEntity>().RotationX = Input.GetAxis("Mouse X") * RotateSpeed;
                        GetEntity<LookAtCameraEntity>().RotationY = Input.GetAxis("Mouse Y") * RotateSpeed;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        isFingerRotate = false;
                    }
                }
                //双指缩放
                if (Input.touchCount == 2 && !SaveValue.StorageState)
                {
                    if (Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        oldOffset = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                        isFingerRotate = false;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
                    {
                        GetEntity<LookAtCameraEntity>().MouseScrollWheel = (Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) - oldOffset) * 0.001f;
                        oldOffset = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
                    {
                        oldOffset = 0;
                        isFingerRotate = false;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(1) && !SaveValue.StorageState)
                {
                    GetEntity<LookAtCameraEntity>().RotationX = Input.GetAxis("Mouse X") * RotateSpeed;
                    GetEntity<LookAtCameraEntity>().RotationY = Input.GetAxis("Mouse Y") * RotateSpeed;
                }
                if (Input.GetAxis("Mouse ScrollWheel") != 0 && !SaveValue.StorageState)
                {
                    GetEntity<LookAtCameraEntity>().MouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
                }
            }
            
            if (isUseTargetCenterMove)
            {
                if (Input.GetMouseButton(2) && !SaveValue.StorageState)
                {
                    GetEntity<LookAtCameraEntity>().MoveX = Input.GetAxis("Mouse X") * MoveSpeed;
                    GetEntity<LookAtCameraEntity>().MoveY = Input.GetAxis("Mouse Y") * MoveSpeed;
                }
                if (Input.GetMouseButtonUp(2) && !SaveValue.StorageState)
                {
                    GetEntity<LookAtCameraEntity>().MoveX = 0;
                    GetEntity<LookAtCameraEntity>().MoveY = 0;
                }
                if (IsClickMouseTwice(0.2f,ref time,2) && !SaveValue.StorageState)
                {
                    GetEntity<LookAtCameraEntity>().ResetTargetPosition();
                }
            }
            
        }

        private void FixedUpdate()
        {

            if (isUseTargetCenterMove) {
                target.transform.position += (targetMoveX * transform.right) + (targetMoveY * transform.up);
            }
            mouseY = ClampAngle(mouseY, UpDownRotateLimit.x, UpDownRotateLimit.y);
            tmpRotation =  Quaternion.Euler( mouseY, mouseX, 0);
            tmpRotation = Quaternion.Lerp(transform.localRotation, tmpRotation, Time.deltaTime * rotateLerpValue);
            transform.localRotation = Quaternion.Euler(tmpRotation.eulerAngles.x, tmpRotation.eulerAngles.y, 0); 

            toRotation = transform.localRotation;

            Vector3 toPosition;
            if (target != null)
            {
                toPosition = target.position  - (toRotation * Vector3.forward * GetCurDistance());
                transform.position = toPosition;
                //防穿墙
                RaycastHit hit1;
                RaycastHit hit2;
                RaycastHit hit3;
                RaycastHit hit4;
                RaycastHit hit5;
                Vector3 trueTargetPosition = target.position;
                if (Physics.Linecast(trueTargetPosition, transform.position, out hit1, LayerMask.NameToLayer(LayMaskName)) ||
                    Physics.Linecast(trueTargetPosition , transform.position + (transform.right * tempPos), out hit2, LayerMask.NameToLayer(LayMaskName)) ||
                    Physics.Linecast(trueTargetPosition , transform.position - (transform.right * tempPos), out hit3, LayerMask.NameToLayer(LayMaskName)) ||
                    Physics.Linecast(trueTargetPosition , transform.position + (transform.up * tempPos), out hit4, LayerMask.NameToLayer(LayMaskName)) ||
                    Physics.Linecast(trueTargetPosition , transform.position - (transform.up * tempPos), out hit5, LayerMask.NameToLayer(LayMaskName)))
                {
                    tempDistance1 = GetCurDistance();
                    tempDistance2 = GetCurDistance();
                    tempDistance3 = GetCurDistance();
                    tempDistance4 = GetCurDistance();
                    tempDistance5 = GetCurDistance();
                    if (Physics.Linecast(trueTargetPosition, transform.position, out hit1, LayerMask.NameToLayer(LayMaskName)))
                    {
                        tempDistance1 = Vector3.Distance(trueTargetPosition, hit1.point);
                    }
                    if (Physics.Linecast(trueTargetPosition, transform.position + (transform.right * tempPos), out hit2, LayerMask.NameToLayer(LayMaskName)))
                    {
                        tempDistance2 = Vector3.Distance(trueTargetPosition, hit2.point);
                    }
                    if (Physics.Linecast(trueTargetPosition, transform.position - (transform.right * tempPos), out hit3, LayerMask.NameToLayer(LayMaskName)))
                    {
                        tempDistance3 = Vector3.Distance(trueTargetPosition, hit3.point);
                    }
                    if (Physics.Linecast(trueTargetPosition, transform.position + (transform.up * tempPos), out hit4, LayerMask.NameToLayer(LayMaskName)))
                    {
                        tempDistance4 = Vector3.Distance(trueTargetPosition, hit4.point);
                    }
                    if (Physics.Linecast(trueTargetPosition, transform.position - (transform.up * tempPos), out hit5, LayerMask.NameToLayer(LayMaskName)))
                    {
                        tempDistance5 = Vector3.Distance(trueTargetPosition, hit5.point);
                    }
                    tempDistance = Mathf.Min(tempDistance1, tempDistance2, tempDistance3, tempDistance4, tempDistance5, GetCurDistance());
                    toPosition = target.position - (toRotation * Vector3.forward * tempDistance);
                    transform.position = toPosition;
                }


            }
        }


        public override void ProcessLogic(IEvent evt)
        {
            if (evt.EventName.Equals("MouseScrollWheel"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                Distanceslider -= newValue * DistanceSpeed;
                Distanceslider = Mathf.Clamp(Distanceslider, 0, 1);
            }
            if (evt.EventName.Equals("RotationX"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                mouseX += newValue;
            }
            if (evt.EventName.Equals("RotationY"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                mouseY -= newValue;
            }
            if (evt.EventName.Equals("MoveX"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                targetMoveX = -newValue;
            }
            if (evt.EventName.Equals("MoveY"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                targetMoveY = -newValue;
            }
            if (evt.EventName.Equals("ResetTargetPosition"))
            {
                ResetTargetPos();
                ResetPostion();
            }
        }

        public void PostionInitialize()
        {
            StartAngles = transform.eulerAngles + new Vector3(20, 0, 0);
            StartDistanceslider = Distanceslider;
        }

        /// <summary>
        /// 重置相机位置
        /// </summary>
        public void ResetPostion()
        {
            mouseX = StartAngles.y;
            mouseY = StartAngles.x;
            Distanceslider = StartDistanceslider;
        }

        /// <summary>
        /// 设置相机旋转
        /// </summary>
        /// <param name="rotation"></param>
        public void SetRotation(Vector2 rotation) {
            mouseX = rotation.y;
            mouseY = rotation.x;
            Distanceslider = StartDistanceslider;
        }

        /// <summary>
        /// 重置观察物体位置
        /// </summary>
        private void ResetTargetPos() {
            target.position = orgTargetPos;
            //targetMoveY = orgTargetPos.y;
        }

        /// <summary>
        /// 获取相机物体间距
        /// </summary>
        /// <returns></returns>
        private float GetCurDistance()
        {
            NowDistanceslider = Distanceslider;
            return distanceRange.x + (distanceRange.y - distanceRange.x) * NowDistanceslider;
        }

        /// <summary>
        /// 限制旋转最大/最小值
        /// </summary>
        /// <param name="angle">当前</param>
        /// <param name="min">最小</param>
        /// <param name="max">最大</param>
        /// <returns></returns>
        private static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// 是否双击了鼠标
        /// </summary>
        /// <param name="offsetTime">时间间隔</param>
        /// <param name="Timer">计时</param>
        /// <param name="keyNum">鼠标键位</param>
        /// <returns></returns>
        public bool IsClickMouseTwice(float offsetTime, ref float Timer, int keyNum)
        {
            if (Input.GetMouseButtonDown(keyNum))
            {
                return IsInTime(offsetTime, ref Timer);
            }
            return false;
        }

        /// <summary>
        /// 是否在时间内
        /// </summary>
        /// <param name="offsetTime">时间间隔</param>
        /// <param name="timer">计时</param>
        /// <returns></returns>
        public static bool IsInTime(float offsetTime, ref float timer)
        {
            if (Time.time - timer < offsetTime)
            {
                return true;
            }
            else
            {
                timer = Time.time;
                return false;
            }
        }
    }
}
