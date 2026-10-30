using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFHTest1 : MonoBehaviour
{
    [SFHStartCall(1)]
    void OnStart()
    {
        Debug.Log("第一个执行");
    }
}
