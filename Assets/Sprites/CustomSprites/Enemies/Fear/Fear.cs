using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour
{
    private Animator a;
    private Enemy e;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        e = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        a.SetBool("isMoving", e.isMoving);
    }
}
