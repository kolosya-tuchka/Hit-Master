using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Image _bar;

    private void Update()
    {
        _bar.fillAmount = _enemy.HealPoints / _enemy.MaxHealPoints;
        transform.LookAt(Camera.main.transform);
    }
}
