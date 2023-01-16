using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    private float spawnRangeLR = 15;

    private float startDelay = 2f;
    private float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.lives<1){
            CancelInvoke();
            FindAnimalsOnScene();
        }        
    }
    
    void FindAnimalsOnScene(){
        GameObject[] pool = GameObject.FindGameObjectsWithTag("Animals");
        foreach(GameObject g in pool){
            Destroy(g);
            // Debug.Log("destroyed");
        }
    }

    void SpawnRandomAnimal(){
        // randomize spawn location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Vector3 spawnPosLeft = new Vector3(-spawnRangeLR, 0, Random.Range(-5, 2));
        Vector3 spawnPosRight = new Vector3(spawnRangeLR, 0, Random.Range(-5, 2));

        // each side creates a different batch of animals
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int animalIndex2 = Random.Range(0, animalPrefabs.Length);
        int animalIndex3 = Random.Range(0, animalPrefabs.Length);

        // Actual spawning on the scene
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        Instantiate(animalPrefabs[animalIndex2], spawnPosLeft, Quaternion.Euler(0, 90, 0));
        Instantiate(animalPrefabs[animalIndex3], spawnPosRight, Quaternion.Euler(0, -90, 0));
    }
}
