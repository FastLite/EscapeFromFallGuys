using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    public void LoadScene(int par)
    {
        Debug.Log("2");
        SceneManager_vlad.instance.StartNextLevel(par);
    }
    
}
