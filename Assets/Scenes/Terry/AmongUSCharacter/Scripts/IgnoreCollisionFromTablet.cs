using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionFromTablet : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player"
            || collision.gameObject.tag == "Rock"
            || collision.gameObject.tag == "Pillars"
            || collision.gameObject.tag == "Barriers")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
