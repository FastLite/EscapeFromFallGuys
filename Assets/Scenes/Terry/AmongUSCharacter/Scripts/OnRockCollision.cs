using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRockCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.instance.animator.SetTrigger("stumble");
            TellScriptToDropTablet.instance.DropTheTablet();
            AudioManager.Instance.StopAudio("Running");
            GameManager.Instance.tabletNumber--;
            GameManager.Instance.TakeDamage();
            if (GameManager.Instance.tabletNumber == 0)
            {
                GameManager.Instance.GameOver();
            }
            PlayerMovement.instance.canMove = false;
            Destroy(gameObject);
            Invoke("WaitForAnimationToEnd", 3.5f);
        }
    }

    public void WaitForAnimationToEnd()
    {
        PlayerMovement.instance.canMove = true;
    }
}
