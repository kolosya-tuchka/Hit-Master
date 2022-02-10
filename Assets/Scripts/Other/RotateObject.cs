using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 direction = new Vector3(0, 1, 0);
    [SerializeField] private float speed = 3;

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
