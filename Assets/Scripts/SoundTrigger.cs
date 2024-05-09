using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Getalld
{
    public class SoundTrigger : MonoBehaviour
    {
        private AudioSource source;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            //check with the  tag
            if(collider.gameObject.CompareTag("Player"))
            {
                //on trigger play Sound
                source.PlayOneShot(source.clip);
               
            }
        }
        
        private void Awake()
        {
            source = GetComponent<AudioSource>();
            
            
        }
    }
}
