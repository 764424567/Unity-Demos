/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：LookCameraLogic
* 创建日期：2020-06-09 11:19:36
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：观察相机移动相关逻辑脚本
******************************************************************************/
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using DG.Tweening;

namespace Com.Rainier.ZC_Frame
{   
	/// <summary>
    /// 
    /// </summary>
	public class LookCameraLogic : ObjLogicBase 
	{
        private bool isUseFPS = false;

        private Transform parent;

        private FPSLogic fPS;

        private TPSLogic tPS;

        private UnityAction endAction;


        /// <summary>
        /// 移动观察相机到目标位置
        /// </summary>
        /// <param name="targetName">目标位置名字</param>
        /// <param name="time">时间</param>
        /// <param name="action">结束后回调</param>
        public void MoveLookCamera(string targetName,float time,UnityAction action) {
            if (action != null)
            {
                endAction = action;
            }
            GetEntity<LookCameraEntity>().MoveLookCamera(targetName,time);
        }

        /// <summary>
        /// 设置观察相机到目标位置
        /// </summary>
        /// <param name="targetName">目标位置</param>
        public void SetLookCamera(string targetName) {
            GetEntity<LookCameraEntity>().SetLookCamera(targetName);
        }

        /// <summary>
        /// 重置观察相机
        /// </summary>
        public void ReSetLookCamera() {
            GetEntity<LookCameraEntity>().ReSetLookCamera();
        }

        private void Awake()
        {
            
        }

        private void Start()
        {
            AddEntity<LookCameraEntity>();

            transform.GetComponent<Camera>().enabled = false;
            
            parent = transform.parent;
            if (FindObjectOfType<FPSLogic>())
            {
                isUseFPS = true;
                fPS = FindObjectOfType<FPSLogic>();
            }
            else
            {
                isUseFPS = false;
                tPS = FindObjectOfType<TPSLogic>();
            }
        }

        private void OnDestroy()
        {
            RemoveEntity<LookCameraEntity>();
        }

        public override void ProcessLogic(IEvent evt)
        { 
            if (evt is MethodEvent)
            {
                //移动到目标位置
                if (evt.EventName.Equals("MoveLookCamera"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string targetName = (string)data[0];
                    float time = (float)data[1];
                    //UnityAction action = (UnityAction)data[2];
                    MoveLookCameraLogic(targetName, time, endAction);
                }
                //设置到目标位置
                if (evt.EventName.Equals("SetLookCamera"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string targetName = (string)data[0];
                    SetLookCameraLogic(targetName);
                }
                //重置观察相机
                if (evt.EventName.Equals("ReSetLookCamera"))
                {
                    ReSetLookCameraLogic();
                }
            }
        }

        

        /// <summary>
        /// 移动相机到目标位置
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="time"></param>
        /// <param name="action"></param>
        private void MoveLookCameraLogic(string targetName,float time ,UnityAction action) {
            transform.GetComponent<Camera>().enabled = true;
            transform.parent = null;
            SetControlOnOrOff(false);
            Transform target = InjectService.Get<ObjManager>().GetGameObject(targetName, targetName).transform;
            Tween tweenerPos = transform.DOMove(target.localPosition, time).SetEase(Ease.Linear);

            Tween tweenRot = transform.DORotate(target.localEulerAngles, time).SetEase(Ease.Linear);
            tweenRot.OnComplete(()=> {
                if (action != null)
                {
                    action.Invoke() ;
                }
                tweenerPos.Kill();
                tweenRot.Kill();
            });
            
        }

        /// <summary>
        /// 设置相机到目标位置
        /// </summary>
        /// <param name="targetName"></param>
        private void SetLookCameraLogic(string targetName) {
            transform.GetComponent<Camera>().enabled = true;
            transform.parent = null;
            SetControlOnOrOff(false);
            Transform target = InjectService.Get<ObjManager>().GetGameObject(targetName, targetName).transform;
            transform.localPosition = target.localPosition;
            transform.localEulerAngles = target.localEulerAngles;
        }

        /// <summary>
        /// 重置相机
        /// </summary>
        private void ReSetLookCameraLogic() {
            transform.GetComponent<Camera>().enabled = false;
            transform.parent = parent;
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            SetControlOnOrOff(true);
        }

        /// <summary>
        /// 启用或禁用第一第三人称控制
        /// </summary>
        /// <param name="isOn"></param>
        private void SetControlOnOrOff(bool isOn) {
            if (isOn)
            {
                if (isUseFPS)
                {
                    fPS.gameObject.SetActive(true);
                }
                else
                {
                    tPS.gameObject.SetActive(true);
                    tPS.lookCamera.gameObject.SetActive(true);
                }
            }
            else
            {
                if (isUseFPS)
                {
                    fPS.gameObject.SetActive(false);
                }
                else
                {
                    tPS.gameObject.SetActive(false);
                    tPS.lookCamera.gameObject.SetActive(false);
                }
            }
        }
    }
}
