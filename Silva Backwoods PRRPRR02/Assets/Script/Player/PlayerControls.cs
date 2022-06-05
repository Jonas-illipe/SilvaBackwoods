using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool interact;

    // Start is called before the first frame update
    void Start()
    {
        //Turns interact false from start.
        interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If player presses E turns interact true.
        if (Input.GetKey("e"))
        {
            interact = true;
            //Debug.Log("Interaction works");
        }
    }
}
