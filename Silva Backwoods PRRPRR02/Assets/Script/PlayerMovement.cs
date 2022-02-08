using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    private float dirx;
    private float diry;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        diry = Input.GetAxisRaw("Space");


        if (Input.GetKey("Space"))
        {
            
        }

    }

    private void FixedUpdate()
    {
        Vector2 xmovement = new Vector2(dirx * moveSpeed, rb.velocity.y);

        rb.velocity = xmovement;

        Vector2 ymovement = new Vector2(rb.velocity.x, diry * moveSpeed);

        rb.velocity = ymovement;

        
    }

}
