using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    public Vector3[] pos;
    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(2);
        for (int i = 0; i < 2; i++)
        {
            lineRenderer.SetPosition(i, pos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
