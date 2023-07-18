using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CoreVideoController : MonoBehaviour
{
    public GameObject coreVideo;
    public VideoPlayer videoPlayer;

    private bool isVideoOpen;

    public void VideoPlay () {
        VideoUIOpen();
        videoPlayer.Play();
    }

    public void VideoUIOpen()
    {
        isVideoOpen = !isVideoOpen;
        coreVideo.SetActive(isVideoOpen);
    }
}
