using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SoundTrigger: MonoBehaviour
    {
        private AudioSource musicSource;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            //check with the  tag
            if(collider.gameObject.CompareTag("Player"))
            {
                //on trigger play Sound
               // source.PlayOneShot(source.clip);
               
            }
        }
        
        private void Awake()
        {
           // source = GetComponent<AudioSource>();
            
            
        }
    }

