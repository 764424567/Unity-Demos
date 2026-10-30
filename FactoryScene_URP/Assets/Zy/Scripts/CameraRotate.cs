using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    public float minDistance = 120;/*缩放最近距离*/
    public float maxDistance = 240;//缩放的最远距离

    public int yMinLimit = 10;//旋转的Y轴最小值
    public int yMaxLimit = 80;//旋转的Y轴最大值

    public float speed = 30f;//缩放的速度

    public float smoothness = 0.1f;//惯性的平滑系数

    public GameObject TargetPoint;
    public GameObject[] TargetPointArray;
    Vector3 currentDirention;
    public float distance;
    float angle;
    float targetangle;
    float pinchDist = 0;
    float roatspeedy;
    public static  bool m_autoRotation = false;
    public  float waittime = 5;
    public  float x;
    public  float y;
    float xSpeed = 30f;
    float ySpeed = 30f;
    bool keepMove = false;
    float zoomVelocity = 0.01f;
    float targetDistance = 10f;
    readonly Vector2 m_fitScreenRes = new Vector2(2048f, 1536f);
    float m_touchMaxDist = 20f;
    Vector3 tempPos;
    Quaternion temproat;


    void Awake()
    {
    }

    private void Start()
    {
        tempPos = transform.localPosition;
        temproat = transform.localRotation;
        distance = Vector3.Distance(transform.position, TargetPoint.transform.position);
        currentDirention = transform.position - TargetPoint.transform.position;
        angle = Vector3.Angle(currentDirention, new Vector3(0, 1, 0));
        targetangle = angle;
        targetDistance = distance;
        float xFactor = m_fitScreenRes.x / Screen.width;
        float yFactor = m_fitScreenRes.y / Screen.height;
        xSpeed = xFactor * speed;
        ySpeed = yFactor * speed;
        m_touchMaxDist /= xFactor;
    }

    // 切换目标点
    public void CutTarget()
    {
        TargetPoint = TargetPointArray[1];
    }

    void LateUpdate()
    {
        //if (OpenUnit.ISMove)
        {
            float time = Time.deltaTime;
            if (time > 0.035f)
            {
                time = 0.035f;
            }
            //#if UNITY_EDITOR

            if (Input.touchCount > 0)
            {
                if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
                {
                    m_autoRotation = false;
                    waittime = 2;
                    keepMove = false;
                    y = Input.touches[0].deltaPosition.y;
                    x = Input.touches[0].deltaPosition.x;
                    x = Mathf.Clamp(x, -m_touchMaxDist, m_touchMaxDist);
                    y = Mathf.Clamp(y, -m_touchMaxDist, m_touchMaxDist);
                    transform.RotateAround(TargetPoint.transform.position, Vector3.up, x * xSpeed * time * 0.5f);
                    currentDirention = transform.position - TargetPoint.transform.position;

                    roatspeedy = y * ySpeed * time;

                    targetangle = angle + roatspeedy * 0.25f;
                    if (targetangle < yMinLimit)
                    {
                        roatspeedy = 0;
                        targetangle = yMinLimit;
                    }
                    if (targetangle > yMaxLimit)
                    {
                        roatspeedy = 0;
                        targetangle = yMaxLimit;
                    }
                    transform.RotateAround(TargetPoint.transform.position, transform.right, -roatspeedy * 0.5f);
                    currentDirention = transform.position - TargetPoint.transform.position;
                    angle = Vector3.Angle(currentDirention, Vector3.up); //求出两向量之间的夹角 
                }
                else if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Ended)
                {
                    keepMove = true;
                }
                else if (Input.touchCount > 1)
                {
                    m_autoRotation = false;
                    waittime = 2;
                    keepMove = false;
                    if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
                    {
                        if (pinchDist == 0)
                        {
                            pinchDist = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                        }
                        else
                        {
                            float dx = ((pinchDist - (float)Vector2.Distance(Input.touches[0].position, Input.touches[1].position)) * 0.04f);
                            zoomVelocity = dx;
                            if (targetDistance + zoomVelocity < minDistance)
                            {
                                zoomVelocity = minDistance - targetDistance;
                            }
                            else if (targetDistance + zoomVelocity > maxDistance)
                            {
                                zoomVelocity = maxDistance - targetDistance;
                            }
                            targetDistance += zoomVelocity;
                            pinchDist = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                        }
                        currentDirention = transform.position - TargetPoint.transform.position;
                        distance = Mathf.Lerp(distance, targetDistance, 0.3f);
                        transform.position = TargetPoint.transform.position + distance * currentDirention.normalized;
                    }
                    if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[1].phase == TouchPhase.Ended)
                    {
                        pinchDist = 0;
                    }

                }
            }
            float w = Input.GetAxis("Mouse ScrollWheel");

            if (Input.GetMouseButton(1))
            {
                x = Input.GetAxis("Mouse X") * xSpeed * 0.4f;
                y = Input.GetAxis("Mouse Y") * ySpeed * 0.4f;
                waittime = 5;
                m_autoRotation = false;

                transform.RotateAround(TargetPoint.transform.position, Vector3.up, x * xSpeed * time);
                roatspeedy = y * ySpeed * time;
                targetangle = angle + roatspeedy;
                if (targetangle < yMinLimit)
                {
                    //roatspeedy=speed*Time.deltaTime;
                    roatspeedy = 0;
                }
                if (targetangle > yMaxLimit)
                {
                    //roatspeedy=-speed*Time.deltaTime;
                    roatspeedy = 0;
                }
                transform.RotateAround(TargetPoint.transform.position, transform.right, -roatspeedy);
                currentDirention = transform.position - TargetPoint.transform.position;
                angle = Vector3.Angle(currentDirention, Vector3.up); //求出两向量之间的夹角 
                keepMove = false;
            }
            if (w != 0)
            {
                waittime = 5;
                m_autoRotation = false;
                zoomVelocity = w * -3;
                if (Camera.main.fieldOfView >= 35 && Camera.main.fieldOfView <= 56)
                {
                    Camera.main.fieldOfView += zoomVelocity;
                }
                else if (Camera.main.fieldOfView < 35)
                {
                    Camera.main.fieldOfView = 35;
                }
                else if (Camera.main.fieldOfView > 56)
                {
                    Camera.main.fieldOfView = 56;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                keepMove = true;
            }
            if (keepMove) //惯性（缓动）
            {
                if (x > -0.1f && x < 0.1f)
                {
                    keepMove = false;
                }
                x = x - x * smoothness;
                transform.RotateAround(TargetPoint.transform.position, Vector3.up, x * xSpeed * time);
                return;      
            }
        }
    }
}