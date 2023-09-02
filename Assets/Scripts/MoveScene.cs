using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MoveScene : MonoBehaviour {
    private GameObject _player;
    [SerializeField] private String _nextScene;
    [SerializeField] private float _posX;
    [SerializeField] private float _posY;

    void Start() {
        _player = GameObject.Find("Goblin");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(_nextScene);
            _player.transform.position = new Vector3(_posX, _posY, _player.transform.position.z);
        }
    }
}