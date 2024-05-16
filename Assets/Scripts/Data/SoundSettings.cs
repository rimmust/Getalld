using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Getalld.Data
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class SoundSettings : ScriptableObject
    {
        [SerializeField] private AudioClip backgroundMusic1;
        [SerializeField] private AudioClip backgroundMusic2;
        [SerializeField] private AudioClip collectDiamond;
        [SerializeField] private AudioClip collision;
        [SerializeField] private AudioClip gameover;
        [SerializeField] private AudioClip reducehalth;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip obstacle;
        [SerializeField] private AudioClip water;
        
        
        public AudioClip BackgroundMusic1 => backgroundMusic1;

        public AudioClip BackgroundMusic2 => backgroundMusic2;

        public AudioClip CollectDiamond => collectDiamond;

        public AudioClip Collision => collision;

        public AudioClip Gameover => gameover;

        public AudioClip Reducehalth => reducehalth;

        public AudioClip Jump => jump;

        public AudioClip Obstacle => obstacle;

        public AudioClip Water => water;

        public AudioClip GetClip(SoundType type)
        {
            switch (type)
            {
                case SoundType.BackgroundMusic1:
                    return BackgroundMusic1;
                case SoundType.BackgroundMusic2:
                    return BackgroundMusic2;
                case SoundType.CollectDiamond:
                    return CollectDiamond;
                case SoundType.Collision:
                    return Collision;
                case SoundType.GameOver:
                    return Gameover;
                case SoundType.ReduceHealth:
                    return Reducehalth;
                case SoundType.Jump:
                    return Jump;
                case SoundType.Obstacle:
                    return Obstacle;
                case SoundType.Water:
                    return Water;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}