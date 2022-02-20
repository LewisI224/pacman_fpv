using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !game_manager.gameEnded)
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
