using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Shadowhaven_TitleMenu");
        Time.timeScale = 1;
    }
}
