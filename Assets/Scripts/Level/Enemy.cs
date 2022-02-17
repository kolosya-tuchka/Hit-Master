using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public float MaxHealPoints
    {
        get
        {
            return maxHealPoints;
        }
        protected set
        {
            maxHealPoints = value;
        }
    }

    public float HealPoints { get; private set; }
    [SerializeField] protected float maxHealPoints;
    [SerializeField] protected Collider enemyCollider;
    [SerializeField] protected RagdollController ragdoll;
    [SerializeField] protected Animator enemyAnimator;

    private void Start()
    {
        HealPoints = MaxHealPoints;
    }

    public void TakeDamage(float damage)
    {
        HealPoints -= damage;
        if (HealPoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameManager gm = GameManager.Instance;
        gm.Stages[gm.CurStage].RemoveEnemy();
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
