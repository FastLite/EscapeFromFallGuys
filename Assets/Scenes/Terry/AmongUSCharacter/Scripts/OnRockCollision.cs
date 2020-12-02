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
            TellScriptToDropTablet.instance.DropTheTaptop();
            //transform.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
