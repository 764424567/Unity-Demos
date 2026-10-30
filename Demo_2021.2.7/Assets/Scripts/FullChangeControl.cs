using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullChangeControl : MonoBehaviour
{
    public Button BtnFullScreen;
    public Button BtnExitFullScreen;

    void Start()
    {
    }

    void Update()
    {
        // 根据全屏状态切换按钮
        if (Screen.fullScreen)
        {
            BtnFullScreen.gameObject.SetActive(false);
            BtnExitFullScreen.gameObject.SetActive(true);
        }
        else
        {
            BtnFullScreen.gameObject.SetActive(true);
            BtnExitFullScreen.gameObject.SetActive(false);
        }
    }

    // 全屏
    public void BtnFullScreenEvent()
    {
        if (Screen.fullScreen == false)
        {
            Resolution[] resolutions = Screen.resolutions;
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
            Screen.fullScreen = true;
        }
    }

    // 退出全屏
    public void BtnExitFullScreenEvent()
    {
        if (Screen.fullScreen == true)
        {
            Screen.SetResolution(960, 540, false);
            Screen.fullScreen = false;
        }
    }
}