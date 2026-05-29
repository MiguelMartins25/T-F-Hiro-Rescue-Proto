using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerThomas : MonoBehaviour
{
    //Character speed
    [SerializeField] private float speed = 0;
    //Acceleration added onto character speed
    [SerializeField] private float acceleration = 0;
    //Max character speed
    [SerializeField] private float maxSpeed = 150;
    //Max character acceleration
    [SerializeField] private float maxAcceleration = 50;
    //Rate of acceleration lost after no inputs
    [SerializeField] private float accelerationDecrease = 1;
    //How fast speed decreases after reaching 0 acceleration
    [SerializeField] private float frictionPower = 2;
    //Area for player collision check
    [SerializeField] private Transform playerPivot;
    //Radius of collison check
    [SerializeField] private float collisionDetectionRadius;
    //Pivot of player collision area
    [SerializeField] private LayerMask collisionLayer;
    //Time between bounce of collision
    [SerializeField] private float collisionCooldown;
    [SerializeField] private GameObject AudioSource;
    private Rigidbody2D     rb;
    private bool            onCollision;
    private float           collisionTimer = 0.0f;
    [SerializeField] private float puffingCooldown = 0.0f;
    [SerializeField] private float accelerationRate = 60.0f;
    private AudioSource audioPlayer;
    //Place to put audio in
    [SerializeField] private AudioClip puffing;
    //Bool to known when player is moving
    private bool isPuffing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //RigidBody of Player
        rb = GetComponent<Rigidbody2D>(); 
        audioPlayer = AudioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Called Methods
        CollisionDetect();

        // Horizontal input
        float dx = Input.GetAxis("Horizontal");

        collisionTimer += Time.deltaTime;
        if ((speed > 0 && onCollision == true) || (speed < 0 && onCollision == true))
            if (collisionTimer > collisionCooldown)
            {
                speed = -speed/2;
                collisionTimer = 0.0f;
            }
    }

    //puffing sound player
    void PuffingSounds()
    {
        audioPlayer.PlayOneShot(puffing);
    }
    
    //checks for player and level collidable collision
    void CollisionDetect()
    {
        onCollision = false;

        Collider2D colliding = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, collisionLayer);
        if (colliding != null)
            onCollision = true;
    }
    void FixedUpdate()
    {
        // Horizontal input
        float dx = Input.GetAxis("Horizontal");

        //Acceleration from input
        acceleration += (dx * 5) * accelerationRate * Time.fixedDeltaTime;

        acceleration = Mathf.Clamp(acceleration, -maxAcceleration, maxAcceleration);

        // Apply acceleration to speed
        speed += acceleration * Time.fixedDeltaTime;

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        // Slow down when no input
        if (dx == 0)
        {
            // Reduce acceleration toward 0
            if (acceleration > 0)
            {
                acceleration -= accelerationDecrease * Time.fixedDeltaTime;

                if (acceleration < 0)
                    acceleration = 0;
            }
            else if (acceleration < 0)
            {
                acceleration += accelerationDecrease * Time.fixedDeltaTime;

                if (acceleration > 0)
                    acceleration = 0;
            }

            // Apply friction to speed
            if (speed > 0)
            {
                speed -= frictionPower * Time.fixedDeltaTime;

                if (speed < 0)
                    speed = 0;
            }
            else if (speed < 0)
            {
                speed += frictionPower * Time.fixedDeltaTime;

                if (speed > 0)
                    speed = 0;
            }
        }

        // Reset acceleration if input is from opposite direction
        if ((dx > 0 && acceleration < 0) || (dx < 0 && acceleration > 0))
        {
            acceleration = 0;
        }

        if ((dx > 0 && speed < 0) || (dx < 0 && speed > 0))
        {
            acceleration = acceleration * 2;
        }

        // Apply movement
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        
        //Makes the puff sound when the player is moving
        if (speed != 0)
        {
            if (!isPuffing)
            {
                //Invokes the method at an interval
                InvokeRepeating(nameof(PuffingSounds), 0f, puffingCooldown);
                isPuffing = true;
            }
        }
        else
        {
            if (isPuffing)
            {
                //Cancels the invokation
                CancelInvoke(nameof(PuffingSounds));
                isPuffing = false;
            }
        }
    }

    public void ChangeMaxSpeed(int addMaxSpeed)
    {
        maxSpeed = maxSpeed + addMaxSpeed;
    }

    public void ChangeMaxAcceleration(int addMaxAcceleration)
    {
        maxAcceleration = maxAcceleration + addMaxAcceleration;
    }
}