using System;
using UnityEngine;

public abstract class Observer : MonoBehaviour, IObserver
{
    public abstract void OnNotify(string str);
}
