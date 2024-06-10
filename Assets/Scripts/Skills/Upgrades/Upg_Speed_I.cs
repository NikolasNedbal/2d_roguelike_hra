using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upg_Speed_I : BaseUpgrade
{
    private PlayerMovement playermov;

    private float mult = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        playermov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playermov.speedMultiplier != mult)
        {
            SetMultiplier();
        }
    }

    private void SetMultiplier()
    {
        playermov.speedMultiplier = mult;
    }
}
