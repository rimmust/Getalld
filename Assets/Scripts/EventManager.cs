using System;
using System.Collections;
using System.Collections.Generic;
using Getalld.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Getalld
{
    public class EventManager : MonoBehaviour
    {
        //where to spawn
        [SerializeField] private Tilemap SoundTileMap;

        //the sound settings
        [SerializeField]  private SoundSettings Settings;
        
        //sound trigger
        private Collider2D soundTrigger;
        

        //the game object created in unity
        [SerializeField] AudioSource musicSource, sfxSource;

        public AudioSource MusicSource => musicSource;

        public AudioSource SfxSource => sfxSource;

        public static EventManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

      
        private void Start()
        {
            var positions = SoundTileMap.cellBounds.allPositionsWithin;
            foreach (var cell in positions)
            {
                if (SoundTileMap.GetTile(cell) == null)
                    continue;
            
                //find cell position in world 
                var position = SoundTileMap.CellToWorld(cell) + SoundTileMap.tileAnchor;
                //Instantiate(soundeventrigger, position, Quaternion.identity);
            }
            
           
        }
        
     
        
       
        
     

        
       
        
       
    }
}
