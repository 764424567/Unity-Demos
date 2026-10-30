using MyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDLL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string num=MyClass.Rell(123);
        Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
