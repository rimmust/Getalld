using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DiamondCollector : MonoBehaviour
{
   // [Tooltip("The associated text component.")]
    //[SerializeField] private TextMeshProUGUI scoreTextUI;
        
    // The player's score.
   // private int _score;

    /// <summary>
    /// The player's score.
    /// </summary>
    //private int Score
   // {
     //   get
      //  {
        //    return _score;
        //}
        //set
        //{
          //  _score = value;
           // scoreTextUI.text = _score.ToString();
       // }
    //}


  private void OnTriggerEnter2D(Collider2D other)
   {
        //arrange it from player to Diaomnd
        //create the tag for Diaomnd
        if (other.CompareTag("Diamond"))
        {
            Debug.Log("add score");
           //Score++;
           GameManager.instance.AddScore();
           Destroy(other.gameObject);
           
           
        }
    }
}

