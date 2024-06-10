using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private PlayerHp php;
    // Start is called before the first frame update
    void Start()
    {
        php = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RtrnBtn()
    {
        php.curHp = 0;
    }
}
