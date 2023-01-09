using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public GameObject player;
    // private Vector3 offset = new Vector3(0, 8, -15);
    private Vector3 allocentric = new Vector3(-0.5f, 8f, -15f);
    private Vector3 egocentric = new Vector3(0f, 2f, 1f);
    public bool currentState;

    void Start(){
        currentState = true;
        transform.position = player.transform.position + allocentric;
    }

    void LateUpdate()
    {
        // 1. Camera will follow player. Recap why.
        // Answer: Camera's position is assigned as player's position in scene.
        // 2. By adding new 3 coordinates, we could change offset for every frame updates.
        // 3. What happens when using LateUpdate()?
        // transform.position = player.transform.position + offset;

        if(currentState)
        {
            transform.position = player.transform.position + allocentric;
        } 
        else
        {
            transform.position = player.transform.position + egocentric;
        }

        // Challenge : Camera Switching
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            currentState = !currentState;
        }
    }
}
