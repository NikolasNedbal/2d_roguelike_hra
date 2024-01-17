using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMovement : PlayerMovement
{
    //protected new float dashingPower = 15f;

    [SerializeField] private float Radius;
    [SerializeField] GameObject BashAbleObj;
    private bool NearToBashAbleObj;
    private bool IsChosingDir;
    private bool IsBashing;
    [SerializeField] private float BashPower;
    [SerializeField] private float BashTime;
    [SerializeField] private GameObject Arrow;
    Vector3 BashDir;
    private float BashTimeReset;

    // Start is called before the first frame update
    void Start()
    {
        BashTimeReset = BashTime;

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isDashing)
        {
            return;
        }

        //Attack();
        RunAndJump();
        Bash();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    protected new void RunAndJump()
    {
        
        moveSpeed = Input.GetAxisRaw("Horizontal") * speed;
        /*if (IsBashing == false)
        {
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow) && airborne == false)
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
            if (IsBashing == false)
            {
                Vector2 movement = new Vector2(moveSpeed, rb.velocity.y);
                rb.velocity = movement;
            }
        }

        IsGrounded();
        anim.SetFloat("Speed", Mathf.Abs(moveSpeed));

        //animace
        /*
        if (airborne)
        {
            JumpAnimation();
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(moveSpeed));
        }*/
        

        //flipovani spritu pri pohybu
        if (moveSpeed < 0)
        {
            spRen.flipX = true;
        }
        else if (moveSpeed > 0)
        {
            spRen.flipX = false;
        }
    }

    protected new void IsGrounded()
    {
        isGrounded = Physics2D.CircleCast(player.position, 1.7f, Vector2.down, 0.01f, groundLayer);

        if (isGrounded)
        {
            if (doubleJump)
            {
                doubleJump = false;
                airborne = false;
            }
            else
            {
                airborne = false;
            }
            //anim.SetBool("Falling", false);
        }
    }

    void Bash()
    {
        RaycastHit2D[] Rays = Physics2D.CircleCastAll(transform.position, Radius, Vector3.forward);
        foreach (RaycastHit2D ray in Rays)
        {

            NearToBashAbleObj = false;

            if (ray.collider.tag == "BashAble")
            {
                NearToBashAbleObj = true;
                BashAbleObj = ray.collider.transform.gameObject;
                break;
            }
        }
        if (NearToBashAbleObj)
        {
            BashAbleObj.GetComponent<SpriteRenderer>().color = Color.yellow;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Time.timeScale = 0;
                BashAbleObj.transform.localScale = new Vector2(1.4f, 1.4f);
                Arrow.SetActive(true);
                Arrow.transform.position = BashAbleObj.transform.transform.position;
                IsChosingDir = true;
            }
            else if (IsChosingDir && Input.GetKeyUp(KeyCode.Mouse1))
            {
                Time.timeScale = 1f;
                BashAbleObj.transform.localScale = new Vector2(1, 1);
                IsChosingDir = false;
                IsBashing = true;
                rb.velocity = Vector2.zero;
                transform.position = BashAbleObj.transform.position;
                BashDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                BashDir.z = 0;
                /*if (BashDir.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }*/
                BashDir = BashDir.normalized;
                BashAbleObj.GetComponent<Rigidbody2D>().AddForce(-BashDir * 50, ForceMode2D.Impulse);
                Arrow.SetActive(false);

            }
        }
        else if (BashAbleObj != null)
        {
            BashAbleObj.GetComponent<SpriteRenderer>().color = Color.white;
        }

        //Preform the bash
        if (IsBashing)
        {
            if (BashTime > 0)
            {
                BashTime -= Time.deltaTime;
                rb.velocity = BashDir * BashPower * Time.deltaTime;
            }
            else
            {
                IsBashing = false;
                BashTime = BashTimeReset;
                rb.velocity = new Vector2(rb.velocity.x, 0);


            }
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.65f);
    }*/
}
