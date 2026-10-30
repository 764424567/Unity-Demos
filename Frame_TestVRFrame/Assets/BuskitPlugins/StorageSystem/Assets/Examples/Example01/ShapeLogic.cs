using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{

    public class ShapeLogic : LogicBehaviour
    {
        public override void ProcessLogic(IEvent evt)
        {

            if (evt.EventName.Equals("ShapeColor"))
            {
                SetColor(evt);
            }
            else if(evt.EventName.Equals("Pos"))
            {
                SetPosition(evt);
            }
        }


        /// <summary>
        /// 设置目标颜色
        /// </summary>
        /// <param name="evt"></param>
        public void SetColor(IEvent evt)
        {
            PropertyEvent pevt = evt as PropertyEvent;
            transform.GetComponent<MeshRenderer>().material.SetColor("_Color", (Color)pevt.NewValue);
        }

        /// <summary>
        /// 设置目标位置
        /// </summary>
        /// <param name="evt"></param>
        public void SetPosition(IEvent evt)
        {
            PropertyEvent pevt = evt as PropertyEvent;
            transform.position = (Vector3)pevt.NewValue;
        }
    }
}