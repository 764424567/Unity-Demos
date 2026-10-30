using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouselook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 1f;
    public float sensitivityVert = 1f;

    public float minmumVert = -45f;
    public float maxmumVert = 45f;

    private float _rotationX = 0;
    // Use this for initialization
    void Start()
    {

    }
    bool ison = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ison = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            ison = false;
        }
        if (ison)
        {

            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(-_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

                float delta = -Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(-_rotationX, rotationY, 0);
            }
        }

    }
}