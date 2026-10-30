using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test01 : MonoBehaviour
{
    public Button btn1;
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() => {

            Debug.Log(1);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
