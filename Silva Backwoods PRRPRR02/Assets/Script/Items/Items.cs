using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private ItemManager itemManager;
    private PlayerControls playerControls;

    private void Start()
    {
        //Gets components (scripts) from the games objects
        itemManager = GameObject.Find("HUD Canvas").GetComponent<ItemManager>();
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //If the colliding object has the tag player and player presses E.
        if(collision.tag == "Player" && playerControls.interact == true)
        {
            //If gameobject is stick or apples increase amount with 1 and turns interact false. After that destroys self.
            if(gameObject.tag == "Stick")
            {
                playerControls.interact = false;
                itemManager.AddStick();
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Apple")
            {
                playerControls.interact = false;
                itemManager.AddApple();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
