using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XCharts;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class ChangePanel : MonoBehaviour
{
    [SerializeField] private List<ChangeModule> m_ChangeModule = new List<ChangeModule>();

    void Awake()
    {
        InitModuleButton();
    }

    void Update()
    {
#if UNITY_EDITOR
        InitModuleButton();
#endif
    }

    void InitModuleButton()
    {
        for (int i = 0; i < m_ChangeModule.Count; i++)
        {
            var module = m_ChangeModule[i];
            if (module.select)
            {
                module.panel.SetActive(true);
                module.select = true;
            }
            else
            {
                module.panel.SetActive(false);
                module.select = false;
            }    
        }
    }
}