using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        if (Mathf.Abs(-(90 - angle)) < 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, -(90 - angle));
        }
    }
}
