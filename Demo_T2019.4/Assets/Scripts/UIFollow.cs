using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using static UnityEngine.GraphicsBuffer;

public class UIFollow : MonoBehaviour
{
    GameObject currentObj;
    GameObject BGContent;

    public Vector2 offset;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        BGContent = GameObject.Find("BGContent");
    }

    private void Update()
    {
        if (IsVisableInCamera(Target.transform.position))
        {
            BGContent.transform.gameObject.SetActive(true);
            BGContent.GetComponent<RectTransform>().anchoredPosition = GetScreenPosition(Target.transform.position);
        }
        else
        {
            BGContent.transform.gameObject.SetActive(false);
        }
    }

    public Vector2 GetScreenPosition(Vector3 v3)
    {
        Vector3 viewportPos = new Vector3();
        viewportPos = Camera.main.WorldToViewportPoint(v3);
        Transform ca = GameObject.Find("Canvas").transform;
        RectTransform canvasRtm = ca.GetComponent<RectTransform>();
        Vector2 uguiPos = Vector2.zero;
        uguiPos.x = (viewportPos.x - offset.x) * canvasRtm.sizeDelta.x;
        uguiPos.y = (viewportPos.y - offset.y) * canvasRtm.sizeDelta.y;
        return uguiPos;
    }

    public bool IsVisableInCamera(Vector3 v3)
    {
        Camera mCamera = Camera.main;
        //转化为视角坐标
        Vector3 viewPos = mCamera.WorldToViewportPoint(v3);
        // z<0代表在相机背后
        if (viewPos.z < 0) return false;
        //太远了！看不到了！
        if (viewPos.z > mCamera.farClipPlane)
            return false;
        // x,y取值在 0~1之外时代表在视角范围外；
        if (viewPos.x < 0 || viewPos.y < 0 || viewPos.x > 1 || viewPos.y > 1) return false;
        return true;
    }
}
