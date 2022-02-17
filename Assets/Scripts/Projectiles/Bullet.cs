using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletPool Pool;
    public float Speed
    {
        get
        {
            return _speed;
        }
        private set
        {
            _speed = value;
        }
    }
    public float Damage
    {
        get
        {
            return _damage;
        }
        private set
        {
            _damage = value;
        }
    }
    public Rigidbody Rb
    {
        get
        {
            return _rb;
        }
        private set
        {
            _rb = value;
        }
    }

    [SerializeField] private float _speed, _damage;
    [SerializeField] private Rigidbody _rb;
}
