using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Getalld.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ds : MonoBehaviour
{
    //where to spawn
    [SerializeField] private Tilemap diamondTileMap;

    //what to spaewn
    [SerializeField]  private SoundTrigger diamond;

    //the sound settings
    [SerializeField]  private SoundSettings Settings;

    private void Start()
    {
        var positions = diamondTileMap.cellBounds.allPositionsWithin;
        foreach (var cell in positions)
        {
            var tile = diamondTileMap.GetTile(cell);
            if (tile == null || tile is not DiamondTile diamondTile)
                continue;
            
            //find cell positionn in wolrd
            var position = diamondTileMap.CellToWorld(cell) + diamondTileMap.tileAnchor;
            var trigger = Instantiate(diamond, position, Quaternion.identity);
            trigger.SetClip(Settings.GetClip(diamondTile.soundType));
        }
    }
    
    
}
