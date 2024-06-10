using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int moneyAmount;

    public bool yuh;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        moneyAmount += amount;
    }

    public void RemoveMoney(int amount)
    {
        yuh = false;   
        if((moneyAmount - amount) >= 0)
        {
            moneyAmount -= amount;
            yuh = true;
        } else
        {
            Debug.Log("ne.");
        }
        
    }
}
