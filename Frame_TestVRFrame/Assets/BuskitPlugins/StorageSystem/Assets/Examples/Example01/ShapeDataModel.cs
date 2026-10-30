using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.Storage.Test
{

    public class ShapeDataModel : DataModelBehaviour
    {
        ShapeEntity shapeEntity = new ShapeEntity();
        protected override void Awake()
        {
            base.Awake();
            Entities.Add(shapeEntity);
        }
        protected override void Start()
        {
            base.Start();
        }
        private void OnMouseDown()
        {
            shapeEntity.ShapeColor = Color.green;
         
        }

        private void OnMouseUp()
        {
            shapeEntity.ShapeColor = Color.white;
        }
        private void OnMouseDrag()
        {
            Vector3 zpos = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 spos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zpos.z);

            Vector3 wpos = Camera.main.ScreenToWorldPoint(spos);

            shapeEntity.Pos = wpos;
        }

    }
}