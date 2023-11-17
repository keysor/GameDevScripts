using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Heroz : MonoBehaviour
{
    static public Heroz S;
    public float speed = 30;

    void Awake()
    {
       
            if (S == null)
            {
                S = this;
            }
            else
            {
                Debug.LogError("The singleton S of hero has already been set!");
            }
        
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed*Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        print(PlayerStat.Score);
        PlayerStat.Score++;
    }
}
