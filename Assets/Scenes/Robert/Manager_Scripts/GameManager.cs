using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletNumber;
    public bool isPaused = false;
    public bool hasTablet = true;

    public Slider tabletHealthBar;

    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject hud;
    public GameObject rules;
    public GameObject credits;
    public GameObject mainScreen;
    public GameObject mainScreenBackground;

    private void Start()
    {
        Time.timeScale = 1;
        tabletNumber = 4;
        tabletHealthBar.value = 100;

        //foreach(Transform child in transform)
        //{
        //    DontDestroyOnLoad(child);
        //}
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                PauseGame();
            }     
            else
            {
                isPaused = false;
                ResumeGame();
            }              
        }
    }

    public void TakeDamage()
    {
        tabletHealthBar.value -= 25;
    }

    public void GameOver()
    {
        AudioManager.Instance.StopAudio("BGM");
        AudioManager.Instance.PlayAudio("Defeat");
        Time.timeScale = 0.15f;
        loseScreen.SetActive(true);
        Debug.Log("<color=cyan>Game Over!</color>");
    }

    // Restarts the game
    public void RestartGame()
    {
        Time.timeScale = 1;
        loseScreen.SetActive(false);
        tabletNumber = 4;
        tabletHealthBar.value = 100;
        Debug.Log("<color=green>Game has been reset</color>");
    }

    // Pauses the game
    public void PauseGame()
    {
        AudioManager.Instance.PlayAudio("ButtonPress");
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Resumes gameplay
    public void ResumeGame()
    {
        AudioManager.Instance.PlayAudio("ButtonPress");
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayButtonPress()
    {
        AudioManager.Instance.PlayAudio("ButtonPress");
    }

    public void PlayLevelMusic()
    {
        AudioManager.Instance.StopAudio("MenuMusic");
        AudioManager.Instance.PlayAudio("BGM");
    }
}
