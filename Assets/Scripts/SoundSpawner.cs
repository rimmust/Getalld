using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Getalld;
using Getalld.Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class SoundSpawner : MonoBehaviour
{
    //where to spawn
    [SerializeField] private Tilemap tileMap;

    //what to spaewn
    [SerializeField]  private SoundTrigger prefab;

    //the sound settings
    [SerializeField]  private SoundSettings Settings;

    private void Start()
    {
        //check which tile 
        var positions = tileMap.cellBounds.allPositionsWithin;
        foreach (var cell in positions)
        {
            var tile = tileMap.GetTile(cell);
            if (tile == null || tile is not SoundTile soundTile)
                continue;
            
            //find cell positionn in wolrd
            var position = tileMap.CellToWorld(cell) + tileMap.tileAnchor;
            var trigger = Instantiate(prefab, position, Quaternion.identity);
            trigger.SetClip(Settings.GetClip(soundTile.soundType));
        }
    }
    
    
}
