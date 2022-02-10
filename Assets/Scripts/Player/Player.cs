using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float movementSpeed
    {
        get
        {
            return _movementSpeed;
        }
        private set
        {
            _movementSpeed = value;
        }
    }
    public float turnSpeed
    {
        get
        {
            return _turnSpeed;
        }
        private set
        {
            _turnSpeed = value;
        }
    }

    public NavMeshAgent navAgent
    {
        get
        {
            return _navAgent;
        }
    }

    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private PlayerNavigation playerNavigation;
    [SerializeField] private PlayerAnimations playerAnimations;

    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _turnSpeed;

    private void Start()
    {
        GameManager.Instance.onStartedGame.AddListener(ActivatePlayer);
        GameManager.Instance.onFinishedGame.AddListener(DisablePlayer);
    }

    private void ActivatePlayer()
    {
        playerShooting.enabled = true;
        playerNavigation.enabled = true;
        navAgent.enabled = true;
        playerAnimations.enabled = true;
    }
    private void DisablePlayer()
    {
        playerShooting.enabled = false;
        playerNavigation.enabled = false;
        navAgent.enabled = false;
        playerAnimations.enabled = false;
    }

}