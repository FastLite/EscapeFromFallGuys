using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_vlad : MonoBehaviour
{
    public int currentScene = 0;
    public static SceneManager_vlad instance;

    private void Awake()
    {
        
        DontDestroyOnLoad(this);
        if (instance== null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        

    }

    public void StartNextLevel(int nextScene)
    {
        
       // UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);

        currentScene = nextScene;
        if (currentScene != 0)
        {
            PlayerPrefs.SetInt("LastScenePlayed", currentScene);
        }
    }

    public void ContinueGame()
    {
        StartNextLevel(PlayerPrefs.GetInt("LastScenePlayed"));
    }

    public void Restart()
    {
        StartNextLevel(currentScene);
    }
    
    

}
