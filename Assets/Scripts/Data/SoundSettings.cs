using UnityEngine;
using UnityEngine.AI;

namespace Getalld.Data
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class SoundSettings : ScriptableObject
    {
        [SerializeField] private AudioClip backgroundMusic1;
        [SerializeField] private AudioClip backgroundMusic2;
        [SerializeField] private AudioClip collectDiamond;
        [SerializeField] private AudioClip collsion;
        [SerializeField] private AudioClip gameover;
        [SerializeField] private AudioClip reducehalth;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip obstacle;
        [SerializeField] private AudioClip water;
        
        
     
        public AudioClip  BackgroundMusic1
        {
            get
            {
                return BackgroundMusic1;
            }
        }
        public AudioClip  BackgroundMusic2
        {
            get
            {
                return BackgroundMusic2;
            }
        }
        
        public AudioClip  CollectDiamond
        {
            get
            {
                return CollectDiamond;
            }
        }
        
        public AudioClip  Collision
        {
            get
            {
                return Collision;
            }
        }
        
        public AudioClip  GameOver
        {
            get
            {
                return GameOver;
            }
        }

        public AudioClip ReduceHealth
        {
            get
            {
                return ReduceHealth;
            }
        }
        
      
            
        public AudioClip Jump
        {
            get
            {
                return Jump;
            }
        }

        public AudioClip Obtstacle
        {
            get
            {
                return Obtstacle;

            }
        }
        
        public AudioClip Water
        {
            get
            {
                return Water;

            }
        }
    }
}