using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerAnimations PlayerAnimator
    {
        get
        {
            return _playerAnimations;
        }
    }
    public InputManager inputManager
    {
        get
        {
            return _inputManager;
        }
    }
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private InputManager _inputManager;

    private void Start()
    {
        GameManager.Instance.OnStartedGame.AddListener(ActivatePlayer);
        GameManager.Instance.OnFinishedGame.AddListener(DisablePlayer);
    }

    private void ActivatePlayer()
    {
        _playerAnimations.enabled = true;
    }
    private void DisablePlayer()
    {
        _playerAnimations.enabled = false;
    }

}