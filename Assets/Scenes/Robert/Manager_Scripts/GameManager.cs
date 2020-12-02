using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int tabletHealth;
    public bool hasTablet;
    public int completedLevels;
    public int totalLevels;
    public float popUpForce;

    public GameObject player;
    public GameObject tabletPrefab;

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
        if (hasTablet && tabletHealth > 0)
        {
            // Drops the tablet
            var tablet = GameObject.FindGameObjectWithTag("Tablet");
            Destroy(tablet);
            var newTablet = Instantiate(tabletPrefab, player.transform.position, Quaternion.identity);
            newTablet.GetComponent<Rigidbody>().AddForce(transform.up * popUpForce);

            // Tablet loses health
            tabletHealth --;
            tabletHealthBar.value = tabletHealth;
            Debug.Log("<color=red>You have taken damage!</color>");

            // Checks if game is over
            GameOver();
            hasTablet = false;
        }
    }

    public void GameOver()
    {
        // Activates game over if health reaches 0
        if(tabletHealth <= 0)
        {
            AudioManager.Instance.PlayAudio("Defeat");
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            Debug.Log("<color=cyan>Game Over!</color>");
        }

        // Activates win screen after all levels are complete
        if(hasTablet && completedLevels == totalLevels)
        {
            AudioManager.Instance.PlayAudio("Victory");
            Time.timeScale = 0;
            winScreen.SetActive(true);
            Debug.Log("<color=blue>Congratulations, you win!</color>");
        }
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
