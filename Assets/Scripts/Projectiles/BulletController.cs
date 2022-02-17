using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private void ActivateBullet()
    {
        _bullet.Rb.velocity = transform.forward * _bullet.Speed;
        StartCoroutine(Deactivation());
    }

    private IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(3);
        _bullet.Pool.DeactivateBullet(_bullet);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IEnemy>().TakeDamage(_bullet.Damage);
        }
        _bullet.Pool.DeactivateBullet(_bullet);
    }

    private void OnEnable()
    {
        ActivateBullet();
    }

}
