using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;

    private Rigidbody2D rb;

    public Transform groundCheckPoint1, groundCheckPoint2;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public Animator anim;
    public SpriteRenderer playerSR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        //Move horizontally
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        //Check if player is on the ground
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint1.position, 1f, whatIsGround) || Physics2D.OverlapCircle(groundCheckPoint2.position, 1f, whatIsGround);

        //Jump upwards
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Flip the player
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSR.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSR.flipX = true;
        }
    }

}
