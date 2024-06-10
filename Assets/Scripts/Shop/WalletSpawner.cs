using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wallet;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Wallet(Clone)") == null)
        {
            Instantiate(wallet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
