using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour
{
    /// <summary>
    /// 初始化顺序
    /// </summary>
    public int StartOrder;
    /// <summary>
    /// 层级顺序
    /// </summary>
    public int LayerOrder;
    /// <summary>
    /// 唯一标识符
    /// </summary>
    [HideInInspector]public int UniqueID;

    public virtual void OnStart() { }
    public virtual void ShowInfo(bool ison) { }
}