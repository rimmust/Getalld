using System.Collections;
using System.Collections.Generic;
using Behaviours;
using Getalld;
using UnityEngine;

[System.Serializable]

public class SoundTrigger: MonoBehaviour
{
    //the clip 
    private AudioClip clip;
    
    //when touch an object play sound
    private void OnTriggerEnter2D(Collider2D collider)
        {
            //check with the  tag
            if(collider.gameObject.CompareTag("Player"))
            {
                //on trigger play Sound
                EventManager.Instance.SfxSource.PlayOneShot(clip);

            }
        }
    
    //create a new clip

        public void SetClip(AudioClip newClip)
        {
            clip = newClip;
        }
        
        
        
        
    }

