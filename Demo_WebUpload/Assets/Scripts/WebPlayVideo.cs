using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WebPlayVideo : MonoBehaviour
{
    public VideoPlayer video;
    void Start()
    {
        video.clip = Resources.Load<VideoClip>("VideoClip/培养基的分装");
        video.Play();
    }
}