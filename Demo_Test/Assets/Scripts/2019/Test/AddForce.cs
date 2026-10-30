using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody m_Rig;
    // Use this for initialization
    void Start()
    {
        m_Rig = gameObject.GetComponent<Rigidbody>();
        m_Rig.AddForce(0, 0, -10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
