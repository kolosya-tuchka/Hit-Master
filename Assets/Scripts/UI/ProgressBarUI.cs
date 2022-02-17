using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image _bar;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (_gameManager.CurStage == _gameManager.StagesCount) return;

        StartCoroutine(UpdateBarCor());
        _gameManager.Stages[_gameManager.CurStage].OnCompletedStage.AddListener(UpdateBar);
    }

    private IEnumerator UpdateBarCor()
    {
        float time = 1;
        float target = (float)_gameManager.CurStage / (float)_gameManager.StagesCount;
        while (target - _bar.fillAmount > 0.005f)
        {
            _bar.fillAmount += ((target - _bar.fillAmount) / time * Time.deltaTime);
            yield return null;
        }
        _bar.fillAmount = target;
    }

}
