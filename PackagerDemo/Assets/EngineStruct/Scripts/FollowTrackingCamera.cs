using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowTrackingCamera : MonoBehaviour
{
    // Camera target to look at.
    //相机跟随目标
    public Transform target;

    // Exposed vars for the camera position from the target.
    //从目标到摄像机位置的外露vars.
    public float height = 41;
    public float distance = 41;

    // Camera limits.
    //相机移动范围
    public float min = 10f;
    public float max = 60;

    // Options.
    //public bool doRotate;
    //相机旋转以及缩放功能开关
    public bool doZoom = true;
    public bool doRotate = true;

    // The movement amount when zooming.缩放时的移动量。
    public float zoomStep = 30f;
    public float zoomSpeed = 5f;
    private float heightWanted;
    private float distanceWanted;


    public float xSpeed = 9f;
    public float ySpeed = 9f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    //public float xMinLimit = 30f;
    //public float xMaxLimit = 220f;

    public float distanceMin = 1.5f;
    public float distanceMax = 15f;

    public float smoothTime = 2f;

    float rotationYAxis = 230.0f;
    float rotationXAxis = -8.0f;

    float velocityX = 0.0f;
    float velocityY = 0.0f;

    //两根手指
    private Touch oldTouch1;
    private Touch oldTouch2;
    //Vector2 m_screenPos = Vector2.zero; //记录手指触碰的位置

    float scaleFactor;

    // Result vectors.
    private Vector3 zoomResult;//缩放后坐标
    private Quaternion rotationResult;
    private Vector3 targetAdjustedPosition;
    private Quaternion rotation;

    void Start()
    {

        init();

    }
    public void init()
    {
        Position = transform.position;
        rotation = transform.rotation;

        //得到相机欧拉角
        Vector3 angles = transform.eulerAngles;
        //相机绕Y轴转动的角度值
        rotationYAxis = angles.y;
        //相机绕X轴转动的角度值
        rotationXAxis = angles.x;
        //print("Y轴数值"+ rotationYAxis);
        //print("X轴数值" + rotationXAxis);

        // Initialise default zoom vals.
        //相机当前高度赋值于目标高度
        heightWanted = height;
        distanceWanted = distance;
        // Setup our default camera.  We set the zoom result to be our default position.
        zoomResult = new Vector3(0f, height, -distance);
    }
    public static float InitAngle = -90;
    public float CurrAngle = 45;
    public float WantedScale = 20;//想要的缩进大小
    void LateUpdate()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //}
        if (IsInit == true)
        {
            distanceWanted = WantedScale;
            //AsianAni.Instance.Tween(InitAngle);
            rotationXAxis = 25;
            //DOTween.To(() => distanceWanted, x => distanceWanted = x, 19, 0.01f);
            DOTween.To(() => rotationXAxis, x => rotationXAxis = x, CurrAngle, 0.5f);
            rotationYAxis = 0;
            IsInit = false;
        }
        // Check target.
        //检测目标是否存在
        if (!target)
        {
            Debug.LogError("This camera has no target, you need to assign a target in the inspector.");
            return;
        }

        //相机视角缩放
        if (doZoom)
        {
            //print(doRotate);
            //if (Input.touchCount <= 0)
            //{
            //    return;
            //}
            float mouseInput;
            if (Input.touchCount > 1)
            {

                Touch newTouch1 = Input.GetTouch(0);
                Touch newTouch2 = Input.GetTouch(1);
                //第2点刚开始接触屏幕, 只记录，不做处理  
                if (newTouch2.phase == TouchPhase.Began)
                {
                    oldTouch2 = newTouch2;
                    oldTouch1 = newTouch1;
                    //return;
                }
                //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型  
                float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
                float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
                //两个距离只差，为正表示放大，为负表示缩小
                float offset = newDistance - oldDistance;
                //缩放因子
                scaleFactor = offset / 1000f;

                mouseInput = scaleFactor;

                heightWanted -= zoomStep * mouseInput;
                distanceWanted -= zoomStep * mouseInput;
            }

            // Record our mouse input.  If we zoom add this to our height and distance.
            //记录鼠标滚轮滚动时的变量 并赋值记录
            //mouseInput特性：正常状态为0；滚轮前推一格变为+0.1一次，后拉则变为-0.1一次
            // Input.GetAxis("Mouse ScrollWheel");
            if (Input.touchCount <= 0)
            {
                mouseInput = Input.GetAxis("Mouse ScrollWheel");

                heightWanted -= zoomStep * mouseInput;
                distanceWanted -= zoomStep * mouseInput;
            }
            //print("+++"+mouseInput);

            // Make sure they meet our min/max values.
            //限制相机高度范围 
            heightWanted = Mathf.Clamp(heightWanted, min, max);
            distanceWanted = Mathf.Clamp(distanceWanted, min, max);
            //差值计算，动态修改相机高度值（平滑的变化）
            height = Mathf.Lerp(height, heightWanted, Time.deltaTime * zoomSpeed);
            distance = Mathf.Lerp(distance, distanceWanted, Time.deltaTime * zoomSpeed);

            // Post our result.
            //缩放后坐标
            zoomResult = new Vector3(0f, height, -distance);
        }
        //相机视角旋转
        if (doRotate)
        {
            //print("水平" + Input.GetAxis("Horizontal"));
            //print("竖直" + Input.GetAxis("Vertical"));
            if (Input.touchCount == 1)
            {
                Touch newTouch1 = Input.GetTouch(0);
                //Touch touch = Input.GetTouch(0);
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    oldTouch1 = newTouch1;
                    //m_screenPos = touch.position;  
                }

                if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    float CX = newTouch1.position.x - oldTouch1.position.x;
                    float CY = newTouch1.position.y - oldTouch1.position.y;

                    velocityX += xSpeed * CX * 0.02f * Time.deltaTime;
                    velocityY += ySpeed * CY * 0.02f * Time.deltaTime;
                }
            }
            if (Input.GetMouseButton(1))
            {
                // print("欧拉角"+transform.eulerAngles);
                velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            if (rotationXAxis >= 90)
            {
                rotationXAxis = 90;
            }
            else if (rotationXAxis <= 1)
            {
                rotationXAxis = 1;
            }
        }
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        //相机跟随
        Vector3 position = rotation * negDistance + target.position;
        //改变相机Rotation，从而旋转相机
        transform.rotation = rotation;



        //将缩放后的坐标作为相机的当前坐标位置
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        //限制相机转动角度 
        return Mathf.Clamp(angle, min, max);
    }

    public void InitPoint()
    {
        heightWanted = max;
        distanceWanted = max;
    }

    public void InitReturn(float a, float b)
    {
        heightWanted = a;
        distanceWanted = b;
    }
    public Vector3 Position;//当前摄像机的位置
    public Vector3 Rotation;//当前摄像机的角度

    public bool IsInit = false;
}
