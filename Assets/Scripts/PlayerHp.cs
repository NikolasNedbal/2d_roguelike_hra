using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour, IDamageable
{
    [SerializeField]
    public float maxHp {get; private set;}

    public float curHp;

    private SkillManager smh;
    private Animator hita;

    public IEnumerator Bleed(float bleedTime, float bleedAmount)
    {
        for (float i = 0; i < bleedTime; i++)
        {

            yield return new WaitForSeconds(0.5f);
            hita.SetTrigger("hit");
            curHp -= bleedAmount;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Damage(float damageAmount)
    {
        hita.SetTrigger("hit");
        curHp -= damageAmount;
    }

    public void Heal(float healAmount)
    {
        curHp += healAmount;
    }

    public void HealMax()
    {
        curHp += maxHp;
    }

    public void Death()
    {
        smh = null;
        smh = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
        smh.ByeBye();
        SceneManager.LoadScene(0);
        GameObject.Find("m").GetComponent<MoSkillMan>().reset = true;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hita = GameObject.FindGameObjectWithTag("onHit").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp > 30)
        {
            curHp = maxHp;
        }

        Debug.Log(curHp);
        if (curHp <= 0)
        {
            Death();
            Debug.Log("Rip");
        }
    }
}
