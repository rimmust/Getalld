using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //ask sir if i can arrange it from
    [SerializeField] private  Slider healthSlider;
    
    [SerializeField] private int currentHealth = 30;

    [SerializeField] private int maxHealth = 30 ;

    public float NormalizedHeath
    {
        get
        {
            return CurrentHealth / (float)maxHealth;
        }
    }

    //takes current helath,and arranges the value of lside when chnages 
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            healthSlider.value = NormalizedHeath;
            //find from Game Manger the value of the health which is value 
            GameManager.instance.UpdateHealth(value);
        }
        
}


    private  void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (currentHealth <= 0)
        {
            //se jerga jibda l-icore minn 100
            CurrentHealth = maxHealth;
        }
        
        
       
    }
    
    private void Start()
    {
        
        CurrentHealth = GameManager.instance.Data.currentHealth;
        
    } 
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
       {
            TakeDamage(2);
            Debug.Log("obstacle touches");
            //EventManager.Instance.PlaySfx("");

       }
    }

  
}
