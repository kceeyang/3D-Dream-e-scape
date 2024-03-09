using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    /*
    public static bool GameIsPaused = false;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    */


    public void Pause()
    {
        //Debug.Log("Pausing");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
            

    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        // TODO Without Clear it won't work.
        DOTween.Clear(true);
        // TODO Reload current scene

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}
