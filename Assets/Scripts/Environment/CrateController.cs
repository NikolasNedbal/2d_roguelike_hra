using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CrateController : EnviromentHp
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();
    private Vector3 positionToSpawn;
    private int rand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            positionToSpawn = transform.position;
        }
        DeadSpawn();

        if (curHp <= 0)
        {
            FakeDeath();
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

    public GameObject healObj;
    private void DeadSpawn()
    {
        if(isDead)
        {
            rand = Random.Range(0, 2);
            Debug.Log("Random cislo = " + rand);
            if (rand == 1)
            {
                Debug.Log("SPAWNWPAASNWANS " + positionToSpawn.x + " " + transform.position.x);
                Instantiate(healObj, positionToSpawn, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
