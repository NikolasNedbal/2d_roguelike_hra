using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmaOrb : MonoBehaviour
{
    private Vector3 initialPlayerPosition;
    public float shootSpeed = 8f;
    public float followDuration = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        initialPlayerPosition = player.position;

        StartCoroutine(Sorri());
    }

    void Update()
    {
        ShootAtPlayer();
    }

    private IEnumerator Sorri() 
    {
        yield return new WaitForSeconds(followDuration);
        Destroy(gameObject);
    }

    void ShootAtPlayer()
    {
       
        if (initialPlayerPosition != null)
        {
            //Debug.Log("LLLLLLLLLLLLLLLLLLLLLLLLLLLl");
            Vector2 direction = (initialPlayerPosition - transform.position).normalized;
            //Vector2 force = direction * shootSpeed;

            rb.velocity = direction * shootSpeed;
        }
    }

    private IDamageable ida;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ida = collision.gameObject.GetComponent<IDamageable>();
            ida.Damage(5f);
            Destroy(gameObject);
        }
    }
}
