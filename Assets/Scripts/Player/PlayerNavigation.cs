using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 0.5f;
    [SerializeField] private Player player;

    private void Start()
    {
        player.navAgent.speed = player.movementSpeed;
        MoveToTheNextWaypoint();
    }

    private IEnumerator Move()
    {
        GameManager gm = GameManager.Instance;
        Stage stage = gm.stages[gm.curStage];
        player.navAgent.isStopped = false;
        player.navAgent.SetDestination(stage.waypoint.position);

        yield return new WaitUntil(() => Vector3.Distance(stage.waypoint.position, transform.position) < stoppingDistance);
        StartCoroutine(SmoothRotation(stage.waypoint));
        player.navAgent.isStopped = true;
        stage.onStartedStage.Invoke();
        if (gm.curStage != gm.stagesCount - 1)
        {
            stage.onCompletedStage.AddListener(MoveToTheNextWaypoint);
        }
    }

    private void MoveToTheNextWaypoint()
    {
        StartCoroutine(Move());
    }

    private IEnumerator SmoothRotation(Transform target)
    {
        Vector3 direction = (target.position + 5 * target.forward - transform.position).normalized;
        Quaternion rotTarget = Quaternion.LookRotation(direction);

        while (Mathf.Abs((target.eulerAngles - transform.eulerAngles).y) > 0.2f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, player.turnSpeed);
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
    }
}
