using System;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, IObservable
{
    //List of observers
    private List<Observer> observers = new List<Observer>();

    //Method to notify the observers
    public void Notify()
    {
        foreach (var observer in observers) 
        { 
            observer.OnNotify("");
        }
    }

    //Method to add an observers
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    //Method to remove an observers
    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
}
