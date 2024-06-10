using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetPortal;
    private bool isPlayerInPortal = false;
    private GameObject player;
    private bool found = false;

    void Update()
    {
        if(gameObject.tag == "PortalB" && !found)
        {
            targetPortal = GameObject.FindGameObjectWithTag("PortalR").GetComponent<Transform>();
            found = true;
        }
        else if(gameObject.tag == "PortalR" && !found)
        {
            targetPortal = GameObject.FindGameObjectWithTag("PortalB").GetComponent<Transform>();
            found = true;
        }


        if (isPlayerInPortal && Input.GetKeyDown(KeyCode.F))
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (player != null && targetPortal != null)
        {
            player.transform.position = targetPortal.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInPortal = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInPortal = false;
            player = null;
        }
    }
}
