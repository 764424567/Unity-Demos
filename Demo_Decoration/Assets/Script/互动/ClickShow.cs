using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClickShow : MonoBehaviour
{
    public GameObject obg;

    private void OnMouseDown()
    {
        if (obg.GetComponent<VideoPlayer>().isPlaying)
        {
            obg.GetComponent<VideoPlayer>().Pause();
        }
        else
        {
            obg.GetComponent<VideoPlayer>().Play();
        }
        //obg.SetActive(!obg.activeSelf);
    }
}
