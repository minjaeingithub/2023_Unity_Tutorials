using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDrive : MonoBehaviour
{
    Vector3 position;

    void Start(){
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.z -= 1 * Time.deltaTime;
        transform.position = position;
    }
}
