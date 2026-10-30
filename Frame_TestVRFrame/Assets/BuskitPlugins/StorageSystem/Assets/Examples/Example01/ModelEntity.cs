using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{

    /// <summary>
    /// 管理shape
    /// </summary>
    public class ModelEntity : Entity
    {


        private ShapeInfo info;
        public ShapeInfo Info {

            get {
                return info;
            }
            set {

                var oldvalue = info;
                info = value;
                FireEvent("Info", oldvalue, value);
            }
        }

        public struct ShapeInfo
        {
            public string modelShape;
            
            public float shapeScale;

            public Vector3 birthPos;
        }
    }
}

