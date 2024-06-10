using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{
    [SerializeField]
    private GameObject skill;

    private bool bought = false;

    private Wallet wallet = new Wallet();

    [SerializeField]
    private int price = 5;
    public void BuySkill()
    {
        if (!bought)
        {
            wallet = GameObject.Find("Wallet(Clone)").GetComponent<Wallet>();
            wallet.RemoveMoney(price);

            if (wallet.yuh == true)
            {
                Instantiate(skill);
                GameObject skillObj = GameObject.Find("Dash(Clone)");
                DontDestroyOnLoad(skillObj);
                bought = true;
            }
        }
    }
}
