/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：TargetPanelLogic
* 创建日期：2020-10-09 14:40:24
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class TargetPanelLogic : MVVMLogicBase 
	{
        private GameObject target;

        private GameObject self;

        /// <summary>
        /// 设置观察目标提示的相机
        /// </summary>
        public GameObject TargetCamera {
            set { self = value; }
        }

        private string targetName = "Target";

        private bool isHaveTarget = false;

        public bool UseRotate = false;

        private float direction; //箭头旋转的方向，或者说角度，只有正的值

        private Vector3 tmpAngle;   //叉乘结果，用于判断上述角度是正是负

        private float devValue;   //离屏边缘距离

        private float showWidth;    //由devValue计算出从中心到边缘的距离（宽和高）

        private float showHeight;

        private Quaternion originRot;   //箭头原角度

        private bool isScaleMode = true;   //canvas的缩放模式

        private RectTransform canvasSize;

        private void Start()
        {
            float x = GetUIBehaviours(targetName).Width / 2;
            float y = GetUIBehaviours(targetName).Height / 2;
            devValue = x > y ? x : y;
            originRot = transform.rotation;

            if (transform.parent.GetComponent<CanvasScaler>().uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                isScaleMode = true;
                canvasSize = transform.parent.GetComponent<RectTransform>();
            }
            else
            {
                isScaleMode = false;
            }
        }

        private void Update()
        {
            if (isHaveTarget && self != null)
            {
                if (isScaleMode)
                {
                    showWidth = canvasSize.sizeDelta.x / 2 - devValue;
                    showHeight = canvasSize.sizeDelta.y / 2 - devValue;
                }
                else
                {
                    showWidth = Screen.width / 2 - devValue;
                    showHeight = Screen.height / 2 - devValue;
                }
                // 计算向量和角度
                Vector3 forVec = self.transform .forward;  //计算本物体的前向量
                Vector3 angVec = (target.transform.position - self.transform.position).normalized;  //本物体和目标物体之间的单位向量
                Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized; //计算出一个代表方向的向量后投射到本身的xy平面
                Vector3 originVec = self.transform.up;
                direction = Vector3.Dot(originVec, targetVec);  //再跟y轴正方向做点积和叉积，就求出了箭头需要旋转的角度和角度的正负
                tmpAngle = Vector3.Cross(originVec, targetVec);
                direction = Mathf.Acos(direction) * Mathf.Rad2Deg;  //转换为角度
                tmpAngle = self.transform.InverseTransformDirection(tmpAngle);  //叉积结果转换为本物体坐标

                //是否旋转目标标识
                if (UseRotate)
                {
                    GetUIBehaviours(targetName).Rotation = (originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (tmpAngle.z > 0 ? 1 : -1)))).eulerAngles;
                }
                // 计算当前物体在屏幕上的位置
                //Vector2 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);//有问题
                Vector2 screenPos = self.GetComponent<Camera>().WorldToScreenPoint(target.transform.position);

                // 不在屏幕内的情况
                if (screenPos.x < devValue || screenPos.x > Screen.width - devValue || screenPos.y < devValue || screenPos.y > Screen.height - devValue || Vector3.Dot(forVec, angVec) < 0)
                {
                    Vector3 result = Vector3.zero;
                    if (direction == 0) //特殊角度0和180直接赋值
                    {
                        result.y = showHeight;
                    }
                    else if (direction == 180)
                    {
                        result.y = -showHeight;
                    }
                    else    //非特殊角
                    {
                        // 转换角度
                        float direction_new = 90 - direction;
                        float k = Mathf.Tan(Mathf.Deg2Rad * direction_new);
                        // 矩形
                        result.x = showHeight / k;
                        if ((result.x > (-showWidth)) && (result.x < showWidth))    // 角度在上下底边的情况
                        {
                            result.y = showHeight;
                            if (direction > 90)
                            {
                                result.y = -showHeight;
                                result.x = result.x * -1;
                            }
                        }
                        else    // 角度在左右底边的情况
                        {
                            result.y = showWidth * k;
                            if ((result.y > -showHeight) && result.y < showHeight)
                            {
                                result.x = result.y / k;
                            }
                        }
                        if (tmpAngle.z > 0)
                            result.x = -result.x;
                    }
                    GetUIBehaviours(targetName).LocalPosition = result;
                }
                else    // 在屏幕内的情况
                {
                    GetUIBehaviours(targetName).Position = screenPos;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowTargetTip(GameObject targetObject) {
            isHaveTarget = true;
            target = targetObject;
            GetUIBehaviours(targetName).Scale = Vector3.one;
        }

        /// <summary>
        /// 隐藏目标位置
        /// </summary>
        public void HideTargetTip()
        {
            isHaveTarget = false;
            GetUIBehaviours(targetName).Scale = Vector3.zero;
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
            if (!(evt.EventSource is ViewModel))	return;

			//获取事件源
            ViewModel vm = evt.EventSource as ViewModel;

        }
    }
}
