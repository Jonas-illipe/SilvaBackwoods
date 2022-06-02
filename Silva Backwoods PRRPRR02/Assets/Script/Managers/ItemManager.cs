using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text textApples;
    public int appleAmount;
    public int maxAppleAmount;

    public Text textSticks;
    public int stickAmount;
    public int maxStickAmount;

    // Start is called before the first frame update
    void Start()
    {
        appleAmount = 0;
        textApples.text = appleAmount.ToString() + " Apples";

        stickAmount = 0;
        textSticks.text = stickAmount.ToString() + " Sticks";
    }

    // Update is called once per frame
    void Update()
    {
        if (appleAmount > maxAppleAmount)
        {
            appleAmount = maxAppleAmount;
        }

        if (stickAmount > maxStickAmount)
        {
            stickAmount = maxStickAmount;
        }

        textApples.text = appleAmount.ToString() + " Apples";

        textSticks.text = stickAmount.ToString() + " Sticks";
    }
}
