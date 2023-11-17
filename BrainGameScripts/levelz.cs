using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class levelz : MonoBehaviour
{
    public Text leveltext;
    public ScoreCounter scoreCounter;
    public int cratesLeft = 10;
    public int level = 1;
    public int cratesFailed = 0;
    public Text cratesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cratesLeft == 0)
        {
            level += 1;
            cratesLeft = 10;
        }
        if (cratesFailed == 3)
        {
            if (level > 0)
            {
                level -= 1;
                cratesFailed = 0;
            }
            cratesFailed = 0;
        }
        cratesText.text = ("Crates left: " + cratesLeft + " Crates Missed: " + cratesFailed);
        leveltext.text = "Level: " + level;

    }
}
