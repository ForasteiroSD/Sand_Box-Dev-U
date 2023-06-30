using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy {
    public Goblin(string name, float life, float damage, float speed) : base(name, life, damage, speed) {}
    
    public void Move(float direction) {
        Vector3 movement = new Vector3(-direction, 0f, 0f);
        transform.position += movement * Time.deltaTime * this.Speed;
        if(direction == 1) this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    private void OnEnable() {
        GameManager.Move += Move;
    }

    private void OnDisable() {
        GameManager.Move = Move;
    }
}