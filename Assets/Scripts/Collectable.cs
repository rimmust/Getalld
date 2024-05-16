using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Getalld
{
    public class Collectable : MonoBehaviour
    {
        //as the player touches  the key it gets destroyed
        private void OnTriggerEnter(Collider other)
        {
            if (gameObject.CompareTag("Player"))
            {
                
                Destroy(gameObject);
            }
        }

    }

}

