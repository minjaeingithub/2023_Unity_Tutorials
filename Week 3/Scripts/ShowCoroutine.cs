using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Coroutine");
        StartCoroutine("RunCoroutine");

        // ====================================================
        // Mechanism of Coroutine
        // IEnumerator runCoroutine = RunCoroutine();
        // while (runCoroutine.MoveNext()) {
        //     // MoveNext() : Advances the enumerator to the next element of the collection.
        //     object result = runCoroutine.Current;

        //     if (result is WaitForSeconds) {
        //         // In actual code for StartCoroutine, time delay will occur
        //         Debug.Log("I am waiting...");
        //     }
        // }
    }

    IEnumerator RunCoroutine() {
        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Going Back to Unity");
    }

    // Change return type of Start() to IEnumerator:
    // IEnumerator Start() {
    //     yield return StartCoroutine(WaitAndPrint(2.0F));
    //     Debug.Log ("Done " + Time.time);
    // }
    // IEnumerator WaitAndPrint(float waitTime) {
    //     yield return new WaitForSeconds(waitTime);
    //     Debug.Log ("Wait And Print " + Time.time);
    // }
}
