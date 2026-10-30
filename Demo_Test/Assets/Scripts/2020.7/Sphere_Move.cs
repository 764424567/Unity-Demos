using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Move : MonoBehaviour
{
    public GameObject m_Cube;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_Cube.transform.position, 0.03f);
    }
}
