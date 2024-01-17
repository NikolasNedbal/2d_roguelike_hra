using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject ronin;

    [SerializeField]
    private GameObject mage;

    private Transform activePlayer;

    private float smoothSpeed = 1f;

    void Start()
    {
        
    }
    void Update()
    {
        CheckActivePlayer();
    }

    void LateUpdate()
    {
        if (activePlayer != null)
        {
            Vector3 desiredPosition = new Vector3(activePlayer.position.x, activePlayer.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    void CheckActivePlayer()
    {
        if(ronin.activeInHierarchy) 
        {
            activePlayer = ronin.transform;
        }
        else
        {
            activePlayer = mage.transform;
        }
        //activePlayer = ronin;
    }
}
