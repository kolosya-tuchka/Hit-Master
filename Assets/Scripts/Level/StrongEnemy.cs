using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy
{
    [SerializeField] private GameObject enemyUI;

    public override void Die()
    {
        base.Die();
        enemyUI.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        enemyUI.SetActive(true);
    }
}
