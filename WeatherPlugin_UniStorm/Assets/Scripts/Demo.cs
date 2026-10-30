using System.Collections;
using System.Collections.Generic;
using UniStorm;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    public Button BtnChangeWeather;
    public Slider m_Slider;

    void Start()
    {
        // 点击按钮，控制天气
        BtnChangeWeather.onClick.AddListener(BtnChangeWeatherEvent);
        m_Slider.onValueChanged.AddListener(SliderValueChangedEvent);
    }

    void BtnChangeWeatherEvent()
    {
        UniStormSystem.Instance.ChangeWeather(UniStormSystem.Instance.AllWeatherTypes[18]);
    }

    void SliderValueChangedEvent(float value)
    {
        UniStormSystem.Instance.m_TimeFloat=value;
    }
}