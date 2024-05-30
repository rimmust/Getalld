using System;
using Getalld;
using Getalld.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBehaviour : MonoBehaviour
    {
        //the code used  for the animaation
        private Animator _animator;
        private bool Grounded;
        [SerializeField] private SoundSettings settings;

        private AudioSource _audioSource;
        private SpriteRenderer _spriteRenderer;

        

        //cont                         same name of animation
        private const string P_WALK = "Walking";
        private const string P_GRND = "Grounded";

        
        
        //move speed of the player
        [SerializeField] private float moveSpeed = 10;

        [SerializeField] private float jumpSpeed = 20f;


        // The Rigidbody2D Component
        private Rigidbody2D rb;

        //vector 2 movement of the player
        private Vector2 movement;


        private void Awake()
        {
            //rigidblody component of the player
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Start is called before the first frame update
       private void Start()
        {
            rb.MovePosition(GameManager.instance.Data.playerPosition);
        }

        private void Update()
        {
            if (GameManager.State != GameState.Playing)
            {
                return;
            }

            // creates a circle on the player's feet
            // if it collides with the tilemap, the player is on the ground
            Grounded = Physics2D.OverlapCircle(rb.position, 0.3f, 1 << LayerMask.NameToLayer("Ground"));
            
            //player moves left and right only horizontal 
            movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            
            
            // Mathf.Abs turns a negative number to positive (biex ticcekkja condition wahda)
            if (Mathf.Abs(movement.x) > Mathf.Epsilon)
            {
                _spriteRenderer.flipX = movement.x < 0;
            }
            
            movement.y = rb.velocity.y;
            //_animator.SetBool(P_WALK,movement.x !=0);


//checks if the button is pressed
            if (Input.GetButtonDown("Jump") && Grounded)
            {
                Jump();
            }
            
            //se jaqra il position ta fejn wasal il-player 
            GameManager.instance.UpdatePlayerPosition(rb.position);
            _animator.SetBool(P_GRND, Grounded);
        }

        private void FixedUpdate()
        {
            //player moves in direction with time.delta time
            rb.velocity = movement;
        }

        private void Jump()
        {
            //the jump code
            var velocity = rb.velocity;
            velocity.y = jumpSpeed;
            rb.velocity = velocity;
            _audioSource.PlayOneShot(settings.Jump);

        }
        

    }
    
   



}
