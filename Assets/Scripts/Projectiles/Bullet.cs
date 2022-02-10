using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletPool pool;
    public float speed
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
    public float damage
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
    public Rigidbody rb
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
