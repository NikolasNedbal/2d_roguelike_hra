using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estir : MonoBehaviour
{
    [SerializeField]
    private GameObject orb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        Instantiate(orb);
    }
}
