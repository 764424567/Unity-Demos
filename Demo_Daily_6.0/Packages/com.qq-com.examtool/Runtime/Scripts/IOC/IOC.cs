using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOC : MonoBehaviour
{
    private void Awake()
    {
        if (InjectService.Get<ExamManager>() == null)
        {
            InjectService.RegisterSingleton(new ExamManager());
        }
    }
}
