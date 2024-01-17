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
    [SerializeField]
    private GameObject player2;

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
        SceneManager.LoadScene(sceneId);
        player.SetActive(true);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(player2);
        DontDestroyOnLoad(mainCamera);
    }
}
