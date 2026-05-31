using System;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    // Basically the direction value;
    public float horizontal;

    public float speed = 50f;

    // Forces
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float acceleration;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float friction;

    // Detectors
    [SerializeField] private Transform frontWheel;
    [SerializeField] private Transform rearWheel;
    [SerializeField] private LayerMask groundLayer;

    // Sprite-related
    [SerializeField] public GameObject Happy;
    [SerializeField] public GameObject Scared;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;
    [SerializeField] public SpriteRenderer[] sparkSprites;
    [SerializeField] public Animator[] sparks;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip puffing;
    [SerializeField] private float puffingCooldown;
    private float puffingTime;

    // How far the ground detectors can trigger
    public float rayLength = 500f;

    // Updates every frame
    private void Update()
    {
        // Gets the direction the player is pressing
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Scared.activeInHierarchy == true)
        {
            spriteRenderer = Scared.GetComponent<SpriteRenderer>();
            animator = Scared.GetComponent<Animator>();
        }
        else
        {
            spriteRenderer = Happy.GetComponent<SpriteRenderer>();
            animator = Happy.GetComponent<Animator>();
        }

        // These depend on "ThomasAnim" Animator's bools!
        if (speed > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (speed < 0)
        {
            animator.SetBool("isReverse", true);
        }
        else
        {
            animator.SetBool("isReverse", false);
        }
    }

    // Updates every frame but physics-flavored
    // Only physics related code can be here! VVV
    private void FixedUpdate()
    {
        // Front wheel ground detector
        RaycastHit2D frontHit = Physics2D.Raycast(
            frontWheel.position,
            Vector2.down,
            rayLength,
            groundLayer
        );

        // Back wheel ground detector
        RaycastHit2D rearHit = Physics2D.Raycast(
            rearWheel.position,
            Vector2.down,
            rayLength,
            groundLayer
        );

        // Basically saying - "If grounded"
        if (frontHit && rearHit)
        {
            puffingTime += Time.deltaTime;
            if (speed != 0)
                PlayPuffing();
            else
                StopPuffing();

            // Forward
            if (horizontal > 0)
            {
                if (speed < 0)
                {
                    // To be more forgiving and not feel terrible to try and control;
                    // This is a Thomas the Tank Engine game, for God's sake! Lil' Timmy
                    // would break into tears with how many times Thomas was crashing into things
                    // during testing!
                    speed += acceleration * 3 * Time.fixedDeltaTime;
                    foreach (Animator anim in sparks)
                    {
                        anim.SetBool("IsBraking", true); // Triggers every spark anim in array
                    }
                }

                else
                {
                    speed += acceleration * Time.fixedDeltaTime;
                    foreach (Animator anim in sparks)
                    {
                        anim.SetBool("IsBraking", false);} // Disables afterwards or keeps disabled
                                                           // when not needed
                }
            }

            // Back
            if (horizontal < 0)
            {
                if (speed > 0)
                {
                    // Same as the above, but for braking
                    speed -= acceleration * 3 * Time.fixedDeltaTime;

                    foreach (SpriteRenderer sprite in sparkSprites)
                    {
                        sprite.flipX = true; // Flips each spark sprite before triggering the
                                             // animations
                    }
                    
                    foreach (Animator anim in sparks)
                    {
                        anim.SetBool("IsBraking", true); // Triggers every blah blah blah
                    }
                }

                else 
                {
                    speed -= acceleration * Time.fixedDeltaTime;

                    foreach (SpriteRenderer sprite in sparkSprites)
                    {
                        sprite.flipX = false; // Unflips each spark
                    }

                    foreach (Animator anim in sparks)
                    {
                        anim.SetBool("IsBraking", false); // Disables
                    }
                }
            }
            
            
            // Idle, N/A
            if (horizontal == 0)
            {
                // Thomas slides after letting go of a direction until speed hits 0;
                // affected by the friction value
                speed = Mathf.MoveTowards(
                    speed,
                    0,
                    friction * Time.fixedDeltaTime
                );
            }

            // Even the rails have speed limits, and Thomas doesn't want to pay
            // for speeding tickets
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed); // Limits speed value

            // Angle from rear wheel to front wheel
            Vector2 slopeDirection =
                (frontHit.point - rearHit.point).normalized;

            // Applies speed; mindful of where the player is standing
            rb.linearVelocity = slopeDirection * speed;

            float angle = Mathf.Atan2(
                slopeDirection.y,
                slopeDirection.x
                ) * Mathf.Rad2Deg;
            
            // Rotates sprite
            transform.rotation =
                Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0, 0, angle),
                10f * Time.fixedDeltaTime // Smooth!
                );
        }
    }

    void PlayPuffing()
    {
        if(puffingTime >= puffingCooldown)
        {
            audioPlayer.PlayOneShot(puffing);
            puffingTime = 0.0f;
        }
    }

    void StopPuffing()
    {
        audioPlayer.Stop();
    }
}