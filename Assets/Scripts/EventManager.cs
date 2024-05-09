using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Getalld
{
    public class EventManager : MonoBehaviour
    {
        private AudioSource source;
        private AudioSource source2;
        
        private Collider2D soundTrigger;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            //check with the  tag
           if(collider.gameObject.CompareTag("Player"))
           {
               //on trigger play Sound
               source.Play();
           }
        }
        
        

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            soundTrigger = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collider2D collider)
        {
            //check with the  tag
            if(collider.gameObject.CompareTag("Player"))
            {
                //on trigger play Sound
                source2.Play();
            }
        }
        
       
    }
}
