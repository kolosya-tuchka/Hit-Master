using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent onTap;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && onTap != null)
        {
            onTap.Invoke();
        }
    }

    private void Start()
    {
        onTap.AddListener(GameManager.Instance.OnStartedGame.Invoke);
    }
    
}
