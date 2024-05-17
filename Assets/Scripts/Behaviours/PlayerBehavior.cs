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
        private Animator _animator;
        private bool Grounded;

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
        }

        // Start is called before the first frame update
        void Start()
        {
            rb.MovePosition(GameManager.instance.Data.playerPosition);
            // _animator = GetComponent<Animator>();
            _animator.SetTrigger(P_GRND);

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
            _animator.SetBool(P_WALK,movement.x !=0);



            if (Input.GetButtonDown("Jump") &&  !Grounded)
            {
                
                _animator.SetBool(P_GRND, Grounded);
                Jump();


            }
            
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
