using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement : MonoBehaviour
{
    public float teleportInterval = 15f; // Time interval for teleportation
    private UnityEngine.AI.NavMeshAgent agent;
    private Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(TeleportRandomly());
        SetRandomTarget();
    }

    void Update()
    {
        // Check if the enemy has reached its destination
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomTarget();
        }
    }

    IEnumerator TeleportRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);
            TeleportToRandomPoint();
        }
    }

    void SetRandomTarget()
    {
        // Get a random point on the navmesh within a specified range
        Vector3 randomPoint = Random.insideUnitSphere * 10f;
        randomPoint += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas);
        targetPosition = hit.position;

        // Move towards the random target
        agent.SetDestination(targetPosition);
    }

    void TeleportToRandomPoint()
    {
        // Teleport the enemy to a random point on the navmesh
        Vector3 randomPoint = Random.insideUnitSphere * 10f;
        randomPoint += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas);
        transform.position = hit.position;
    }
}
