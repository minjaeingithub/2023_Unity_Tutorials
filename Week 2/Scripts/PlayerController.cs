using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float xRange = 20f;
    public float zRange = 15f;

    public GameObject projectilePrefab;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "Player";
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space)){
            // Launch a projectile from the player script
            Instantiate(projectilePrefab, SpawnPoint.position, projectilePrefab.transform.rotation);
        }

        // ToDo: Make the player stay inside the game view(boundary)
        // 1. Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } 
        // Comment: Why did we not write code with using just "else"?
        // Answer: Because infinite loop is occured under {else} loop. Make an error to check it! (Boundary Value Analysis)
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        // Bonus tutorial [Easy] - 2. Vertical Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        } 
       
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        // ==================================================================================================================
    }
    
}
