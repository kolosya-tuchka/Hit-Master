using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public static InputManager Instance;
    [HideInInspector] public UnityEvent onTap;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && onTap != null)
        {
            onTap.Invoke();
        }
    }

    private void Awake()
    {
        OnAwake();
    }
    
    private void Start()
    {
        OnAwake();
        onTap.AddListener(GameManager.Instance.onStartedGame.Invoke);
    }

    private void OnAwake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
