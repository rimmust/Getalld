using System;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBehaviour : MonoBehaviour
    {
        private Animator _animator;
        
        //move speed of the player
        [SerializeField] private float moveSpeed = 10;
        
        [SerializeField] private float  jumpSpeed = 20f;
        
       
        // The Rigidbody2D Component
        private Rigidbody2D rb;
        
        //vector 2 movement of the player
        private Vector2 movement;
        
        
        private void Awake()
        {
            //rigidblody component of the player
            rb = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            rb.MovePosition(GameManager.instance.Data.playerPosition);
        }

        private void Update()
        {
            if (GameManager.State != GameState.Playing)
            {
                return;
            }
            
            //player moves left and right only horizontal 
            movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            movement.y = rb.velocity.y;
            
            if (Input.GetButtonDown("Jump"))
            {

                Jump();

            }
            
            _animator.SetBool("Walking",movement.x != 0);
            
            //se jaqra il position ta fejn wasal il-player 
            GameManager.instance.UpdatePlayerPosition(rb.position);
        }
        
        private void FixedUpdate()
        {
           //player moves in direction with time.delta time
           rb.velocity = movement;

        }


        private void Jump()
        {
            var velocity = rb.velocity;
            velocity.y = jumpSpeed;
            rb.velocity = velocity;
           

        }
        

    }
  
}
