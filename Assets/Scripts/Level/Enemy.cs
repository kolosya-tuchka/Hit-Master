using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    void TakeDamage(float damage);
    void Die();
}

public class Enemy : MonoBehaviour, IEnemy
{
    public float maxHealpoints
    {
        get
        {
            return _maxHealpoints;
        }
        protected set
        {
            _maxHealpoints = value;
        }
    }

    public float healpoints { get; private set; }
    [SerializeField] protected float _maxHealpoints;
    [SerializeField] protected Collider enemyCollider;
    [SerializeField] protected RagdollController ragdoll;
    [SerializeField] protected Animator enemyAnimator;

    private void Start()
    {
        healpoints = maxHealpoints;
    }

    public void TakeDamage(float damage)
    {
        healpoints -= damage;
        if (healpoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameManager gm = GameManager.Instance;
        gm.stages[gm.curStage].RemoveEnemy();
        ragdoll.ActivateRagdoll();
        enemyAnimator.enabled = false;
        enemyCollider.enabled = false;

        Destroy(gameObject, 30);
    }

    public virtual void Activate()
    {
        enemyCollider.enabled = true;
    }

}
