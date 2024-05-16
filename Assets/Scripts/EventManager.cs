using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Getalld
{
    public class EventManager : MonoBehaviour
    {
        //where to spawn
        [SerializeField] private Tilemap SoundTileMap;

        //what to spaewn
        [SerializeField]  private SoundTrigger soundeventrigger;
        
        private Collider2D soundTrigger;

        //the game object created in unity
        public AudioSource musicSource, sfxSource;

        public static EventManager Instance;

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
                Instantiate(soundeventrigger, position, Quaternion.identity);
            }
            
            //playMusic("theme")
        }
        
        //add the play music method
        
       
        
     

        
       
        
       
    }
}
