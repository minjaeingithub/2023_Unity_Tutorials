using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    // Soln. #2 - Coroutine
    IEnumerator SpawnRandomBall ()
    {   
        while(true){ // Infinite loop is not a good idea, but wanted to show how coroutine works.
            int idx = Random.Range(0, ballPrefabs.Length);
            float spawnInterval = Random.Range(3,6);

            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            
            Instantiate(ballPrefabs[idx], spawnPos, ballPrefabs[idx].transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
