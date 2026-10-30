using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{


    public class ShapeEntity : Entity
    {
        /// <summary>
        /// 位置
        /// </summary>
        private Vector3 pos;
        public Vector3 Pos {
            get {
                return pos;
            }
            set {

                var oldvalue = pos;
                pos = value;
                FireEvent("Pos", oldvalue, value);
            }
        }


        /// <summary>
        /// 颜色
        /// </summary>
        private Color shapeColor;
        public Color ShapeColor {
            get { return shapeColor; }
            set {

                var oldvalue = shapeColor;
                shapeColor = value;
                FireEvent("ShapeColor", oldvalue, value);
            
            }
        }

    }
}

