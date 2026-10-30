using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class do2 : MonoBehaviour
{
    public Transform[] items;
    public Transform[] items2;
    public Ease ease1;
    public float f1=1000;
    public float f2 = 1f;
    public bool ss = false;
    public GameObject ui;
    public GameObject ui2;
    // Use this for initialization
    void Start()
    {
        //ShowAnimation();
        ui.SetActive(false);
        ui2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void sss()
    {
        ui.SetActive(true);
        ui2.SetActive(false);
        ShowAnimation();
    }

    public void sss2()
    {
        ui.SetActive(false);
        ui2.SetActive(true);
        ShowAnimation2();
    }

    void ShowAnimation()
    {
        StartCoroutine(Show());
    }

    void ShowAnimation2()
    {
        StartCoroutine(Show2());
    }

    IEnumerator Show()
    {
        //items数组引用了图片中的那几个长条Transform
        foreach (var item in items)
        {
            item.DOLocalMoveX(f1, f2, ss).From().SetEase(ease1);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator Show2()
    {
        //items数组引用了图片中的那几个长条Transform
        foreach (var item in items2)
        {
            item.DOLocalMoveX(f1, f2, ss).From().SetEase(ease1);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
