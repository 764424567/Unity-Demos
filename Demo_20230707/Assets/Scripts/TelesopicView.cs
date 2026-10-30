using UnityEngine;
using System.Collections;

public class TelesopicView : MonoBehaviour
{
    public int zoomLevel = 1;//缩放等级
    private float initFOV;



    void Start()
    {
        //获取当前摄像机的视野范围
        initFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        KeyCodeEvent();
        ControlView();
    }

    void KeyCodeEvent()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            zoomLevel++;
            if (zoomLevel > 3)
            {
                zoomLevel = 1;
            }
            //放大摄像机的视野区域
            Camera.main.fieldOfView = initFOV / zoomLevel;
        }
    }

    void ControlView()
    {
        float vMouseX = Input.GetAxis("Mouse X");
        float vMouseY = Input.GetAxis("Mouse Y");
        Camera.main.transform.rotation = Quaternion.Euler(vMouseX, vMouseY, Camera.main.transform.rotation.eulerAngles.z);
    }
}