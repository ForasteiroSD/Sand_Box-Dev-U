using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static Action<float> Move;
    [SerializeField] private GameObject Ogre;
    [SerializeField] private GameObject Goblin;

    void Start() {
        Ogre ogre1 = Ogre.AddComponent<Ogre>();
        Goblin goblin1 = Goblin.AddComponent<Goblin>();
        ogre1.Speed = 3f;
        goblin1.Speed = 4f;
    }

    void FixedUpdate() {
        if(Input.GetKey(KeyCode.UpArrow)) Move?.Invoke(1);
        if(Input.GetKey(KeyCode.DownArrow)) Move?.Invoke(-1);
    }
}