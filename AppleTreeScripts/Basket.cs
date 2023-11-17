using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");         // b
         // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();            // c
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
     Vector3 mousePos2D = Input.mousePosition;                             // a

         // The Camera’s z position sets how far to push the mouse into 3D
         // If this line causes a NullReferenceException, select the Main Camera
         //  in the Hierarchy and set its tag to MainCamera in the Inspector.
    mousePos2D.z = -Camera.main.transform.position.z;                     // b

         // Convert the point from 2D screen space into 3D game world space
    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);    // c

         // Move the x position of this Basket to the x position of the Mouse
    Vector3 pos = this.transform.position;
    pos.x = mousePos3D.x;
    this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {                             // a
         // Find out what hit this basket
    GameObject collidedWith = coll.gameObject;                        // b
         if (collidedWith.CompareTag("Apple"))
        {                         // c
    Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
         else if (collidedWith.CompareTag("GApple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 500;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
         else if (collidedWith.CompareTag("PApple"))
        {
            Destroy(collidedWith);
            scoreCounter.score -= 500;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        }
     }
}
