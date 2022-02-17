using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Time { get; private set; }
    public float RecordTime { get; private set; }
    private bool _isTimerRunning;

    private void Start()
    {
        Time = 0;
        RecordTime = SaveManager.LoadRecordTime();
        _isTimerRunning = false;
        GameManager.Instance.OnStartedGame.AddListener(StartTimer);
        GameManager.Instance.OnFinishedGame.AddListener(StopTimer);
    }

    void Update()
    {
        if (!_isTimerRunning) return;
        
        Time += UnityEngine.Time.deltaTime;
    }

    private void StartTimer()
    {
        _isTimerRunning = true;
        Time = 0;
    }

    private void StopTimer()
    {
        _isTimerRunning = false;
        CheckRecordTime();
    }

    private void CheckRecordTime()
    {
        if (Time < RecordTime)
        {
            SaveManager.SaveRecordTime(Time);
        }
    }
    
    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time) / 60,
            seconds = Mathf.FloorToInt(time) % 60,
            milliseconds = Mathf.FloorToInt(time * 100) % 100;
        return string.Format("{0:0}.{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
