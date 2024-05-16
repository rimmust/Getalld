using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Getalld
{
    public class Door : MonoBehaviour
    {
        //as the player touches  the  door the screen changes
        private void OnTriggerEnter2D(Collider2D other)
        {
            //arrange it from player to Diaomnd
            //create the tag for Diaomnd
            if (other.CompareTag("Player"))
            {
                Debug.Log("opened");
            }
        }

    }
}

