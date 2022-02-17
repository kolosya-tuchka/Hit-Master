using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _results;
    [SerializeField] private GameObject _newRecordMessage;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        _results.text = "Your time: " + Timer.FormatTime(_timer.Time);
        if (_timer.Time < _timer.RecordTime)
        {
            _newRecordMessage.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
