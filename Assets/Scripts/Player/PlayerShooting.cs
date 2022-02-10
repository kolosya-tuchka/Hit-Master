using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private BulletPool bulletPool;

    [Tooltip("Firing rate per second")]
    [SerializeField] private float shootingSpeed = 2;

    private bool canShot, isReloaded;

    private void Start()
    {
        isReloaded = true;
        DisableShooting();
        InputManager.Instance.onTap.AddListener(Shot);
    }

    private void Shot()
    {
        if (!canShot || !isReloaded) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == GameManager.UILayer) return;
            bulletSpawnPoint.LookAt(hit.point);
            bulletPool.SpawnBullet(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }

        isReloaded = false;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1 / shootingSpeed);
        isReloaded = true;
    }

    private void DisableShooting()
    {
        canShot = false;
        GameManager gm = GameManager.Instance;
        if (gm.curStage < gm.stagesCount) gm.stages[gm.curStage].onStartedStage.AddListener(EnableShooting);
    }

    private void EnableShooting()
    {
        canShot = true;
        GameManager gm = GameManager.Instance;
        gm.stages[gm.curStage].onCompletedStage.AddListener(DisableShooting);
    }
}
