using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raytest : MonoBehaviour
{
    private Vector3 m_UpPoint;
    private Vector3 m_DownPoint;
    private Vector3[] m_PointTarget;
    public float m_Width = 3;
    public float m_Heigth = 5;
    private float m_Length;
    private MeshFilter meshFilter;
    // Use this for initialization
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

    }

    // Update is called once per frame
    void Update()
    {
        //初始坐标
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                GameObject gameobj = hit.collider.gameObject;
                if (gameobj.tag == "collider")
                {
                    Debug.Log("Down" + hit.point);
                    m_UpPoint = hit.point;
                }
            }
        }
        //最后的坐标
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                GameObject gameobj = hit.collider.gameObject;
                if (gameobj.tag == "collider")
                {
                    Debug.Log("Up" + hit.point);
                    m_DownPoint = hit.point;
                }
            }
        }
        //根据4个坐标点画立方体
        if (Input.GetMouseButtonUp(0))
        {
            meshFilter.mesh = CreatMesh();
        }
    }

    public Vector3[] GetPointTarget(Vector3 tag1, Vector3 tag2, float width, float height, float length)
    {
        Vector3[] target = new Vector3[24];
        //前
        target[0] = new Vector3(tag1.x, tag1.y, tag1.z - width);
        target[1] = new Vector3(tag1.x, tag1.y + height, tag1.z - width);
        target[2] = new Vector3(tag2.x, tag2.y, tag2.z - width);
        target[3] = new Vector3(tag2.x, tag2.y + height, tag2.z - width);
        //后
        target[4] = new Vector3(tag2.x, tag2.y, tag2.z + width);
        target[5] = new Vector3(tag2.x, tag2.y + height, tag2.z + width);
        target[6] = new Vector3(tag1.x, tag1.y, tag1.z + width);
        target[7] = new Vector3(tag1.x, tag1.y + height, tag1.z + width);
        //左
        target[8] = target[6];
        target[9] = target[7];
        target[10] = target[0];
        target[11] = target[1];
        //右
        target[12] = target[2];
        target[13] = target[3];
        target[14] = target[4];
        target[15] = target[5];
        //上
        target[16] = target[1];
        target[17] = target[7];
        target[18] = target[3];
        target[19] = target[5];
        //下
        target[20] = target[2];
        target[21] = target[4];
        target[22] = target[0];
        target[23] = target[6];
        return target;
    }

    Mesh CreatMesh()
    {
        //设置顶点
        //根据两个坐标点，推算出来4个坐标点
        m_Length = (m_DownPoint - m_UpPoint).sqrMagnitude;
        m_PointTarget = GetPointTarget(m_UpPoint, m_DownPoint, m_Width, m_Heigth, m_Length);
        //设置索引
        int triangles_cout = 6 * 2 * 3;
        int[] triangles = new int[triangles_cout];
        for (int i = 0, vi = 0; i < triangles_cout; i += 6, vi += 4)
        {
            triangles[i] = vi;
            triangles[i + 1] = vi + 1;
            triangles[i + 2] = vi + 2;

            triangles[i + 3] = vi + 3;
            triangles[i + 4] = vi + 2;
            triangles[i + 5] = vi + 1;
        }
        //设置UV
        Vector2[] uv = new Vector2[24]
        {
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),

            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),

            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),

            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),

            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0),

            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0)
        };
        Mesh mesh = new Mesh();
        mesh.name = "MyMesh";
        mesh.vertices = m_PointTarget;
        mesh.triangles = triangles;
        mesh.uv = uv;
        return mesh;
    }
}
