using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBarrierJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement.instance.animator.SetTrigger("trip");
            TellScriptToDropTablet.instance.DropTheTablet();
            AudioManager.Instance.StopAudio("Running");
            AudioManager.Instance.PlayAudio("Trip");
            Invoke("PlayGetBackUp", 1.5f);
            GameManager.Instance.tabletNumber--;
            GameManager.Instance.TakeDamage();
            if (GameManager.Instance.tabletNumber == 0)
            {
                GameManager.Instance.GameOver();
            }
            transform.GetComponent<CapsuleCollider>().enabled = false;
            PlayerMovement.instance.canMove = false;
            Invoke("WaitForAnimationToEnd", 3.5f);
            //Destroy(gameObject);
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
