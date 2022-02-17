using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTimeUI : MonoBehaviour
{
    [SerializeField] private Timer _timer; 
    [SerializeField] private TextMeshProUGUI _timeText;

    void Update()
    {
        _timeText.text = Timer.FormatTime(_timer.Time);
    }
}
