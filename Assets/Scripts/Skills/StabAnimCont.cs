using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabAnimCont : MonoBehaviour
{
    private Animator anim;

    private Skill_Stab ss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null)
        {
            //Debug.Log("DEBILEK1");
            anim = gameObject.GetComponent<Animator>();
        }

        if (ss == null)
        {
            ss = GameObject.FindGameObjectWithTag("Player").GetComponent<Skill_Stab>();
        }

        if(anim != null && ss != null && !ss.cd && Input.GetKey(KeyCode.Q))
        {
            //Debug.Log("DEBILEK2");
            StartCoroutine(HIGIHAGA());
        }
    }

    private IEnumerator HIGIHAGA()
    {
        anim.SetBool("stabing", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("stabing", false);
        //Debug.Log("DEBILEK3");
    }
    
}
