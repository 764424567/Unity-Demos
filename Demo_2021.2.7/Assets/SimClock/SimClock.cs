using UnityEngine;
using System.Collections;
using System;
using UniRx;

public class SimClock : MonoBehaviour
{
    /// <summary>
    /// 时针
    /// </summary>
    [SerializeField]
    private Transform HourHands;

    /// <summary>
    /// 分针
    /// </summary>
    [SerializeField]
    private Transform MinuteHands;

    /// <summary>
    /// 时针的角度
    /// </summary>
    private Quaternion HourHandsAngle;

    /// <summary>
    /// 分针的角度
    /// </summary>
    private Quaternion MinuteHandsAngle;

    /// <summary>
    /// 是否初始化了
    /// </summary>
    private bool isInit = false;

    /// <summary>
    /// 是否停止了
    /// </summary>
    private bool isStopClock = true;

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        HourHandsAngle = HourHands.rotation;
        MinuteHandsAngle = MinuteHands.rotation;
    }

    private void Start()
    {
        //设置分钟 和完成的秒数
        SetTime(300, 6, () => { Debug.Log("完成"); });
    }

    /// <summary>
    /// 恢复角度
    /// </summary>
    private void RecoverAngles()
    {
        HourHands.localEulerAngles = Vector3.zero;
        MinuteHands.localEulerAngles = Vector3.zero;
    }

    /// <summary>
    /// 设置时间
    /// </summary>
    /// <param name="minute">设置分钟数</param>
    /// <param name="seconds">完成秒数</param>
    /// <param name="onComplete">委托函数</param>
    public void SetTime(float minute, float seconds, Action onComplete)
    {
        if (isInit == false)
            Init();

        if (isStopClock == false) return;

        isStopClock = false;
        RecoverAngles();

        // 角度 = 分钟 / 60秒转动周数 * 360度
        float angles = minute / 60 * 360;
        // 转动的角度 = 角度 / 转动秒数 * 0.1秒转动的角度
        float interval = angles / seconds * 0.1f;
        float count = 0;
        IDisposable dispose = null;

        dispose = Observable.Interval(TimeSpan.FromSeconds(0.1f)).Subscribe(param => {
            MinuteHands.Rotate(Vector3.back, interval);
            HourHands.Rotate(Vector3.back, (interval / 360) * (360 / 12));
            count += interval;
            if (count >= angles)
            {
                isStopClock = true;
                onComplete();
                dispose.Dispose();
            }
        });
    }
}
