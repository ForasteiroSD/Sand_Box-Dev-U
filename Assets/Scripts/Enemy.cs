using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    private string _name;
    protected float _life;
    protected float _damage;
    protected float _speed;

    // Constructor
    public Enemy(string name, float life, float damage, float speed) {
        _name = name;
        _life = life;
        _damage = damage;
        _speed = speed;
    }

    // Getters and Setters
    public float Damage { get => _damage; set => _damage = value; }
    public float Life { get => _life; set => _life = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public string Name { get => _name; set => _name = value; }

    // Methods
    public void LooseLife(float amount) {
        Life -= amount;
    }
}