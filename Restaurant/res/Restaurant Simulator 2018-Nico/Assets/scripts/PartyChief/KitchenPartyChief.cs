using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPartyChief : Observer
{
    public bool isFree;

    void Start()
    {
        foreach (var KitchenChief in FindObjectsOfType<KitchenChief>())
        {
            KitchenChief.AddObserver(this);
        }
    }

    public override void OnNotify()
    {
        if (isFree)
        {
           //NewOrder(true);
        }
    }
}
