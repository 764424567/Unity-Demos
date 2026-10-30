using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChangeModule
{
    [SerializeField] private string m_Name;
    [SerializeField] private bool m_Selected;
    [SerializeField] private GameObject m_Panel;

    public string name { get { return m_Name; } set { m_Name = value; } }
    public bool select { get { return m_Selected; } set { m_Selected = value; } }
    public GameObject panel { get { return m_Panel; } set { m_Panel = value; } }
}