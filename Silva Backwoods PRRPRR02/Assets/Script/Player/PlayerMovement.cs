using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce;
    public float moveSpeed;

    [Header("Player")]
    private Rigidbody2D rb;

    [Header("Trackers")]
    public Transform groundCheckPoint;
    public float groundPointRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public LayerMask whatIsWall;
    public Transform wallGrabPoint;

    [Header("Grab")]
    public float grabRange;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    public float timeBetweenGrab;
    private float timeBetweenGrabCount;

    //public SpriteRenderer playerSR;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
    }


    private void Update()
    {
        //Move horizontally
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        //Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundPointRadius, whatIsGround);

        //Jump upwards
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && isGrabbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            timeBetweenGrabCount = timeBetweenGrab;
        }

        //Flip the player
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //playerSR.flipX = false;
            
            Vector3 scaler = transform.localScale;
            scaler.x = -1f;
            transform.localScale = scaler;
            
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //playerSR.flipX = true;
           
            Vector3 scaler = transform.localScale;
            scaler.x = 1f;
            transform.localScale = scaler;
           
        }

        //handle wall jumping
        canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, grabRange, whatIsWall);

        isGrabbing = false;
        if (timeBetweenGrabCount <= 0)
        {
            if (canGrab && !isGrounded)
            {
                if ((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
                {
                    isGrabbing = true;
                }
            }
        }
        else
        {
            timeBetweenGrabCount -= Time.deltaTime;
        }

        if (isGrabbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.gravityScale = gravityStore;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Draws red outlines for the OverlapCircles.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wallGrabPoint.position, grabRange);
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundPointRadius);
    }

}
