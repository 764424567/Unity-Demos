using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsDemo : MonoBehaviour
{
    private QuesionsControl m_quesionsControl;
    public GameObject Content;

    void Start()
    {
        m_quesionsControl = GetComponent<QuesionsControl>();

        List<int> topicIndex = new List<int> { 2,5 };
        for (int i = 0; i < topicIndex.Count; i++)
        {
            int index = i + 1;
            m_quesionsControl.CreateQuestion(Content, topicIndex[i], "(" + index + ")、");
        }
    }
}
