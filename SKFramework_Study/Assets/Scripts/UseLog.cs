using SK.Framework;
using SK.Framework.Logger;
using UnityEngine;

public class UseLog : MonoBehaviour
{
    Log Debug;
    void Start()
    {
        Debug = SKFramework.Module<Log>();
        Debug.Info("This is a log message.");
        Debug.Warning("This is a warning message!");
        Debug.Error("This is an error message!");
    }
}