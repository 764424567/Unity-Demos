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
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit3D;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.ZC_Frame;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.ZhouXinPeng;

namespace Com.Rainier.ZhouXinPeng
{
    public class DrawLineYSG : MonoBehaviour
    {
        public Material mat;
        public bool isDraw = false;
        public bool isDrawLine = false;
        public bool isDrawActiveLine = false;//动态画线    
        public bool isDrawLineList = false;
        public Vector3 lineStart;
        public Vector3 lineEnd;
        private Dictionary<string, Vector3> lineStartDic = new Dictionary<string, Vector3>();
        private Dictionary<string, Vector3> lineEndDic = new Dictionary<string, Vector3>();
        public Vector3[] tempList;//临时线的点列表
        private Vector3 temp;

        private void Start()
        {

        }

        public void DrawLineList()
        {
            isDrawLineList = true;


        }

        public void ClearLine2()
        {
            lineStartDic.Clear();
            lineEndDic.Clear();
        }

        public void SetLine(Vector3 start, Vector3 end)
        {
            lineStart = start;
            lineEnd = end;
            isDraw = true;
        }

        public void SetLine(string names, Vector3 start, Vector3 end)
        {
            if (lineStartDic.ContainsKey(names))
            {
                lineStartDic[names] = start;
            }
            else
            {
                lineStartDic.Add(names, start);

            }

            if (lineEndDic.ContainsKey(names))
            {
                lineEndDic[names] = end;
            }
            else
            {
                lineEndDic.Add(names, end);

            }

            isDraw = true;
        }


        public void SetMultiLine(Vector3[] list)
        {
            isDrawLine = true;
            tempList = list;
        }

        public void SetActiveLine(Vector3 start, Vector3 end, Vector3 active)
        {
            lineStart = start;
            lineEnd = end;
            temp = active;
            isDrawActiveLine = true;
        }

        public void ChangeActiveLine(Vector3 active)
        {
            temp = active;
        }

        public void CancelLine()
        {
            isDraw = false;
            isDrawLine = false;
            isDrawActiveLine = false;
        }

        /// <summary>
        /// 在相机完成场景渲染之后被调用
        /// </summary>
        private void OnPostRender()
        {
            if (InjectService.Get<UIManager>().GetGameObject("DrawLinePanel", "DrawLinePanel").GetComponent<DrawLinePanelLogic>().lineStartDic.Count != 0)
            {
                if (isDraw)
                {
                    mat.SetPass(0);
                    GL.PushMatrix();
                    GL.LoadPixelMatrix();

                    GL.Begin(GL.LINES);
                    GL.Color(Color.red);
                    foreach (var item in lineStartDic)
                    {
                        DrawLine2D(item.Value.x, item.Value.y, lineEndDic[item.Key].x, lineEndDic[item.Key].y);
                    }
                    GL.End();
                    GL.PopMatrix();
                }
            }
        }

        private void DrawLine2D(float x1, float y1, float x2, float y2)
        {
            GL.Vertex3(x1, y1, 0);
            GL.Vertex3(x2, y2, 0);
        }

        /// <summary>
        /// 清除线
        /// </summary>
        public void ClearLine()
        {
            lineStartDic.Clear();
            lineEndDic.Clear();
            GL.Clear(true, true, Color.white);
        }

        private void OnDestroy()
        {
            ClearLine();
        }
    }
}
