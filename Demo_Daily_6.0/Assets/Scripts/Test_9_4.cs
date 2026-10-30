using System.Collections;
using UnityEngine;
public class Test_9_4 : MonoBehaviour
{
    void Start()
    {
        Stack st = new Stack();//初始化队列
        st.Push('A');//添加元素
        st.Push('B');
        Debug.Log("添加元素前：");
        foreach (char item in st)
        {
            Debug.Log(item);
        }
        st.Push('C');
        Debug.Log("添加元素后：");
        foreach (char item in st)
        {
            Debug.Log(item);
        }
        char ch = (char)st.Peek();//返回在 Stack 的顶部的对象，但不移除它
        Debug.Log("返回 Stack 顶部的对象：" + ch);
        st.Pop();//删除元素
        Debug.Log("删除元素后：");
        foreach (char item in st)
        {
            Debug.Log(item);
        }
    }
}