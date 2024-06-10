using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOrb : MonoBehaviour
{
    private Transform player;
    public float followSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPlayer();

    }

    void FollowPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * followSpeed * Time.deltaTime);
        }
    }

    private IDamageable ida;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ida = collision.gameObject.GetComponent<IDamageable>();
            ida.Damage(5f);
            Destroy(gameObject);
        }
    }
}
