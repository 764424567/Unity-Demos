using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{

    public class ModelDataModel : DataModelBehaviour
    {
        ModelEntity modelEntity = new ModelEntity();

        string[] shapeType = new string[] { "cube", "sphere", "cylinder" };
        protected override void Awake()
        {
            base.Awake();
            Entities.Add(modelEntity);
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {

                CreateInfo();

            }
        }

        public void CreateInfo()
        {
            ModelEntity.ShapeInfo info = new ModelEntity.ShapeInfo();
            info.shapeScale = Random.Range(0.5f, 1.5f);

            info.modelShape = shapeType[Random.Range(0, 3)];

            Vector3 spos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);

            Vector3 wpos = Camera.main.ScreenToWorldPoint(spos);

            info.birthPos = wpos;

            modelEntity.Info = info;
        }
    }
}