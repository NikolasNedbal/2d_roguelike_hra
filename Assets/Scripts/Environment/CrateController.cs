using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : EnviromentHp
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }

        switch (curHp)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = sprites[3]; 
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            default:
                break;
        }
    }
}
