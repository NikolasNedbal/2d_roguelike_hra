using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    private EnemyHp ehp;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ehp.wantentodie = false;
        ehp = GetComponent<EnemyHp>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ehp.curHp == 0)
        {
            ani.SetTrigger("Death");
            gameObject.SetActive(false);
        }
    }
}
