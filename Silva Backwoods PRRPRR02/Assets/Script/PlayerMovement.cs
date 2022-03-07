using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float checkPointRadius;

    private Rigidbody2D rb;

    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public LayerMask whatIsWall;
    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing;
    private float gravityStore;
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
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkPointRadius, whatIsGround) || Physics2D.OverlapCircle(wallGrabPoint.position, checkPointRadius, whatIsGround);

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
        canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, 2f, whatIsWall);

        isGrabbing = false;
        if(canGrab && !isGrounded)
        {
            Debug.Log("äpple");
            if ((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
            {
                isGrabbing = true;
                //https://www.youtube.com/watch?v=uNJanDrjMgU
            }
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

}
