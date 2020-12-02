using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletHealth;
    public bool hasTablet;

    public Slider tabletHealthBar;
    public GameObject loseScreen;
    private void Start()
    {
        hasTablet = false;
        tabletHealth = 3;
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
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        loseScreen.SetActive(false);
        SceneManager.Instance.GameReset();
    }
}
