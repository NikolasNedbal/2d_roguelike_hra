using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThroughDoor : MonoBehaviour
{
    [SerializeField] private int sceneId;
    //[SerializeField] private static string ronin = "Ronin";
    //[SerializeField] private static string mage = "Mage";
    private GameObject player;
    private GameObject cam;

    private GameObject levelos;
    private List<SpawnRandomObjects> spr = new List<SpawnRandomObjects>();
    private bool unlocked;

    private Collider2D[] detection;
    [SerializeField]
    private Transform midPoint;
    [SerializeField]
    private float cRange;

    private Scene scene;

    private FadeLoader fade;

    private int wentThrough = 0;
    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeLoader>();
        scene = SceneManager.GetActiveScene();
        FindLevelManager();
        FindSceneId();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            ChangeScene(sceneId);
        }

        if (spr[1].unlockos == true)
        {
            unlocked = spr[1].unlockos;
        }
    }

    private void FindSceneId() 
    {
        sceneId = scene.buildIndex+1;
    }

    private void FindLevelManager()
    {
        levelos = GameObject.Find("Level");
        Debug.Log(levelos);
        SpawnRandomObjects[] array = levelos.GetComponents<SpawnRandomObjects>();

        spr.AddRange(array);
    }

    private void FindPlayer()
    {
        cam = GameObject.Find("Main Camera");
        detection = Physics2D.OverlapCircleAll(midPoint.position, cRange);
        foreach (Collider2D collider in detection)
        {
            if (collider.CompareTag("Player"))
            {
                player = collider.gameObject;
            }
        }
        /*player = GameObject.Find(ronin);
        if(player == null)
        {
            player = GameObject.Find(mage);
        }*/
    }

    private void ChangeScene(int sceneId)
    {
        if (wentThrough == 0)
        {
            FindPlayer();
        }
            
        if (player != null && unlocked == true)
        {
            fade.ArrestThisMan();
            fade.HeTalksInMath();
            SceneManager.LoadScene(sceneId);
            fade.transition.SetTrigger("LockOut");
            if (wentThrough == 0)
            {
                DontDestroyOnLoad(player);
                DontDestroyOnLoad(cam);
                wentThrough = 1;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(midPoint.position, cRange);
    }
}
