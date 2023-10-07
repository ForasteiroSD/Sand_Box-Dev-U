using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSubject : MonoBehaviour {
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer) {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer) {
        _observers.Remove(observer);
    }

    protected void Notify() {
        foreach (IObserver observer in _observers) {
            observer.OnNotify();
        }
    }
}