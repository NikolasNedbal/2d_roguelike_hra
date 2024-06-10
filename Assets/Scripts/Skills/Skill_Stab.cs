using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Stab : BaseSkill
{
    protected RaycastHit2D[] hits;

    [SerializeField] public Transform attackTr;

    [SerializeField] protected float attackRng = 5f;
    [SerializeField] protected LayerMask attackableLayer;

    [SerializeField] protected float bleedTime = 2f;
    [SerializeField] protected float bleedAmount = 3f;

    public bool cd { get; private set; } = false;

    Vector2 size;

    public bool active { get; private set; } = false;

    private Animator anim;
    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("ona").GetComponent<Animator>();
        txt = GameObject.FindGameObjectWithTag("sktxt").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);
        attackableLayer = LayerMask.GetMask("Attackable");
        attackTr = GameObject.Find("AttackTr").transform;
        size = new Vector2(6f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(attackTr);
        if(Input.GetKey(KeyCode.Q) && !cd)
        {
            Stab();
            StartCoroutine(Delay(5f));
        }
    }

    private void Stab()
    {
        hits = Physics2D.BoxCastAll(attackTr.position, size, 0f, transform.right, 10f, attackableLayer);

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
        txt.text = "Stab";
        anim.SetTrigger("cdend");
        cd = false;
        yield return new WaitForSeconds(0.5f);
        txt.text = string.Empty;
    }
}
