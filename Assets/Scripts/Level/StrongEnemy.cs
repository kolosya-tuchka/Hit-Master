using UnityEngine;

public class StrongEnemy : Enemy
{
    [SerializeField] private GameObject _enemyUI;

    public override void Die()
    {
        base.Die();
        _enemyUI.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        _enemyUI.SetActive(true);
    }
}
