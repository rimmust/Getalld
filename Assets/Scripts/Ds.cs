using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ds : MonoBehaviour
{
    //where to spawn
    [SerializeField] private Tilemap diamondTileMap;

    //what to spaewn
    [SerializeField]  private GameObject diamond;

    
    private void Start()
    {
        var positions = diamondTileMap.cellBounds.allPositionsWithin;
        foreach (var cell in positions)
        {
            if (diamondTileMap.GetTile(cell) == null)
                continue;
            
            //find cell positionn in wolrd
            var position = diamondTileMap.CellToWorld(cell) + diamondTileMap.tileAnchor;
            Instantiate(diamond, position, Quaternion.identity);
        }
    }
    
    
}
