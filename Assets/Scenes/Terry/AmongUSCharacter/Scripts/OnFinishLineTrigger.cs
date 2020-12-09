using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0.1f;
            GameManager.Instance.winScreen.SetActive(true);
            AudioManager.Instance.StopAudio("BGM");
            AudioManager.Instance.PlayAudio("Victory");
        }
    }
}
