using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Dash : BaseSkill
{
    protected bool canDash = true;
    protected bool isDashing;
    protected float dashingPower = 10f;
    protected float dashingTime = 0.2f;
    protected float dashingCooldown = 1f;

    private GameObject player;
    private PlayerMovement pm;

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Transform pltr;

    private Animator anim;
    private TextMeshProUGUI txt;

    public void Use()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        pm.enabled = false;
        canDash = false;
        isDashing = true;
        float ogGravity = rb.gravityScale;
        rb.gravityScale = 0;
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(pltr.localScale.x * dashingPower, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-pltr.localScale.x * dashingPower, 0f);
        }

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = ogGravity;
        pm.enabled = true;
        isDashing = false;
        
        yield return new WaitForSeconds(dashingCooldown);
        txt.text = "Dash";
        anim.SetTrigger("cdend");
        canDash = true;
        yield return new WaitForSeconds(0.5f);
        txt.text = string.Empty;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        anim = GameObject.FindGameObjectWithTag("ona").GetComponent<Animator>();
        txt = GameObject.FindGameObjectWithTag("sktxt").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        tr = player.GetComponent<TrailRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
        pltr = player.GetComponent<Transform>();
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Use();
    }
}
