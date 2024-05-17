using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Getalld
{
    public class Sack : MonoBehaviour
    {
      
        private void OnTriggerEnter2D(Collider2D other)
        {
           
            if (other.CompareTag("Player"))
            {
               
                GameManager.instance.AddScore();
                Destroy(gameObject);
               GameManager.instance.ChangeStatetoWin();

            }
        }
    }
}
