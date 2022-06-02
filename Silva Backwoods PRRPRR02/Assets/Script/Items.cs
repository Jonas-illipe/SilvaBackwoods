using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private ItemManager itemManager;
    private PlayerControls playerControls;

    private void Start()
    {
        itemManager = GameObject.Find("HUD Canvas").GetComponent<ItemManager>();
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && playerControls.interact == true)
        {
            if(gameObject.tag == "Stick")
            {
                itemManager.stickAmount += 1;
                playerControls.interact = false;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Apple")
            {
                itemManager.appleAmount += 1;
                playerControls.interact = false;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
