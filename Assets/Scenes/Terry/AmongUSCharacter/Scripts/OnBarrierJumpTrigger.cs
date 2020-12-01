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
            //Destroy(gameObject);
        }
    }
}
