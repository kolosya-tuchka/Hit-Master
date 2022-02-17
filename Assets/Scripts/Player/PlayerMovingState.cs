using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovingState : PlayerState
{
    [SerializeField] private float _stoppingDistance = 0.5f;
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _turnSpeed;

    private IEnumerator Move()
    {
        GameManager gm = GameManager.Instance;
        Stage stage = gm.Stages[gm.CurStage];
        _navAgent.SetDestination(stage.Waypoint.position);

        yield return new WaitUntil(() => Vector3.Distance(stage.Waypoint.position, _player.transform.position) < _stoppingDistance);
        StartCoroutine(SmoothRotation(stage.Waypoint));
        
        _stateMachine.SwitchState<PlayerShootingState>();
    }

    private void MoveToNextWaypoint()
    {
        StartCoroutine(Move());
    }

    private IEnumerator SmoothRotation(Transform target)
    {
        Vector3 direction = (target.position + 5 * target.forward - _player.transform.position).normalized;
        Quaternion rotTarget = Quaternion.LookRotation(direction);

        while (Mathf.Abs((target.eulerAngles - _player.transform.eulerAngles).y) > 0.2f)
        {
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, rotTarget, _turnSpeed);
            yield return null;
        }

        _player.transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
    }

    public override void OnStart()
    {
        base.OnStart();
        _navAgent.speed = _movementSpeed;
    }

    public override void Enter()
    {
        StartMoving();
        MoveToNextWaypoint();
    }

    public override void Exit()
    {
        StopMoving();
    }

    private void StartMoving()
    {
        _navAgent.enabled = true;
        _player.PlayerAnimator.SetRunningState(true);
    }

    private void StopMoving()
    {
        _navAgent.enabled = false;
        _player.PlayerAnimator.SetRunningState(false);
    }
}
