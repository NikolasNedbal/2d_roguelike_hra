using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillLearner : MonoBehaviour
{
    private SkillManager skillManager;
    private int a, b = 0;
    public string skillName { get ; private set; }
    public string upgradeName {  get ; private set; }

    private int i;
    private int j;

    public bool chosen=false;
    // Start is called before the first frame update
    void Start(){
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        i = Random.Range(0, skillManager.allSkills.Count);
        j = Random.Range(0, skillManager.allUpgrade.Count);
    }
    // Update is called once per frame
    void Update(){
        if (gameObject.active == true){
            skillName = skillManager.allSkills[i].skillName;
            upgradeName = skillManager.allUpgrade[j].upgradeName;
        }
    }
    public void BTNlearnUpgrade(){
        if(chosen != true){
            skillManager.LearnUpgrade(skillManager.allUpgrade[j]);
            skillManager.player.AddComponent(skillManager.playerUpgrade[a].GetType());
            a++;
            chosen = true;
        }
    }
    public void BTNLearnSkill(){
        if (chosen != true){
            skillManager.LearnSkill(skillManager.allSkills[i]);
            skillManager.player.AddComponent(skillManager.playerSkills[b].GetType());
            b++;
            chosen = true;
        }
    }
    public void BTNReroll(){
        i = Random.Range(0, skillManager.allSkills.Count);
        j = Random.Range(0, skillManager.allUpgrade.Count);
    }
}
