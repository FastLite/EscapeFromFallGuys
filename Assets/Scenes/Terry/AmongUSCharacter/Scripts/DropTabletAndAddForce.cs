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

        if(GameManager.Instance.tabletNumber == 4)
        {
            GameManager.Instance.helpMessageTextField.gameObject.SetActive(true);
            Invoke("WaitForSomeTime", 4.5f);
        }   
    }

    public void WaitForSomeTime()
    {
        GameManager.Instance.helpMessageTextField.gameObject.SetActive(false);
    }
}
