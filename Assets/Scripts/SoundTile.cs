using UnityEngine;
using UnityEngine.Tilemaps;

namespace Getalld
{
    //declare the sound types
    public enum SoundType
    {
        BackgroundMusic1,
        BackgroundMusic2,
        CollectDiamond,
        Collision,
        GameOver,
        ReduceHealth,
        Jump,
        Obstacle,
        Water
    }
    
    [CreateAssetMenu(menuName = "Custom Tiles/Sound Tile")]
    public class SoundTile: Tile
    {
        public SoundType soundType;
    }
}