using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHp : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float maxHp = 5f;

    protected float curHp;
    protected bool isDead = false;
    public void Damage(float damageAmount)
    {
        curHp -= damageAmount;
    }

    public IEnumerator Bleed(float bleedTime, float bleedAmount)
    {
        Debug.Log("Objekty nekrvácí");
        yield return new WaitForSeconds(0.5f);
    }

    protected void Die()
    {
        Destroy(gameObject);
    }

    protected void FakeDeath()
    {
        isDead = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }
    }
}
