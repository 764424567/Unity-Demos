using Com.Zcst.Zy;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CameraTargetMove : MonoBehaviour
{
    public Transform target;
    public Vector3 pivotOffset = Vector3.zero;
    public float distance = 10.0f;
    public float minDistance = 2f;
    public float maxDistance = 15f;
    public float zoomSpeed = 1f;
    public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;
    public bool allowYTilt = true;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float targetX = 0f;
    private float targetY = 0f;
    public float targetDistance = 0f;

    bool isMove = true;
    public GameObject[] TargetPointArray;

    private void Start()
    {
        var angles = transform.eulerAngles;
        targetX = x = angles.y;
        targetY = y = angles.x;//ClampAngle(angles.y, yMinLimit, yMaxLimit);
        targetDistance = distance;
    }

    public void CutTarget(int index)
    {
        GData.Instance.isInto = true;
        isMove = false;
        target = TargetPointArray[index].transform;
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + pivotOffset;
        transform.DOMove(position, 1.5f).OnComplete(() =>
        {
            isMove = true;
            if (index == 0)
            {
                GData.Instance.isInto = false;
            }
        });
    }

    Vector3 GetMiddlePoint(Vector3 pointA, Vector3 pointB)
    {
        return (pointA + pointB) * 0.5f;
    }

    private void LateUpdate()
    {
        if (!target) return;
        if (isMove)
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            //if (scroll > 0.0f) targetDistance -= zoomSpeed;
            //else if (scroll < 0.0f)
            //    targetDistance += zoomSpeed;
            targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
            if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
            {
                targetX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                if (allowYTilt)
                {
                    targetY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                    targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
                }
            }

            x = targetX;
            y = targetY;
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            distance = targetDistance;
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + pivotOffset;
            transform.rotation = rotation;
            transform.position = position;
        }
    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
