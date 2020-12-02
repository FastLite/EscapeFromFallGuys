using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.animator.SetTrigger("trip");
            TellScriptToDropTablet.instance.DropTheTaptop();
            //Destroy(gameObject);
        }
    }
}
