using System;
using System.Collections;
using System.Collections.Generic;
using Getalld;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DiamondCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
   {
       
       //check if the tag is diamond if yes add score and desctroy game object
        if (other.CompareTag("Diamond"))
        { 
            //Debug.Log("add score");
           GameManager.instance.AddScore();
           Destroy(other.gameObject);
           
        }
    }
}

