using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    private float smoothSpeed = 1f;

    private bool waited = false;

    private Scene curScene;

    private void Awake()
    {
        curScene = SceneManager.GetActiveScene();
    }

    void Start()
    {
        
    }
    void Update()
    {
        WaitUntilSceneChanges();
    }

    void LateUpdate()
    {
        if (waited)
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    void WaitUntilSceneChanges()
    {
        if (curScene.buildIndex != 0 && !waited)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            waited = true;
        }
    }
}
