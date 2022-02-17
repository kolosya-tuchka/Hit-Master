using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 _direction = new Vector3(0, 1, 0);
    [SerializeField] private float _speed = 3;

    void Update()
    {
        transform.Rotate(_direction * _speed * Time.deltaTime);
    }
}
