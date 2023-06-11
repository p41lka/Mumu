using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private string videoFileName;
    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }


    public void PlayVideo()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();

        if (player)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            player.url = videoPath;
            player.Play();
        }
    }
}
