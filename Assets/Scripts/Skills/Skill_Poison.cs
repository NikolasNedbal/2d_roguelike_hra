using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Poison : BaseSkill
{
    protected RaycastHit2D[] hits;

    [SerializeField] public Transform player;

    [SerializeField] protected float attackRng = 5f;
    [SerializeField] protected LayerMask attackableLayer;

    [SerializeField] protected float bleedTime = 5f;
    [SerializeField] protected float bleedAmount = 0.5f;

    private bool cd = false;

    private Animator anim;
    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("ona").GetComponent<Animator>();
        txt = GameObject.FindGameObjectWithTag("sktxt").GetComponent<TextMeshProUGUI>();
        attackableLayer = LayerMask.GetMask("Attackable");
        DontDestroyOnLoad(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G) && !cd)
        {
            ApplyPoison();
            StartCoroutine(Delay(5f));
        }
    }

    private void ApplyPoison()
    {
        hits = Physics2D.CircleCastAll(player.position, attackRng, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable idamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (idamageable != null)
            {
                StartCoroutine(idamageable.Bleed(bleedTime, bleedAmount));
            }
        }
    }

    private IEnumerator Delay(float delayTime)
    {
        cd = true;
        yield return new WaitForSeconds(delayTime);
        txt.text = "Poison";
        anim.SetTrigger("cdend");
        cd = false;
        yield return new WaitForSeconds(0.5f);
        txt.text = string.Empty;
       
    }
}
