using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [HideInInspector] public static TimeManager Instance;
    public float time { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        time = -1;
        GameManager.Instance.onStartedGame.AddListener(StartTimer);
    }

    void Update()
    {
        if (time == -1) return;

        time += Time.deltaTime;
    }

    private void StartTimer()
    {
        time = 0;
    }

    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time) / 60,
            seconds = Mathf.FloorToInt(time) % 60,
            miliseconds = Mathf.FloorToInt(time * 100) % 100;
        return string.Format("{0:0}.{1:00}.{2:00}", minutes, seconds, miliseconds);
    }
}
