using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectile : MonoBehaviour
{
    private float destroyTime = 3f;

    [SerializeField] private float damageAmount = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null && !collision.CompareTag("Player"))
        {
            damageable.Damage(damageAmount);
            Debug.Log("hit");
        }
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
