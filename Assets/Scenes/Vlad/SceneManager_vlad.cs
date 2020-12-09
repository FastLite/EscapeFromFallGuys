using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_vlad : Singleton<SceneManager_vlad>
{
    public int currentScene = 0;
    public static SceneManager_vlad instance;

    public void StartNextLevel(int nextScene)
    {
        
       // UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);

        currentScene = nextScene;
        if (currentScene != 0)
        {
            PlayerPrefs.SetInt("LastScenePlayed", currentScene);
        }
        Time.timeScale = 1;
        AudioManager.Instance.StopAudio("BGM");
    }

    public void ContinueGame()
    {
        StartNextLevel(PlayerPrefs.GetInt("LastScenePlayed"));
    }

    public void Restart()
    {
        StartNextLevel(currentScene);
        Time.timeScale = 1;
        GameManager.Instance.PlayLevelMusic();
    }
}
