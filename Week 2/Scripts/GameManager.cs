using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public int lives;
    //Variables below do not matter for this week
    public Projectile banana;
    public PlayerController player;
    public DetectCollisions[] spawnManager;

    private void Awake()
    {  
        //Singleton design
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // Bonus tutorial [Hard]
        // 1. Display starting value of Lives & Score in console tab
        CurrentLive(3);
        CurrentScore(0);
        
    }

    public void CurrentLive(int value)
    {
        lives += value;
        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            lives = 0;
        }
        Debug.Log("Lives : " + lives);
    }

    public void CurrentScore(int value)
    {
        score += value;
        Debug.Log("Score : " + score);
    }
}
