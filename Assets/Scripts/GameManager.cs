using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    void Start() {
        Ogre ogre1 = new Ogre("Shrek", 100, 20, 2);
        Goblin goblin1 = new Goblin("Green Goblin", 40, 5, 6);

        Debug.Log("Ogre: " + ogre1.Life + "HP");
        Debug.Log("Goblin: " + goblin1.Life + "HP");
        ogre1.LooseLife(20);
        goblin1.LooseLife(20);
        Debug.Log("Ogre: " + ogre1.Life + "HP");
        Debug.Log("Goblin: " + goblin1.Life + "HP");
    }

    void Update() {
        
    }
}
