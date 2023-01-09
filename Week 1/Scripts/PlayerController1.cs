using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
      horizontalInput = Input.GetAxis("Horizontal1");
      forwardInput = Input.GetAxis("Vertical1");
      // Move forward
      transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
      // Turn 
      transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
