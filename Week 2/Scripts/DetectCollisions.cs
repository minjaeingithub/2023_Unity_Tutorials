using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Bonus tutorial [Hard]
    // 2. Score & Lives adjustment, called only when collided
    private void OnTriggerEnter(Collider other) {
        // Override 
        // That's why we didn't put this func() inside Start nor Update.
        if(other.CompareTag("Player")){
            GameManager.instance.CurrentLive(-1);
            Destroy(gameObject);
        }
        if(other.CompareTag("Animals")){
            // GameManager.instance.score++;
            // Bonus tutorial [Expert]
            other.GetComponent<SliderBar>().GiveFood(1);
            Destroy(gameObject);
        }
    }
}
