using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoSkillMan : MonoBehaviour
{
    public bool reset = false;

    public SkillManager skillManager;
    public Canvas skillMenuCanv;

    private void Awake()
    {
        skillMenuCanv = GameObject.FindGameObjectWithTag("SKC").GetComponent<Canvas>();
        DontDestroyOnLoad(skillMenuCanv);
        skillMenuCanv.enabled = false;
        skillManager = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (reset)
        {
            if(skillManager == null)
            {
                reset = false;
                UpdateSkillManager();
            }
        }
    }

    public void UpdateSkillManager()
    {
        skillMenuCanv = GameObject.FindGameObjectWithTag("SKC").GetComponent<Canvas>();
        skillManager = GameObject.FindGameObjectWithTag("SkillManager").GetComponent<SkillManager>();
    }
}
