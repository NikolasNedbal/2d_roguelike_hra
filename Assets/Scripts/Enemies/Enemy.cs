using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform targetPlayer = null;
    Transform target = null;

    GameObject player;
    PlayerAttack pa;
    MageAttack ma;

    NavMeshAgent agent;

    public bool isMoving { get; private set; } = false;

    Collider2D[] detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        FlipIfNeeded();
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pa = player.GetComponent<PlayerAttack>();
        ma = player.GetComponent<MageAttack>();
    }

    void FollowPlayer()
    {
        detectionRange = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (Collider2D collider in detectionRange)
        {
            if (collider.CompareTag("Player"))
            {
                if (pa != null)
                {
                    target = pa.attackTrL;
                }
                else
                {
                    target = ma.AttackTrL;
                }
                targetPlayer = collider.attachedRigidbody.transform;
                agent.SetDestination(target.position);
            } 
        }
    }

    void FlipIfNeeded()
    {
        if(targetPlayer != null)
        {
            if (targetPlayer.transform.position.x > transform.position.x)
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
