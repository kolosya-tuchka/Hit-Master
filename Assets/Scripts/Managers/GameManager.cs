using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public const int UILayer = 5;
    [HideInInspector] public UnityEvent OnFinishedGame, OnStartedGame;

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Player player;
    [SerializeField] private Timer timer;
    
    public Stage[] Stages
    {
        get
        {
            return _stages;
        }
    }
    public int CurStage { get; private set; }
    public int StagesCount { get; private set; }

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
        CurStage = 0;
        StagesCount = Stages.GetLength(0);
        OnStartedGame.AddListener(StartGame);
    }

    public void NextStage()
    {
        ++CurStage;
        if (CurStage == StagesCount)
        {
            OnFinishedGame.Invoke();
            return;
        }
    }

    private void StartGame()
    {
        _inputManager.onTap.RemoveListener(OnStartedGame.Invoke);
    }
}
