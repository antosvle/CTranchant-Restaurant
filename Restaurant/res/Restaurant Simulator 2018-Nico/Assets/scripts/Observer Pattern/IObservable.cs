using System;

public interface IObservable
{
    void Notify(string str);
    void AddObserver(Observer observer);
    void RemoveObserver(Observer observer);
}

