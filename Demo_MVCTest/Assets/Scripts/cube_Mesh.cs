using UnityEngine;

public class cube_Mesh : MonoBehaviour
{
    public float Length = 5;
    public float Width = 6;
    public float Heigth = 7;
    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreatMesh(Length, Width, Heigth);
    }

    Mesh CreatMesh(float Length, float Width, float Heigth)
    {
        //设置顶点
        int vertices_count = 4 * 6;//4个点6个面
        Vector3[] vertices = new Vector3[vertices_count];
        //前
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, Heigth, 0);
        vertices[2] = new Vector3(Length, 0, 0);
        vertices[3] = new Vector3(Length, Heigth, 0);
        //后
        vertices[4] = new Vector3(Length, 0, Width);
        vertices[5] = new Vector3(Length, Heigth, Width);
        vertices[6] = new Vector3(0, 0, Width);
        vertices[7] = new Vector3(0, Heigth, Width);
        //左
        vertices[8] = vertices[6];
        vertices[9] = vertices[7];
        vertices[10] = vertices[0];
        vertices[11] = vertices[1];
        //右
        vertices[12] = vertices[2];
        vertices[13] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];
        //上
        vertices[16] = vertices[1];
        vertices[17] = vertices[7];
        vertices[18] = vertices[3];
        vertices[19] = vertices[5];
        //下
        vertices[20] = vertices[2];
        vertices[21] = vertices[4];
        vertices[22] = vertices[0];
        vertices[23] = vertices[6];

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
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        return mesh;
    }
}
