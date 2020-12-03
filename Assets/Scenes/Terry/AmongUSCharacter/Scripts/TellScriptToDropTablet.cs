using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellScriptToDropTablet : MonoBehaviour
{
    public static TellScriptToDropTablet instance;
    public Transform tabletHolder;
    public GameObject[] tabletPrefabs;

    private void Awake()
    {
        instance = this;
    }

    public void DropTheTablet()
    {
        transform.GetComponentInChildren<DropTabletAndAddForce>().DropTablet();
    }

    // Instantiates new tablet in player's hand.
    public void PutTabletInHand()
    {
        int tabletNum = GameManager.Instance.tabletNumber;
        GameObject go = Instantiate(tabletPrefabs[tabletNum-1], tabletHolder);
    }
}
