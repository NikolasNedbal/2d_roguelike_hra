using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Hover : BaseSkill
{
    private Rigidbody2D rb;
    private GameObject player;
    private MageMovement mm;

    private float origGrav;
    private float countdown = 1.5f;
    private bool hoverIsReady = true;

    private float elapsedTime = 0f;

    private Vector2 origVelocity;

    private Animator anim;
    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("ona").GetComponent<Animator>();
        txt = GameObject.FindGameObjectWithTag("sktxt").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        mm = player.GetComponent<MageMovement>();
        origGrav = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T) && hoverIsReady)
        {
            StartCoroutine(Hover());
            Debug.Log("yessss");
        }
    }

    private IEnumerator Hover()
    {
        Debug.Log("111111");
        origVelocity = rb.velocity;
        //mm.enabled = false;
        hoverIsReady = false;

        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(1f);
        rb.velocity = origVelocity;
        //rb.gravityScale = origGrav;
        //mm.enabled = true;
        yield return new WaitForSeconds(1f);
        txt.text = "Hover";
        anim.SetTrigger("cdend");
        hoverIsReady = true;
        yield return new WaitForSeconds(0.5f);
        txt.text = string.Empty;
        
    }
}
