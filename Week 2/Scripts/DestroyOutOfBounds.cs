using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float ceiling = 45;
    private float floor = -20;
    private float leftRight = 30;

    void Update()
    {
        // Bonus tutorial [Hard]
        // Condition: If player passed animals w/o shooting projectile.
        if(transform.position.z > ceiling)
        {
            Destroy(gameObject);
            GameManager.instance.CurrentLive(-1);
        } 
        else if(transform.position.z < floor)
        {
            Destroy(gameObject);
            GameManager.instance.CurrentLive(-1);
        }
        else if(transform.position.x > leftRight)
        {
            Destroy(gameObject);
            GameManager.instance.CurrentLive(-1);
        }
        else if(transform.position.x < -leftRight)
        {
            Destroy(gameObject);
            GameManager.instance.CurrentLive(-1);
        }
    }
}
