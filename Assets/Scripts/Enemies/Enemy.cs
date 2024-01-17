using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target = null;

    NavMeshAgent agent;

    Collider2D[] detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        FlipIfNeeded();
    }

    void FollowPlayer()
    {
        detectionRange = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (Collider2D collider in detectionRange)
        {
            if (collider.CompareTag("Player"))
            {
                target = collider.attachedRigidbody.transform;
                agent.SetDestination(target.position);
            }
        }
    }

    void FlipIfNeeded()
    {
        if(target != null)
        {
            if (target.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
