using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // For loading next scene

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button skipButton;
    public string nextSceneName;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        skipButton.onClick.AddListener(SkipCutscene);
    }

    void EndReached(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void SkipCutscene()
    {
        videoPlayer.Stop();
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}