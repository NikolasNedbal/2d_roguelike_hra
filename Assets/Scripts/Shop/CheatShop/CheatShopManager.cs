using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatShopManager : MonoBehaviour
{
    bool cKeyPressed = false;
    bool fKeyPressed = false;
    bool bought = false;

    [SerializeField]
    private Canvas csCanvas;

    // Start is called before the first frame update
    void Start()
    {
        csCanvas = GetComponent<Canvas>();
        csCanvas.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            cKeyPressed = true;
        }
        else
        {
            cKeyPressed= false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            fKeyPressed = true;
        }
        else
        {
            fKeyPressed= false;
        }

        if (cKeyPressed && fKeyPressed && !bought)
        {
            csCanvas.enabled = true;
        }
    }

    public void HealButton()
    {
        csCanvas.enabled = false;
        PlayerHp player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();
        player.HealMax();
        bought = true;
    }

    public void UnlockButton()
    {
        csCanvas.enabled = false;
        SpawnRandomObjects[] spw = GameObject.Find("Level").GetComponents<SpawnRandomObjects>();
        spw[1].unlockos = true;
        bought = true;
    }
}
