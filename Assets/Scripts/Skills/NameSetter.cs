using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class NameSetter : MonoBehaviour
{
    public int uos;
    public TextMeshProUGUI btnText;

    private SkillLearner sk;
    // Start is called before the first frame update
    void Start()
    {
        sk = GameObject.Find("ButtonA").GetComponent<SkillLearner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(uos == 0)
        {
            btnText.text = sk.skillName;
        }
        else 
        {
            btnText.text = sk.upgradeName;
        }
    }
}
