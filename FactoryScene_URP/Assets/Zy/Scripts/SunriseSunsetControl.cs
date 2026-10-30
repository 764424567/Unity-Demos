using Com.Zcst.Zy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;
using UnityEngine.UI;

public class SunriseSunsetControl : MonoBehaviour
{
    public AzureTimeController azureTime;
    public Slider m_TimeSlider;

    public CameraTargetMove m_CamerRotate;

    public GameObject[] HighObj;
    public Material[] HighMat;

    public Button BtnBack;

    public ObjHover[] objHovers;

    void Start()
    {
        //Debug.Log(azureTime.GetTimeline());

        m_TimeSlider.onValueChanged.AddListener(value => TimeSliderValue(value));

        BtnBack.onClick.AddListener(BtnBackEvent);
        BtnBack.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        for (int i = 0; i < HighMat.Length; i++)
        {
            HighMat[i].DisableKeyword("_EMISSION");
        }
    }

    void TimeSliderValue(float value)
    {
        float num = 24f * value;
        azureTime.SetTimeline(num);
    }

    public void CutTarget(string objName)
    {
        if (objName == "pengzhuang01")
        {
            m_CamerRotate.CutTarget(1);
            objHovers[0].ShowInfo(true);
        }
        else if (objName == "pengzhuang02")
        {
            m_CamerRotate.CutTarget(2);
            objHovers[1].ShowInfo(true);
        }
        GData.Instance.isInto = true;
        BtnBack.gameObject.SetActive(true);
    }

    void BtnBackEvent()
    {
        //GData.Instance.isInto = false;
        m_CamerRotate.CutTarget(0);
        BtnBack.gameObject.SetActive(false);
        for (int i = 0; i < objHovers.Length; i++)
        {
            objHovers[i].ShowInfo(false);
        }
    }

    private void Update()
    {
        m_TimeSlider.value = azureTime.GetTimeline() / 24f;

        if (azureTime.GetTimeline() >= 17 || azureTime.GetTimeline() <= 5)
        {
            for (int i = 0; i < HighObj.Length; i++)
            {
                HighObj[i].SetActive(true);
            }
            for (int i = 0; i < HighMat.Length; i++)
            {
                HighMat[i].EnableKeyword("_EMISSION");
            }
        }
        else
        {
            for (int i = 0; i < HighObj.Length; i++)
            {
                HighObj[i].SetActive(false);
            }
            for (int i = 0; i < HighMat.Length; i++)
            {
                HighMat[i].DisableKeyword("_EMISSION");
            }
        }
    }
}