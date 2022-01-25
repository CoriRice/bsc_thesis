using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused;

    [SerializeField] private GameObject pauseMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        ResumeGame();
        Cursor.visible = true;
        SceneManager.LoadScene("00 - Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
