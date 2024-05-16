using System.Collections;
using System.Collections.Generic;
using Getalld;
using UnityEngine;

[System.Serializable]

public class SoundTrigger: MonoBehaviour
{
    private AudioClip clip;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            //check with the  tag
            if(collider.gameObject.CompareTag("Player"))
            {
                //on trigger play Sound
                EventManager.Instance.SfxSource.PlayOneShot(clip);
               
            }
        }

        public void SetClip(AudioClip newClip)
        {
            clip = newClip;
        }
    }

