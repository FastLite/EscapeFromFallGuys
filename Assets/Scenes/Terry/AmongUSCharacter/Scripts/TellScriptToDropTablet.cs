using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellScriptToDropTablet : MonoBehaviour
{
    public static TellScriptToDropTablet instance;
    public Transform tabletHolder;

    private void Awake()
    {
        instance = this;
    }

    public void DropTheTaptop()
    {
        transform.GetComponentInChildren<DropTabletAndAddForce>().DropTablet();
    }
}
