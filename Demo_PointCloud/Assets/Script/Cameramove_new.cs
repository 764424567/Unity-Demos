using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove_new : MonoBehaviour
{
    // Model.Instance.Origin
    private void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) zoom();
        if (Input.GetMouseButton(2)) RotateView();
        if (Input.GetMouseButton(0)) transation();
        //离得近后系数减小

        if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector3.forward * 2 * 1); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(Vector3.left * 2 * 1); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(Vector3.back * 2 * 1); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector3.right * 2 * 1); }
        if (Input.GetKey(KeyCode.Q)) { transform.Translate(Vector3.up * 2 * 1); }
        if (Input.GetKey(KeyCode.E)) { transform.Translate(Vector3.down * 2 * 1); }
    }
    /// <summary>
    /// 缩放
    /// </summary>
    void zoom()
    {
        //Debug.Log(transform.position);
        //Debug.Log(Model.Instance.zoomOrigin);
        Vector3 RecordV3 = transform.position;
        Vector3 a = transform.position - Model.Instance.zoomOrigin;
        float distance=0.0f;
        distance = a.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel")*6 ;
        a = a.normalized * distance;
        Vector3 testV3 = a + Model.Instance.zoomOrigin;
        
        if (testV3.y> Model.Instance.zoomOrigin.y)
        {
            transform.position = a + Model.Instance.zoomOrigin;
        }
        else
        {
            transform.position = RecordV3;
        }
        
    }
    void RotateView()
    {
        Vector3 a = transform.position;
        Quaternion Ra = transform.rotation;

        transform.RotateAround(Model.Instance.Origin, Vector3.up, Input.GetAxis("Mouse X") * 5);
        Vector3 originposition = transform.position;
        Quaternion originRotation = transform.rotation;
        transform.RotateAround(Model.Instance.Origin, transform.right, Input.GetAxis("Mouse Y") * -5);
        //if (transform.eulerAngles.x<30||transform.eulerAngles.x>80)
        //{
        //    transform.position = originposition;
        //    transform.rotation = originRotation;
        //}

        if (transform.position.y < Model.Instance.Origin.y)
        {
            transform.position = a;
            transform.rotation = Ra;
        }
      
    }
    void transation()
    {
      
        Vector3 p0 = Camera.main.transform.position;
        Vector3 p01 = p0 - Camera.main.transform.right * Input.GetAxisRaw("Mouse X") * 1 * Time.timeScale;
        Vector3 p03 = p01 - Camera.main.transform.up * Input.GetAxisRaw("Mouse Y") * 1 * Time.timeScale;
        Camera.main.transform.position = p03;
    }


}
