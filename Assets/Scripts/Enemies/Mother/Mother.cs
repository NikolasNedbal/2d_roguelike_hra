using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public GameObject[] orbs;
    public Transform firePoint;
    public float shootInterval = 10f;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Attack", 0f, 10f);
    }

    void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            LaunchOrbs();
        }
    }

    void LaunchOrbs()
    {
        int randomIndex = Random.Range(0, orbs.Length);
        Instantiate(orbs[randomIndex], firePoint.position, Quaternion.identity);

        animator.SetInteger("A", randomIndex + 1);

        Invoke("FinishAttack", 1.5f);
    }

    void FinishAttack()
    {
        animator.SetInteger("A", 0);
        isAttacking = false;
    }
}
