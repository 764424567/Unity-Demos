using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFHTest2 : MonoBehaviour
{
    [SFHStartCall(2)]
    void OnStart()
    {
        Debug.Log("第二个执行");
    }
}
