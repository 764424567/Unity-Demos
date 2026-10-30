/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：FPSLogic
* 创建日期：2020-06-05 13:23:51
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：第一人称人物移动相机控制
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{

    /// <summary>
    /// 
    /// </summary>
    public class FPSLogic : ObjLogicBase
    {
        #region 视角相关
        /// <summary>
        /// 第一人称相机
        /// </summary>
        private Transform fpsCamera;

        /// <summary>
        /// 第一人称相机
        /// </summary>
        public Transform FPSCamera {
            get { return fpsCamera; }
        }

        /// <summary>
        /// Y轴旋转最小值
        /// </summary>
        private float minRotateY = -60f;

        /// <summary>
        /// Y轴旋转最大值
        /// </summary>
        private float maxRotateY = 60f;

        /// <summary>
        /// 最小视野
        /// </summary>
        private float minFOV = 10f;

        /// <summary>
        /// 最大视野
        /// </summary>
        private float maxFOV = 60f;

        /// <summary>
        /// 视野
        /// </summary>
        private float fov = 60f;

        /// <summary>
        /// 旋转速度
        /// </summary>
        private float rotateSpeed = 2f;

        /// <summary>
        /// 旋转速度
        /// </summary>
        public float RotateSpeed {
            get { return GetEntity<FPSEntity>().RotateSpeed; }
            set { GetEntity<FPSEntity>().RotateSpeed = value; }
        }

        

        private Quaternion tmpRotationX;
        private Quaternion tmpRotationY;

        /// <summary>
        /// 相机旋转平滑度
        /// </summary>
        [Range(1f, 5f)]
        public float rotateLerpValue = 3f;
        #endregion

        #region 移动相关
        [SerializeField, Tooltip("是否使用重力")]
        public bool isUseGravity = true;

        /// <summary>
        /// 移动速度
        /// </summary>
        private float moveSpeed = 5f;

        /// <summary>
        /// 人物移动速度
        /// </summary>
        public float MoveSpeed {
            get { return GetEntity<FPSEntity>().MoveSpeed; }
            set { GetEntity<FPSEntity>().MoveSpeed = value; }
        }

        /// <summary>
        /// 角色控制器
        /// </summary>
        private CharacterController character;

        private Vector3 move = Vector3.zero;

        private bool isUseCameraMove = false;
        #endregion

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

        public GameObject canvas;

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
            fpsCamera = transform.GetChild(0);
        }

        private void OnEnable()
        {
            ResetFOV();
            ResetRotate();
        }

        private void Start()
        {
            AddEntity<FPSEntity>();
            if (GetComponent<CharacterController>())
            {
                character = transform.GetComponent<CharacterController>();
            }

            MoveSpeed = SaveValue.MoveSpeed;
            RotateSpeed = SaveValue.RotateSpeed;
            ResetRotate();
        }

        private void OnDestroy()
        {
            RemoveEntity<FPSEntity>();
        }

        private void Update()
        {
            if (IPointerOver.IsPointerOverUI(canvas)&&!SaveValue.StorageState)
            {
                ResetRotate();
                return;
            }
            if (!isUseCameraMove)
            {
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
                            GetEntity<FPSEntity>().RotationX = Input.GetAxis("Mouse X") * rotateSpeed * (fov / maxFOV);
                            GetEntity<FPSEntity>().RotationY = Input.GetAxis("Mouse Y") * rotateSpeed * (fov / maxFOV);
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
                            fov -= (Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) - oldOffset) * 0.05f;
                            fov = Mathf.Clamp(fov, minFOV, maxFOV);
                            GetEntity<FPSEntity>().Fov = fov;
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
                        GetEntity<FPSEntity>().RotationX = Input.GetAxis("Mouse X") * rotateSpeed * (fov / maxFOV);
                        GetEntity<FPSEntity>().RotationY = Input.GetAxis("Mouse Y") * rotateSpeed * (fov / maxFOV);
                    }
                    if (Input.GetAxis("Mouse ScrollWheel") != 0 && !SaveValue.StorageState)
                    {
                        fov -= Input.GetAxis("Mouse ScrollWheel") * 20f;
                        fov = Mathf.Clamp(fov, minFOV, maxFOV);
                        GetEntity<FPSEntity>().Fov = fov;
                    }
                    
                }
                    
                transform.localRotation = Quaternion.Slerp(transform.localRotation, tmpRotationX, Time.deltaTime * rotateLerpValue);
                fpsCamera.localRotation = Quaternion.Slerp(fpsCamera.localRotation, tmpRotationY, Time.deltaTime * rotateLerpValue);

                if (character != null && !SaveValue.StorageState)
                {
                    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                    {
                        GetEntity<FPSEntity>().Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    }
                    
                }
                
            }
        }

        private void ResetRotate()
        {
            tmpRotationX = transform.localRotation;
            tmpRotationY = fpsCamera.localRotation;
        }

        /// <summary>
        /// 重置视距
        /// </summary>
        public void ResetFOV()
        {
            if (GetEntity<FPSEntity>() != null)
            {
                fov = 60f;
                GetEntity<FPSEntity>().Fov = 60f;
            }
        }

        /// <summary>
        /// 移动到目标位置
        /// </summary>
        /// <param name="targetName">目标位置</param>
        /// <param name="time">移动时长</param>
        /// <param name="action">回调</param>
        public void MoveToPos(string targetName, float time, UnityAction action) {
            SetCallBackAction(action);
            GetEntity<FPSEntity>().MoveToPos(targetName, time );
        }

        /// <summary>
        /// 同步到目标位置
        /// </summary>
        /// <param name="targetName"></param>
        public void SetToPos(string targetName) {
            GetEntity<FPSEntity>().SetToPos(targetName);
        }

        public override void ProcessLogic(IEvent evt)
        {
            //移动视角X轴
            if (evt.EventName.Equals("RotationX"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                tmpRotationX *= Quaternion.Euler(0, newValue, 0);
            }
            //移动视角Y轴
            if (evt.EventName.Equals("RotationY"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                tmpRotationY *= Quaternion.Euler(-newValue, 0, 0);
                tmpRotationY = ClampRotation(tmpRotationY, minRotateY, maxRotateY);
            }
            //设置视野
            if (evt.EventName.Equals("Fov"))
            {
                
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                fpsCamera.GetComponent<Camera>().fieldOfView = newValue;
            }
            //设置移动速度
            if (evt.EventName.Equals("MoveSpeed"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                moveSpeed = newValue;
            }
            //设置相机旋转速度
            if (evt.EventName.Equals("RotateSpeed"))
            {
                PropertyEvent propertyEvent = evt as PropertyEvent;
                float newValue = (float)propertyEvent.NewValue;
                rotateSpeed = newValue;
            }
            //人物移动
            if (evt is MethodEvent)
            {
                if (evt.EventName.Equals("Move"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    float moveX = (float)data[0];
                    float moveZ = (float)data[1];
                    move.x = moveX * moveSpeed;
                    move.z = moveZ * moveSpeed;
                    if (isUseGravity)
                    {
                        character.SimpleMove(transform.TransformVector(move));
                    }
                    else
                    {
                        move.x = move.x * 0.01f;
                        move.z = move.z * 0.01f;
                        character.Move(transform.TransformVector(move));
                    }
                }
                if (evt.EventName.Equals("MoveToPos"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string targetName = (string)data[0];
                    float time = (float)data[1];
                    MoveToPosLogic(targetName, time, GetCallBackAction());
                }
                if (evt.EventName.Equals("SetToPos"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string targetName = (string)data[0];
                    SetToPosLogic(targetName);
                }
            }
        }


        private void MoveToPosLogic(string targetName,float time,UnityAction action) {
            if (character)
            {
                Debug.Log("使用人物移动无法调用此方法，请使用LookCamera");
                return;
            }
            ResetFOV();
            isUseCameraMove = true;
            Transform target = InjectService.Get<ObjManager>().GetGameObject(targetName, targetName).transform;
            Tween tweenPos = transform.DOMove(target.localPosition, time).SetEase(Ease.Linear);
            Tween tweenRotX = transform.DORotate(new Vector3(0, target.localEulerAngles.y, 0), time).SetEase(Ease.Linear);
            Tween tweenRotY = fpsCamera.DOLocalRotate(new Vector3(target.localEulerAngles.x, 0, 0), time).SetEase(Ease.Linear);
            tweenPos.OnComplete(()=> {
                if (action != null)
                {
                    action.Invoke();
                }
                tweenPos.Kill();
                tweenRotX.Kill();
                tweenRotY.Kill();
                
                isUseCameraMove = false;
                ResetRotate();
            });
        }


        private void SetToPosLogic(string targetName) {
            if (character)
            {
                Debug.Log("使用人物移动无法调用此方法");
                return;
            }
            ResetFOV();
            transform.DOKill();
            fpsCamera.DOKill();
            Transform target = InjectService.Get<ObjManager>().GetGameObject(targetName, targetName).transform;
            transform.position = target.position;
            transform.eulerAngles = new Vector3(0, target.localEulerAngles.y, 0);
            fpsCamera.localEulerAngles = new Vector3(target.localEulerAngles.x, 0, 0);
            ResetRotate();
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
            //if (angle < 0)
            //    angle += 360;
            if (angle > 180)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

        private Quaternion ClampRotation(Quaternion rotation ,float min,float max)
        {
            rotation.x /= rotation.w;
            rotation.y /= rotation.w;
            rotation.z /= rotation.w;
            rotation.w = 1.0f;
            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(rotation.x);
            angleX = Mathf.Clamp(angleX, min, max);
            rotation.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
            return rotation;
        }
    }
}
