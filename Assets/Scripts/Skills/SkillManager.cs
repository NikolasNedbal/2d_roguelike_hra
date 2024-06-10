using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.CompilerServices;
using TMPro;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    public List<BaseSkill> allSkills = new List<BaseSkill>();
    public List<BaseUpgrade> allUpgrade = new List<BaseUpgrade>();
    public List<BaseSkill> playerSkills = new List<BaseSkill>();
    public List<BaseUpgrade> playerUpgrade = new List<BaseUpgrade>();

    public GameObject player;
    //private GameObject dash;

    public GameObject SkillInv;

    private GameObject[] skillArray;
    private GameObject[] roninSkillArray;
    private GameObject[] mageSkillArray;

    private GameObject[] upgradeArray;

    List<MonoBehaviour> allObjectsScripts = new List<MonoBehaviour>();

    bool filled = false;
    public bool waited { get; private set; } = false;

    private bool isRonin = false;
    private bool isMage = false;

    private int pocetZmacknutiTlacitkaI = 0;
    public TextMeshProUGUI t;
    public TextMeshProUGUI t2;
    private bool takze = false;

    Scene curScene;

    [SerializeField]
    Canvas skillMenuCanvas;

    private SkillLearner skillLearner;
    private bool endChoosing = false;

    private MoSkillMan mosm;

    public GameObject portalB;
    public GameObject portalR;

    private void Awake()
    {
        curScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        mosm = GameObject.Find("m").GetComponent<MoSkillMan>();
        SceneManager.sceneLoaded += mosm.skillManager.OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        curScene = scene;
        Debug.Log("Scene loaded: " + scene.name);
        endChoosing = true;
        if(allSkills.Count>0 && curScene.buildIndex != 0)
        {
            mosm.skillManager.StartCoroutine(ChoosingSkills());
        }
    }

    // Update is called once per frame
    void Update()
    {       
        mosm.skillManager.WaitUntilSceneChanges();
        mosm.skillManager.LoadSkillInv();
    }

    void LoadSkillInv()
    {
        if (Input.GetKeyDown(KeyCode.I) && !takze)
        {
            takze = true;
            pocetZmacknutiTlacitkaI++;
            if (pocetZmacknutiTlacitkaI % 2 != 0)
            {
                takze = false;
                SkillInv.SetActive(true);
                foreach (BaseSkill skill in playerSkills)
                {
                    t.text += $"{skill.name}\n";
                    t2.text += $"{skill.skillDescription}\n";
                }
            }
            else
            {
                takze = false;
                t.text = string.Empty;
                t2.text = string.Empty;
                SkillInv.SetActive(false);
            }
        }
    }

    void WaitUntilSceneChanges()
    {
        if (curScene.buildIndex != 0 && !waited)
        {
            mosm.skillManager.FindPLayer();
            mosm.skillManager.StartCoroutine(FillAllSkillsList());
            waited = true;
        }
    }

    void FindPLayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.name == "Ronin(Clone)")
        {
            isRonin = true;
        }
        else if(player.name == "Mage(Clone)")
        {
            isMage = true;
        }
    }

    private IEnumerator FillAllSkillsList()
    {
        if (!filled) {
            upgradeArray = GameObject.FindGameObjectsWithTag("Upgrade");

            skillArray = GameObject.FindGameObjectsWithTag("Skill");
            roninSkillArray = GameObject.FindGameObjectsWithTag("RoninSkill");
            mageSkillArray = GameObject.FindGameObjectsWithTag("MageSkill");

            foreach (GameObject upg in upgradeArray) {
                allObjectsScripts.Add(upg.GetComponent<MonoBehaviour>());
            }

            foreach (GameObject scr in skillArray) {
                allObjectsScripts.Add(scr.GetComponent<MonoBehaviour>());
            }

            if (isRonin) {
                foreach (GameObject scr in roninSkillArray) {
                    allObjectsScripts.Add(scr.GetComponent<MonoBehaviour>());
                }

                foreach (GameObject obj in mageSkillArray) {
                    obj.gameObject.SetActive(false);
                }
            }
            else if (isMage) {
                foreach (GameObject scr in mageSkillArray) {
                    allObjectsScripts.Add(scr.GetComponent<MonoBehaviour>());
                }

                foreach (GameObject obj in roninSkillArray) {
                    obj.gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.1f);
            foreach (MonoBehaviour obj in allObjectsScripts)
            {
                BaseSkill skill = obj.GetComponent<BaseSkill>();
                if (skill != null)
                {
                    allSkills.Add(skill);
                    obj.gameObject.SetActive(false);
                }
                BaseUpgrade upgrade = obj.GetComponent<BaseUpgrade>();
                if(upgrade != null)
                {
                    allUpgrade.Add(upgrade);
                    obj.gameObject.SetActive(false);
                }
            }
        }
        filled = true;
    }

    private void EndChoosing()
    {
        //skillLearner = GameObject.Find("ButtonA").GetComponent<SkillLearner>();
        if(skillLearner != null && skillLearner.chosen)
        {
            endChoosing = false;
            //Debug.Log("tady3");
            mosm.skillMenuCanv.enabled = false;
            Time.timeScale = 1;
        }
        else
        {
            //Debug.Log("tady4");
            endChoosing = true;
        }
    }
    private IEnumerator ChoosingSkills()
    {
        if (skillLearner == null)
        {
            skillLearner = GameObject.Find("ButtonA").GetComponent<SkillLearner>();
        }
        skillLearner.chosen = false;
        yield return new WaitForSeconds(0.3f);
        //skillMenuCanvas.enabled = true;
        //Time.timeScale = 0;
        //Debug.Log("tady1");
        while (endChoosing)
        {
            //Debug.Log("tady2");
            mosm.skillMenuCanv.enabled = true;
            Time.timeScale = 0.000001f;

            yield return null;

            EndChoosing();
        }
    }
    public void LearnSkill(BaseSkill skill)
    {
        playerSkills.Add(skill);
        allSkills.Remove(skill);
    }

    public void LearnUpgrade(BaseUpgrade upgrade)
    {
        playerUpgrade.Add(upgrade);
        allUpgrade.Remove(upgrade);
    }

    public void ByeBye()
    {
        Destroy(GameObject.Find("MainCamera"));
        Destroy(GameObject.Find("SkillMenuCanvas"));
        Destroy(GameObject.Find("PlayerUI"));
        Destroy(gameObject);
    }
}
