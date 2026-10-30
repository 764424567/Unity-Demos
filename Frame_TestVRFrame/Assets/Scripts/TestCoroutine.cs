using System.Collections;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    void Start()
    {
        Debug.Log("在协程之前执行函数");
        StartCoroutine(m_Ien());
        Debug.Log("在协程之后执行函数");
    }

    IEnumerator m_Ien()
    {
        Debug.Log("执行函数");
        yield return new WaitForSeconds(1);//等待1秒
        Debug.Log("执行后面的函数");
    }
}
