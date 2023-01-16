using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool pressedSpace;

    void Start(){
        pressedSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            pressedSpace = true;
        }

        if(pressedSpace){
            // Unique(?) code style in Unity, b/c of continuously incrementing # of frames
            pressedSpace = false;
            DogAfterDelay();
        }
    }

    void DogAfterDelay(){
        float delay = Random.Range(0, 2);
        // Debug.Log(delay);
        Invoke("MakeDog", delay);
    }

    void MakeDog(){
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
}
