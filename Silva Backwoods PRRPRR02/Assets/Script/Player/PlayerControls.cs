using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool interact;

    // Start is called before the first frame update
    void Start()
    {
        interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            interact = true;
            //Debug.Log("Interaction works");
        }
    }
}
