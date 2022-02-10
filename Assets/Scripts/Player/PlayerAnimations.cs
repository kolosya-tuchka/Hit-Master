using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;

    void Update()
    {
        animator.SetBool("isRunning", player.navAgent.velocity != Vector3.zero);
    }
}
