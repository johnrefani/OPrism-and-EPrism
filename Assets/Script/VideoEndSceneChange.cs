using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName1, sceneName2;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        int OnboardingStatus = PlayerPrefs.GetInt("OnboardingStatus");
        if (OnboardingStatus == 0)
        {
            SceneManager.LoadScene(sceneName1);
        }
        else if (OnboardingStatus == 1) 
        { 
            SceneManager.LoadScene(sceneName2);
        }
       
    }
}


