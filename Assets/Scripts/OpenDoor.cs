using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IObserver {
    [SerializeField] private bool _horizontal;
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _size = 4f;
    private float _step;
    private Vector3 _target;
    private bool _canOpen = false;

    private void Start() {
        _target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, _target, _step);
    }

    public void OnNotify() {
        _step = _speed * Time.deltaTime;
        if(_horizontal) _target = new Vector3(transform.position.x + _size, transform.position.y, transform.position.z);
        else _target = new Vector3(transform.position.x, transform.position.y + _size, transform.position.z);
    }
}