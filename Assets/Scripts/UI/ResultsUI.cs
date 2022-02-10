using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI results;
    [SerializeField] private GameObject newRecordMessage;

    private void Start()
    {
        results.text = "Your time: " + TimeManager.FormatTime(TimeManager.Instance.time);
        if (TimeManager.Instance.time < GameManager.Instance.record)
        {
            newRecordMessage.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
