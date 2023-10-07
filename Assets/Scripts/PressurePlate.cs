using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : BaseSubject {
    private OpenDoor[] _doors;
    private bool _doorsOpened = false;

    private void Awake() {
        _doors = FindObjectsOfType<OpenDoor>();
    }

    private void OnEnable() {
        foreach(IObserver door in _doors) {
            AddObserver(door);
        }
    }

    private void OnDisable() {
        foreach(IObserver door in _doors) {
            RemoveObserver(door);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player" && !_doorsOpened) {
            _doorsOpened = true;
            Notify();
        }
    }
}
