using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultiplier;

    [SerializeField]
    public float speed;
    protected float moveSpeed = 0f;
    public Rigidbody2D rb;

    [SerializeField]
    protected Transform groundChecker;

    [SerializeField]
    protected Animator anim;

    protected SpriteRenderer spRen;

    [SerializeField]
    protected int jumpForce;

    public LayerMask groundLayer;

    protected bool isGrounded;

    [SerializeField]
    protected Transform player;

    protected bool airborne = false;
    protected bool doubleJump = false;

    /*protected bool canDash = true;
    protected bool isDashing;
    protected float dashingPower = 10f;
    protected float dashingTime = 0.2f;
    protected float dashingCooldown = 1f;*/

    [SerializeField]
    public TrailRenderer tr;

    protected bool isFalling = false;
    protected bool isAirborne = false;

    protected float previousYPosition;

    protected float attackCD = 0.4f;
    protected bool canAttack = true;

    private bool isLookingLeft = false;
    private bool isLookingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = 1;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();

        previousYPosition = player.position.y;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MULTIPLIER: " + speedMultiplier);
        if (Input.GetKey(KeyCode.B))
        {
            SceneManager.LoadScene(0);
        }

        Attack();
        RunAndJump();
        Debug.Log(rb.gravityScale);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coll"))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contacts);

            bool playerOnTop = false;
            foreach (ContactPoint2D contact in contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    playerOnTop = true;
                    break;
                }
            }

            if (!playerOnTop)
            {
                float wallSlideSpeed = -speed * 1f;
                rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameObject.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    protected void Attack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(AttackAnimation());
        }
    }

    protected private IEnumerator AttackAnimation()
    {
        canAttack = false;
        anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }

    protected void RunAndJump() {

        moveSpeed = Input.GetAxisRaw("Horizontal") * speed * speedMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && airborne == false)
        {
            if (doubleJump == false)
            {
                Vector2 movement = new Vector2(moveSpeed, jumpForce);
                rb.velocity = movement;
                airborne = true;
                doubleJump = true;
            }
            else
            {
                Vector2 movement = new Vector2(moveSpeed, jumpForce);
                rb.velocity = movement;
                airborne = true;
            }
        }
        else
        {
            Vector2 movement = new Vector2(moveSpeed, rb.velocity.y);
            rb.velocity = movement;
        }
        IsGrounded();        

        //animace
        if (airborne)
        {
            JumpAnimation();
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(moveSpeed));
        }

        //flipovani spritu pri pohybu
        if (moveSpeed < 0)
        {
            if (isLookingRight && Input.GetKey(KeyCode.A))
            {
                isLookingRight = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                isLookingLeft = true;
            }
        }
        else if (moveSpeed > 0)
        {
            if (isLookingLeft && Input.GetKey(KeyCode.D))
            {
                isLookingLeft = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isLookingRight = true;
            }
        }
    }

    protected void JumpAnimation()
    {
        float currentYPosition = transform.position.y;
        if (currentYPosition < previousYPosition)
        {
            isFalling = true;
            isAirborne = false;
        }
        else if (currentYPosition > previousYPosition)
        {
            isFalling = false;
            isAirborne = true;
        }

        // Update animator bools
        anim.SetBool("Falling", isFalling);
        anim.SetBool("Airborne", isAirborne);

        // Update previous Y position for the next frame
        previousYPosition = currentYPosition;
    }

     protected void IsGrounded()
     {
        isGrounded = Physics2D.CircleCast(player.position, 1.4f, Vector2.down, 0.01f, groundLayer);

        if (isGrounded)
        {
            if (doubleJump)
            {
                doubleJump = false;
                airborne = false;
                //anim.SetBool("Falling", false);
            }
            else
            {
                airborne = false;
                //anim.SetBool("Falling", false);
            }
            anim.SetBool("Falling", false);
        }
    }
    /*private void OnDrawGizmos()
    {G
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.4f);
    }*/
}
