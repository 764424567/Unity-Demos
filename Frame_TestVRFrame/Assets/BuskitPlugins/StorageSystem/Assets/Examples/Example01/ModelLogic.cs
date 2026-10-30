using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{

    public class ModelLogic : LogicBehaviour
    {
        public GameObject prefabCube;
        public GameObject prefabSphere;
        public GameObject prefabCylinder;

        private GameObject prefab;

        public override void ProcessLogic(IEvent evt)
        {

            if (evt.EventName.Equals("Info"))
            {
                CreateShape(evt);
            }
        }


        /// <summary>
        /// 生成目标
        /// </summary>
        /// <param name="evt"></param>
        public void CreateShape(IEvent evt)
        {
            PropertyEvent pevt = evt as PropertyEvent;
            ModelEntity.ShapeInfo va = (ModelEntity.ShapeInfo)pevt.NewValue;
            if (va.modelShape.Equals("cube"))
            {
                prefab = Instantiate(prefabCube);
                prefab.transform.position = va.birthPos;
                prefab.transform.localScale = va.shapeScale*Vector3.one;
            }
            else if (va.modelShape.Equals("sphere"))
            {
                prefab = Instantiate(prefabSphere);
                prefab.transform.position = va.birthPos;
                prefab.transform.localScale = va.shapeScale * Vector3.one;
            }
            else if (va.modelShape.Equals("cylinder"))
            {
                prefab = Instantiate(prefabCylinder);
                prefab.transform.position = va.birthPos;
                prefab.transform.localScale = va.shapeScale * Vector3.one;
            }
        }

      
    }
}