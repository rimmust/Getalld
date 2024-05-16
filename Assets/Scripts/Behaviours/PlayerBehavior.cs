using System;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBehaviour : MonoBehaviour
    {
        private Animator _animator;

        //player animations
        private string _animState;

        private bool Grounded;

        //cont                         same name of animation
        private const string P_IDLE = "Idle";
        private const string P_WALK = "Walk";
        private const string P_JUMP = "Jump";
        private const string P_P = "Player";


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
            //ChangeAnimationState(P_WALK);

            if (Input.GetButtonDown("Jump"))
            {

                Jump();

            }

            _animator.SetBool("Walk", movement.x != 0);

            //se jaqra il position ta fejn wasal il-player 
            GameManager.instance.UpdatePlayerPosition(rb.position);
        }

        private void FixedUpdate()
        {
            //player moves in direction with time.delta time
            rb.velocity = movement;

            //check animation
            if (!AnimationPlays(_animator, P_IDLE))
            {
                if (Grounded)
                {
                    ChangeAnimationState(P_WALK);
                }
                else if (!Grounded)
                {
                    //not grounded
                    ChangeAnimationState(P_JUMP);
                }

            }
        }
        
        private void Jump()
        {
            var velocity = rb.velocity;
            velocity.y = jumpSpeed;
            rb.velocity = velocity;
            // ChangeAnimationState(P_JUMP);


        }

        //change animation code
        //just created a new state
        private void ChangeAnimationState(string newState)
        {
            //if anim is = to current state
            if (newState == _animState)
            {
                //just return
                return;
            }

            _animator.Play(newState);
            //update animation
            _animState = newState;
        }

        //check animation playing
        bool AnimationPlays(Animator animator, string stateName)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
