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
                musicSource.PlayOneShot(musicSource.clip);
               
            }
        }
        
        private void Awake()
        {
            musicSource = GetComponent<AudioSource>();
            
            
        }
    }

