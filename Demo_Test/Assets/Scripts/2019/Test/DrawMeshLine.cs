using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 网格线段绘制器
/// </summary>
public class DrawMeshLine {
    

    /// <summary>
    /// 画一条3D网格线段
    /// </summary>
    /// <param name="startPositon">开始位置</param>
    /// <param name="endPosition">结束位置</param>
    /// <param name="lineMaterial">线条材质</param>
    /// <param name="radius">线条半径</param>
    public static GameObject Draw(Vector3 startPositon ,Vector3 endPosition , Material lineMaterial, float radius)
    {
        bool trade = false;
        float Xgap = Mathf.Abs(startPositon.x - endPosition.x);
        float Ygap = Mathf.Abs(startPositon.y - endPosition.y);
        float Zgap = Mathf.Abs(startPositon.z - endPosition.z);

        Vector3[] _Vertices = new Vector3[24];
        //X轴向线条
        if (Xgap >= Ygap && Xgap >= Zgap)
        {
            Vector3 middle;
            if (startPositon.x < endPosition.x)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[24]
            {
                new Vector3(startPositon.x, startPositon.y, startPositon.z + radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y + radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y, startPositon.z - radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y - radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),

                new Vector3(endPosition.x, endPosition.y, endPosition.z + radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y + radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y, endPosition.z - radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y - radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z + Mathf.Cos(3.14f/180*30) * radius)
            };
        }
        //Y轴向线条
        else if (Ygap >= Xgap && Ygap >= Zgap)
        {
            Vector3 middle;
            if (startPositon.y < endPosition.y)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[24]
            {
                new Vector3(startPositon.x, startPositon.y, startPositon.z + radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x - radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y, startPositon.z - radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x + radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),

                new Vector3(endPosition.x, endPosition.y, endPosition.z + radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x - radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y, endPosition.z - radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x + radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
            };
        }
        //Z轴向线条
        else if (Zgap >= Xgap && Zgap >= Ygap)
        {
            Vector3 middle;
            if (startPositon.z < endPosition.z)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[]
            {
                new Vector3(startPositon.x - radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*30) * radius, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*60) * radius, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y + radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*60) * radius, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*30) * radius, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x + radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*30) * radius, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*60) * radius, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y - radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*60) * radius, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*30) * radius, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z),

                new Vector3(endPosition.x - radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*30) * radius, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*60) * radius, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y + radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*60) * radius, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*30) * radius, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x + radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*30) * radius, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*60) * radius, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y - radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*60) * radius, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*30) * radius, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
            };
        }

        GameObject _Line = new GameObject("MeshLine");
        _Line.AddComponent<MeshFilter>();
        _Line.AddComponent<MeshRenderer>();
        if (lineMaterial == null) Debug.Log("The line material is empty！ 请注意，线段材质为空！");
        else _Line.GetComponent<MeshRenderer>().material = lineMaterial;

        GameObject _Head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _Head.name = trade ? "end" : "start";
        _Head.transform.localScale = new Vector3(radius * 2.1f, radius * 2.1f, radius * 2.1f);
        _Head.transform.position = startPositon;
        _Head.transform.SetParent(_Line.transform);
        if (lineMaterial != null) _Head.GetComponent<MeshRenderer>().material = lineMaterial;

        GameObject _End = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _End.name = trade ? "start" : "end";
        _End.transform.localScale = new Vector3(radius * 2.1f, radius * 2.1f, radius * 2.1f);
        _End.transform.position = endPosition;
        _End.transform.SetParent(_Line.transform);
        if (lineMaterial != null) _End.GetComponent<MeshRenderer>().material = lineMaterial;

        //生成所有面
        int[] _Triangles = new int[72]
        {
            //顶点0,1,12按顺序生成一个面，面朝向顺时针方向
            0,1,12,
            1,13,12,
            1,2,13,
            2,14,13,
            2,3,14,
            3,15,14,
            3,4,15,
            4,16,15,
            4,5,16,
            5,17,16,
            5,6,17,
            6,18,17,
            6,7,18,
            7,19,18,
            7,8,19,
            8,20,19,
            8,9,20,
            9,21,20,
            9,10,21,
            10,22,21,
            10,11,22,
            11,23,22,
            11,0,23,
            0,12,23
        };

        Mesh _mesh = new Mesh();
        _mesh.Clear();
        _mesh.vertices = _Vertices;
        _mesh.triangles = _Triangles;
        _mesh.RecalculateNormals();
        _Line.GetComponent<MeshFilter>().mesh = _mesh;

        if (_Head.GetComponent<SphereCollider>() != null) GameObject.Destroy(_Head.GetComponent<SphereCollider>());
        if (_End.GetComponent<SphereCollider>() != null) GameObject.Destroy(_End.GetComponent<SphereCollider>());
        
        return _Line;
    }
    /// <summary>
    /// 画一条3D网格线段，允许启用碰撞体
    /// </summary>
    /// <param name="startPositon">开始位置</param>
    /// <param name="endPosition">结束位置</param>
    /// <param name="lineMaterial">线条材质</param>
    /// <param name="radius">线条半径</param>
    /// <param name="isCollider">是否启用碰撞体</param>
    public static GameObject Draw(Vector3 startPositon, Vector3 endPosition, Material lineMaterial, float radius, bool isCollider)
    {
        bool trade = false;
        float Xgap = Mathf.Abs(startPositon.x - endPosition.x);
        float Ygap = Mathf.Abs(startPositon.y - endPosition.y);
        float Zgap = Mathf.Abs(startPositon.z - endPosition.z);

        Vector3[] _Vertices = new Vector3[24];
        //X轴向线条
        if (Xgap >= Ygap && Xgap >= Zgap)
        {
            Vector3 middle;
            if (startPositon.x < endPosition.x)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[24]
            {
                new Vector3(startPositon.x, startPositon.y, startPositon.z + radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y + radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y, startPositon.z - radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y - radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),

                new Vector3(endPosition.x, endPosition.y, endPosition.z + radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y + radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y, endPosition.z - radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y - radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z + Mathf.Cos(3.14f/180*30) * radius)
            };
        }
        //Y轴向线条
        else if (Ygap >= Xgap && Ygap >= Zgap)
        {
            Vector3 middle;
            if (startPositon.y < endPosition.y)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[24]
            {
                new Vector3(startPositon.x, startPositon.y, startPositon.z + radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x - radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x - Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x, startPositon.y, startPositon.z - radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x + radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*60) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(startPositon.x + Mathf.Sin(3.14f/180*30) * radius, startPositon.y, startPositon.z + Mathf.Cos(3.14f/180*30) * radius),

                new Vector3(endPosition.x, endPosition.y, endPosition.z + radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x - radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x - Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x, endPosition.y, endPosition.z - radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*30) * radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z - Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x + radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*60) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*60) * radius),
                new Vector3(endPosition.x + Mathf.Sin(3.14f/180*30) * radius, endPosition.y, endPosition.z + Mathf.Cos(3.14f/180*30) * radius),
            };
        }
        //Z轴向线条
        else if (Zgap >= Xgap && Zgap >= Ygap)
        {
            Vector3 middle;
            if (startPositon.z < endPosition.z)
            {
                middle = startPositon;
                startPositon = endPosition;
                endPosition = middle;
                trade = true;
            }

            _Vertices = new Vector3[]
            {
                new Vector3(startPositon.x - radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*30) * radius, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*60) * radius, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y + radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*60) * radius, startPositon.y + Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*30) * radius, startPositon.y + Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x + radius, startPositon.y, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*30) * radius, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z),
                new Vector3(startPositon.x + Mathf.Cos(3.14f/180*60) * radius, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x, startPositon.y - radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*60) * radius, startPositon.y - Mathf.Sin(3.14f/180*60) * radius, startPositon.z),
                new Vector3(startPositon.x - Mathf.Cos(3.14f/180*30) * radius, startPositon.y - Mathf.Sin(3.14f/180*30) * radius, startPositon.z),

                new Vector3(endPosition.x - radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*30) * radius, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*60) * radius, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y + radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*60) * radius, endPosition.y + Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*30) * radius, endPosition.y + Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x + radius, endPosition.y, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*30) * radius, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
                new Vector3(endPosition.x + Mathf.Cos(3.14f/180*60) * radius, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x, endPosition.y - radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*60) * radius, endPosition.y - Mathf.Sin(3.14f/180*60) * radius, endPosition.z),
                new Vector3(endPosition.x - Mathf.Cos(3.14f/180*30) * radius, endPosition.y - Mathf.Sin(3.14f/180*30) * radius, endPosition.z),
            };
        }

        GameObject _Line = new GameObject("MeshLine");
        _Line.AddComponent<MeshFilter>();
        _Line.AddComponent<MeshRenderer>();
        if (lineMaterial == null) Debug.Log("The line material is empty！ 请注意，线段材质为空！");
        else _Line.GetComponent<MeshRenderer>().material = lineMaterial;

        GameObject _Head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _Head.name = trade ? "end" : "start";
        _Head.transform.localScale = new Vector3(radius * 2.1f, radius * 2.1f, radius * 2.1f);
        _Head.transform.position = startPositon;
        _Head.transform.SetParent(_Line.transform);
        if (lineMaterial != null) _Head.GetComponent<MeshRenderer>().material = lineMaterial;

        GameObject _End = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _End.name = trade ? "start" : "end";
        _End.transform.localScale = new Vector3(radius * 2.1f, radius * 2.1f, radius * 2.1f);
        _End.transform.position = endPosition;
        _End.transform.SetParent(_Line.transform);
        if (lineMaterial != null) _End.GetComponent<MeshRenderer>().material = lineMaterial;

        //生成所有面
        int[] _Triangles = new int[72]
        {
            //顶点0,1,12按顺序生成一个面，面朝向顺时针方向
            0,1,12,
            1,13,12,
            1,2,13,
            2,14,13,
            2,3,14,
            3,15,14,
            3,4,15,
            4,16,15,
            4,5,16,
            5,17,16,
            5,6,17,
            6,18,17,
            6,7,18,
            7,19,18,
            7,8,19,
            8,20,19,
            8,9,20,
            9,21,20,
            9,10,21,
            10,22,21,
            10,11,22,
            11,23,22,
            11,0,23,
            0,12,23
        };

        Mesh _mesh = new Mesh();
        _mesh.Clear();
        _mesh.vertices = _Vertices;
        _mesh.triangles = _Triangles;
        _mesh.RecalculateNormals();
        _Line.GetComponent<MeshFilter>().mesh = _mesh;

        if (isCollider) _Line.AddComponent<MeshCollider>();
        if (!isCollider && _Head.GetComponent<SphereCollider>() != null) GameObject.Destroy(_Head.GetComponent<SphereCollider>());
        if (!isCollider && _End.GetComponent<SphereCollider>() != null) GameObject.Destroy(_End.GetComponent<SphereCollider>());
        
        return _Line;
    }

}
