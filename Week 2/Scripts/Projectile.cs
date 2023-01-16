using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float ceiling = 35;
    private float floor = -10;
    private float leftRight = 15;

    void Update()
    {
        if(transform.position.z > ceiling)
        {
            Destroy(gameObject);
        } 
        else if(transform.position.z < floor)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x > leftRight)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -leftRight)
        {
            Destroy(gameObject);
        }
    }
}
