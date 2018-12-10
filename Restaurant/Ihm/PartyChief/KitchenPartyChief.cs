using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPartyChief : Observer
{
    void Start()
    {
        foreach (var KitchenChief in FindObjectsOfType<KitchenChief>())
        {
            KitchenChief.AddObserver(this);
        }
    }

    public override void OnNotify()
    {
        Debug.Log("New Order");
    }
}
