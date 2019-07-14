using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField] private GameObject videoPlaneObject;
    private List<VideoPlane> videoPlanes = new List<VideoPlane>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearVideoPlane(string videoUrl, GameObject appearParent = null)
    {
        GameObject parentObj = appearParent;
        if (parentObj == null)
        {
            parentObj = this.gameObject;
        }
        VideoPlane videoPlane = ComponentUtil.InstantiateTo<VideoPlane>(parentObj, videoPlaneObject);
        videoPlane.PlayVideoFromUrl(videoUrl);
        videoPlane.OnFinished = () =>
        {
            Destroy(videoPlane.gameObject);
            videoPlanes.Remove(videoPlane);
        };
        videoPlanes.Add(videoPlane);
    }
}
