using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFHTest3 : MonoBehaviour
{
    [SFHStartCall(3)]
    void OnStart()
    {
        Debug.Log("第三个执行");
    }
}
