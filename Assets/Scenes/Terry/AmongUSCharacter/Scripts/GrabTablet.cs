using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTablet : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //bool isKine = transform.GetComponent<Rigidbody>().isKinematic;
        if (other.CompareTag("Player") && transform.parent.GetComponent<Rigidbody>().isKinematic == false)
        {
            if(Input.GetKey(KeyCode.E))
            {
                TellScriptToDropTablet.instance.PutTabletInHand();
                Destroy(transform.parent.gameObject);
            }     
        }
    }
}
