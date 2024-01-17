using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour, IDamageable
{

    [SerializeField]
    private float maxHp = 10f;

    private float curHp;

    public IEnumerator Bleed(float bleedTime, float bleedAmount)
    {
        for (float i = 0; i < bleedTime; i++)
        {

            yield return new WaitForSeconds(0.5f);
            curHp -= bleedAmount;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Damage(float damageAmount)
    {
        curHp -= damageAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            //Die();
            Debug.Log("Rip");
        }
    }
}
