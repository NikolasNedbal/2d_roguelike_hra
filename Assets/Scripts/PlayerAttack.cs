using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : Attack
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackVoid();
        }   
    }

    protected new void AttackVoid()
    {
        hits = Physics2D.CircleCastAll(attackTr.position, attackRng, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable idamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (idamageable != null)
            {
                idamageable.Damage(damageAmount);
                StartCoroutine(idamageable.Bleed(bleedTime, bleedAmount));
            }
        }
    }
}
