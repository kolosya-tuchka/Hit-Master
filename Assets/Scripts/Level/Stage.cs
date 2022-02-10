using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    [HideInInspector] public UnityEvent onCompletedStage, onStartedStage;
    public int enemyCount { get; private set; }
    public Transform waypoint
    {
        get
        {
            return _waypoint;
        }
        private set
        {
            _waypoint = value;
        }
    }

    [SerializeField] private Enemy[] enemies;

    [SerializeField] private Transform _waypoint;

    private void Start()
    {
        onStartedStage.AddListener(ActivateEnemies);
        onCompletedStage.AddListener(GameManager.Instance.NextStage);
        enemyCount = enemies.GetLength(0);
    }

    public void RemoveEnemy()
    {
        --enemyCount;
        if (enemyCount == 0)
        {
            onCompletedStage.Invoke();
        }
    }

    private void ActivateEnemies()
    {
        foreach (var e in enemies)
        {
            e.Activate();
        }
    }

}
