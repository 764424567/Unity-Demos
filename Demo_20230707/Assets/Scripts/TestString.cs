using UnityEngine;

public class TestString : MonoBehaviour
{
    string str1 = "helloworld";
    string c2 = "he";

    void Start()
    {
        Debug.Log("使用 StartsWith方法:" + str1.StartsWith(c2));
        Debug.Log("使用 EndsWith方法:" + str1.EndsWith(c2));
    }
}