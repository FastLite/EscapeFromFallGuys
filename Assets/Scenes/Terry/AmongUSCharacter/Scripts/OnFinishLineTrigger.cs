using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

        }
    }
}
