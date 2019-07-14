using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlane : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private bool isFinished = false;

    public Action OnFinished;

    void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();
    }

    public void PlayVideoFromUrl(string url)
    {
        isFinished = false;
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();
        videoPlayer.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            if (OnFinished != null && !isFinished)
            {
                isFinished = true;
                OnFinished();
            }
            return;
        }
    }
}
