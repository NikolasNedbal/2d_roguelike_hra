using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    
    public UnityEngine.UI.Image speakerImg;
    public Sprite speakerSprite;

    [SerializeField] public float dt;

    public string[] holyTexts;
    private float textSpd = 0.1f;

    private int index;
    private bool lineFinished = false;

    private bool started = false;
    private bool pridano;
    private bool konecDialogu = false;

    private Canvas upgMenu;

    private bool yumeko = false;
    // Start is called before the first frame update
    void Start()
    {
        speakerImg.sprite = speakerSprite;
        textComp.text = string.Empty;
        gameObject.GetComponent<Canvas>().enabled = false;
        upgMenu = GameObject.Find("SkillMenuCanvas").GetComponent<Canvas>();
        StartCoroutine(Jabami());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("INDEX: " + index);

        if (upgMenu.enabled == false && yumeko == true && !konecDialogu)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
            if (!started)
            {
                StartDialogue();
            }
            if (lineFinished) 
            {
                DalsiPlski();
            }
        }
    }

    public void SkipDialogue()
    {
        konecDialogu = true;
        gameObject.GetComponent<Canvas>().enabled = false;  
    }

    private void StartDialogue()
    { 
        index = 0;
        StartCoroutine(Spisovatel());
        started = true;
    }

    private void DalsiPlski()
    {
        if (index < holyTexts.Length - 1)
        {
            index++;
            textComp.text = "";
            StartCoroutine(Spisovatel());
        }
        else 
        {
            konecDialogu = true;
            Debug.Log("AHDIUFHSIUEGHIWURHGUIWSGHUIWRHIUWHI");
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }

    private IEnumerator Spisovatel()
    {
        lineFinished = false;
        for (int i = 0; i < holyTexts[index].ToCharArray().Length; i++)
        {
            pridano = false;
            if (!pridano)
            {
                textComp.text += holyTexts[index].ToCharArray()[i];
                yield return new WaitForSeconds(textSpd);
            }
            pridano = true;
            //yield return new WaitForSeconds(textSpd);
        }
        lineFinished = true;
        textComp.text = string.Empty;
    }

    private IEnumerator Jabami()
    {
        yield return new WaitForSeconds(1f);
        yumeko = true;
    }

}
