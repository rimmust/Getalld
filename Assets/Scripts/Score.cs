using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable] //the data becomes accesible for saving 
public struct Score 
{
   
    
    //struct is just a data structure
    public int score { get;  set;}
    
    public int highScore;

    //qed jaqra il position ta fejn wasal il-player 
    public Vector3 playerPosition; //player position

    //player currenthealth habba il-health bar 
    public int currentHealth;
    
}
