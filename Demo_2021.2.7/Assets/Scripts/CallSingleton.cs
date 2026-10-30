using UnityEngine;

public class CallSingleton : MonoBehaviour
{
    void Start()
    {
        // 修改单例类的变量值
        UseSingleton.Instance.Name = "张三";
    }
}