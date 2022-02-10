using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;

    void Update()
    {
        time.text = TimeManager.FormatTime(TimeManager.Instance.time);
    }
}
