using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPillarCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement.instance.animator.SetTrigger("stumble");
            TellScriptToDropTablet.instance.DropTheTaptop();
            transform.GetComponent<CapsuleCollider>().enabled = false;
            //Destroy(gameObject);
        }
    }
}
