using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : Attack
{
    protected Collider2D[] detectionRange;

    [SerializeField]
    protected Animator anim;

    private bool canAttack = true;

    void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        detectionRange = Physics2D.OverlapCircleAll(attackTr.position, attackRng);
        foreach (Collider2D collider in detectionRange)
        {
            if (collider.CompareTag("Player") && canAttack)
            {
                StartCoroutine(AttackCor());
            }
        }
    }

    private IEnumerator AttackCor()
    {
        canAttack = false;
        anim.SetBool("isAttacking", true);
        AttackVoid();
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }
}
