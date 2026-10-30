using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    public int num = 3;
    public Vector3[] vertices1;
    public Vector3[] vertices2;

    public Vector3[] vertices;

    public int[] triangles;

    public Material m;

    MeshFilter mf;
    Mesh mesh;
    MeshRenderer mr;

    public float f1 = 1;
    public float f2 = 1;
    // Use this for initialization
    void Start()
    {
        mf = gameObject.AddComponent<MeshFilter>();
        mr = gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
    }

    void FixedUpdate()
    {
        vertices = new Vector3[num * 2 * 3];
        triangles = new int[num * 2 * 3];

        vertices1 = GetVertices(num, f1, 0);
        vertices2 = GetVertices(num, f2, -1);

        for (int i = 0; i < triangles.Length; i++)
        {
            triangles[i] = i;
        }

        vertices[0] = vertices1[0];
        vertices[1] = vertices2[1];
        vertices[2] = vertices2[0];

        vertices[3] = vertices1[0];
        vertices[4] = vertices1[1];
        vertices[5] = vertices2[1];

        vertices[6] = vertices1[1];
        vertices[7] = vertices2[2];
        vertices[8] = vertices2[1];

        vertices[9] = vertices1[1];
        vertices[10] = vertices1[2];
        vertices[11] = vertices2[2];

        vertices[12] = vertices1[2];
        vertices[13] = vertices2[0];
        vertices[14] = vertices2[2];

        vertices[15] = vertices1[2];
        vertices[16] = vertices1[0];
        vertices[17] = vertices2[0];
        Debug.Log(vertices1[0] + ";" + vertices1[1] + ";" + vertices1[2]);
        Debug.Log(vertices2[0] + ";" + vertices2[1] + ";" + vertices2[2]);
        //vertices[18] = vertices1[2];
        //vertices[19] = vertices1[0];
        //vertices[20] = vertices2[0];

        //vertices[21] = vertices1[2];
        //vertices[22] = vertices1[0];
        //vertices[23] = vertices2[0];

        mr.material = m;
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mf.mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3[] GetVertices(int num, float r, float y)
    {
        Vector3[] v = new Vector3[num];
        for (int i = 0; i < num; i++)
        {
            v[i] = new Vector3(r * Mathf.Cos((i - 1) * (2 * Mathf.PI / num)), y, r * Mathf.Sin((i - 1) * 2 * (Mathf.PI / num)));
        }
        return v;
    }
}