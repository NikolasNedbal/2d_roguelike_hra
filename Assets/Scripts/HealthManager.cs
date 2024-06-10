using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class HealthManager : MonoBehaviour
{
    public GameObject hpbar;
    public Image healthBar;
    [SerializeField]
    private float health;
    private float maxhealth;

    private bool isSet = false;
    private bool asd = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SkillManager").GetComponent<SkillManager>().waited == false && !isSet)
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Canvas>().enabled = true;
            isSet = true;
        }

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>().curHp;
        maxhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>().maxHp;
        healthBar.fillAmount = (health / maxhealth);
    }
}


