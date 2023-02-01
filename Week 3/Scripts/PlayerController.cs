using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool hasPowerup = false;
    private float powerupStrength = 15f;
    public GameObject powerupIndicator;
    public float posX;
    public float posZ;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        KeepInBoundary();
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            // ForceMode.Impulse = Add an instant force impulse(=> immediate effect) to the rigidbody, using its mass.
            // Reference: https://docs.unity3d.com/kr/530/ScriptReference/ForceMode.html
            // Enemy knockbacks when collided
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    public void KeepInBoundary(){
        posX = transform.position.x;
        posZ = transform.position.z;

        if(posX >= 7){
            transform.position = new Vector3(0,-1,0);
        } 
        else if(posX <= -7){
            transform.position = new Vector3(0,-1,0);
        }
        else if(posZ >= 7){
            transform.position = new Vector3(0,-1,0);
        }
        else if(posZ <= -7){
            transform.position = new Vector3(0,-1,0);
        }
    }
}
