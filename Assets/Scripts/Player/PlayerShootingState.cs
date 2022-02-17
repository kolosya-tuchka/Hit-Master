using System.Collections;
using UnityEngine;

public class PlayerShootingState : PlayerState
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private BulletPool bulletPool;

    [Tooltip("Firing rate per second")]
    [SerializeField] private float shootingSpeed = 2;

    private bool canShot, isReloaded;

    public override void OnStart()
    {
        isReloaded = true;
        _player.inputManager.onTap.AddListener(Shot);
        DisableShooting();
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
    }

    private void EnableShooting()
    {
        canShot = true;
    }

    public override void Enter()
    {
        EnableShooting();
        
        GameManager gm = GameManager.Instance;
        gm.Stages[gm.CurStage].OnStartedStage.Invoke();
        if (gm.CurStage != gm.StagesCount - 1)
        {
            gm.Stages[gm.CurStage].OnCompletedStage.AddListener(() => _stateMachine.SwitchState<PlayerMovingState>());
        }
    }

    public override void Exit()
    {
        DisableShooting();
    }
}
