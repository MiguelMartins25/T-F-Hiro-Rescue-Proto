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
    //Rate of acelaration lost after no inputs
    [SerializeField] private float accelerationDecrease = 1;
    //How fast speed drecreases after reaching 0 acceleration
    [SerializeField] private float frictionPower = 2;
    //Check ground collision
    [SerializeField] private Transform groundCheck;
    //Radius of groundcheck
    [SerializeField] private float groundCheckRadius;
    //Which layer check for ground check
    [SerializeField] private LayerMask groundLayer;
    //Gracity applied to player while moving
    [SerializeField] private float movingGravity = 5;
    //Area for player collision check
    [SerializeField] private Transform playerPivot;
    //Radius of collison check
    [SerializeField] private float collisionDetectionRadius;
    //Pivot of player collision area
    [SerializeField] private LayerMask collisionLayer;
    //Time between bounce of collision
    [SerializeField] private float collisionCooldown;
    //End the level detection
    [SerializeField] private LayerMask levelEndTouch;

    private Rigidbody2D     rb;
    private bool            onGround;
    private bool            onCollision;
    private bool            levelEnd;
    private float           collisionTimer = 0.0f;
    [SerializeField] private float puffingCooldown = 0.0f;
    [SerializeField] private float accelerationRate = 20.0f;

    //Place to put audio in
    public AudioClip puffing;
    //Bool to known when player is moving
    private bool isPuffing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //RigidBody of Player
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Called Methods
        GroundDetect();
        CollisionDetect();
        LevelEnd();

        float dx = Input.GetAxis("Horizontal");

        //Makse the player character stop on slopes
        if (dx == 0 && onGround == true)
            rb.gravityScale = 0;
        else
            rb.gravityScale = movingGravity;
        
        //Makes the player bounce when colliding with an object of the collision layer
        collisionTimer += Time.deltaTime;
        if ((speed > 0 && onCollision == true) || (speed < 0 && onCollision == true))
            if (collisionTimer > collisionCooldown)
            {
                speed = -speed/2;
                collisionTimer = 0.0f;
            }
        
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

        //makes the player unable to move at the end of the level
        if (levelEnd == true)
        {
            speed = 0;
        }
    }

    //puffing sound player
    void PuffingSounds()
    {
        SoundManager.PlaySound(puffing);
    }
    
    //checks for player and level collidable collision
    void CollisionDetect()
    {
        onCollision = false;

        Collider2D colliding = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, collisionLayer);
        if (colliding != null)
            onCollision = true;
    }

    //checks for player and ground collisions to be able to stop on slopes
    void GroundDetect()
    {
        onGround = false;

        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
            onGround = true;
    }

    //Visualize ground check
    void OnDrawGizmosSelected()
    {
        if (groundCheck)
        {
            Gizmos.color = (onGround) ? (Color.black) : (Color.red);
            Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        }
    }

    //tells the scrpt that the level has ended
    void LevelEnd()
    {
        levelEnd = false;

        Collider2D end = Physics2D.OverlapCircle(playerPivot.position, collisionDetectionRadius, levelEndTouch);
        if (end != null)
            levelEnd = true;
    }

    void FixedUpdate()
    {
        // Horizontal input
        float dx = Input.GetAxis("Horizontal");

        //Acceleration from input
        acceleration += dx * accelerationRate * Time.fixedDeltaTime;

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

        // Apply movement
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
    }
}