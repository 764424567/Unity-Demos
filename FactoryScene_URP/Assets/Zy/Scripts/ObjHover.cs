using Com.Zcst.Zy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHover : MonoBehaviour
{
    public SunriseSunsetControl SunriseSunsetControl;
    public GameObject[] HighObj;

    public void ShowInfo(bool ison)
    {
        for (int i = 0; i < HighObj.Length; i++)
        {
            HighObj[i].SetActive(ison);
        }
    }

    private void OnMouseEnter()
    {
        if (GData.Instance.isInto)
            return;
        for (int i = 0; i < HighObj.Length; i++)
        {
            HighObj[i].SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (GData.Instance.isInto)
            return;
        for (int i = 0; i < HighObj.Length; i++)
        {
            HighObj[i].SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (GData.Instance.isInto)
            return;
        SunriseSunsetControl.CutTarget(gameObject.name);
    }
}