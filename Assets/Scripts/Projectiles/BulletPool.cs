using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private GameObject _bulletPrefab;
    private Queue<Bullet> _bullets;

    void Start()
    {
        _bullets = new Queue<Bullet>();
        for (int i = 0; i < _size; ++i)
        {
            GameObject g = Instantiate(_bulletPrefab, transform);
            _bullets.Enqueue(g.GetComponent<Bullet>());
            g.GetComponent<Bullet>().Pool = this;
            g.SetActive(false);
        }
    }

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = _bullets.Dequeue();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.gameObject.SetActive(true);
        bullet.enabled = true;
    }

    public void DeactivateBullet(Bullet bullet)
    {
        bullet.enabled = false;
        bullet.gameObject.SetActive(false);
        _bullets.Enqueue(bullet);
    }
}
