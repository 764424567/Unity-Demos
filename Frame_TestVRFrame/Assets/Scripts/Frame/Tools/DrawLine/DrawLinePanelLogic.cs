/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称：DrawLinePanelLogic
* 创建日期：2020-09-11 09:11:51
* 作者名称：周新彭
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：画线
******************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace Com.Rainier.ZhouXinPeng
{
    /// <summary>
    /// 
    /// </summary>
    public class DrawLinePanelLogic : MVVMLogicBase
    {

        [SerializeField, HeaderAttribute("场景3")]
        //ui相机
        public Camera uiCamera;
        public Camera drawLineCamera;

        public Dictionary<string, GameObject> lineStartDic = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> lineEndDic = new Dictionary<string, GameObject>();

        /// <summary>
        /// 起始点
        /// </summary>
        private GameObject startPos;
        public GameObject StartPos
        {
            get { return startPos; }
            set { startPos = value; }
        }

        /// <summary>
        /// 终点
        /// </summary>
        private GameObject endPos;

        public GameObject EndPos
        {
            get { return endPos; }
            set { endPos = value; }
        }
        private GameObject tipsPos;


        Ray ray;
        RaycastHit hitInfo;

        private void Start()
        {
            AddEntity<DrawLineEntity>();

            drawLineCamera = InjectService.Get<ObjManager>().GetGameObject("ObjCamera", "DrawLineCamera").GetComponent<Camera>();
            uiCamera = InjectService.Get<ObjManager>().GetGameObject("ObjCamera", "UICamera").GetComponent<Camera>();
            if (GetUIBehaviours(this.gameObject.name).GetComponent<RawImage>())
            {
                GetUIBehaviours(this.gameObject.name).GetComponent<RawImage>().enabled = true;

                if (Screen.fullScreen)
                {
                    int widths = Screen.currentResolution.width;
                    int heights = Screen.currentResolution.height;

                    GetUIBehaviours(this.gameObject.name).RawImageTexture = CreateTexture(widths, heights, 24, drawLineCamera);
                }
                else
                {
                    GetUIBehaviours(this.gameObject.name).RawImageTexture = CreateTexture(960, 540, 24, drawLineCamera);
                }



            }
            AddPoint();
        }

        private void AddPoint()
        {
            lineStartDic.Add("点1", InjectService.Get<ObjManager>().GetGameObject("点1", "点1"));
            lineEndDic.Add("点1", InjectService.Get<UIManager>().GetGameObject("DrawLinePanel", "点1"));

            lineStartDic.Add("点2", InjectService.Get<ObjManager>().GetGameObject("点2", "点2"));
            lineEndDic.Add("点2", InjectService.Get<UIManager>().GetGameObject("DrawLinePanel", "点2"));
        }


        private void OnDestroy()
        {
            RemoveEntity<DrawLineEntity>();
        }

        private void FixedUpdate()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawLine();
            }
        }

        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="contentName"></param>
        public void DrawLine()
        {
            if (lineStartDic.Count > 0 && lineEndDic.Count > 0)
            {
                foreach (var dic in lineStartDic)
                {
                    DrawLineEntity(dic.Key, dic.Value, lineEndDic[dic.Key]);
                }
            }
        }

        private void DrawLineEntity(string key, GameObject startPos, GameObject endPos)
        {
            GetEntity<DrawLineEntity>().Drawline( key, startPos, endPos);
        }

        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="startPos2">起始点</param>
        /// <param name="endPos">终点</param>
        private void Drawline(string key, GameObject startPos2, GameObject endPos)
        {
            //print(endPos.name);
            //设置鼠标点位置
            Vector3 screen = uiCamera.WorldToScreenPoint(startPos2.transform.position);

            GetUIBehaviours(key + "StartPos").transform.position = uiCamera.ScreenToWorldPoint(screen);
            drawLineCamera.GetComponent<DrawLineYSG>().SetLine(key, screen, uiCamera.WorldToScreenPoint(endPos.GetComponent<RectTransform>().position));
            //Debug.Log(key+"************画线");
        }


        /// <summary>
        /// 创建画布
        /// </summary>
        /// <param name="widths">画布宽</param>
        /// <param name="heights">画布高</param>
        /// <param name="depths">画布</param>
        /// <returns></returns>
        private RenderTexture CreateTexture(int widths, int heights, int depths, Camera cam)
        {
            RenderTexture tmpTexture = new RenderTexture(widths, heights, depths);
            cam.targetTexture = tmpTexture;
            return tmpTexture;
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(IEvent evt)
        {
            if (evt is MethodEvent)
            {
                if (evt.EventName.Equals("Drawline"))
                {
                    MethodEvent mthodEvent = evt as MethodEvent;
                    object[] data = mthodEvent.Argments;
                    string key = (string)data[0];
                    GameObject startPos = (GameObject)data[1];
                    GameObject endPos = (GameObject)data[2];
                    Drawline(key, startPos, endPos);
                }
            }
        }
    }
}
