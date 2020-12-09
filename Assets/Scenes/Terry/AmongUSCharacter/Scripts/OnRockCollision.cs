using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRockCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GameManager.Instance.hasTablet == true)
        {
            GameManager.Instance.hasTablet = false;
            PlayerMovement.instance.animator.SetTrigger("stumble");
            TellScriptToDropTablet.instance.DropTheTablet();
            AudioManager.Instance.StopAudio("Running");
            AudioManager.Instance.PlayAudio("RockHit");
            Invoke("PlayGetBackUp", 2.9f);
            GameManager.Instance.tabletNumber--;
            GameManager.Instance.TakeDamage();
            if (GameManager.Instance.tabletNumber == 0)
            {
                GameManager.Instance.GameOver();
            }
            transform.GetComponent<SphereCollider>().enabled = false;
            PlayerMovement.instance.canMove = false;
            Invoke("WaitForAnimationToEnd", 4.9f);
        }
    }

    public void WaitForAnimationToEnd()
    {
        PlayerMovement.instance.canMove = true;
    }

    public void PlayGetBackUp()
    {
        AudioManager.Instance.PlayAudio("GetBackUp");
    }
}
