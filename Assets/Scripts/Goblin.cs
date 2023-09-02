using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {
    private static Goblin _instance;

    public static Goblin Instance => _instance;

    private void Awake() {
        if(_instance == null) {
            _instance = this;
        }
        else {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(_instance);
    }
}