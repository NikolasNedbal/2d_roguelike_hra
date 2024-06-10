using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyHp : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float maxHp = 5f;

    public float curHp;

    [SerializeField]
    private int moneyDrop = 5;

    public bool wantentodie = true;

    public void Damage(float damageAmount)
    {
        curHp -= damageAmount;
    }

    public IEnumerator Bleed(float bleedTime, float bleedAmount)
    {
        for (float i = 0; i < bleedTime; i++)
        {

            yield return new WaitForSeconds(0.5f);
            curHp -= bleedAmount;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Die()
    {
        Wallet wallet = GameObject.Find("Wallet(Clone)").GetComponent<Wallet>();
        wallet.AddMoney(moneyDrop);
        if(wantentodie){
            gameObject.SetActive(false);
        }
        //Destroy(gameObject);
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
            Die();
        }
    }
}
