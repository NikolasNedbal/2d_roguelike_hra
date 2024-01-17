using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : EnviromentHp
{
    private bool untilAttacked = false;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }

        if (curHp != maxHp && untilAttacked == false)
        {
            ps.Stop();   
            anim.SetBool("isAttacked", true);
            untilAttacked = true;
        }
    }
}
