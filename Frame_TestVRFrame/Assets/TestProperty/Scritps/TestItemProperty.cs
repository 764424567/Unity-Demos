using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestItemProperty
{
    [SerializeField] private bool m_Selected;
    [SerializeField] private GameObject m_Panel;

    public bool select { get { return m_Selected; } set { m_Selected = value; } }
    public GameObject panel { get { return m_Panel; } set { m_Panel = value; } }
}
