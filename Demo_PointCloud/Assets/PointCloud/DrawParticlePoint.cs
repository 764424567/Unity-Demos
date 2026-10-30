using UnityEngine;
using System.Collections;
using System.IO;

public class DrawParticlePoint : MonoBehaviour {

    ParticleSystem particleSystem;                  // 整个粒子系统
    int pointCount;                                 // 粒子数目

    ArrayList list = new ArrayList();

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // 1. 读取数据
        list = ReadFile();

        //2.粒子显示
        DrawPointCloud(list);
       
    }

    ArrayList ReadFile()
    {
        // 提前将点云存成csv文件放在Assert/StreamingAssets文件夹下，文本的每行代表一个点，由点的x，y，z
        //csv文件存储数据，用逗号分隔，比较容易读取处理
        string path = (Application.streamingAssetsPath + "/" + "campus.csv");
        FileInfo fInfo = new FileInfo(path);

        string s = "";
        StreamReader r;
        ArrayList vecList = new ArrayList();

        if (fInfo.Exists)
        {
            r = new StreamReader(path);
        }
        else
        {
            Debug.Log("文件不存在");
            return null;
        }
        // 点云数据存入队列
        while ((s = r.ReadLine()) != null)
        {
            string[] words = s.Split(","[0]);

            Vector3 xyz = new Vector3(float.Parse(words[0]), -float.Parse(words[1]), float.Parse(words[2])) * 10;
            vecList.Add(xyz);
        }

        return vecList;
    }

    ParticleSystem.Particle[] allParticles;         // 所有粒子的集合
    void DrawPointCloud(ArrayList drawList)
    {
        var main = particleSystem.main;
        main.startSpeed = 0.0f;                           // 设置粒子的初始速度为0
        main.startLifetime = 1000.0f;

        var pointCount = drawList.Count;
        allParticles = new ParticleSystem.Particle[pointCount];
        main.maxParticles = pointCount;
        particleSystem.Emit(pointCount);
        particleSystem.GetParticles(allParticles);
        for (int i = 0; i < pointCount; i++)
        {
            allParticles[i].position = (Vector3)drawList[i];    // 设置每个点的位置
            allParticles[i].startColor = Color.yellow;    // 设置每个点的rgb
            allParticles[i].startSize = 0.02f;                     
        }

        particleSystem.SetParticles(allParticles, pointCount);      // 将点云载入粒子系统
    }
}
