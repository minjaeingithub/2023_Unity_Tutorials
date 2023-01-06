using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 8, -15);

    void LateUpdate()
    {
        // 1. Camera will follow player. Recap why.
        // Answer: Camera's position is assigned as player's position in scene.
        // 2. By adding new 3 coordinates, we could change offset for every frame updates.
        // 3. What happens when using LateUpdate()?
        transform.position = player.transform.position + offset;
    }
}
