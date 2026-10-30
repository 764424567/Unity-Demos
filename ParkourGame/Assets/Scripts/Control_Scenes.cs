using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Scenes : MonoBehaviour
{
    //是否到达第一段路
    bool m_ISFirst=true;
    //所有的路段对象
    public GameObject[] m_RoadArray;
    //障碍物数组对象
    public GameObject[] m_ObstacleArray;
    //障碍物的位置
    public List<Transform> m_ObstaclePosArray = new List<Transform>();

    void Start()
    {
        //游戏开始自动生成3组障碍物
        for (int i = 0; i < 3; i++)
        {
            Spawn_Obstacle(i);
        }
    }

    //根据传递的参数来决定切换那条路段
    public void Change_Road(int index)
    {
        //到达第一条路段不切换
        if (m_ISFirst && index == 0)
        {
            m_ISFirst = false;
            return;
        }
        else
        {
            int lastIndex = index - 1;
            if (lastIndex < 0)
                lastIndex = 2;
            //当前到达的路段的上一条路段进行切换，也就是说达到第二条路段，将第一条路段进行切换
            m_RoadArray[lastIndex].transform.position = m_RoadArray[lastIndex].transform.position + new Vector3(150, 0, 0);
            Spawn_Obstacle(lastIndex);
        }
    }

    public void Spawn_Obstacle(int index)
    {
        //销毁原来的对象
        GameObject[] obsPast = GameObject.FindGameObjectsWithTag("Obstacle" + index);
        for (int i = 0; i < obsPast.Length; i++)
        {
            Destroy(obsPast[i]);
        }
        //生成障碍物 每个m_ObstaclePosArray对象中都存有三个坐标
        foreach (Transform item in m_ObstaclePosArray[index])
        {
            GameObject prefab = m_ObstacleArray[Random.Range(0, m_ObstacleArray.Length)];
            Vector3 eulerAngle = new Vector3(0, Random.Range(0, 360), 0);
            GameObject obj = Instantiate(prefab, item.position, Quaternion.Euler(eulerAngle));
            obj.tag = "Obstacle" + index;
        }
    }
}
