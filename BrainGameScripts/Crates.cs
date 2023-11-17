using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crates : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public levelz levelz;
    public static float bottomY = 0f;
    public Text boxHPT;
    public int boxHP;
    [Header("Inscribed")]
    public float speed = .7f;

    
    

    void Awake()
    {
        GameObject scoreboard = GameObject.Find("Scoreboard");
        scoreCounter = scoreboard.GetComponent<ScoreCounter>();
        GameObject Levelz = GameObject.Find("level");
        levelz = Levelz.GetComponent<levelz>();
        if (levelz.level == 1) // random hp based on level
        {
            boxHP = Random.Range(3, 14);

        }
        if (levelz.level == 2)
        {
            boxHP = Random.Range(6, 28);
        }
        if (levelz.level == 3)
        {
            boxHP = Random.Range(9, 42);
        }
        if (levelz.level == 4)
        {
            boxHP = Random.Range(12, 56);
        }

    }

    public Vector3 pos // make move work.

    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }
    void Update()
    {
        Move();
        boxHPT.text = boxHP.ToString(); // constantly updates text to show accurate hp
        if (pos.y < -2f)
        {
            Destroy(this.gameObject);
            levelz.cratesFailed += 1;
            CurrentScore.TRY_SET_C_SCORE(scoreCounter.score);
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        

        if (boxHP <= 0) // if hp less than 0 delete and give/take points
        {
            if (boxHP == 0)
            {
                scoreCounter.score += 1;
                levelz.cratesLeft -= 1;
                Destroy(this.gameObject);
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
                CurrentScore.TRY_SET_C_SCORE(scoreCounter.score);
                
            }
            else
            {
                levelz.cratesFailed += 1;
                Destroy(this.gameObject);
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
                CurrentScore.TRY_SET_C_SCORE(scoreCounter.score);
            }
        }
        if (transform.position.y < bottomY)
        {
            levelz.cratesFailed += 1;
            Destroy(this.gameObject);
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            CurrentScore.TRY_SET_C_SCORE(scoreCounter.score);
        }

    }

    public virtual void Move() // move....
    { 
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll) //subtract hp based on bullet
    {                            
        GameObject collidedWith = coll.gameObject;                       
        if (collidedWith.CompareTag("pOne"))
        {                         
            boxHP = boxHP - 1;
            boxHPT.text = boxHP.ToString();
            Destroy(collidedWith);
        }
        else if (collidedWith.CompareTag("pTwo"))
        {
            boxHP = boxHP - 2;
            boxHPT.text = boxHP.ToString();
            Destroy(collidedWith);
        }
        else if (collidedWith.CompareTag("pThree"))
        {
            boxHP = boxHP - 3;
            boxHPT.text = boxHP.ToString();
            Destroy(collidedWith);

        }
    }

}
