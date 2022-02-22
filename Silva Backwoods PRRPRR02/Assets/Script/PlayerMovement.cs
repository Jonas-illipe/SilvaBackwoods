using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float checkPointRadius;

    private Rigidbody2D rb;

    public Transform groundCheckPoint;//, wallGrabPoint;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public Animator anim;

    public Transform wallGrabPoint;
    private bool canGrab, isGrabing;
    //public SpriteRenderer playerSR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //Move horizontally
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        //Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkPointRadius, whatIsGround); //|| Physics2D.OverlapCircle(wallGrabPoint.position, checkPointRadius, whatIsGround);

        //Jump upwards
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Flip the player
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //playerSR.flipX = false;
            Vector3 scaler = transform.localScale;
            scaler.x = 1f;
            transform.localScale = scaler;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //playerSR.flipX = true;
            Vector3 scaler = transform.localScale;
            scaler.x = -1f;
            transform.localScale = scaler;
        }

        //handle wall jumping
        canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, 2f, whatIsGround);

        if(canGrab && !isGrounded)
        {/*
            if (transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0)
            {
                isGrabing = true;
                https://www.youtube.com/watch?v=uNJanDrjMgU
            }*/
        }
    }

}