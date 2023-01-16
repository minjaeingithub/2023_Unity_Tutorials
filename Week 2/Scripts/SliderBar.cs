using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    // Bonus tutorial [Expert]
    public float currentHealth;
    public float maxHealth;
    // public GameObject healthBarUI;
    public Slider slider;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 1f;
        slider.value = 0;
        slider.fillRect.gameObject.SetActive(false);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void GiveFood(float amount){
        currentHealth += amount;
        slider.fillRect.gameObject.SetActive(true);
        slider.value = currentHealth;
        if(currentHealth >= maxHealth)
        {
            gm.CurrentScore((int)maxHealth);
            Destroy(gameObject, 0.1f);
        }
    }
}