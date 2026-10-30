using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo001 : MonoBehaviour
{
    public static Demo001 Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fun1()
    {
        Debug.Log(1);
    }
}
