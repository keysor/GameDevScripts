using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public int p1Left;
    public int p2Left;
    public int p3Left;
    public Text p1Text;
    public Text p2Text;
    public Text p3Text;


    [Header("Dynamic")]
    public float shootForce = 10f;

    public GameObject startpos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && p1Left > 0)
        {
            Shoot1();
            p1Left -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && p2Left > 0 )
        {
            Shoot2();
            p2Left -= 1;
        }
        if (Input.GetKeyDown(KeyCode.F) && p3Left > 0)
        {
           Shoot3();
           p3Left -= 1;
        }
        p1Text.text = p1Left.ToString();
        p2Text.text = p2Left.ToString();
        p3Text.text = p3Left.ToString();
        if (p1Left == 0 && p2Left == 0 && p3Left == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
   
    void Shoot1()
    {
        Vector3 startingPosition = startpos.transform.position;
        GameObject newProjectile = Instantiate(p1, startingPosition, Quaternion.identity);
        Vector3 shootingDirection = transform.up;
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = shootingDirection * shootForce;
    }

    void Shoot2()
    {
        Vector3 startingPosition = startpos.transform.position;
        GameObject newProjectile = Instantiate(p2, startingPosition, Quaternion.identity);
        Vector3 shootingDirection = transform.up;
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = shootingDirection * shootForce;
    }

    void Shoot3()
    {
        Vector3 startingPosition = startpos.transform.position;
        GameObject newProjectile = Instantiate(p3, startingPosition, Quaternion.identity);
        Vector3 shootingDirection = transform.up;
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = shootingDirection * shootForce;
    }


}
