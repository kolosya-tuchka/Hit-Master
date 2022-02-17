using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void SetRunningState(bool isRunning)
    {
        _animator.SetBool("isRunning", isRunning);
    }
}
