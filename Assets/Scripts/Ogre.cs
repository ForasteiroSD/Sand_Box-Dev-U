using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Enemy {
    public Ogre(string name, float life, float damage, float speed) : base(name, life, damage, speed) {}

    public void Move(float direction) {
        Vector3 movement = new Vector3(direction, 0f, 0f);
        transform.position += movement * Time.deltaTime * this.Speed;
        if(direction == 1) this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnEnable() {
        GameManager.Move += Move;
    }

    private void OnDisable() {
        GameManager.Move = Move;
    }
}