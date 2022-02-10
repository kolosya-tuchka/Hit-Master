using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance;

    public const int UILayer = 5;
    [HideInInspector] public UnityEvent onFinishedGame, onStartedGame;
    public float record;

    [SerializeField] private Player player;
    
    public Stage[] stages
    {
        get
        {
            return _stages;
        }
        private set
        {
            _stages = value;
        }
    }
    public int curStage { get; private set; }
    public int stagesCount { get; private set; }

    [SerializeField] private Stage[] _stages;

    void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnAwake();
    }

    private void OnAwake()
    {
        Application.targetFrameRate = 100;
        if (Instance == null)
        {
            Instance = this;
        }
        curStage = 0;
        stagesCount = stages.GetLength(0);
        onStartedGame.AddListener(StartGame);
        onFinishedGame.AddListener(FinishGame);
    }

    public void NextStage()
    {
        ++curStage;
        if (curStage == stagesCount)
        {
            onFinishedGame.Invoke();
            return;
        }
    }

    private void StartGame()
    {
        InputManager.Instance.onTap.RemoveListener(onStartedGame.Invoke);
        record = SaveManager.Instance.LoadRecord();
    }

    private void FinishGame()
    {
        if (TimeManager.Instance.time < record)
        {
            SaveManager.Instance.SaveRecord(TimeManager.Instance.time);
        }
    }
}
