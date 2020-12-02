using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletHealth;
    public bool hasTablet;
    public int completedLevels;

    public Slider tabletHealthBar;

    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;
    private void Start()
    {
        hasTablet = false;
        tabletHealth = 3;
        completedLevels = 0;
    }
    
    public void TakeDamage()
    {
        if (hasTablet)
        {
            if (tabletHealth > 0)
            {
                tabletHealth --;
                tabletHealthBar.value = tabletHealth;
                Debug.Log("<color=red>You have taken damage!</color>");
                GameOver();
                hasTablet = false;
            }
        }
    }

    public void GameOver()
    {
        if(tabletHealth <= 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            Debug.Log("<color=cyan>Game Over!</color>");
        }

        if(hasTablet && completedLevels == 3)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
            Debug.Log("<color=blue>Congratulations, you win!</color>");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        loseScreen.SetActive(false);
        completedLevels = 0;
        SceneManager.Instance.GameReset();
        Debug.Log("<color=green>Game has been reset</color>");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
