using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour, IStateMachine
{
    [SerializeField] private Player _player;
    [SerializeField] private List<PlayerState> _playerStates;
    private PlayerState _currentState;

    private void Start()
    {
        foreach (var s in _playerStates)
        {
            s.Init(_player, this);
            s.OnStart();
        }
        GameManager.Instance.OnStartedGame.AddListener(Init);
    }

    public void Init()
    {
        SwitchState<PlayerMovingState>();
    }
    public void SwitchState<T>() where T : PlayerState
    {
        var state = _playerStates.FirstOrDefault(s => s is T);
        _currentState?.Exit();
        state?.Enter();
        _currentState = state;
    }
}
