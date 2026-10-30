using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    static Model _instance;
    public Vector3 Origin;//原点 每次更新模型中心点变化
    public Vector3 zoomOrigin;
   
    private void Awake()
    {
        _instance = this;
        
    }
    public static Model Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Update()
    {
        //鼠标转世界坐标
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 mousePosOnScreen = Input.mousePosition;
        //mousePosOnScreen.z = screenPos.z;
        //Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);

        if (Input.GetMouseButtonDown(2))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(cameraRay, out floorHit))
            {
                if (floorHit.point!=null)
                {
                    Origin = floorHit.point;
                }
                
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(cameraRay, out floorHit))
            {
                if (floorHit.point != null)
                {
                    zoomOrigin = floorHit.point;
                }

            }


        }

    }
}
