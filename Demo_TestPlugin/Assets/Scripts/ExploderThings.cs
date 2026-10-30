using Exploder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exploder.Utils;


public class ExploderThings : MonoBehaviour
{
    public GameObject m_ExploderObj;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "爆炸"))
        {
            ExploderSingleton.Instance.ExplodeObject(m_ExploderObj);
        }
    }
}

