using System;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected Player _player;
    protected IStateMachine _stateMachine;

    public void Init(Player player, IStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }
    public abstract void Enter();
    public virtual void OnStart(){}
    public abstract void Exit();
}
