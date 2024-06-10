using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected RaycastHit2D[] hits;

    [SerializeField] public Transform attackTr;
    [SerializeField] public Transform attackTrL;
    [SerializeField] protected float attackRng = 1.5f;
    [SerializeField] protected LayerMask attackableLayer;

    [SerializeField] protected float damageAmount = 1f;

    [SerializeField] protected float bleedTime = 3f;
    [SerializeField] protected float bleedAmount = 1f;

    protected void AttackVoid()
    {
        hits = Physics2D.CircleCastAll(attackTr.position, attackRng, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable idamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (idamageable != null)
            {
                idamageable.Damage(damageAmount);
            }
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTr.position, attackRng);
    }
}
