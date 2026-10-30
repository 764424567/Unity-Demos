using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    //管理枪支
    private List<GunSystem> managerdGuns;
    //当前的枪支
    private GunSystem currentGun;
    //枪支编号
    private int index = 0;

    private void Awake()
    {
        managerdGuns = new List<GunSystem>();
        // currentGun = GetComponent<FPSGun>();
    }
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //添加每一把枪
            managerdGuns.Add(transform.GetChild(i).GetComponent<GunSystem>());
        }
        if (managerdGuns.Count > 0)
        {
            //当前先使用的第一把枪
            currentGun = managerdGuns[index];
        }
    }
    private void Update()
    {
        //当前是否有一把枪
        if (!currentGun)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentGun.Reload();//换弹
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentGun.gameObject.SetActive(false);
            //计算新枪的编号
            index = ++index % managerdGuns.Count;
            currentGun = managerdGuns[index];//更新当前枪支
            currentGun.gameObject.SetActive(true);//新枪
        }
    }
}
