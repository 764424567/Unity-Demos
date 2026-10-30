using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshTest : MonoBehaviour
{
    private MeshFilter m_Filter;
    private Mesh m_Mesh;
    // Use this for initialization
    void Start()
    {
        m_Filter = GetComponent<MeshFilter>();
        m_Mesh = new Mesh();
        m_Filter.mesh = m_Mesh;
        //初始化网格
        InitMesh();
    }

    public void InitMesh()
    {
        m_Mesh.name = "MyMesh";
        //为网格创建顶点数组
        Vector3[] vertices = new Vector3[8]
        {
            new Vector3(1,1,0),
            new Vector3(-1,1,0),
            new Vector3(1,-1,0),
            new Vector3(-1,-1,0),
            new Vector3(1,1,0),
            new Vector3(-1,1,0),
            new Vector3(1,-1,0),
            new Vector3(-1,-1,0)
        };
        m_Mesh.vertices = vertices;
        //通过顶点为网格创建三角形
        int[] triangles = new int[4 * 3]
        {
            0,3,1,0,2,3,0,1,3,0,3,2
        };
        m_Mesh.triangles = triangles;
        //为mesh设置纹理贴图坐标
        Vector2[] uv = new Vector2[8]
        {
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0)
        };
        m_Mesh.uv = uv;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
