using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnable : MonoBehaviour
{
    [SerializeField]
    private Canvas Canvas1;
    [SerializeField]
    private Canvas Canvas2;

    public void EnableCanvas()
    {
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(true);
    }
}
