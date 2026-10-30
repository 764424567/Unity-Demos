using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TimeAttribute : PropertyAttribute
{
    /// <summary>
    /// 显示小时
    /// </summary>
    public readonly bool displayHours;
    /// <summary>
    /// 显示毫秒
    /// </summary>
    public readonly bool displayMillseconds;
    /// <summary>
    /// 构造函数 
    /// </summary>
    /// <param name="displayHours">显示小时</param>
    /// <param name="displayMillseconds">显示毫秒</param>
    public TimeAttribute(bool displayHours = false, bool displayMillseconds = false)
    {
        this.displayHours = displayHours;
        this.displayMillseconds = displayMillseconds;
    }
}
