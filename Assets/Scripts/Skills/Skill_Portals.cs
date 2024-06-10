using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_Portals : BaseSkill
{
    private GameObject portalB;
    private GameObject portalR;

    private bool off, off2 = false;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        portalB = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>().portalB;
        portalR = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>().portalR;
        DontDestroyOnLoad(this);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        off = false;
        off2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !off)
        {
            Instantiate(portalB, gameObject.transform.position, Quaternion.identity);
            off = true;
        }
        if (Input.GetKeyDown(KeyCode.P) && !off2)
        {
            Instantiate(portalR, gameObject.transform.position, Quaternion.identity);
            off2 = true;
        }
    }
}
