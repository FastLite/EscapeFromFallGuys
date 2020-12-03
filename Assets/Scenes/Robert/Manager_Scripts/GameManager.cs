using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletNumber;
    public bool hasTablet;
    public int completedLevels;

    public Slider tabletHealthBar;

    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    private void Start()
    {
        hasTablet = false;
        tabletNumber = 4;
        completedLevels = 0;
    }
    
    public void TakeDamage()
    {
        //tabletHealthBar.value -= 25;
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
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        AudioManager.Instance.PlayAudio("ButtonPress");

    }

    // Resumes gameplay
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        AudioManager.Instance.PlayAudio("ButtonPress");

    }
}
