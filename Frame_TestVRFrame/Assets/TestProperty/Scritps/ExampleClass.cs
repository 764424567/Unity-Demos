using System;
using UnityEngine;

[System.Serializable]
public class BoxColliderAttribute
{
    [SerializeField] private bool m_IsCollider;
    [SerializeField] private BoxCollider m_BoxCollider;
}

public class ExampleClass : MonoBehaviour
{
    public BoxColliderAttribute box;
}