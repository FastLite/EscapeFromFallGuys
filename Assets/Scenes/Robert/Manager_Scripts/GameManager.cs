using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletNumber;
    public bool hasTablet;
    public int completedLevels;
    public bool isPaused = false;

    public Slider tabletHealthBar;

    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject hud;
    private void Start()
    {
        hasTablet = false;
        tabletNumber = 4;
        completedLevels = 0;
        tabletHealthBar.value = 100;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else if (isPaused)
                ResumeGame();
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


        // Activates win screen after all levels are complete
        //if(hasTablet && completedLevels == totalLevels)
        //{
        //    AudioManager.Instance.PlayAudio("Victory");
        //    Time.timeScale = 0;
        //    winScreen.SetActive(true);
        //    Debug.Log("<color=blue>Congratulations, you win!</color>");
        //}
    }

    // Restarts the game
    public void RestartGame()
    {
        Time.timeScale = 1;
        loseScreen.SetActive(false);
        completedLevels = 0;
        SceneManager.Instance.GameReset();
        Debug.Log("<color=green>Game has been reset</color>");
    }

    // Pauses the game
    public void PauseGame()
    {
        AudioManager.Instance.PlayAudio("ButtonPress");
        Time.timeScale = 0;
        pauseScreen.SetActive(true);     
    }

    // Resumes gameplay
    public void ResumeGame()
    {
        AudioManager.Instance.PlayAudio("ButtonPress");
        Time.timeScale = 1;
        pauseScreen.SetActive(false);    
    }
}
