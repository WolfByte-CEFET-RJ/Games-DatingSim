using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject configMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        configMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        configMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
/*
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        //Usar quando existir
        //SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }
*/
    public void ConfigGame()
    {
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}