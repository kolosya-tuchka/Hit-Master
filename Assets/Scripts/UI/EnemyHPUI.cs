using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image bar;

    private void Update()
    {
        bar.fillAmount = enemy.healpoints / enemy.maxHealpoints;
        transform.LookAt(Camera.main.transform);
    }
}
