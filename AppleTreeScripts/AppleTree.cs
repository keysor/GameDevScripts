 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public Text levelText;
    int level = 1;
     [Header("Inscribed")]                                                  // a
     // Prefab for instantiating apples
     public GameObject applePrefab;
    public GameObject GApplePrefab;
    public GameObject PApplePrefab;
 
    // Speed at which the AppleTree moves
     public float speed = 1f;
 
     // Distance where AppleTree turns around
     public float leftAndRightEdge = 10f;
 
     // Chance that the AppleTree will change directions
     public float changeDirChance = 0.1f;
 
     // Seconds between Apples instantiations
     public float appleDropDelay = 1f;

    public int count;
    public int count2;
    

     void Start()
    {
        count = 0;
        count2 = 0;
        // Start dropping apples                                           // b
        Invoke("DropApple", 2f);
     }
       void DropApple()
    {
        //GameObject gApple = Instantiate<GameObject>(GApplePrefab);
        //GameObject pApple = Instantiate<GameObject>(PApplePrefab);
        if (count % 3 == 0)
        {
            GameObject PApple = Instantiate<GameObject>(PApplePrefab);
            PApple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
            count++;
        }
        else if (count % 10 == 0){
            GameObject GApple = Instantiate<GameObject>(GApplePrefab);
            GApple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
            count++;
        }
        else {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
            count++;
        }
    }
     void Update()
    {
        
         if (scoreCounter.score > 4000 && scoreCounter.score < 5000 && count2 == 3) // Golden apples made me add manual levels instead of (REFER TO A1) because it would end up on a number that wasnt %1000 = 0
        {
            level = 5;
            levelText.text = "Level: " + level;
            speed += .1f;
            count2++;
        }
        else if (scoreCounter.score < 4000 && scoreCounter.score > 3000 && count2 == 2)
        {
            level = 4;
            levelText.text = "Level: " + level;
            speed += .1f;
            count2++;
        }
        else if (scoreCounter.score < 3000 && scoreCounter.score > 2000 && count2 == 1)
        {
            level = 3;
            levelText.text = "Level: " + level;
            speed += .1f;
            count2++;
        }
        else if (scoreCounter.score < 2000 && scoreCounter.score > 1000 && count2 == 0)
        {
            level = 2;
            levelText.text = "Level: " + level;
            speed += .1f;
            count2++;
        }
        else if (scoreCounter.score % 1000 == 0 && scoreCounter.score != 0) // A1
        {
            level = 1 + scoreCounter.score / 1000;
            levelText.text = "Level: " + level;
            speed += .1f;
            count2++;
        }

        // Basic Movement                                                  // b
        Vector3 pos = transform.position;                        // b
        pos.x += speed * Time.deltaTime;                         // c
        transform.position = pos;                                // d
        // Changing Direction                                              // b
        if (pos.x < -leftAndRightEdge)
        {
         speed = Mathf.Abs(speed);   // Move right                   
         }
        else if (pos.x > leftAndRightEdge)
        {
         speed = -Mathf.Abs(speed);  // Move left                    
         }
        /*else if (Random.value < changeDirChance)
        {                         // a
         speed *= -1;  // Change direction                                  // b
        }*/
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance )
        {
            speed *= -1;
        }
    }
}