using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseRocks : MonoBehaviour
{
    public List<Transform> rocks;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(Transform singleRock in rocks)
            {
                singleRock.transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }


}
