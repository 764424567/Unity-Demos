using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoExam : MonoBehaviour
{
    ExamComponent m_ExamComponent;

    private GameObject BGContent;

    void Start()
    {
        m_ExamComponent = GetComponent<ExamComponent>();

        BGContent = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/BGContent"), GameObject.Find("Canvas").transform);//内容容器

        m_ExamComponent.LoadExam("Exam");
        m_ExamComponent.CreateExam(BGContent.transform.Find("Scroll View/Viewport/ExamContent").transform, new ExamCreateParame(ExamCreateParame.Type.生成全部));
    }
}