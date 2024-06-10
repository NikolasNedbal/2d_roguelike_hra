using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Vanish : BaseSkill
{
    private GameObject player;
    private Vector3 mousePos;
    private Vector3 mousePos2;
    private bool cooldown = false;

    private Animator anim;
    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("ona").GetComponent<Animator>();
        txt = GameObject.FindGameObjectWithTag("sktxt").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
    }

    void GetMousePos()
    {
        if (Input.GetKey(KeyCode.V))
        {
            mousePos = Input.mousePosition;
            mousePos2 = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos2.z = 0;
            Debug.Log(mousePos);
        }
        else if (Input.GetKey(KeyCode.C) && !cooldown)
        {
            player.transform.position = mousePos2;
            StartCoroutine(Delay(4f));
            txt.text = "Vanish";
            anim.SetTrigger("cdend");
            StartCoroutine(Delay(0.5f));
            txt.text = string.Empty;
        }
    }

    private IEnumerator Delay(float delayTime)
    {
        cooldown = true;
        yield return new WaitForSeconds(delayTime);
        cooldown = false;
    }
}
