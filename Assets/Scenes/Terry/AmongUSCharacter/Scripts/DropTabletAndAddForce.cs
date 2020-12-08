using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTabletAndAddForce : MonoBehaviour
{
    public void DropTablet()
    { 
        Rigidbody rb = GetComponent<Rigidbody>();
        transform.SetParent(null);

        rb.velocity = Vector3.zero;
        rb.isKinematic = false;

        rb.AddForce(transform.up * 150);
    }
}
