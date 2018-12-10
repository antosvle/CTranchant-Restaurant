using System;

public interface IObservable
{
    void Notify();
    void AddObserver(Observer observer);
    void RemoveObserver(Observer observer);
}

