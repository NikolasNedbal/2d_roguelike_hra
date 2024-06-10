using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainChance : MonoBehaviour
{
    public int chance;
    private int rand;
    private void Awake()
    {
        gameObject.SetActive(false);
        rand = Random.Range(0, chance);
        Debug.Log("YYYYYYYYYYY"+rand);
        if(rand == 1)
        {
            gameObject.SetActive(true);
        }       
    }
}
