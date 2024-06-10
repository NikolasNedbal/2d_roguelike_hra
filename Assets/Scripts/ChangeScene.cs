using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int sceneId;

    [SerializeField]
    private GameObject player;

    private GameObject activePlayer;

    [SerializeField]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToScene()
    {
        if(!player.activeInHierarchy)
        {
            StartCoroutine(load());
        }
        else
        {
            //SceneManager.LoadScene(sceneId);
        }
        
    }

    private IEnumerator load()
    {
        Instantiate(player);
        activePlayer = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(activePlayer);
        DontDestroyOnLoad(mainCamera);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneId);
    }
}
