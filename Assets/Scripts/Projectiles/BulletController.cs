using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    private void ActivateBullet()
    {
        bullet.rb.velocity = transform.forward * bullet.speed;
        StartCoroutine(Deactivation());
    }

    private IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(3);
        bullet.pool.DeactivateBullet(bullet);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IEnemy>().TakeDamage(bullet.damage);
        }
        bullet.pool.DeactivateBullet(bullet);
    }

    private void OnEnable()
    {
        ActivateBullet();
    }

}
