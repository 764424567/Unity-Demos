using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public VideoPlayer videoPlay;
    public GameObject img_Menu;
    private bool isPlay = true;
    
    public void OnClickVideo()
    {
        if (isPlay)
        {
            isPlay = false;
            videoPlay.Pause();
            img_Menu.SetActive(true);
        }
        else
        {
            isPlay = true;
            videoPlay.Play();
            img_Menu.SetActive(false);
        }
    }

    /// <summary>
    /// µã»÷ÍË³ö°´Å¥
    /// </summary>
    public void OnClickClose()
    {
        Application.Quit();
    }

    public void OnClickUser()
    {
        SceneManager.LoadScene("UserScene");
    }
}                          
