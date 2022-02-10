using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private GameObject bulletPrefab;
    private Queue<Bullet> bullets;

    void Start()
    {
        bullets = new Queue<Bullet>();
        for (int i = 0; i < size; ++i)
        {
            GameObject g = Instantiate(bulletPrefab, transform);
            bullets.Enqueue(g.GetComponent<Bullet>());
            g.GetComponent<Bullet>().pool = this;
            g.SetActive(false);
        }
    }

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = bullets.Dequeue();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.gameObject.SetActive(true);
        bullet.enabled = true;
    }

    public void DeactivateBullet(Bullet bullet)
    {
        bullet.enabled = false;
        bullet.gameObject.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
