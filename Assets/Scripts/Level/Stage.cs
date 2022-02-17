using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnCompletedStage, OnStartedStage;
    public int EnemyCount { get; private set; }
    public Transform Waypoint
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

    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private Transform _waypoint;

    private void Start()
    {
        OnStartedStage.AddListener(ActivateEnemies);
        OnCompletedStage.AddListener(GameManager.Instance.NextStage);
        EnemyCount = _enemies.GetLength(0);
    }

    public void RemoveEnemy()
    {
        --EnemyCount;
        if (EnemyCount == 0)
        {
            OnCompletedStage.Invoke();
        }
    }

    private void ActivateEnemies()
    {
        foreach (var e in _enemies)
        {
            e.Activate();
        }
    }

}
