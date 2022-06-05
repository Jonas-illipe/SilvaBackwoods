using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    /*
    public int appleAmount;
    public int maxAppleAmount;
    public int stickAmount;
    public int maxStickAmount;*/

    //Creates a new dictionary with string keys and int values.
    private Dictionary<string, int> playerInventory = new Dictionary<string, int>();
    public Text inventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //Turns the amount on screen to zero.
        /*
        appleAmount = 0;
        textApples.text = appleAmount.ToString() + " Apples";

        stickAmount = 0;
        textSticks.text = stickAmount.ToString() + " Sticks";
        */


        //Adds Apples and Sticks to dictionary.
        playerInventory.Add("Apple", 0);
        playerInventory.Add("Stick", 0);

        //Calls method.
        DisplayInventory();
    
    }


    // Update is called once per frame 
    /*void Update()
    {
        //If the carried amount exceeds the max amount turn the carried amount to max. 
        if (appleAmount > maxAppleAmount)
        {
            appleAmount = maxAppleAmount;
        }

        if (stickAmount > maxStickAmount)
        {
            stickAmount = maxStickAmount;
        }

        //Changes the amount carried number on screen
        textApples.text = appleAmount.ToString() + " Apples";

        textSticks.text = stickAmount.ToString() + " Sticks";
    }*/

    //Method that display the current dictionary;
    public void DisplayInventory()
    {
        inventoryDisplay.text = "";
        //Writes the items from the dictionary. "\n" moves text down a row.
        foreach (var item in playerInventory)
        {
            inventoryDisplay.text += item.Key + " " + item.Value + "\n";
        }
    }

    public void AddApple()
    {
        //Adds a apple to the dictionary then calls Display method.
        if (playerInventory.ContainsKey("Apple"))
        {
            playerInventory["Apple"]++;
        }
        else
        {
            playerInventory.Add("Apple", 1);
        }

        DisplayInventory();
    }


    public void RemoveApple()
    {
        //Removes a apple from the dictionary then calls Dipslay method.
        if (playerInventory.ContainsKey("Apple"))
        {
            playerInventory["Apple"]--;
        }
        if(playerInventory["Apple"] <= 0)
        {
            playerInventory.Remove("Apple");
        }

        DisplayInventory();
    }


    public void AddStick()
    {
        //Adds a stick to the dictionary then calls Display method.
        if (playerInventory.ContainsKey("Stick"))
        {
            playerInventory["Stick"]++;
        }
        else
        {
            playerInventory.Add("Stick", 1);
        }

        DisplayInventory();
    }

    public void RemoveStick()
    {
        //Removes a stick from the dictionary then calls Dipslay method.
        if (playerInventory.ContainsKey("Stick"))
        {
            playerInventory["Stick"]--;
        }
        if (playerInventory["Stick"] <= 0)
        {
            playerInventory.Remove("Stick");
        }

        DisplayInventory();
    }
}
