using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTabletAndAddForce : MonoBehaviour
{
    public void DropTablet()
    { 
        Rigidbody rb = GetComponent<Rigidbody>();
        

        //transform.position = transform.parent.position;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        //var postPos = transform.parent.position;
        //postPos.y += 1;
        transform.SetParent(null);

        rb.velocity = Vector3.zero;
        rb.isKinematic = false;

        //transform.SetParent(null);
        //transform.position = postPos;
        //rb.AddForce(transform.forward * 100);
        //transform.GetComponent<BoxCollider>().enabled = true;
    }
}
