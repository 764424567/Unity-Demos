using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public float speed = 2;
    private Camera cameraMain;
    private Vector2 screenSize;
    public Vector3 oldpos;
    void Start()
    {
        cameraMain = Camera.main;
        oldpos = cameraMain.transform.position;
    }
    void LateUpdate()
    {
        ControlCamera();
    }
    /// <summary>
    /// 控制相机
    /// </summary>
    void ControlCamera()
    {
        //视角拉伸
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            cameraMain.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * -1;

            if (MapManager.ins == null) return;

            if (cameraMain.orthographicSize < 3f)
            {
                if (MapManager.ins.zoom < 18)
                {
                    cameraMain.orthographicSize = 5f;
                    MapManager.ins.ChangeLayer(MapManager.ins.zoom + 1);
                }
                else
                {
                    if (cameraMain.orthographicSize < 2f) cameraMain.orthographicSize = 2f;
                }
            }
            if (cameraMain.orthographicSize > 6f)
            {
                if (MapManager.ins.zoom > 13)
                {
                    cameraMain.orthographicSize = 4f;
                    MapManager.ins.ChangeLayer(MapManager.ins.zoom - 1);
                }
                else
                {
                    if (cameraMain.orthographicSize > 7f) cameraMain.orthographicSize = 7f;
                }
            }
        }
        //视角滑动
        //非精准移动
        if (Input.GetMouseButton(2) || Input.GetMouseButton(1))
        {
            //调用

            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(-x, -y, 0) * Time.deltaTime * 90 * speed);
            //范围圈定
            GetOffset();
            MaxPos = MapManager.ins.mapAxesTransfer.GetRightPos();
            if (transform.position.x > MaxPos.x - Screenoffset.x)
            {
                transform.position = new Vector3(MaxPos.x - Screenoffset.x, 20, transform.position.z);
            }
            if (transform.position.z > MaxPos.z - Screenoffset.z)
            {
                transform.position = new Vector3(transform.position.x, 20, MaxPos.z - Screenoffset.z);
            }
            if (transform.position.x < Screenoffset.x)
            {
                transform.position = new Vector3(Screenoffset.x, 20, transform.position.z);
            }
            if (transform.position.z < Screenoffset.z)
            {
                transform.position = new Vector3(transform.position.x, 20, Screenoffset.z);
            }
        }

    }
    public Vector3 MaxPos;
    private Vector3 Screenoffset;
    RaycastHit hit;
    Ray ray;
    void GetOffset()
    {
        ray = Camera.main.ScreenPointToRay(screenSize);
        if (Physics.Raycast(ray, out hit))
        {
            Screenoffset = transform.position - hit.point;
        }
    }
}