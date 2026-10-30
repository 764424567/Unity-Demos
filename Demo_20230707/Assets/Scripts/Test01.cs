using System.Runtime.CompilerServices;
using UnityEngine;

public class Test01 : MonoBehaviour
{
    public static readonly string[] Values = { "Value1", "Value2", "Value3", "Value4" };

    void Start()
    {
        Debug.Log(Values[0]);
    }
}